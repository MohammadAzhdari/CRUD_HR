using CRUD_HR.Core.Interfaces;
using CRUD_HR.Infrastructure.Data;
using CRUD_HR.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));

// Dependency Injection
builder.Services.AddScoped<IRepository, EfRepository>();
builder.Services.AddScoped<IProductCategoryFeatureRepository, ProductCategoryFeatureRepository>();
builder.Services.AddScoped<IProductCategoryFeatureValueRepository, ProductCategoryFeatureValueRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
