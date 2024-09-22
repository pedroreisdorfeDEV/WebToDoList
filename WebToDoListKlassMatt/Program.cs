using Microsoft.AspNetCore.Connections;
using WebToDoListKlassMatt.Data.Connections.Abstractions;
using WebToDoListKlassMatt.Data.Connections;
using WebToDoListKlassMatt.UseCase.AdicaoTarefa;
using WebToDoListKlassMatt.UseCase.AdicaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.AdicaoTarefa.Services.Repositories;
using WebToDoListKlassMatt.UseCase.AdicaoTarefa.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using WebToDoListKlassMatt.Data.Contexts;
using WebToDoListKlassMatt.Shared.Abstractions;
using WebToDoListKlassMatt.Shared.OutPutPort;
using WebToDoListKlassMatt.UseCase.ObtencaoTarefa;
using WebToDoListKlassMatt.UseCase.ObtencaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.ObtencaoTarefa.Services.Repositories.Abstractions;
using WebToDoListKlassMatt.UseCase.ObtencaoTarefa.Services.Repositories;
using WebToDoListKlassMatt.UseCase.ExclusaoTarefa.Services.Repositories.Abstractions;
using WebToDoListKlassMatt.UseCase.ExclusaoTarefa.Services.Repositories;
using WebToDoListKlassMatt.UseCase.ExclusaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.ExclusaoTarefa;
using WebToDoListKlassMatt.UseCase.AtualizacaoTarefa.Services.Repositories.Abstractions;
using WebToDoListKlassMatt.UseCase.AtualizacaoTarefa.Services.Repositories;
using WebToDoListKlassMatt.UseCase.AtualizacaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.AtualizacaoTarefa;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader());
});


builder.Services.AddSingleton<IConnectionManager, ConnectionManager>();
builder.Services.AddSingleton<IDataBaseConnectionFactory, DataBaseConnectionFactory>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IOutputPort, Outputport>();

builder.Services.AddScoped<IAdicaoTarefa, AdicaoTarefaUseCase>();
builder.Services.AddScoped<IAdicaoTarefaRepository, AdicaoTarefaRepository>();
builder.Services.AddScoped<IObtencaoTarefas, ObtencaoTarefasUseCase>();
builder.Services.AddScoped<IObtencaoTarefasRepository, ObtencaoTarefasRepository>();
builder.Services.AddScoped<IExclusaoTarefa, ExclusaoTarefaUseCase>();
builder.Services.AddScoped<IExclusaoTarefaRepository, ExclusaoTarefaRepository>();
builder.Services.AddScoped<IAtualizacaoTarefaRepository, AtualizacaoTarefaRepository>();
builder.Services.AddScoped<IAtualizacaoTarefa, AtualizacaoTarefaUseCase>();

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
