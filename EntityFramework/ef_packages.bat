echo Installing entity framework Core
dotnet add package Microsoft.EntityFrameworkCore
dotnet build
clear
echo Installing EF Core tools
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet build
clear
echo Installing Postgre EF Core driver
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet build