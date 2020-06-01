using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProgramaPrestamos.Entidades
{
    public class Prestamos
    {
        [Key]
        public int IdPrestamo { get; set; }
        public int IdPersona { get; set; } 
        public double Monto { get; set; }
        public string ConceptoPrestamo { get; set; }
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;
        
    }
}
