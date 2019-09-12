using ejemplo_tema4.Modelo;
using MahApps.Metro.Controls;
using System.Windows;
using ejemplo_tema4.MVVM;
using System.Windows.Controls;

namespace ejemplo_tema4.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogUsuarioMVVM.xaml
    /// </summary>
    public partial class DialogUsuarioMVVM : MetroWindow
    {
        private diinventarioEntities invEnt;
        private MVUsuario mvUsu;

        public DialogUsuarioMVVM(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            mvUsu = new MVUsuario(invEnt);
            // Sirve para indicar el lugar donde se tiene que guardar la informacion
            DataContext = mvUsu;

            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvUsu.OnErrorEvent));
            mvUsu.btnGuardar = btnGuardarUsu;
        }
   
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Guardamos la contraseña. No lo hacemos mediante un binding por seguridad
            mvUsu.usuarioNuevo.password = pbPassword.Password;

            if (mvUsu.guarda())
            {
                MessageBox.Show("Inserción ", "GESTIÓN INVENTARIO", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Error al realizar la inserción ", "GESTIÓN INVENTARIO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
      
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
