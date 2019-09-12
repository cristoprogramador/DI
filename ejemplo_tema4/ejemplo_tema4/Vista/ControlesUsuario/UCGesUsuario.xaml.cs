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
    /// Lógica de interacción para UCGesUsuario.xaml
    /// </summary>
    public partial class UCGesUsuario : UserControl
    {
        private diinventarioEntities invEnt;
        private MVUsuario mvUsu;
        private PropertyGroupDescription grupoDepartamento;
        private Predicate<Object> predicadoNombreApellido;

        public UCGesUsuario(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            mvUsu = new MVUsuario(invEnt);
            DataContext = mvUsu;
            predicadoNombreApellido = new Predicate<object>(filtroNombreApellido);
            grupoDepartamento = new PropertyGroupDescription("departamento");
        }

        private void chbxAgrupar_Checked(object sender, RoutedEventArgs e)
        {
            mvUsu.listaCollectionUsuarios.GroupDescriptions.Add(grupoDepartamento);
        }

        private void chbxAgrupar_Unchecked(object sender, RoutedEventArgs e)
        {
            mvUsu.listaCollectionUsuarios.GroupDescriptions.Remove(grupoDepartamento);
        }

        private void cbxFiltrar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mvUsu.listaCollectionUsuarios.Filter = new Predicate<object>(filtroGrpo);
        }

        private bool filtroGrpo(Object obj)
        {
            bool correcto = true;
            usuario usu;
            // Primero Hacemos la conversion
            if (obj != null)
            {
                usu  = (usuario)obj;
                if (usu.grupo == null || !usu.grupo1.nombre.Equals(mvUsu.grupoSeleccionado.nombre))
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
            mvUsu.listaCollectionUsuarios.Filter = null;
        }

        private void txtBuscaNombreApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvUsu.listaCollectionUsuarios.Filter = predicadoNombreApellido;
        }

        private bool filtroNombreApellido(Object obj)
        {
            bool correcto = true;
            usuario usu;

            // Primero hacemos la conversion
            if (obj != null)
            {
                // Hacemos conversion
                usu = (usuario)obj;
                if (usu.nombre == null || !usu.nombre.ToUpper().StartsWith(txtBuscaNombreApellido.Text.ToUpper()))
                {
                    if (usu.apellido1 == null || !usu.apellido1.ToUpper().StartsWith(txtBuscaNombreApellido.Text.ToUpper()))
                    {
                        correcto = false;
                    }else if (usu.apellido1.ToUpper().StartsWith(txtBuscaNombreApellido.Text.ToUpper()))
                    {
                        correcto = true;
                    }
                    else
                    {
                        correcto = true;
                    }
                    
                }
            }
            else
            {
                correcto = false;
            }

            return correcto;
        }
    }
}
