using Microsoft.EntityFrameworkCore;
using ProgramaPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPrestamos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Personas> Personas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\RegistroPrestamo.db");
        }
    }
}
