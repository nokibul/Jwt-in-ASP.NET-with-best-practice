using System.Reflection.Metadata.Ecma335;
using Agency.Models.MyContext;
using Microsoft.EntityFrameworkCore;
using Agency.Models.DTOs;
using FluentValidation;
using FluentValidation.AspNetCore;
using Agency.Models.Validators;
using Agency.Data.Repositories;
using Agency.Interfaces;
using Agency.Models.Entities.Agency;
using Agency.Models.MappingProfile;
using AutoMapper;
using Agency.Configuration.Jwt;
using Agency.Services.Authentication.UserService;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<MyContext>(DbContextOptionsBuilder =>
{
    DbContextOptionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=nokib");
});

var jwtOptionsSection = builder.Configuration.GetRequiredSection("JwtSettings");
builder.Services.Configure<jwtOptionsSection>(jwtOptionsSection);

// jwt auth configuration
builser.Services.AddAuthentication(options =>
{
    options.DefaultAuthentication = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtOptions =>
{
    var configurationKey = jwtOptionsSection["Key"];
    var key = Encoding.UTF8.GetBytes(configurationKey);

    jwtOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = jwtOptionsSection["Issuer"],
        ValidAudience = jwtOptionsSection["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };

});

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(Program));

// repository registration
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// service registration
builder.Services.AddScoped<UserService>();

builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    conf.AutomaticValidationEnabled = false;
});


// builder.Services.AddTransient<IValidator<CreateAgencyRequestDTO>, CreateAgencyRequestValidator>();

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
