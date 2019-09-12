using dam.di.inventario.Servicios;
using ejemplo_tema4.Servicios;
using MahApps.Metro.Controls;
using ejemplo_tema4.Modelo;
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
using ejemplo_tema4.MVVM;

namespace ejemplo_tema4.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogArticuloMVVM.xaml
    /// </summary>
    public partial class DialogArticuloMVVM : MetroWindow
    {
        private diinventarioEntities invEnt;
        private MVArticulo mvArt;

        private ArticuloServicio artServ;

        public DialogArticuloMVVM(diinventarioEntities ent)
        {
            InitializeComponent();

            invEnt = ent;

            mvArt = new MVArticulo(invEnt);

            artServ = new ArticuloServicio(ent);

            DataContext = mvArt;

            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvArt.OnErrorEvent));

            mvArt.btnGuardar = btnGuardarArt;
        }

        

        private void btnArtEnviar_Click(object sender, RoutedEventArgs e)
        {
            mvArt.articuloNuevo.idarticulo = artServ.getLastId() + 1;

            if (mvArt.guarda())
            {
                MessageBox.Show("Inserción ", "GESTIÓN INVENTARIO", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Error al realizar la inserción ", "GESTIÓN INVENTARIO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnArtCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
