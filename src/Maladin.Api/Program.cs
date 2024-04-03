using LinqExpressionParser.AspNetCore.Results;

using Maladin.Api;
using Maladin.Api.Models;
using Maladin.EFCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using Portone.Extensions;

using System.Net;
using System.Text;

const string JWT_SECTION = "Jwt";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.MapType(typeof(OrderByOptions<>), () => new());
    o.MapType(typeof(ValueParseResult<,>), () => new());
    o.MapType<IPAddress>(() => new() { Title = "string" });
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("entityApiSettings.Development.json", false, true);
}
else
{
    builder.Configuration.AddJsonFile("entityApiSettings.json", false, true);
}

string connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new NullReferenceException();
builder.Services.AddDbContext<MaladinDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.ConfigureAuthentication(JWT_SECTION, CreateKey);
builder.ConfigureAuthorization();
builder.ConfigureEntityActionFilter();
builder.ConfigureCrudOptions();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddPortoneClient();

var app = builder.Build();

// Options the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static SecurityKey CreateKey(string key) => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));