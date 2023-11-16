using Agency.Data.MyContext;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Agency.Configuration.Jwt;
using Agency.Configuration.Repository;
using Agency.Configuration.Service;
using Agency.Configuration.Swagger;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(DbContextOptionsBuilder =>
{
    DbContextOptionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=nokib");
});

builder.Services.AddJwtConfiguration(builder.Configuration);


builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(Program));

// service registration
builder.Services.AddCustomService();

// repository registration
builder.Services.AddCustomRepositories();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
