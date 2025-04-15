using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesosDatos.Repositorios
{
    public class RepositorioRol : IRepositorioRol
    {
        public UsuarioContext Contexto {  get; set; }

        public RepositorioRol(UsuarioContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Rol item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> FindAll()
        {
            return Contexto.Roles;
        }

        public Rol FindById(int id)
        {
            return Contexto.Roles.Find(id);
        }

        public void Update(Rol item)
        {
            throw new NotImplementedException();
        }
    }
}
