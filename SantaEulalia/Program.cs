var builder = WebApplication.CreateBuilder(args);

// ✅ Agrega controladores con soporte para Newtonsoft.Json
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(); // necesario para serializar objetos en sesión

// ✅ Configuración de sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiración de sesión
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// ✅ Middleware de sesión
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Detalles de errores en desarrollo
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ✅ Ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Producto}/{action=Tienda}/{id?}");

// ✅ Rotativa para generación de PDF (si lo usas)
Rotativa.AspNetCore.RotativaConfiguration.Setup(app.Environment.WebRootPath, "Rotativa");

app.Run();
