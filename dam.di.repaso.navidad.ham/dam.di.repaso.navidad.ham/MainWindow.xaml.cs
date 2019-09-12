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

namespace dam.di.repaso.navidad.ham
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void hamMenuPrincipal_ItemClick(object sender, ItemClickEventArgs e)
        {
            // set the content
            this.hamMenuPrincipal.Content = e.ClickedItem;
            // close the pane
            this.hamMenuPrincipal.IsPaneOpen = false;
        }
    }
}
