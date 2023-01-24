using Microsoft.EntityFrameworkCore;
using ProyectoDatosEF.Data;
using ProyectoDatosEF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("sqlhospital");
//RESOLVEMOS LA DEPENDENCIA DEL REPOSITORY
builder.Services.AddTransient<RepositoryHospital>();
//LAS CLASES CONTEXT DE ACCESO A DATOS UTILIZAN
//UN METODO ESPECIAL LLAMADO AddContext
builder.Services.AddDbContext<HospitalContext>
    ( options => options.UseSqlServer(connectionString) );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
