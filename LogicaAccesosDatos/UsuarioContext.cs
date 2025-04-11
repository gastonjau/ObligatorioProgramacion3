using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LogicaAccesosDatos
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public UsuarioContext(DbContextOptions options) : base(options)
        {

        }
    }
}
