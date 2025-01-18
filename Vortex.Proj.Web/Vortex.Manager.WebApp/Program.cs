using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Vortex.Manager.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews(); 
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); // Adicione esta linha


// Configure o banco de dados SQLite
builder.Services.AddDbContext<VortextManagerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


//
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/AuthSystem/Index"; // Path to the login page
        options.AccessDeniedPath = "/AuthSystem/Index"; // Path to the access denied page
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie expiration time
        options.SlidingExpiration = true; // Renews the cookie on each request
    });

// Configure authorization by default to require authentication
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder(
            CookieAuthenticationDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
});

// Adicione o serviço de sessão:
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Tempo de inatividade antes da sessão expirar (opcional)
    options.Cookie.HttpOnly = true; // Acessível apenas por HTTP, não por JavaScript (segurança)
    options.Cookie.IsEssential = true; // Cookie essencial para o funcionamento do aplicativo (opcional)
});

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AuthSystem}/{action=Index}/{id?}");

app.Run();
