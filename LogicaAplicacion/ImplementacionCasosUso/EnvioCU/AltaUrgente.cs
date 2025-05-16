using Compartido.DTOs.Envio;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.Envio;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class AltaUrgente : IAltaUrgente
    {
        public IRepositorioEnvio RepoEnvio { get; set; }
        public IRepositorioUsuario RepoUsuario { get; set; }

        public AltaUrgente(IRepositorioEnvio repoEnvio, IRepositorioUsuario repoUsuarios)
        {
            RepoEnvio = repoEnvio;
            RepoUsuario = repoUsuarios;
        }

        public void Ejecutar(UrgenteDTO urgenteDTO)
        {
            Usuario cliente = RepoUsuario.ObtenerPorEmail(urgenteDTO.Email);
            Usuario empleado = RepoUsuario.ObtenerPorEmail(urgenteDTO.EmpleadoEmail);
            Envio envio = EnvioMapper.UrgenteFromUrgenteDTO(cliente, empleado, urgenteDTO);
            envio.CodTracking = $"{cliente.Datos.Substring(0, 3)}{urgenteDTO.DirPostal.Substring(0, 4)}";
            RepoEnvio.Add(envio);
        }
    }
}
