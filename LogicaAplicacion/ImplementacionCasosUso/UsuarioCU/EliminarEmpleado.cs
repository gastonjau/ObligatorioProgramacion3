using LogicaAplicacion.InterfacesCasosUso.Usuario;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class EliminarEmpleado : IEliminarEmpleado
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public EliminarEmpleado(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public void Ejecutar(int id)
        {
            RepoUsuario.Delete(id);
        }
    }
}
