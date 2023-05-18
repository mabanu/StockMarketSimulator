using Microsoft.EntityFrameworkCore;
using StockMarketSimulator.Repositories.NasdaqRepository;
using StockMarketSimulator.Services.AppContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
  opt.UseSqlite(builder.Configuration.GetValue<string>("Database:ConnectionString")));

builder.Services.AddScoped<INasdaqRepository, NasdaqRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
  "default",
  "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();