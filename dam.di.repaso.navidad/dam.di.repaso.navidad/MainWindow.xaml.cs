using dam.di.repaso.navidad.Modelo;
using dam.di.repaso.navidad.Servicios;
using dam.di.repaso.navidad.Vista.ControlesUsuario;
using dam.di.repaso.navidad.Vista.Dialogos;
using MahApps.Metro.Controls;
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

namespace dam.di.repaso.navidad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private jardineriaEntities jEnt;

        public MainWindow()
        {
            InitializeComponent();
            conectar();
        }

        private void conectar()
        {
            jEnt = new jardineriaEntities();
        }

        private void btnAltaProductos_Click(object sender, RoutedEventArgs e)
        {
            DialogProductos diag = new DialogProductos();
            diag.ShowDialog();
        }

        private void btnAltaEmpleados_Click(object sender, RoutedEventArgs e)
        {
            DialogEmpleados diag = new DialogEmpleados();
            diag.ShowDialog();
        }

        private void btnAltaOficinas_Click(object sender, RoutedEventArgs e)
        {
            UCOficinas ucOf = new UCOficinas(jEnt);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(ucOf);
            //DialogOficinas diag = new DialogOficinas();
            //diag.ShowDialog();
        }

        private void btnAltaPedidos_Click(object sender, RoutedEventArgs e)
        {
            UCArbolOficinas ucArbOf = new UCArbolOficinas(jEnt);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(ucArbOf);
            //DialogPedidos diag = new DialogPedidos();
            //diag.ShowDialog();
        }
    }
}
