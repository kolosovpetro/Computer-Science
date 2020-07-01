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

### Building a relations between entities by Fluent API

- One to one 

https://www.entityframeworktutorial.net/efcore/configure-one-to-one-relationship-using-fluent-api-in-ef-core.aspx

- One to many

https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx

- Many to many

https://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx
