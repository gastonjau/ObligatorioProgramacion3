using LogicaAccesosDatos;
using LogicaAccesosDatos.Repositorios;
using LogicaAplicacion.ImplementacionCasosUso.Rol;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.Rol;
using LogicaAplicacion.InterfacesCasosUso.Usuario;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace MVC
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<RepositorioUsuario>();
            builder.Services.AddScoped<LoginUsuario>();

			builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
			builder.Services.AddScoped<IRepositorioRol, RepositorioRol>();

			builder.Services.AddScoped<IAltaEmpleado, AltaEmpleado>();
			builder.Services.AddScoped<IListadoEmpleado, ListadoEmpleado>();
			builder.Services.AddScoped<IBuscarRoles, BuscarRoles>();
			builder.Services.AddScoped<IBuscarEmpleado, BuscarEmpleado>();
			builder.Services.AddScoped<IActualizarEmpleado, ActualizarEmpleado>();
			builder.Services.AddScoped<IEliminarEmpleado, EliminarEmpleado>();

            string cadenaConexion = builder.Configuration.GetConnectionString("cadenaConexion");
			builder.Services.AddDbContext<UsuarioContext>(option => option.UseSqlServer(cadenaConexion));
			
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
		}
	}
}
