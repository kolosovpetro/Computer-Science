## ASP NET Core MVC and Entity Framework (DVD rental store)

### To implement

- Create (C from CRUD): Implement functionality in order to add new entries to database (use EF Core)
- Read (R from CRUD): Implement reading from database using EF (Database first, or Reverse eng. in EF Core)
- Update (U from CRUD): Implement update function for database entries (in EF Core)
- Delete (D from CRUD): Implement delete function (EF Core)

### Additional functionalities

- Implement search in db
- Implement action links in order to sort movies in index
- Comment on code
- Implement login form for user
- Implement user dashboard
- Impelemnt user registration form
- Implement user functionality: order movie
- Implement administator login form
- Implement administator panel with functionlities: add movie, edit movie, delete movie, modify client data

### To do

- Fix view User's login form
- Fix view Admin Login form
- Fix view Edit Client
- Fix view List of clients
- Implement all controllers with repository pattern
- Work on routing

### Migration command

Enable-Migrations -ProjectName DVDRentalStore -ContextTypeName DVDRentalStore.DAL.RentalContext -Force

### Notes

- Libraries for Reverse engineering of Postgres DB:

`Npgsql.EntityFrameworkCore.PostgreSQL`

`Microsoft.EntityFrameworkCore.Tools`
 
- Reverse engineering command (EF Core only):

`Scaffold-DbContext "Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=password" Npgsql.EntityFrameworkCore.PostgreSQL`

- Connection string in App.config

```cs
<connectionStrings>
    <add name="Rental"
         connectionString="Server=localhost;User Id=postgres;Password=postgres;Database=rental;"
         providerName="Npgsql" />
</connectionStrings>
```

- To use connection string from App.config

`ConfigurationManager.ConnectionStrings["Database"].ConnectionString`
