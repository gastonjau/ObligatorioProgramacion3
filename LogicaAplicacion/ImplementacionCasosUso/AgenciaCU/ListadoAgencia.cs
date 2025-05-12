using Compartido.DTOs.Agencia;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.Agencia;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.AgenciaCU
{
    public class ListadoAgencia : IListadoAgencia
    {
        public IRepositorioAgencia RepoAgencia { get; set; }

        public ListadoAgencia(IRepositorioAgencia repoAgencia)
        {
            RepoAgencia = repoAgencia;
        }

        public IEnumerable<DatoAgenciaDTO> Ejecutar()
        {
            return AgenciaMapper.ListDatoAgenciaDTOFromListAgencia(RepoAgencia.FindAll());
        }
    }
}
