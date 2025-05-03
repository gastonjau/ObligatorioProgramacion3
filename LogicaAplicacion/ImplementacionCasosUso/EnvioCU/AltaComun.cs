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

        public AltaComun(IRepositorioEnvio repoEnvio, IRepositorioUsuario repoUsuario)
        {
            RepoEnvio = repoEnvio;
            RepoUsuario = repoUsuario;
        }

        public void Ejecutar(ComunDTO comunDTO)
        {
            Usuario usuario = RepoUsuario.ObtenerPorEmail(comunDTO.Email);
            Agencia agencia = RepoAgencia.FindById(comunDTO.AgenciaId);
            Envio envio = EnvioMapper.ComunFromComunDTO(agencia, usuario);
            RepoEnvio.Add(envio);
        }
    }
}
