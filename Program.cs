using API_IntegracaoMSI.Contexts.Cotacao;
using API_IntegracaoMSI.Repositories.Cotacao;
using API_IntegracaoMSI.Services.Cotacao;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CotacaoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"))
);

builder.Services.AddScoped<CotacaoRepository>(); // Registro do CotacaoRepository
builder.Services.AddScoped<CotacaoService>(); // Registro do CotacaoService

builder.Services.AddScoped<CotacaoSeguradoRepository>(); // Registro do CotacaoSeguradoRepository
builder.Services.AddScoped<CotacaoSeguradoService>(); // Registro do CotacaoSeguradoService


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
