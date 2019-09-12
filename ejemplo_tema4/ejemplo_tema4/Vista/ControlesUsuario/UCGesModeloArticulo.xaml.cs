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
    /// Lógica de interacción para UCGesModeloArticulo.xaml
    /// </summary>
    public partial class UCGesModeloArticulo : UserControl
    {
        private diinventarioEntities invEnt;
        private MVModelo mvMod;

        private PropertyGroupDescription grupoTipo;
        private Predicate<Object> predicadoNombre;

        public UCGesModeloArticulo(diinventarioEntities ent) { 
            InitializeComponent();
            invEnt = ent;
            mvMod = new MVModelo(invEnt);
            DataContext = mvMod;
            grupoTipo = new PropertyGroupDescription("tipo");
            predicadoNombre = new Predicate<object>(filtroNombre);
        }

        private void chkGroupTipo_Checked(object sender, RoutedEventArgs e)
        {
            mvMod.listaCollectionModelos.GroupDescriptions.Add(grupoTipo);
        }

        private void chkGroupTipo_Unchecked(object sender, RoutedEventArgs e)
        {
            mvMod.listaCollectionModelos.GroupDescriptions.Remove(grupoTipo);
        }

        private void cbxFiltrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mvMod.listaCollectionModelos.Filter = new Predicate<object>(filtroTipo);
        }

        private bool filtroTipo(Object obj)
        {
            bool correcto = true;
            modeloarticulo modeloArt;
            // Primero Hacemos la conversion
            if(obj != null)
            {
                modeloArt = (modeloarticulo)obj;
                if (modeloArt.tipoarticulo == null || !modeloArt.tipoarticulo.nombre.Equals(mvMod.tipoSeleccionado.nombre))
                    correcto = false;
            }
            else
            {
                correcto = false;
            }

            return correcto;
        }

        private void btnResetFiltro_Click(object sender, RoutedEventArgs e)
        {
            mvMod.listaCollectionModelos.Filter = null;
        }

        private void txtBuscarModeloArticulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvMod.listaCollectionModelos.Filter = predicadoNombre;
        }

        private bool filtroNombre (Object obj)
        {
            bool correcto = true;
            modeloarticulo modArt;

            // Primero hacemos la conversion
            if(obj != null)
            {
                // Hacemos conversion
                modArt = (modeloarticulo)obj;
                if (modArt.nombre == null || !modArt.nombre.ToUpper().StartsWith(txtBuscaModeloArticulos.Text.ToUpper()))
                    correcto = false;
            }
            else
            {
                correcto = false;
            }

            return correcto;
        }
    }
}
