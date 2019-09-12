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

namespace Tema2.Ejercicio3
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

        private void buttonLectura_Click(object sender, RoutedEventArgs e)
        {
            textNombre.IsReadOnly = true;
        }

        private void buttonActivar_Click(object sender, RoutedEventArgs e)
        {
            if(textApellidos.IsEnabled)
            {
                textApellidos.IsEnabled = false;
            }
            else
            {
                textApellidos.IsEnabled = true;
            }
        }

        private void buttonFoco_Click(object sender, RoutedEventArgs e)
        {
            textNombre.Focus();
        }

        private void buttonPasswd_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(passwordBox.Password.ToString()))
            {
                textNotas.Text = passwordBox.Password.ToString();
            }
        }
    }
}
