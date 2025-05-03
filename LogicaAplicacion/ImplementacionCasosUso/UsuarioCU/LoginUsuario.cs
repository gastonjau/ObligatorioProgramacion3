using Compartido.DTOs;
using Compartido.Mappers;
using LogicaAccesosDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using LogicaAplicacion.InterfacesCasosUso.Usuario;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
	public class LoginUsuario: ILoginUsuario
	{
        public IRepositorioUsuario RepoLogin { get; set; }
        public LoginUsuario() { }
        public LoginUsuario(IRepositorioUsuario repo)
        {
            RepoLogin = repo;
		}
		public bool Ejecutar(LoginUserDTO loginUserDTO)
		{
			if (loginUserDTO == null)
			{
				throw new Exception("el dto es null");
			}
			return RepoLogin.FindByEmailAndPass(loginUserDTO.Email, loginUserDTO.Contrasenia);
		}
	}
}
