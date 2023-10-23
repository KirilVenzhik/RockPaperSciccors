using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ServerAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//Creating DB
//BEFORE USING: Uppdate connection string on 18th string.
var options = new DbContextOptionsBuilder<MyDbContext>()
    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=rpsDB;Trusted_Connection=True;MultipleActiveResultSets=true")
    .Options;
using var db = new MyDbContext(options);
db.Database.EnsureCreated();
db.SaveChanges();

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

