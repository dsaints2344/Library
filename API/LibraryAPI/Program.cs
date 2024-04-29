using Application.Category;
using Application.Core;
using Application.Repository;
using Application.Services;
using LibraryAPI;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseInMemoryDatabase("LibraryDb");
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfiles>();
});
// builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddControllers();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBookService, BookService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Seeding service
var context = builder.Services.BuildServiceProvider().GetRequiredService<DataContext>();
SeedingService.SeedData(context).Wait();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
