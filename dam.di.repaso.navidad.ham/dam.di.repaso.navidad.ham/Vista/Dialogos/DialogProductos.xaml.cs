using MahApps.Metro.Controls;
using NLog;
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
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace dam.di.repaso.navidad.ham.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogProductos.xaml
    /// </summary>
    public partial class DialogProductos : MetroWindow
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public DialogProductos()
        {
            InitializeComponent();
        }

        private void btnCancelarProducto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardarProducto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
