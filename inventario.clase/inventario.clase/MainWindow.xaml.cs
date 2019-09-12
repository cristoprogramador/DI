using inventario.clase.Modelo;
using inventario.clase.Vista.ControlesUsuario;
using inventario.clase.Vista.Dialogos;
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

namespace inventario.clase
{




    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variable que contiene el contexto de la base de datos
        private diinventarioEntities invEnt;
        //Guarda el usuario que inicia sesión
        private usuario usuLogin;

        //aqui tenemos que pasarle los objetos
        public MainWindow(diinventarioEntities ent, usuario usu)
        {
            this.InitializeComponent();
            invEnt = ent;
            usuLogin = usu;
            textLogin.Text = usuLogin.username;

            //tbNombreUsuario.Text = usuLogin.username; Este no lo tenemos nosotros asi se haria

        }




        private void btnModArtNuevo_Click(object sender, RoutedEventArgs e)
        {
            DialogModeloArticuloMVC diag = new DialogModeloArticuloMVC(invEnt);
            diag.ShowDialog();

        }

        private void btnUsuNuevo_Click(object sender, RoutedEventArgs e)
        {
            DialogUsuario diag = new DialogUsuario(invEnt);
            diag.ShowDialog();
        }

        private void btnModArtNuevoMVVM_Click(object sender, RoutedEventArgs e)
        {
            DialogModeloArticuloMVVM diag = new DialogModeloArticuloMVVM(invEnt);
            diag.ShowDialog();
        }

        private void BtnUsuNuevoMVVM_Click(object sender, RoutedEventArgs e)
        {
            DialogUsuarioMVVM diag = new DialogUsuarioMVVM(invEnt);
            diag.ShowDialog();

        }



        private void btnArtMVC_Click(object sender, RoutedEventArgs e)
        {
            DialogArticuloMVC diag = new DialogArticuloMVC(invEnt);
            diag.ShowDialog();

        }

        private void btnListaModelo_click(object sender, RoutedEventArgs e)
        {

            UCGesModeloArticulo ucModelo = new UCGesModeloArticulo(invEnt);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(ucModelo);
        }

        private void BtnListaUsuario_Click(object sender, RoutedEventArgs e)
        {

            UCGesUsuario ucUsuario = new UCGesUsuario(invEnt);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(ucUsuario);

        }

        private void BtnListaArticulo_Click(object sender, RoutedEventArgs e)
        {
            UCGesArticulo ucUsuario = new UCGesArticulo(invEnt);
            // Lo colocaremos en el panel central de nuestra aplicación
            // Si hay algo en el grid central lo borramos
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            // Añadimos nuestro user control
            gridCentral.Children.Add(ucUsuario);
        }
    }

}
