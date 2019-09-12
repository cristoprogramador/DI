using ejemplo_tema4.Modelo;
using ejemplo_tema4.MVVM;
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

namespace ejemplo_tema4.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCGesArticulo.xaml
    /// </summary>
    public partial class UCGesArticulo : UserControl
    {
        private diinventarioEntities invEnt;
        private MVArticulo mvArt;
        private PropertyGroupDescription grupoEspacio;

        public UCGesArticulo(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;

            grupoEspacio = new PropertyGroupDescription("espacio");

            mvArt = new MVArticulo(invEnt);

            DataContext = mvArt;
        }

        private void chbxAgrupar_Checked(object sender, RoutedEventArgs e)
        {
            mvArt.listaCollectionArticulos.GroupDescriptions.Add(grupoEspacio);
        }

        private void chbxAgrupar_Unchecked(object sender, RoutedEventArgs e)
        {
            mvArt.listaCollectionArticulos.GroupDescriptions.Remove(grupoEspacio);
        }

        private void cbxFiltrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mvArt.listaCollectionArticulos.Filter = new Predicate<object>(filtroDpto);
        }

        private bool filtroDpto(Object obj)
        {
            bool correcto = true;
            articulo art;
            // Primero Hacemos la conversion
            if (obj != null)
            {
                art = (articulo)obj;
                if (art.departamento == null || !art.departamento1.nombre.Equals(mvArt.departamentoSeleccionado.nombre))
                    correcto = false;
            }
            else
            {
                correcto = false;
            }

            return correcto;
        }

        private void btnNoFiltrar_Click(object sender, RoutedEventArgs e)
        {
            mvArt.listaCollectionArticulos.Filter = null;
        }
    }
}
