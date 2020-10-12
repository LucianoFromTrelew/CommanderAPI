# CommanderAPI

.NET Core 3.1 REST API using EntityFrameworkCore and SQL Server, based on [this video tutorial](https://www.youtube.com/watch?v=fmvcAzHpsk8&list=LLwYViWd8mZ--7R8uzRdJcAA&index=1) by [Les Jackson](https://github.com/binarythistle/)

## Getting started

### Local

- Run locally with `dotnet run`
- Run migrations with `dotnet ef database update` (if EF CLI installed globally), or install EF CLI with `dotnet tool restore` and then `dotnet dotnet-ef database update`

### Docker

- Spin up containers with `docker-compose up -d`
