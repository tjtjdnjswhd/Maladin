using Maladin.Data;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices(collection =>
{
    collection.AddSqlServer<MaladinDbContext>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Maladin;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
        builder =>
        {
            builder.MigrationsAssembly("Maladin.EfCoreMigration");
        });
});

builder.Build().Run();