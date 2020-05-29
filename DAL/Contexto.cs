using Microsoft.EntityFrameworkCore;
using RegistroPrestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamo.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prestamos> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\RegistroPrestamo.db");
        }
    }
}
