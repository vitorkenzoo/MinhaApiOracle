using Microsoft.EntityFrameworkCore;
using MinhaApiOracle.Data;
using Oracle.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDb>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

// Configura os controllers e adiciona a opção para ignorar ciclos no JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API Oracle", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API Oracle v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();

app.Urls.Add("http://*:80");