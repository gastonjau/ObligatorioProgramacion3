using Compartido.DTOs.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Rol
{
    public interface IBuscarRoles
    {
        IEnumerable<RolDTO> Ejecutar();
    }
}
