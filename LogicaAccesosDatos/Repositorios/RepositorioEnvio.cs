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
    public class RepositorioEnvio : IRepositorioEnvio
    {
        public UsuarioContext Contexto { get; set; }
        public RepositorioEnvio(UsuarioContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Envio item)
        {
            Contexto.Add(item);
            Contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> FindAll()
        {
            return Contexto.Envios.Include(e => e.Empleado).Include(e => e.Cliente);
        }

        public Envio FindById(int id)
        {
            return Contexto.Envios.Find(id);
        }
        public void Update(Envio item)
        {
            Contexto.Envios.Update(item);
            Contexto.SaveChanges();
        }
    }
}
