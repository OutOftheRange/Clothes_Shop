using System;
using Bogus;
using ClothesShop.DatabaseAccess.Initializers;
using ClothesShop.DatabaseAccess;
using ClothesShop.DatabaseAccess.Entities.UserEntity.User;
using ClothesShop.DatabaseAccess.Initializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ClothesShop.WebAPI.ServiceCollectionConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.BindServices();
builder.Services.ConfigureMapping();
builder.Services.ConfigureValidation();

builder.Services.AddDbContext<ClothesShopDbContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
    opts.UseSqlServer(connectionString);
});
builder.Services.AddScoped<DbInitializer>();

builder.Services.AddIdentity<User, IdentityRole<Guid>>
    (options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
    }
    )
    .AddEntityFrameworkStores<ClothesShopDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseItToSeedSqlServer();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
