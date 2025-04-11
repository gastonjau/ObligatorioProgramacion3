using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesosDatos.Repositorios
{
	public class RepositorioUsuario
	{
		private UsuarioContext Contexto { get; set; }
		public RepositorioUsuario(UsuarioContext contexto)
		{
			Contexto = contexto;
		}
		public Usuario ObtenerPorEmail(string email)
		{
			return Contexto.Usuarios.Where(c => c.Email.Valor == email).SingleOrDefault();
		}
		public bool FindByEmailAndPass(string email, string contrasenia)
		{
			return Contexto.Usuarios.Any(c => c.Email.Valor == email && c.Contrasenia.Valor == contrasenia && c.Rol.Nombre != "Cliente");
		}
	}
}
