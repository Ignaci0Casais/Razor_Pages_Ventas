var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// 1 new por toda la aplicación
// var listadoVentas = new Ventas.Model.ListadoVentas();
builder.Services.AddSingleton<
    Ventas.Model.IListadoVentas,
    Ventas.Model.ListadoVentas>();// !!!

/*
// Con una interfaz
builder.Services.AddSingleton<
    Ventas.Model.IListadoVentas, 
    Ventas.Model.ListadoVentasDbContext>();
*/
// 1 new por petición HTTP
// builder.Services.AddScoped<Ventas.Model.ListadoVentas>();

// 1 new por página Razor (o cada vez que se pida)
// builder.Services.AddTransient<Ventas.Model.ListadoVentas>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
