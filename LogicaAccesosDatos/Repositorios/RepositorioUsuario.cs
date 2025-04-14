using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesosDatos.Repositorios
{
	public class RepositorioUsuario : IRepositorioUsuario
	{
		private UsuarioContext Contexto { get; set; }
		public RepositorioUsuario(UsuarioContext contexto)
		{
			Contexto = contexto;
		}
		public Usuario ObtenerPorEmail(string email)
		{
			return Contexto.Usuarios.Where(c => c.Email.Valor == email).SingleOrDefault();
		}
		public bool FindByEmailAndPass(string email, string contrasenia)
		{
			return Contexto.Usuarios.Any(c => c.Email.Valor == email && c.Contrasenia.Valor == contrasenia && c.Rol.Nombre != "Cliente");
		}

        public void Add(Usuario item)
        {
            Usuario usuarioBuscado = ObtenerPorEmail(item.Email.Valor);
            if (usuarioBuscado == null)
            {
                Contexto.Usuarios.Add(item);
                Contexto.SaveChanges();
            } else
            {
                throw new UsuarioException("Ya existe un usuario con ese mail.");
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios;
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios.Find(id);
        }

        public void Delete(int id)
        {
            Usuario usuarioBuscado = FindById(id);
            if (usuarioBuscado != null)
            {
                Contexto.Usuarios.Remove(usuarioBuscado);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("No se encontro un usuario con ese id.");
            }
        }

        public void Update(Usuario item)
        {
            Usuario usuarioBuscado = ObtenerPorEmail(item.Email.Valor);
            if (usuarioBuscado == null || item.Id == usuarioBuscado.Id)
            {
                Contexto.Update(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("Ya existe un usuario con ese mail.");
            }
        }
    }
}
