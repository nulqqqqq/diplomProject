using Diplom.Domain.Core;
using DiplomServer.Interfaces;
using DiplomServer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRegistration, RegistrationUser>();
builder.Services.AddScoped<IAdminApp, AdminApp>();
builder.Services.AddScoped<IAdminMenu, AdminMenu>();
builder.Services.AddScoped<ILoginScreen, LoginScreenWindow>();
builder.Services.AddScoped<IOrderFood, OrderFoodWindow>();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
