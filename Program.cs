using Microsoft.OpenApi.Models;
using UserRegistrationApi.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Cargar el archivo .env
Env.Load();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

// Agregar el DbContext y otros servicios
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING")));

builder.Services.AddControllers();


var app = builder.Build();

// Middleware para manejo global de excepciones
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var result = System.Text.Json.JsonSerializer.Serialize(new { error = ex.Message });
        await context.Response.WriteAsync(result);
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserRegistrationApi v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.MapHealthChecks("/health");


var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
var url = $"http://0.0.0.0:{port}";

app.MapGet("/", () => $"Hello {Environment.GetEnvironmentVariable("TARGET") ?? "World"}!");

app.Run(url);
