global using Microsoft.EntityFrameworkCore;
global using Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Models;
global using Microsoft.AspNetCore.Mvc;
global using System.Diagnostics;

using Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. DefaultConnection
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer( builder.Configuration.GetConnectionString("DefaultConnection"))) ;

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
    pattern: "{controller=Home}/{action=Customers}/{id?}");

app.Run();
