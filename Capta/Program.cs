using Capta.Data;
using Capta.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CaptaContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("CaptaContext")));

builder.Services.AddTransient<ClientService, ClientService>();
builder.Services.AddTransient<ClientTypeService, ClientTypeService>();
builder.Services.AddTransient<ClientSituationService, ClientSituationService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}
else
{
  app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "api",
    pattern: "/api/{controller}/{action=Index}/{id?}");

//app.MapFallbackToFile("index.html");
app.UseDefaultFiles();

app.Run();
