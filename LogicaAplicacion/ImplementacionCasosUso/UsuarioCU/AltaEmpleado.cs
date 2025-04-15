using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Compartido.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.Usuario;
using LogicaAplicacion.InterfacesCasosUso.Usuario;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class AltaEmpleado : IAltaEmpleado
    {
        public IRepositorioUsuario RepoUsuario { get; set; }
        public IRepositorioRol RepoRol { get; set; }

        public AltaEmpleado(IRepositorioUsuario repo, IRepositorioRol repoRol)
        {
            RepoUsuario = repo;
            RepoRol = repoRol;
        }

        public void Ejecutar(UsuarioDTO usuarioDTO)
        {
            ArgumentNullException.ThrowIfNull(usuarioDTO);

            LogicaNegocio.EntidadesNegocio.Rol rol = RepoRol.FindById(usuarioDTO.Rol);

            Usuario usuario = UsuarioMapper.UsuarioFromUsuarioDTO(usuarioDTO, rol);

            RepoUsuario.Add(usuario);
        }
    }
}
