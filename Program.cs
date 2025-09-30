using Microsoft.EntityFrameworkCore;
using MinhaApiOracle.Data; // Garanta que este namespace está correto

var builder = WebApplication.CreateBuilder(args);

// ===================================================================================
// CONFIGURAÇÃO DO BANCO DE DADOS (A PARTE MAIS IMPORTANTE)
// 1. Adiciona o DbContext (AppDb) aos serviços da aplicação.
// 2. Configura para usar o SQL SERVER (Azure SQL).
// 3. Pega a string de conexão do arquivo de configuração (appsettings.json ou Azure).
// ===================================================================================
builder.Services.AddDbContext<AppDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlAzureConnection")));


// --- Resto da sua configuração que já estava correta ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
});

var app = builder.Build();

// Configura o endpoint para rodar na porta 8080
app.Urls.Add("http://*:8080");

// Habilita o Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Rota padrão do Swagger UI
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
});


app.UseAuthorization();

app.MapControllers();

app.Run();
