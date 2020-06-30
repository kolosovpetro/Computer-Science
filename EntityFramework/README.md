### CodeFirst

Migration commands: 
- `Add-Migration <MigrationName>`
- `Update-Database`
- `Enable-Migrations -ProjectName DVDRentalStore -ContextTypeName DVDRentalStore.DAL.RentalContext -Force`

Requires packages: EF Core, EF Core tools, NpgSQL-EF-Core

### DatabaseFirst

- Reverse Engineering PM command:

`Scaffold-DbContext "Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=password" Npgsql.EntityFrameworkCore.PostgreSQL`

- CLI

`dotnet ef dbcontext scaffold "Host=my_host;Database=my_db;Username=my_user;Password=my_pw" Npgsql.EntityFrameworkCore.PostgreSQL`

