using dam.di.inventario.clase.Modelo;
using dam.di.inventario.clase.Vista.Dialogos;
using dam.di.inventario.clase.Vista.ControlesUsuario;
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
using MahApps.Metro.Controls;

namespace dam.di.inventario.clase
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // Variable que contiene el contexto de la base de datos
        private diinventarioEntities invEnt;
        // Guarda el usuario que inicia sesión
        private usuario usuLogin;
        private UCGesUsuario ucUsuario;
        private UCGesArticulo ucArticulo;
        private UCGesModeloArticulo ucModelo;

        public MainWindow(diinventarioEntities ent, usuario usu)
        {
            this.InitializeComponent();
            invEnt = ent;
            usuLogin = usu;
            tbNombreUsuario.Text = usuLogin.username;
        }

        private void ribBtnModeloMVC_Click(object sender, RoutedEventArgs e)
        {
            DiagModeloArticuloMVC diag = new DiagModeloArticuloMVC(invEnt);
            diag.ShowDialog();
        }

        private void ribPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            Grid child = VisualTreeHelper.GetChild((DependencyObject)sender, 0) as Grid;
            if (child != null)
            {
                child.RowDefinitions[0].Height = new GridLength(0);
            }
        }

        private void ribBtnModeloMVVM_Click(object sender, RoutedEventArgs e)
        {
            DiagModeloArticuloMVVM diag = new DiagModeloArticuloMVVM(invEnt);
            diag.ShowDialog();
        }

        private void ribBtnArticuloMVC_Click(object sender, RoutedEventArgs e)
        {
            DiagGesArticuloMVC diag = new DiagGesArticuloMVC(invEnt,usuLogin);
            diag.ShowDialog();
        }

        private void ribBtnArticuloMVVM_Click(object sender, RoutedEventArgs e)
        {
            DiagGesArticuloMVVM diag = new DiagGesArticuloMVVM(invEnt,usuLogin);
            diag.ShowDialog();
        }

        private void ribBtnUsuarioMVC_Click(object sender, RoutedEventArgs e)
        {
            DiagGesUsuarioMVC diag = new DiagGesUsuarioMVC(invEnt);
            diag.ShowDialog();
        }

        private void ribBtnUsuarioMVVM_Click(object sender, RoutedEventArgs e)
        {
            DiagGesUsuarioMVVM diag = new DiagGesUsuarioMVVM(invEnt);
            diag.ShowDialog();
        }

        private void ribBtnListaUsuario_Click(object sender, RoutedEventArgs e)
        {
            ucUsuario = new UCGesUsuario(invEnt);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(ucUsuario);
        }

        private void ribBtnListaModelo_Click(object sender, RoutedEventArgs e)
        {
            ucModelo = new UCGesModeloArticulo(invEnt);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(ucModelo);
        }

        private void ribBtnListaArticulo_Click(object sender, RoutedEventArgs e)
        {
            ucArticulo = new UCGesArticulo(invEnt);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(ucArticulo);
        }
    }
}
