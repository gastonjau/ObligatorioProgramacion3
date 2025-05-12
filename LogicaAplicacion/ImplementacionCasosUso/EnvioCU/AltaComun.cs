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
    public class AltaComun : IAltaComun
    {
        public IRepositorioEnvio RepoEnvio { get; set; }
        public IRepositorioUsuario RepoUsuario { get; set; }
        public IRepositorioAgencia RepoAgencia { get; set; }

        public AltaComun(IRepositorioEnvio repoEnvio, IRepositorioUsuario repoUsuario, IRepositorioAgencia repoAgencia)
        {
            RepoEnvio = repoEnvio;
            RepoUsuario = repoUsuario;
            RepoAgencia = repoAgencia;
        }

        public void Ejecutar(ComunDTO comunDTO)
        {
            Usuario cliente = RepoUsuario.ObtenerPorEmail(comunDTO.Email);
            Agencia agencia = RepoAgencia.FindById(comunDTO.AgenciaId);
            Usuario empleado = RepoUsuario.ObtenerPorEmail(comunDTO.EmpleadoEmail);
            Envio envio = EnvioMapper.ComunFromComunDTO(agencia, cliente, empleado, comunDTO.Peso);
            envio.CodTracking = $"{comunDTO.AgenciaId}{comunDTO.Email.Substring(0,4)}";
            RepoEnvio.Add(envio);
        }
    }
}
