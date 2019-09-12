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

namespace actividad1.tema2.di.dam
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

        private void checkPonerColor_Checked(object sender, RoutedEventArgs e)
        {
            gridCentral.Background = Brushes.BurlyWood;
        }

        private void checkPonerColor_Unchecked(object sender, RoutedEventArgs e)
        {
            gridCentral.Background = Brushes.Gray;
        }

        private void checkMostrarCadena_Checked(object sender, RoutedEventArgs e)
        {
            cadenaOculta.Visibility = Visibility.Visible;
        }

        private void checkMostrarCadena_Unchecked(object sender, RoutedEventArgs e)
        {
            cadenaOculta.Visibility = Visibility.Hidden;      
        }
    }
}
