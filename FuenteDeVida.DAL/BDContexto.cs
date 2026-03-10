using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//************************

using Microsoft.EntityFrameworkCore;
using FuenteDeVida.EN;

namespace FuenteDeVida.DAL
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Multa> Multa { get; set; }

        public DbSet<Factura> Factura { get; set; }
        public DbSet<Cuota> Cuota { get; set; }
        public DbSet<Comunidad> Comunidad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }
    }
}
