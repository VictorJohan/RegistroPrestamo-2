using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProgramaPrestamos.Entidades;
using ProgramaPrestamos.BLL;
using ProgramaPrestamos.DAL;
using System.Text.RegularExpressions;

namespace ProgramaPrestamos.UI
{
    /// <summary>
    /// Interaction logic for RegistroPrestamo.xaml
    /// </summary>
    public partial class RegistroPrestamo : Window
    {
        private Prestamos Prestamo = new Prestamos();
        private int previousLineCount = 0;

        public WindowStartupLocation CenterOwner { get; private set; }

        public RegistroPrestamo()
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


        private void buscarPrestamoButton_Click(object sender, RoutedEventArgs e)
        {

             var prestamo = PrestamosBLL.Buscar(int.Parse(idPrestamoTextBox.Text));

             if (Prestamo != null)
             {
                 this.Prestamo = prestamo;
             }
             else
             {
                 this.Prestamo = new Prestamos();
             }

             this.DataContext = Prestamo;

             /*idPrestamoTextBox.IsReadOnly = true;
             idPersonaTextBox.IsReadOnly = true;
             montoTextBox.IsReadOnly = true;
             conceptoTextBox.IsReadOnly = true;
             fechaPrestamoDataPicker.IsEnabled = false;
             guardarButton.IsEnabled = false;*/
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
           /* idPrestamoTextBox.IsReadOnly = false;
            idPersonaTextBox.IsReadOnly = false;
            montoTextBox.IsReadOnly = false;
            conceptoTextBox.IsReadOnly = false;
            fechaPrestamoDataPicker.IsEnabled = true;
            guardarButton.IsEnabled = true;*/
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

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

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PrestamosBLL.Eliminar(int.Parse(idPrestamoTextBox.Text)))
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

            //NO SE QUE SE SUPONE QUE DEBA CODIFICAR AQUI YA QUE A LA HORA DE 
            //BUSCAR EL REGISTRO SE PUEDE EDITAR DIRECTAMENTE.

            /*idPrestamoTextBox.IsReadOnly = false;
            idPersonaTextBox.IsReadOnly = false;
            montoTextBox.IsReadOnly = false;
            conceptoTextBox.IsReadOnly = false;
            fechaPrestamoDataPicker.IsEnabled = true;
            guardarButton.IsEnabled = true;*/
        }


        public bool Validar()
        {
            bool ok = true;
            
            if (idPersonaTextBox.Text.Length == 0)
            {
                MessageBox.Show("El campo Id Persona esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }
            else if (idPrestamoTextBox.Text.Length == 0)
            {
                MessageBox.Show("El campo Id Prestamo esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }
            else if (conceptoTextBox.Text.Length == 0)
            {

                MessageBox.Show("El campo Concepto Monto esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }else if (!PersonasBLL.Existe(int.Parse(idPersonaTextBox.Text)))
            {
                MessageBox.Show("Esta persona no existe en la base de datos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return ok = false;
            }

            if (!Regex.IsMatch(montoTextBox.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Verifique que haya ingresado una cantidad valida", "En el campo Monto solo pueden ir caracteres numericos",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }

            if (!Regex.IsMatch(idPersonaTextBox.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Id de persona no permitido", "Solo se aceptan caracteres numericos",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }

            if (!Regex.IsMatch(idPrestamoTextBox.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Id de prestamo no permitido", "Solo se aceptan caracteres numericos",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }

            return ok;
        }

        private void atrasButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

      

        private void verPersonaButton_Click_1(object sender, RoutedEventArgs e)
        {
            Personas Personas = new Personas();
            Personas = PersonasBLL.Buscar(int.Parse(idPersonaTextBox.Text));

            RegistroPersona registroPersona = new RegistroPersona();
            registroPersona.DataContext = Personas;
            registroPersona.WindowStartupLocation = CenterOwner;
            registroPersona.Show();
        }
    }
}
