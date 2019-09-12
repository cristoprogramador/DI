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
using dam.di.repaso.navidad.ham.Vista.Dialogos;

namespace dam.di.repaso.navidad.ham.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCAdministracion.xaml
    /// </summary>
    public partial class UCAdministracion : UserControl
    {
        public UCAdministracion()
        {
            InitializeComponent();
        }

        private void rbtnAltaEmpleado_Click(object sender, RoutedEventArgs e)
        {
            DialogEmpleados diag = new DialogEmpleados();
            diag.ShowDialog();
        }

        private void rbtnAltaOficina_Click(object sender, RoutedEventArgs e)
        {
            DialogOficinas diag = new DialogOficinas();
            diag.ShowDialog();
        }

        private void rbtnAltaProductos_Click(object sender, RoutedEventArgs e)
        {
            DialogProductos diag = new DialogProductos();
            diag.ShowDialog();
        }

        private void rbtnAltaProducto_Click(object sender, RoutedEventArgs e)
        {
            DialogPedidos diag = new DialogPedidos();
            diag.ShowDialog();
        }

        private void rbtnListaEmpleados_Click(object sender, RoutedEventArgs e)
        {
            UCListaPersonal ucPersonal = new UCListaPersonal();
            if (panelCentral.Children != null) panelCentral.Children.Clear();
            panelCentral.Children.Add(ucPersonal);
        }

        private void rbtnListaOficinas_Click(object sender, RoutedEventArgs e)
        {
            UCListaOficinas ucOficinas = new UCListaOficinas();
            if (panelCentral.Children != null) panelCentral.Children.Clear();
            panelCentral.Children.Add(ucOficinas);
        }

        private void rbtnListaProductos_Click(object sender, RoutedEventArgs e)
        {
            UCListaProductos ucProductos = new UCListaProductos();
            if (panelCentral.Children != null) panelCentral.Children.Clear();
            panelCentral.Children.Add(ucProductos);
        }
    }
}
