using Api.Extensions;
using Api.Middlewares;
using Api.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<LogDatabaseSettings>(
    builder.Configuration.GetSection("LogDatabase"));
//builder.Services.AddSingleton(new MongoClient("mongodb://0.0.0.0:27017"));
//builder.Services.AddSingleton<IMongoDatabase>(x => x.GetService<MongoClient>().GetDatabase("IpLogging"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseRequestLogging();

app.MapControllers();

app.Run();

