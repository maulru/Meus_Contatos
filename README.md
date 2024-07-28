
# Meus Contatos

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue)

## Visão Geral
Tech Challenge 01 e 02 | FIAP - Pós Graduação em Arquitetura de Sistemas .NET com Azure

Meus Contatos é uma aplicação web desenvolvida em ASP.NET Core que permite gerenciar contatos. A aplicação oferece funcionalidades para adicionar, editar, deletar e visualizar contatos.

## Funcionalidades

- Adicionar novos contatos
- Editar informações de contatos existentes
- Deletar contatos
- Visualizar lista de contatos

## Tecnologias Utilizadas

- [.NET Core 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [ASP.NET Core](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [SQL Server](https://www.microsoft.com/sql-server)
- [Docker](https://www.docker.com/)
- [Prometheus](https://prometheus.io/)
- [Grafana](https://grafana.com/)

## Configuração do Ambiente de Desenvolvimento

### Pré-requisitos

- [.NET Core SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)
- [SQL Server](https://www.microsoft.com/sql-server)

### Passos para Configurar

1. Clone o repositório:
   ```bash
   git clone https://github.com/maulru/Meus_Contatos.git
   cd Meus_Contatos
   ```

2. Configure o banco de dados no `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=contatos;User Id=sa;Password=your_password;"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```

3. Execute as migrações do Entity Framework para criar o banco de dados:
   ```bash
   dotnet ef database update
   ```

4. Execute a aplicação:
   ```bash
   dotnet run
   ```

5. Acesse a aplicação em [http://localhost:5000](http://localhost:5000).

## Configuração com Docker

### Passos para Configuração

1. Construa e inicie os containers Docker (vale ressaltar que é importante configurar a senha do banco de dados no arquivo docker-compose.yml):
   ```bash
   docker-compose up --build
   ```

2. Acesse a aplicação em [http://localhost:8080](http://localhost:8080).

### Serviços Docker

- `sqlserver`: Banco de dados SQL Server
- `webapp`: Aplicação ASP.NET Core
- `prometheus`: Servidor Prometheus para monitoramento
- `grafana`: Servidor Grafana para visualização de métricas

## Monitoramento com Prometheus e Grafana

A aplicação está configurada para expor métricas para o Prometheus e visualizar essas métricas no Grafana.

- Prometheus: [http://localhost:9090](http://localhost:9090)
- Grafana: [http://localhost:3000](http://localhost:3000)
  - Usuário: `admin`
  - Senha: `admin`

## Testes

Os testes de unidade são escritos usando xUnit. Para executar os testes, utilize o seguinte comando:

```bash
dotnet test
```
