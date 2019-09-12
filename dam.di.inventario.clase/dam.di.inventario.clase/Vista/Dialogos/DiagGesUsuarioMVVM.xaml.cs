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
using dam.di.inventario.clase.Modelo;
using dam.di.inventario.clase.MVVM;
using dam.di.inventario.MVVM;

namespace dam.di.inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Interaction logic for DiagGesUsuarioMVVM.xaml
    /// </summary>
    public partial class DiagGesUsuarioMVVM : Window
    {

        private diinventarioEntities invEnt;
        private MVUsuario mvUsu;

        public DiagGesUsuarioMVVM(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            mvUsu = new MVUsuario(invEnt);
            DataContext = mvUsu;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvUsu.OnErrorEvent));
            mvUsu.btnGuardar = btnGuardarUsu;

        }

        private void cbTipoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((tipousuario)cbTipoUsuario.SelectedItem).nombre.Equals("Profesor"))
            {
                cbDepartamento.IsEnabled = true;
                cbGrupo.IsEnabled = false;
            }
            else
            {
                cbDepartamento.IsEnabled = false;
                cbGrupo.IsEnabled = true;
            }
        }

        private void btnCancelarUsu_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnGuardarUsu_Click(object sender, RoutedEventArgs e)
        {
            // Guardamos la contraseña. No lo hacemos mediante un binding por seguridad
            mvUsu.usuarioNuevo.password = txtPassword.Password;
 
            // Comprobamos si el usuario es único
            if (mvUsu.usuarioUnico)
            {
                // Comprobamos que todo ha ido correcto
                if (mvUsu.guarda())
                {
                    MessageBox.Show("Usuario insertado correctamente", "GESTIÓN USUARIOS", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Error al insertar el usuario", "GESTIÓN USUARIOS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("El usuario esta duplicado. \nCambie el nombre de usuario", "GESTIÓN USUARIOS", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUsername.Focus();
            }
        }
    }
}
