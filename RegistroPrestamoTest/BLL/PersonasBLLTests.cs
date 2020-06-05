using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramaPrestamos.BLL;
using ProgramaPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPrestamos.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void ExisteTest()
        {
            bool ok = PersonasBLL.Existe(3);

            Assert.IsTrue(ok);
        }

        [TestMethod()]
        public void GuardarTest()
        {
            Personas persona = new Personas();

            persona.PersonaId = 3;
            persona.Nombre = "aa";
            persona.Apellido = "aa";
            persona.Cedula = "111-1111111-1";

            bool ok = PersonasBLL.Guardar(persona);

            Assert.IsTrue(ok);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.IsTrue(PersonasBLL.Eliminar(3));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var encontrado = PersonasBLL.Buscar(3);

            Assert.IsTrue(encontrado != null);
        }
    }
}