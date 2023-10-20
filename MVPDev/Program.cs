using Microsoft.EntityFrameworkCore;
using MVPDev.Context;
using MVPDev.Interfaces;
using MVPDev.Mappings;
using MVPDev.Rest;
using MVPDev.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conn = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<ClienteDbContext>(p => p.UseSqlServer(conn));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IClienteService, ClienteService>();
builder.Services.AddSingleton<ISerproApi, SerproApiRest>();
builder.Services.AddAutoMapper(typeof(ClienteMapping));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
