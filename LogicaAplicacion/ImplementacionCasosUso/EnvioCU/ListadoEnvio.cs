using Compartido.DTOs.Envio;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.Envio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class ListadoEnvio : IListadoEnvio
    {
        public IRepositorioEnvio RepoEnvio { get; set; }

        public ListadoEnvio(IRepositorioEnvio repo)
        {
            RepoEnvio = repo;
        }

        public List<ListadoEnvioDTO> Ejecutar()
        {
            return EnvioMapper.ListEnvioDTOFromListEnvio(RepoEnvio.FindAll().ToList());
        }

    }
}
