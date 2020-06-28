### Code first approcah using CLI

1. Install entity framework

`dotnet add package Microsoft.EntityFrameworkCore`

2. Install postgre driver

`dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL`

3. Implement custom db context

4. Before creating the migration, install Design package

`dotnet add package Microsoft.EntityFrameworkCore.Design`

5. Create migration using command

`dotnet ef migrations add InitialMigration`

6. Apply migration

`dotnet ef database update`