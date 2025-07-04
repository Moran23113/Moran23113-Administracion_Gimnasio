using Microsoft.EntityFrameworkCore;
using Proyecto_1_Basico_1.Models;

var builder = WebApplication.CreateBuilder(args);

// 🛠️ Configurar SQLite antes de Build()
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddControllersWithViews();

// 🧱 Construir la app después de agregar servicios
var app = builder.Build();

// 🌐 Configuración del middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Casa}/{action=Casa}/{id?}");

app.Run();
