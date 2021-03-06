global using Microsoft.EntityFrameworkCore;
global using WebApplication1.Models;
global using WebApplication1.Data;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using System.ComponentModel.DataAnnotations;
global using WebApplication1.Dtos;
global using AutoMapper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();

// add configuration
var configuration = builder.Configuration;

builder.Services.AddDbContext<DataContext>(options =>
	options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddIdentity<AppUser, IdentityRole>()
	.AddEntityFrameworkStores<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseHttpsRedirection();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200")
	.AllowAnyMethod()
	.AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

