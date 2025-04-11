using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Usuario
	{
		public int Id { get; set; }
		public string Datos { get; set; }
		public UsuarioEmail Email { get; set; }
		public UsuarioContrasenia Contrasenia { get; set; }
		public Rol Rol { get; set; }

		private Usuario() { }
		public Usuario(string datos, UsuarioEmail email, UsuarioContrasenia contrasenia, Rol rol)
		{
			Datos = datos;
			Email = email;
			Contrasenia = contrasenia;
			Rol = rol;
		}

	}
}
