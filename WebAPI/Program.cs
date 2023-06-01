using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Business.Utilities.MappingProfiles;
using Core.Extensions;
using Core.IoC.Abstract;
using Core.IoC.Concrete;
using Core.Utilities.Security.Encryption;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Entities.Utilities.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        policy =>
        {
            policy.WithOrigins("*").
            AllowAnyHeader().
            AllowAnyMethod();
        });
});
var configuration = builder.Configuration;

var tokenOptions = configuration.GetSection("TokenOptions").Get<Core.Utilities.Security.TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
        };
    });
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = System.TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AuthMappingProfile));
builder.Services.AddAutoMapper(typeof(OperationClaimMappingProfile));
builder.Services.AddAutoMapper(typeof(UserOperationClaimMappingProfile));
builder.Services.AddAutoMapper(typeof(UserMappingProfile));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.ConfigureCustomExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.Run();
