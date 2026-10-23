using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registrar o contexto do banco de dados
builder.Services.AddScoped<ExoContext>();

// Registrar os controllers
builder.Services.AddControllers();

// Registrar o repositório
builder.Services.AddScoped<ProjetoRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();
