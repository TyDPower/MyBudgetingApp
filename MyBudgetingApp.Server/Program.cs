global using MyBudgetingApp.Shared.Models;
global using MyBudgetingApp.Server.Data;
global using Microsoft.AspNetCore.Mvc;
global using MyBudgetingApp.Server.Services.WalletService;
global using MyBudgetingApp.Server.Data.Repositories.WalletRepository;
global using Microsoft.EntityFrameworkCore;
global using MyBudgetingApp.Server.Utilities.ErrorHandling;
global using MyBudgetingApp.Server.Utilities.SuccessHandling;
global using MyBudgetingApp.Shared.Dtos;
global using MyBudgetingApp.Shared.Dtos.WalletDtos;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Services
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWalletService, WalletService>();

//Repositories
builder.Services.AddScoped<IWalletRepository, WalletRepository>();

var app = builder.Build();

app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
