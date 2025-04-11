using Compartido.DTOs;
using Compartido.Mappers;
using LogicaAccesosDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
	public class LoginUsuario
	{
		private RepositorioUsuario RepoUser;

		public LoginUsuario() { }
		public LoginUsuario (RepositorioUsuario repo)
		{
			RepoUser = repo;
		}
		public bool Ejecutar(LoginUserDTO loginUserDTO)
		{
			if (loginUserDTO == null)
			{
				throw new Exception("el dto es null");
			}
			return RepoUser.FindByEmailAndPass(loginUserDTO.Email, loginUserDTO.Contrasenia);
		}
	}
}
