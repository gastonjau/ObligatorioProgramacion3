using Compartido.DTOs.Agencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso.Agencia
{
    public interface IListadoAgencia
    {
        IEnumerable<DatoAgenciaDTO> Ejecutar();
    }
}
