using Compartido.DTOs.Usuario;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.Usuario;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class ListadoEmpleado : IListadoEmpleado
	{
		public IRepositorioUsuario RepoUsuario { get; set; }

		public ListadoEmpleado(IRepositorioUsuario repo)
		{
			RepoUsuario = repo;
		}
        public List<ListadoUsuarioDTO> Ejecutar()
        {
			return UsuarioMapper.ListUsuarioDTOFromListUsuario(RepoUsuario.FindAll().ToList());
        }
    }
}
