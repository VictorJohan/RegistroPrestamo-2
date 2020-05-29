using RegistroPrestamo.BLL;
using RegistroPrestamo.DAL;
using RegistroPrestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroPrestamo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Prestamos Prestamo = new Prestamos();
        private int previousLineCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Prestamo;
        }

        private void conceptoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (conceptoTextBox.LineCount > previousLineCount)
            {
                previousLineCount = conceptoTextBox.LineCount;
            }
        }

        
        private void buscarPersonaButton_Click(object sender, RoutedEventArgs e)
        {
            var prestamo = PrestamosBLL.Buscar(int.Parse(idPersonaTextBox.Text));

            if (Prestamo != null)
            {
                this.Prestamo = prestamo;
            }
            else
            {
                this.Prestamo = new Prestamos();
            }

            this.DataContext = Prestamo;

            idPrestamoTextBox.IsReadOnly = true;
            idPersonaTextBox.IsReadOnly = true;
            montoTextBox.IsReadOnly = true;
            conceptoTextBox.IsReadOnly = true;
            fechaPrestamoDataPicker.IsEnabled = false;
            guardarButton.IsEnabled = false;
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            idPrestamoTextBox.IsReadOnly = false;
            idPersonaTextBox.IsReadOnly = false;
            montoTextBox.IsReadOnly = false;
            conceptoTextBox.IsReadOnly = false;
            fechaPrestamoDataPicker.IsEnabled = true;
            guardarButton.IsEnabled = true;
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            
            if (!PrestamosBLL.Existe(Prestamo.IdPersona))
            {
                Prestamo.Balance += Prestamo.Monto;
                var ok = PrestamosBLL.Guardar(Prestamo);

                if (ok)
                {
                    Limpiar();
                    MessageBox.Show("Gardado", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Algo salio mal", "Fallo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Contexto contexto = new Contexto();
                var Aux = contexto.Prestamos.Find(Prestamo.IdPersona);

                Prestamo.Balance = Aux.Balance;
                Prestamo.Balance += Prestamo.Monto;
                var ok = PrestamosBLL.Guardar(Prestamo);

                if (ok)
                {
                    Limpiar();
                    MessageBox.Show("Gardado", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Algo salio mal", "Fallo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PrestamosBLL.Eliminar(int.Parse(idPersonaTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void Limpiar()
        {
            this.Prestamo = new Prestamos();
            this.DataContext = Prestamo;
        }

        private void editarButton_Click(object sender, RoutedEventArgs e)
        {
            idPrestamoTextBox.IsReadOnly = false;
            idPersonaTextBox.IsReadOnly = false;
            montoTextBox.IsReadOnly = false;
            conceptoTextBox.IsReadOnly = false;
            fechaPrestamoDataPicker.IsEnabled = true;
            guardarButton.IsEnabled = true;
        }


        public bool Validar()
        {
            bool ok = true;
            String refe = @"^[0-9]+$";

            if(idPersonaTextBox.Text.Length == 0)
            {
                MessageBox.Show("El campo Id Persona esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }else if (idPrestamoTextBox.Text.Length == 0)
            {
                MessageBox.Show("El campo Id Prestamo esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }else if(conceptoTextBox.Text.Length == 0)
            {

                MessageBox.Show("El campo Concepto Monto esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }

            Regex regex = new Regex(refe);
            MatchCollection match = regex.Matches(montoTextBox.Text);

            if(match.Count > 0)
            {

            }
            else
            {
                MessageBox.Show("Verifique que haya ingresado una cantidad valida", "En el campo Monto solo pueden ir caracteres numericos",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }

            return ok;
        }
    }

}
