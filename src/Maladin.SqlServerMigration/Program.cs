using Maladin.EFCore;
using Maladin.SqlServerMigration;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new NullReferenceException();

builder.Services.AddDbContext<MaladinDbContext, MaladinSqlServerDbContext>(options =>
{
    options.UseSqlServer(connectionString, serverOptions =>
    {
        serverOptions.MigrationsAssembly("Maladin.SqlServerMigration");
    });
});

var host = builder.Build();
host.Run();