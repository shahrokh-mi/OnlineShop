﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Core;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.Data;
using OnlineShop.Service;
using OnlineShop.Service.Mapping;

MapperConfiguration mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
AutoMapperConfiguration.Initialize(mapperConfiguration);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OnlineShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopWebContext") ?? throw new InvalidOperationException("Connection string 'OnlineShopWebContext' not found.")));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
