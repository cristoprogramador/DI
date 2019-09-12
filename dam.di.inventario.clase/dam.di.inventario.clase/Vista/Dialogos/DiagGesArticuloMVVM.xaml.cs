using dam.di.inventario.clase.Modelo;
using dam.di.inventario.clase.MVVM;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace dam.di.inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Interaction logic for DiagGesArticuloMVC.xaml
    /// </summary>
    public partial class DiagGesArticuloMVVM : Window
    {
        private diinventarioEntities invEnt;
        private MVArticulo mvArt;
        private usuario usuLogin;

        public DiagGesArticuloMVVM(diinventarioEntities ent, usuario usu)
        {
            InitializeComponent();
            invEnt = ent;
            usuLogin = usu;
            comboUsuarioAlta.SelectedItem = usuLogin;
            mvArt = new MVArticulo(invEnt);
            DataContext = mvArt;
        }

        private void btnGuardarArticulo_Click(object sender, RoutedEventArgs e)
        {
            // Guardamos la contraseña. No lo hacemos mediante un binding por seguridad
            mvArt.articuloNuevo.idarticulo = mvArt.lastId + 1;
            // Comprobamos si el usuario es único
            if (mvArt.numSerieUnico)
            {
                // Comprobamos que todo ha ido correcto
                if (mvArt.guarda())
                {
                    MessageBox.Show("Articulo insertado correctamente", "GESTIÓN ARTICULOS", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Error al insertar el articulo", "GESTIÓN ARTICULOS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("El número de serie esta duplicado. \nComprueba el número de serie", "GESTIÓN ARTICULOS", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNumSerie.Focus();
            }
        }

        private void btnCancelarArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
