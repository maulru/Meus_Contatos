# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copiar os arquivos de solução e do projeto
COPY *.sln ./
COPY Meus_Contatos/*.csproj ./Meus_Contatos/
COPY Core/*.csproj ./Core/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY MeusContatos_Testes/*.csproj ./MeusContatos_Testes/

# Restaurar dependências
RUN dotnet restore

# Copiar o restante dos arquivos
COPY . ./

# Compilar e publicar o projeto principal
RUN dotnet publish Meus_Contatos/Meus_Contatos.csproj -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Instalar o Zabbix Agent, supervisord e procps
RUN apt-get update && \
    apt-get install -y zabbix-agent supervisor procps && \
    rm -rf /var/lib/apt/lists/*

# Criar diretório para os logs do Zabbix Agent e ajustar permissões
RUN mkdir -p /var/log/zabbix && \
    chown -R zabbix:zabbix /var/log/zabbix && \
    chmod -R 755 /var/log/zabbix

# Copiar os arquivos da etapa de build
COPY --from=build-env /App/out .

# Copiar o arquivo de configuração do Zabbix Agent
COPY zabbix_agentd.conf /etc/zabbix/zabbix_agentd.conf

# Copiar o arquivo de configuração do supervisor
COPY supervisord.conf /etc/supervisor/conf.d/supervisord.conf

# Configurar variáveis de ambiente
ENV ASPNETCORE_URLS=http://+:8080

# Expor a porta 8080
EXPOSE 8080

# Iniciar o supervisord
CMD ["/usr/bin/supervisord", "-c", "/etc/supervisor/conf.d/supervisord.conf"]
