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
    public class BuscarEmpleado : IBuscarEmpleado
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public BuscarEmpleado(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public ActualizarUsuarioDTO Ejecutar(int id)
        {
            return UsuarioMapper.ActualizarUsuarioDTOFromUsuario(RepoUsuario.FindById(id));
        }
    }
}
