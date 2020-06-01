using ProgramaPrestamos.BLL;
using ProgramaPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgramaPrestamos.UI
{
    /// <summary>
    /// Interaction logic for RegistroPersona.xaml
    /// </summary>
    public partial class RegistroPersona : Window
    {
       private Personas Personas = new Personas();
        public RegistroPersona()
        {
            InitializeComponent();
            this.DataContext = Personas;
        }

        
        private void buscarPersonaButton_Click(object sender, RoutedEventArgs e)
        {
            var personas = PersonasBLL.Buscar(int.Parse(idPersonaTextBox.Text));

            if(Personas != null)
            {
                this.Personas = personas;
            }
            else
            {
                this.Personas = new Personas();
            }

            this.DataContext = Personas;
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            var ok = PersonasBLL.Guardar(Personas);

            if (ok)
            {
                MessageBox.Show("Guardado.", "Exito.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salio mal.", "Fallo.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void editarButton_Click(object sender, RoutedEventArgs e)
        {
            //NO SE QUE SE SUPONE QUE DEBA CODIFICAR AQUI YA QUE A LA HORA DE 
            //BUSCAR EL REGISTRO SE PUEDE EDITAR DIRECTAMENTE.
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            

            if (PersonasBLL.Eliminar(int.Parse(idPersonaTextBox.Text)))
            {
                MessageBox.Show("Eliminado.", "Exito.",
                  MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Algo salio mal. Es posible que este registro ya haya sido eliminado.", "Error.",
                  MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Limpiar();
        }

        public void Limpiar()
        {
            this.Personas = new Personas();
            this.DataContext = Personas;
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
            else if (nombreTextBox.Text.Length == 0)
            {
                MessageBox.Show("El campo Id Prestamo esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }
            else if (apellidosTextBox.Text.Length == 0)
            {

                MessageBox.Show("El campo Concepto Monto esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }
            else if (cedulaTextBox.Text.Length == 0)
            {
                MessageBox.Show("El campo Concepto Monto esta vacio", "Todos los campos son obligatorios",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }

            if(!Regex.IsMatch(nombreTextBox.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Solo se admiten caracteres alfabeticos.", "Nombre no valido.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }

            if (!Regex.IsMatch(nombreTextBox.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Solo se admiten caracteres alfabeticos.", "Apellido no valido.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }

            if (!Regex.IsMatch(cedulaTextBox.Text, @"\d{3}-\d{7}-\d{1}"))
            {
                MessageBox.Show("Asegurece de cumplir con el siguiente formato: 111-1111111-1.", "Verifique que haya ingresado una cedula valido",
                  MessageBoxButton.OK, MessageBoxImage.Information);
                return ok = false;
            }

            if (!Regex.IsMatch(idPersonaTextBox.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Id de persona no permitido", "Solo se aceptan caracteres numericos",
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
    }
}
