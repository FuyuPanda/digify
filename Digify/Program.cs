using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Digify.Data.Entity;



var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContextPool<DigifyContext>((serviceProvider, options) =>
           options.UseSqlServer(connectionString)
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                  .EnableDetailedErrors(true)
                  .UseInternalServiceProvider(serviceProvider)
                  .ConfigureWarnings(c => c.Log((RelationalEventId.CommandExecuting, LogLevel.Debug))));

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
