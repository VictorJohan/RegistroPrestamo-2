using ProgramaPrestamos.BLL;
using ProgramaPrestamos.DAL;
using ProgramaPrestamos.Entidades;
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
using ProgramaPrestamos.UI;

namespace ProgramaPrestamos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void nuevoPrestamo_Click(object sender, RoutedEventArgs e)
        {
            RegistroPrestamo registroPrestamo = new RegistroPrestamo();
            registroPrestamo.Show();
            this.Close();
        }

        private void nuevaPersona_Click(object sender, RoutedEventArgs e)
        {
            RegistroPersona registroPersona = new RegistroPersona();
            registroPersona.Show();
            this.Close();
        }
    }

}
