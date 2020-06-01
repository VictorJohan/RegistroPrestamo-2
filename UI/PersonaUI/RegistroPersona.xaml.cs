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

namespace ProgramaPrestamos.UI
{
    /// <summary>
    /// Interaction logic for RegistroPersona.xaml
    /// </summary>
    public partial class RegistroPersona : Window
    {
        public RegistroPersona()
        {
            InitializeComponent();
        }

        private void atrasButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
                
        }
    }
}
