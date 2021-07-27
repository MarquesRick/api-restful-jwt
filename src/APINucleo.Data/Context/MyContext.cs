using APINucleo.Data.Mapping;
using APINucleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Api.Data.Context {
    public class MyContext : DbContext {

        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        public DbSet<NucleoUsuario> NucleoUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseOracle
                ("Data Source=10.200.203.13:1521/fpwprd; User Id=grails;Password=ora16ALLIS#grails");
            }
        } 
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<NucleoUsuario>(new NucleoUsuarioMap().Configure);
        }  
    }
}   
