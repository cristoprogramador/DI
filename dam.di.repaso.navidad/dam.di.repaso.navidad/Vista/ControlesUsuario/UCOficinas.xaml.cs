using dam.di.repaso.navidad.Modelo;
using dam.di.repaso.navidad.MVVM;
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

namespace dam.di.repaso.navidad.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCOficinas.xaml
    /// </summary>
    public partial class UCOficinas : UserControl
    {
        private jardineriaEntities jEnt;
        private MVOficinas mvOficina;

        public UCOficinas(jardineriaEntities ent)
        {
            InitializeComponent();
            jEnt = ent;
            mvOficina = new MVOficinas(ent);
            DataContext = mvOficina;
        }

        private void arbolOficina_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is empleados)
            {
                empleados emp = (empleados)e.NewValue;
                //MessageBox.Show("NOMBRE EMPLEADO: "+ emp.Nombre,"GESTION EMPLEADOS", MessageBoxButton.OK,  MessageBoxImage.Asterisk);
                dtEmpleados.ItemsSource = emp.clientes;
            }
        }       
    }
}
