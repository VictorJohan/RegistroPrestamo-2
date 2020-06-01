using Microsoft.EntityFrameworkCore;
using ProgramaPrestamos.DAL;
using ProgramaPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;

namespace ProgramaPrestamos.BLL
{
    public class PrestamosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            
            try
            {
                encontrado = contexto.Prestamos.Any(e => e.IdPersona == id);
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

        private static bool Insertar(Prestamos prestamos)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                
                contexto.Prestamos.Add(prestamos);
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        private static bool Modificar(Prestamos prestamos)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                
                contexto.Entry(prestamos).State = EntityState.Modified;
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.IdPersona))
            {
                return Insertar(prestamos);
            }
            else
            {
                return Modificar(prestamos);
            }
        }

        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                var prestamos = contexto.Prestamos.Find(id);

                if (prestamos != null)
                {
                    contexto.Prestamos.Remove(prestamos);
                    key = contexto.SaveChanges() > 0;
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

            return key;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamos;

            try
            {
                prestamos = contexto.Prestamos.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamos;
        }

       
    }
}
