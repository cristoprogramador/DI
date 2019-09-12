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

namespace Tema2.Ejercicio1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush colorOriginal;

        public MainWindow()
        {
            InitializeComponent();
            colorOriginal = gridPrincipal.Background;
        }

        private void checkBoxColor_Checked(object sender, RoutedEventArgs e)
        {
            gridPrincipal.Background = Brushes.Coral;
        }

        private void checkBoxMostrar_Checked(object sender, RoutedEventArgs e)
        {
            lblVisualizar.Visibility = System.Windows.Visibility.Visible;
        }

        private void checkBoxMostrar_Unchecked(object sender, RoutedEventArgs e)
        {
            lblVisualizar.Visibility = System.Windows.Visibility.Hidden;
        }

        private void checkBoxColor_Unchecked(object sender, RoutedEventArgs e)
        {
            gridPrincipal.Background = colorOriginal;
        }
    }
}
