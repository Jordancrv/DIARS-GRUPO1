var builder = WebApplication.CreateBuilder(args);

<<<<<<< Updated upstream
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
=======
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

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
app.UseRouting();
app.UseAuthorization();

// ✅ Ruta por defecto
app.MapControllerRoute(
    name: "default",
<<<<<<< Updated upstream
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
    //pattern: "{controller=Home}/{action=Index}/{id?}");
=======
    pattern: "{controller=Producto}/{action=Tienda}/{id?}");

// ✅ Rotativa para generación de PDF (si lo usas)
Rotativa.AspNetCore.RotativaConfiguration.Setup(app.Environment.WebRootPath, "Rotativa");
>>>>>>> Stashed changes

app.Run();
