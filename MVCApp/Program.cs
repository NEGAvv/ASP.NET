var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // додаємо послуги MVC

var app = builder.Build();

// встановлюємо зіставлення маршрутів із контролерами

app.MapControllerRoute(

name: "default",

pattern: "{controller=Home}/{action=Registration}/{id?}");

app.Run();