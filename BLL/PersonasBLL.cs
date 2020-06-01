using Microsoft.EntityFrameworkCore;
using ProgramaPrestamos.DAL;
using ProgramaPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows;

namespace ProgramaPrestamos.BLL
{
    public class PersonasBLL
    {

        public static bool Existe(int id)
        {
            bool encontrado;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Personas.Any(e => e.PersonaId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        private static bool Insertar(Personas personas)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Add(personas);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Modificar(Personas personas)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(personas).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static bool Guardar(Personas personas)
        {
            if (!Existe(personas.PersonaId))
            {
                return Insertar(personas);
            }
            else
            {
                return Modificar(personas);
            }
        }

        public static bool Eliminar(int id)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                var personas = contexto.Personas.Find(id);
                if (personas != null)
                {
                    contexto.Remove(personas);
                    ok = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas personas;

            try
            {
                personas = contexto.Personas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return personas;
        }
    }
}
