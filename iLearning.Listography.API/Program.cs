using iLearning.Listography.API.Hubs;
using iLearning.Listography.Application;
using iLearning.Listography.DataAccess;
using iLearning.Listography.Infrastructure;
using iLearning.Listography.Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
services.AddDataAccess(configuration);
services.AddApplication(configuration);
services.AddInfrastructure();
services.AddSignalR();

services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", b => b
        .WithOrigins("https://ilearning-listography.herokuapp.com")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
{
    var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT.Key")!);
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = "ListographyBackend",
        ValidAudience = "ListographyFrontent",
        RequireExpirationTime = true,
    };
});

services.AddControllers(options =>
    options.Filters.Add<ApiExceptionFilter>());

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<AppHub>("/hub");

app.Run();
