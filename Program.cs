using Microsoft.EntityFrameworkCore;
using MagazinFigurineApp.Context;
using MagazinFigurineApp.Repositories.Interfaces;
using MagazinFigurineApp.Repositories;
using MagazinFigurineApp.Services.Intefaces;
using MagazinFigurineApp.Services;
using Microsoft.AspNetCore.Identity;
using MagazinFigurineApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MagazinFigurineContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<Utilizator>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MagazinFigurineContext>()
    .AddDefaultTokenProviders();

// Repository
builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
builder.Services.AddScoped<ICosRepository, CosRepository>();

// Services
builder.Services.AddScoped<IWishlistService, WishlistService>();
builder.Services.AddScoped<ICosService, CosService>();

builder.Services.AddScoped<IFigurineRepository, FigurineRepository>();
builder.Services.AddScoped<IFigurineService, FigurineService>();

builder.Services.AddScoped<IProducatorRepository, ProducatorRepository>();
builder.Services.AddScoped<IProducatorService, ProducatorService>();

builder.Services.AddScoped<IMagazinRepository, MagazinRepository>();
builder.Services.AddScoped<IMagazinService, MagazinService>();

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}





app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 6;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;
});