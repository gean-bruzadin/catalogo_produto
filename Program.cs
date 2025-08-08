using catalogo_produto.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbConfig>(options =>
options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(
        builder.Configuration.GetConnectionString("DefaultConnection")
        )
    )
);

builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", config =>
    {
        config.Cookie.Name = "UsuarioLoginCookie";
        config.LoginPath = "/Autenticacao/Login";
        config.AccessDeniedPath = "/Autenticacao/Login";
    });



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Atenticacao}/{action=Login}/{id?}");

app.Run();
