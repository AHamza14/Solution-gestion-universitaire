using Microsoft.EntityFrameworkCore;
using SolutionGestionUniversitaire.Core.Interfaces;
using SolutionGestionUniversitaire.Core.Services;
using SolutionGestionUniversitaire.Infrastructure;
using SolutionGestionUniversitaire.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register DbContext 
builder.Services.AddDbContext<SolutionGestionUniversitaireContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services 
builder.Services.AddScoped<IProfesseurRepository, ProfesseurRepository>();
builder.Services.AddScoped<IGestionUniversitaireService, GestionUniversitaireService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
