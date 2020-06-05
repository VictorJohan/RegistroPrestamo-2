using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramaPrestamos.BLL;
using ProgramaPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows;

namespace ProgramaPrestamos.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void ExisteTest()
        {
            bool ok = PrestamosBLL.Existe(2);

            Assert.IsTrue(ok);
        }

        [TestMethod()]
        public void GuardarTest()
        {
            Prestamos prestamo = new Prestamos();
            Personas persona = new Personas();

            persona.PersonaId = 2;
            persona.Nombre = "aa";
            persona.Apellido = "aa";
            persona.Cedula = "111-1111111-1";

            PersonasBLL.Guardar(persona);

            prestamo.IdPrestamo = 2;
            prestamo.IdPersona = 2;
            prestamo.Monto = 1150;
            prestamo.ConceptoPrestamo = "aa";
            prestamo.FechaPrestamo = DateTime.Now;

            bool ok = PrestamosBLL.Guardar(prestamo);

            Assert.IsTrue(ok);

        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool ok = PrestamosBLL.Eliminar(2);

            Assert.IsTrue(ok);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var encontrado = PrestamosBLL.Buscar(2);

            Assert.IsTrue(encontrado != null);
        }
    }
}