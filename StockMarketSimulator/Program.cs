using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Json;
using StockMarketSimulator.Repositories.NasdaqRepository;
using StockMarketSimulator.Repositories.UserRepository;
using StockMarketSimulator.Services.AppContext;

Log.Logger = new LoggerConfiguration()
  .WriteTo.Console(new JsonFormatter())
  .WriteTo.File(new JsonFormatter(), "Logs/SystemLog.tx", rollingInterval: RollingInterval.Month)
  .CreateLogger();

try
{
  Log.Information("Starting web host");

  var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
  builder.Host.UseSerilog((context, service, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(service)
    .Enrich.FromLogContext()
    .WriteTo.Console(new JsonFormatter())
    .WriteTo.File(new JsonFormatter(), "Logs/log.txt", rollingInterval: RollingInterval.Month)
  );

  builder.Services.AddOutputCache(options =>
    {
      options.AddPolicy("ExpireOneDay", policyBuilder => { policyBuilder.Expire(TimeSpan.FromDays(1)); });
    }
  );

  builder.Services.AddControllersWithViews();

  builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetValue<string>("Database:ConnectionString")));

  builder.Services.AddScoped<INasdaqRepository, NasdaqRepository>();
  builder.Services.AddScoped<IUserRepository, UserRepository>();

  var app = builder.Build();

// Configure the HTTP request pipeline.
  if (!app.Environment.IsDevelopment())
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

  app.UseSerilogRequestLogging();

  app.UseHttpsRedirection();
  app.UseStaticFiles();
  app.UseRouting();

  app.UseOutputCache();

  app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

  app.MapFallbackToFile("index.html");

  app.Run();
}
catch (Exception ex)
{
  Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
  Log.CloseAndFlush();
}