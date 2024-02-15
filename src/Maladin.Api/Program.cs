using AspNet.Security.OAuth.KakaoTalk;
using AspNet.Security.OAuth.Naver;

using Maladin.Api.Extensions;
using Maladin.Api.Options;
using Maladin.EFCore;
using Maladin.Services.Extensions;

using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

using Portone.Extensions;

using System.Security.Claims;
using System.Text;

const string JWT_SECTION = "Jwt";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPortoneClient();

JwtOptions jwtOptions = builder.Configuration.GetValue<JwtOptions>(JWT_SECTION) ?? throw new NullReferenceException();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetRequiredSection(JWT_SECTION));

builder.Services.AddJwtService(jwtOptions.SecurityAlgorithm, CreateKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        IssuerSigningKey = CreateKey(jwtOptions.SecureKey)
    };

    options.Events.OnAuthenticationFailed = context =>
    {
        if (context.Exception is SecurityTokenExpiredException)
        {
            context.Response.Headers.Append("Access-Token-Expired", StringValues.Empty);
        }
        return Task.CompletedTask;
    };

    options.Events.OnMessageReceived = context =>
    {
        context.Token = context.Request.Cookies.TryGetValue(jwtOptions.AccessTokenName, out string? accessToken) ? accessToken : null;
        return Task.CompletedTask;
    };
})
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration.GetValue<string>("OAuthProvider:Google:ClientId") ?? throw new NullReferenceException();
    options.ClientSecret = builder.Configuration.GetValue<string>("OAuthProvider:Google:ClientSecret") ?? throw new NullReferenceException();
    options.AuthorizationEndpoint += "?prompt=consent";
})
.AddKakaoTalk(options =>
{
    options.ClientId = builder.Configuration.GetValue<string>("OAuthProvider:Kakaotalk:ClientId") ?? throw new NullReferenceException();
    options.ClientSecret = builder.Configuration.GetValue<string>("OAuthProvider:Kakaotalk.ClientSecret") ?? throw new NullReferenceException();
    options.AuthorizationEndpoint += "?prompt=login";
})
.AddNaver(options =>
{
    options.ClientId = builder.Configuration.GetValue<string>("OAuthProvider:Naver:ClientId") ?? throw new NullReferenceException();
    options.ClientSecret = builder.Configuration.GetValue<string>("OAuthProvider:Naver:ClientSecret") ?? throw new NullReferenceException();
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(AuthorizePolicyConstants.OAUTH, pb =>
    {
        pb.AddAuthenticationSchemes(GoogleDefaults.AuthenticationScheme, KakaoTalkAuthenticationDefaults.AuthenticationScheme, NaverAuthenticationDefaults.AuthenticationScheme);
        pb.RequireAuthenticatedUser().RequireClaim(ClaimTypes.NameIdentifier);
    });

string connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new NullReferenceException();
builder.Services.AddDbContextPool<MaladinDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

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