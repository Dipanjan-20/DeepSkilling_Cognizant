using Microsoft.EntityFrameworkCore;
using MyFirstWebAPI.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  

builder.Services.AddControllers();

// Add Swagger  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  Add DbContext  
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("StudentDb")); // Ensure 'Microsoft.EntityFrameworkCore.InMemory' package is installed  

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

