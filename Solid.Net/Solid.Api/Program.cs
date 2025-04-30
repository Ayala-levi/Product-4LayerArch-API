using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Solid.Core.Repositories;
using Solid.Core.Services;
using Solid.Data.Repositories;
using Solid.service;
using webShop.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

//מזריקה את מחלקת הקונטסקסט לכל האפליקציה
builder.Services.AddDbContext<ShopDBContext>();

//builder.Services.AddDbContext<ShopDBContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<ShopDBContext>(option => option.UseSqlServer(@"Server=DESKTOP-783IDMP\\SQLEXPRESS;
//Database=MyShop_db;Integrated Security=True;TrustServerCertificate=True"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
