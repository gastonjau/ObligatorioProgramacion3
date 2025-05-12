using LogicaAccesosDatos;
using LogicaAccesosDatos.Repositorios;
using LogicaAplicacion.ImplementacionCasosUso.AgenciaCU;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.Rol;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.Agencia;
using LogicaAplicacion.InterfacesCasosUso.Envio;
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
            builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();

            builder.Services.AddScoped<IAltaEmpleado, AltaEmpleado>();
			builder.Services.AddScoped<IListadoEmpleado, ListadoEmpleado>();
			builder.Services.AddScoped<IBuscarRoles, BuscarRoles>();
			builder.Services.AddScoped<IBuscarEmpleado, BuscarEmpleado>();
			builder.Services.AddScoped<IActualizarEmpleado, ActualizarEmpleado>();
			builder.Services.AddScoped<IEliminarEmpleado, EliminarEmpleado>();

			builder.Services.AddScoped<IAltaComun, AltaComun>();
			builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
			builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
			builder.Services.AddScoped<IListadoAgencia, ListadoAgencia>();

            builder.Services.AddScoped<IListadoEnvio, ListadoEnvio>();
            builder.Services.AddScoped<IActualizarEnvio, ActualizarEnvio>();

            string cadenaConexion = builder.Configuration.GetConnectionString("cadenaConexion");
			builder.Services.AddDbContext<UsuarioContext>(option => option.UseSqlServer(cadenaConexion));


            // Agrega servicios de sesión
            builder.Services.AddDistributedMemoryCache(); // Necesario para mantener la sesión en memoria
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // tiempo de expiración
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

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
			app.UseSession();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
