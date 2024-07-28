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

# Copiar os arquivos da etapa de build
COPY --from=build-env /App/out .

# Configurar variáveis de ambiente
ENV ASPNETCORE_URLS=http://+:8080

# Expor a porta 8080
EXPOSE 8080

# Iniciar o supervisord
ENTRYPOINT [ "dotnet", "Meus_Contatos.dll" ]
