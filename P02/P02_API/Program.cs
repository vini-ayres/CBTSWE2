using Microsoft.EntityFrameworkCore;
using P02_API.Abstractions;
using P02_API.Repositories;
using TP02.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetSection("ConexaoSqlite:SqliteConnectionString").Value;
builder.Services.AddDbContext<ProvaContext>(options =>
    options.UseSqlite(connection)
);

builder.Services.AddTransient<IProdutosRepository, ProdutosRepository>();
builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();

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
