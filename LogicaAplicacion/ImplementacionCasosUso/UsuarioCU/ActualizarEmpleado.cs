using Compartido.DTOs.Usuario;
using LogicaAplicacion.InterfacesCasosUso.Usuario;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using Compartido.Mappers;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
	public class ActualizarEmpleado : IActualizarEmpleado
	{
		public IRepositorioUsuario RepoUsuario { get; set; }
		public IRepositorioRol RepoRol { get; set; }

		public ActualizarEmpleado(IRepositorioUsuario repo, IRepositorioRol repoRol)
		{
			RepoUsuario = repo;
			RepoRol = repoRol;
		}
        public void Ejecutar(ActualizarUsuarioDTO usuarioDTO)
        {
			LogicaNegocio.EntidadesNegocio.Rol rol = RepoRol.FindById(usuarioDTO.Rol);
			Usuario usuario = UsuarioMapper.UsuarioFromActualizarUsuarioDTO(usuarioDTO, rol);
            RepoUsuario.Update(usuario);
        }
    }
}
