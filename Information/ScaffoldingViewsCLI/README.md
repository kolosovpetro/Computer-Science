### Scaffolding ASP Views in CLI

- In bash select root folder you want place solution inside
- To create new mvc app execute the command `dotnet new mvc -o mvcApp`
- Install code generator `dotnet tool install -g dotnet-aspnet-codegenerator`
- Update it to ensure last version installed `dotnet tool update -g dotnet-aspnet-codegenerator`
- Install package `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design`
- Build solution `dotnet build`
- Check that codegenerator was installed ok `dotnet aspnet-codegenerator -h`
- Perform scaffolding like `dotnet aspnet-codegenerator view Create Create -outDir Views/Person -udl -m Person`

### Links

https://gavilan.blog/2018/04/28/asp-net-core-2-doing-scaffolding-with-dotnet-cli-aspnet-codegenerator/

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-3.1
