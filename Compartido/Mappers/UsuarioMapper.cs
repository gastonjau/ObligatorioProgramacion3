using Compartido.DTOs.Usuario;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class UsuarioMapper
	{
		public static Usuario UsuarioFromUsuarioDTO(UsuarioDTO usuarioDTO, Rol rol)
		{
			ArgumentNullException.ThrowIfNull(usuarioDTO);
			return new Usuario(usuarioDTO.Nombre, usuarioDTO.Email, usuarioDTO.Password, rol);
		}

        public static Usuario UsuarioFromActualizarUsuarioDTO(ActualizarUsuarioDTO usuarioDTO, Rol rol)
        {
            ArgumentNullException.ThrowIfNull(usuarioDTO);
			Usuario usuario = new Usuario(usuarioDTO.Nombre, usuarioDTO.Email, usuarioDTO.Password, rol);
			usuario.Id = usuarioDTO.Id;
            return usuario;
        }

		public static ActualizarUsuarioDTO ActualizarUsuarioDTOFromUsuario(Usuario usuario)
		{
			ActualizarUsuarioDTO usuarioDTO = new ActualizarUsuarioDTO()
			{
				Id = usuario.Id,
				Nombre = usuario.Datos,
				Email = usuario.Email.Valor,
				Password = usuario.Contrasenia.Valor,
			};
			return usuarioDTO;
		}

        public static List<ListadoUsuarioDTO> ListUsuarioDTOFromListUsuario(List<Usuario> usuarios)
		{
			return usuarios.Select(u => new ListadoUsuarioDTO()
			{
				Id = u.Id,
				Nombre = u.Datos
			}).ToList();
		}
	}
}
