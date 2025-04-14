using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
		[ForeignKey("Rol")]
		public int RolId {  get; set; }

		private Usuario() { }

		public Usuario(string datos, string email, string contrasenia, Rol rol)
		{
			Datos = datos;
			Email = new UsuarioEmail(email);
			Contrasenia = new UsuarioContrasenia(contrasenia);
			Rol = rol;
		}

	}
}
