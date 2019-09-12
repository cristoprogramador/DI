using ejemplo_tema4.Modelo;
using ejemplo_tema4.Vista.ControlesUsuario;
using ejemplo_tema4.Vista.Dialogos;
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

namespace ejemplo_tema4
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

        public MainWindow(diinventarioEntities ent, usuario usu)
        {           
            InitializeComponent();
            invEnt = ent;
            usuLogin = usu;
        }

        private void btnModeloMVC_Click(object sender, RoutedEventArgs e)
        {
            DialogModeloArticuloMVC diag = new DialogModeloArticuloMVC(invEnt);
            diag.ShowDialog();
        }

        private void ribBtnUsuarioMVC_Click(object sender, RoutedEventArgs e)
        {
            DialogUsuarioMVC diag = new DialogUsuarioMVC(invEnt);
            diag.ShowDialog();
        }

        private void btnModeloMVVM_Click(object sender, RoutedEventArgs e)
        {
            DialogModeloArticuloMVVM diag = new DialogModeloArticuloMVVM(invEnt);
            diag.ShowDialog();
        }

        private void ribBtnUsuarioMVVM_Click(object sender, RoutedEventArgs e)
        {
            DialogUsuarioMVVM diag = new DialogUsuarioMVVM(invEnt);
            diag.ShowDialog();
        }

        private void btnArticuloMVC_Click (object sender, RoutedEventArgs e)
        {
            DialogArticuloMVC diag = new DialogArticuloMVC(invEnt, usuLogin);
            diag.ShowDialog();
        }

        private void btnArticuloMVVM_Click(object sender, RoutedEventArgs e)
        {
            DialogArticuloMVVM diag = new DialogArticuloMVVM(invEnt);
            diag.ShowDialog();
        }

        private void btnTableModelo_Click(object sender, RoutedEventArgs e)
        {
            UCGesModeloArticulo ucListaModelo = new UCGesModeloArticulo(invEnt);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(ucListaModelo);
        }

        private void btnTableUsuario_Click(object sender, RoutedEventArgs e)
        {
            UCGesUsuario ucListaUsuario = new UCGesUsuario(invEnt);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(ucListaUsuario);
        }

        private void btnTableArticulo_Click(object sender, RoutedEventArgs e)
        {
            UCGesArticulo ucListaArticulo = new UCGesArticulo(invEnt);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(ucListaArticulo);
        }
    }
}
