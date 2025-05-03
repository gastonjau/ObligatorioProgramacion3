using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
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
            throw new NotImplementedException();
        }

        public Envio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Envio item)
        {
            throw new NotImplementedException();
        }
    }
}
