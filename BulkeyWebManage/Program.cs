using System.Runtime.CompilerServices;
using BulkeyWebManage.Application.Interfaces;
using BulkeyWebManage.Application.mapper;
using BulkeyWebManage.Application.Service;
using BulkeyWebManage.DataAccess;
using BulkeyWebManage.DataAccess.Configuration;
using BulkeyWebManage.DataAccess.DataAccess;
using BulkeyWebManage.DataAccess.Repository;
using BulkeyWebManage.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var builderRazor = builder.Services.AddRazorPages();
var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();

builder.Services.RegisterDb(builder.Configuration);

// scoped layers
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<GenreMapper>();


// google authentication
builder.Services.AddAuthentication(
    options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme

    ).AddCookie(options => options.LoginPath = "/user/signin-google").AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Google:ClientId"];
    googleOptions.ClientSecret = configuration["Google:ClientSecret"];
});

// cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder.WithOrigins("https://localhost:7209") // Địa chỉ frontend
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "MyArea",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
