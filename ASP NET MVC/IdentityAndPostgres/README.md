### ASP NET Core Identity using PostgreSql database

1. Connect assemblies 
```cs
	Npgsql.EntityFrameworkCore.PostgreSQL
	Npgsql.EntityFrameworkCore.PostgreSQL.Design
```
1. Update Connection string in appsettings.json to be, for example
```cs
	"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;Database=IdentityTest;User Id=postgres;Password=postgres;"
```
1. Scaffold Identity usging Project -> Add -> New Scaffolding Item -> Identity. Mark the functionlities to be provided and link database context.
1. In Startup.cs change the db operator, namely use
```cs
	public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
```
1. Delete existing migration since it is created for MSSQL db
1. Recreate migration using the command `Add-Migration InitialMigration`, it will create postgre-friendly migration
1. Update database using `Update-Database`



### Links
- https://metanit.com/sharp/aspnet5/16.1.php
- https://medium.com/@RobertKhou/asp-net-core-mvc-identity-using-postgresql-database-bc52255f67c4