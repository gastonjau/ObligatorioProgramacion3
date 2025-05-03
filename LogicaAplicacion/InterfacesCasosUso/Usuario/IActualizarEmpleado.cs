using Compartido.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Usuario
{
    public interface IActualizarEmpleado
    {
        void Ejecutar(ActualizarUsuarioDTO usuarioDTO);
    }
}
