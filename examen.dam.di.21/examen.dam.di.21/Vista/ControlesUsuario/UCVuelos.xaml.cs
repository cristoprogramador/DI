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
using examen.dam.di._21.Modelo;
using examen.dam.di._21.MVVM;

namespace examen.dam.di._21.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCVuelos.xaml
    /// </summary>
    public partial class UCVuelos : UserControl
    {
        private aerolineasEntities aEnt;
        private MVVuelos mvVuelos;

        public UCVuelos(aerolineasEntities ent)
        {

            InitializeComponent();
            aEnt = ent;
            mvVuelos = new MVVuelos(aEnt);
            DataContext = mvVuelos;
        }


        private void mitemEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgVuelos.SelectedItem != null)
            {
                mvVuelos.nuevoVuelo = (vuelos)(dgVuelos.SelectedItem);
                   
                dgVuelos.Items.Refresh();
                
            }
            else
            {
                MessageBox.Show("Debes seleccionar un elemento de la tabla", "GESTIÓN MODELO ARTICULO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void mItemEditar_Click_1(object sender, RoutedEventArgs e)
        {
            mvVuelos.nuevoVuelo = (vuelos)(dgVuelos.SelectedItem);
        }
    }
}
