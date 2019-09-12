using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace actividad2.tema2.di.dam
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void lectura_Click(object sender, RoutedEventArgs e)
        {
            nombre.IsReadOnly = true;
        }

        private void activaDesactiva_Click(object sender, RoutedEventArgs e)
        {
            if (apellidos.IsEnabled == true)
            {
                apellidos.IsEnabled = false;
            } else {
                apellidos.IsEnabled = true;
            }
        }

        private void foco_Click(object sender, RoutedEventArgs e)
        {
            nombre.Focus();
        }

        private void muestra_Click(object sender, RoutedEventArgs e)
        {
            notas.Text = contraseña.Password.ToString();
        }
    }
}
