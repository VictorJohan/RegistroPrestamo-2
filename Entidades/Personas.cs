using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Packaging;
using System.Text;

namespace ProgramaPrestamos.Entidades
{
   public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Historial { get; set; }
        public double Balance { get; set; }
    }
}
