using Compartido.DTOs.Rol;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.Rol;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Rol
{
    public class BuscarRoles : IBuscarRoles
    {
        public IRepositorioRol RepoRol {  get; set; }

        public BuscarRoles(IRepositorioRol repoRol)
        {
            RepoRol = repoRol;
        }

        public IEnumerable<RolDTO> Ejecutar()
        {
            return RolMapper.ListRolDTOFromListRol(RepoRol.FindAll().ToList());
        }
    }
}
