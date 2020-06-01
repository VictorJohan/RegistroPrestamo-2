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
            Contexto contexto = new Contexto();
            Personas personas = PersonasBLL.Buscar(prestamos.IdPersona);
            Prestamos aux = PrestamosBLL.Buscar(prestamos.IdPrestamo);

            if (!Existe(prestamos.IdPersona))
            {

                personas.Balance += prestamos.Monto;
                personas.Historial += $"Agrego: Prest. Id: {prestamos.IdPrestamo}: {prestamos.Monto}\n";
                PersonasBLL.Guardar(personas);
                contexto.Dispose();
                return Insertar(prestamos);
            }
            else
            {
                personas.Balance -= aux.Monto;
                personas.Balance += prestamos.Monto;
                personas.Historial += $"Modif.: Prest. Id: {prestamos.IdPrestamo}: {prestamos.Monto}\n";
                PersonasBLL.Guardar(personas);
                contexto.Dispose();
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
                Personas personas = PersonasBLL.Buscar(prestamos.IdPersona);

                personas.Balance -= prestamos.Monto;
                personas.Historial += $"Elim.: Prest. Id: {prestamos.IdPrestamo}: {prestamos.Monto}\n";
                PersonasBLL.Guardar(personas);

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
