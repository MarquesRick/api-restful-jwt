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
                ("Data Source=99.99.99.99:1521/schema; User Id=user;Password=passOracle");
            }
        } 
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<NucleoUsuario>(new NucleoUsuarioMap().Configure);
        }  
    }
}   
