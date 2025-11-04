using Microsoft.EntityFrameworkCore;
using MinhaApiOracle.Data; // Garanta que este namespace está correto
using Microsoft.OpenApi.Models; // Adicionado para OpenApiInfo
using System.Text.Json.Serialization; // Adicionado para corrigir o Erro 500 (GET)

var builder = WebApplication.CreateBuilder(args);

// ===================================================================================
// CONFIGURAÇÃO DO BANCO DE DADOS (.NET 9 e SQL Server)
// ===================================================================================
builder.Services.AddDbContext<AppDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlAzureConnection")));


// --- Configuração de Serviços ---

// ===================================================================================
// CORREÇÃO (Erro 500 no GET):
// Adiciona o AddJsonOptions para ignorar "loops" (referências circulares)
// ao converter os seus Modelos para JSON.
// ===================================================================================
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();

// CORREÇÃO (Erro de Build):
// Usamos "SwaggerDoc" para definir as informações do documento "v1".
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API V1", Version = "v1" });
});

var app = builder.Build();

// Configura o endpoint para rodar na porta 8080 (bom para containers)
app.Urls.Add("http://*:8080");

// Habilita o Swagger
app.UseSwagger();

// ESTE BLOCO ESTAVA CORRETO:
// O "SwaggerEndpoint" é usado aqui, dentro do "UseSwaggerUI".
app.UseSwaggerUI(c =>
{
    // Rota padrão do Swagger UI (acessar a raiz do site)
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
});


app.UseAuthorization();

app.MapControllers();

app.Run();

