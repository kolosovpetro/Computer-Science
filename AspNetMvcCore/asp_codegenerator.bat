dotnet tool install -g dotnet-aspnet-codegenerator
dotnet build
dotnet tool update -g dotnet-aspnet-codegenerator
dotnet build
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet build
clear
dotnet aspnet-codegenerator -h