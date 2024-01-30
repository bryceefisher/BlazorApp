using BlazorApp.Client.Pages;
using BlazorApp.Components;
using BlazorApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Retrieve the connection string from your configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add Entity Framework Core DbContext to the DI container

builder.Services.AddDbContext<MysqlhomebrewContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("mysql-8.0"), mysqlOptions =>
        mysqlOptions.MigrationsAssembly("HomebrewDesigner.UI").EnableRetryOnFailure().UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
