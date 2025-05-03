using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        public DbSet<Rol> Roles {  get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Comun> Comunes { get; set; }
        public DbSet<Urgente> Urgentes { get; set; }
        public DbSet<Agencia> Agencias { get; set; }

        public UsuarioContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasOne(u => u.Rol).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Envio>().HasOne(e => e.Empleado).WithMany().OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
