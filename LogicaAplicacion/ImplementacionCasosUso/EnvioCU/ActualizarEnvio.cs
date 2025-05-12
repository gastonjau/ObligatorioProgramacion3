using Compartido.DTOs.Envio;
using Compartido.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.InterfacesCasosUso.Envio;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class ActualizarEnvio :IActualizarEnvio
    {
        public IRepositorioEnvio RepoEnvio { get; set; }

        public ActualizarEnvio(IRepositorioEnvio repo)
        {
            RepoEnvio = repo;
        }

        public void Ejecutar(CambiarEstadoDTO dtoEstado)
        {
            Envio envio = RepoEnvio.FindById(dtoEstado.Id);

            if (envio == null)
            {
                throw new Exception("Envío no encontrado");
            }

            envio.Estado = dtoEstado.Estado;

            RepoEnvio.Update(envio);

        }
    }
}
