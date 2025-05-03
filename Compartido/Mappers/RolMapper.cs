using Compartido.DTOs.Rol;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class RolMapper
    {

        public static List<RolDTO> ListRolDTOFromListRol(List<Rol> roles)
        {
            return roles.Select(r => new RolDTO()
            {
                Id = r.Id,
                Nombre = r.Nombre
            }).ToList();
        }
    }
}
