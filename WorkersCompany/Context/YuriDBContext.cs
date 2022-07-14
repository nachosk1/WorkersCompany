using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersCompany.Models;

namespace WorkersCompany.Context
{
    public class YuriDBContext : DbContext
    {
        public YuriDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ContactosEmerg> ContactosEmergs { get; set; }
        public DbSet<DatosLaborales> DatosLaborales { get; set; }
        public DbSet<Trabajador> Trabajadors { get; set; }
        public DbSet<CargaFamiliar> CargaFamiliars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<ContactosEmerg>().ToTable("ContactosEmerg");
            modelBuilder.Entity<DatosLaborales>().ToTable("DatosLaborales");
            modelBuilder.Entity<Trabajador>().ToTable("Trabajador");
            modelBuilder.Entity<CargaFamiliar>().ToTable("CargaFamiliar");
        }



    }
}
