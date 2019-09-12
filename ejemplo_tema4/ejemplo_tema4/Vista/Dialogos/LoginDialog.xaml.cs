using MahApps.Metro.Controls;
using dam.di.inventario.Servicios;
using ejemplo_tema4.Modelo;
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

namespace ejemplo_tema4.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : MetroWindow
    {

        /// <summary>
        /// Variable para incializar el contexto de la base de datos
        /// </summary>
        private diinventarioEntities invEnt;

        /// <summary>
        /// Variable que nos permite trabajar con la tabla usuario de la base de datos
        /// </summary>
        private UsuarioServicio usuServ;

        public LoginDialog()
        {
            InitializeComponent();

            // Inicializa el contexto de la base de datos (la conexion de la BD)
            invEnt = new diinventarioEntities();

            // Le pasamos el contexto (la conexion de la BD) 
            usuServ = new UsuarioServicio(invEnt);
        }

        private void btnLoginGuardar(object sender, RoutedEventArgs e)
        {
            string usu = textBoxUsuario.Text;
            string pass = passwordBoxContraseña.Password;
           
            if (usuServ.login(usu, pass))
            {
                MainWindow ventana = new MainWindow(invEnt, usuServ.usuLogin);
                ventana.Show();
                this.Close();
            }
            else if (String.IsNullOrEmpty(pass) || String.IsNullOrEmpty(usu)){
                if (String.IsNullOrEmpty(pass))
                {
                    passwordBoxContraseña.BorderBrush = Brushes.Red;
                }
                else
                {
                    passwordBoxContraseña.BorderBrush = Brushes.Black;
                }

                if (String.IsNullOrEmpty(usu))
                {
                    textBoxUsuario.BorderBrush = Brushes.Red;
                }
                else
                {
                    textBoxUsuario.BorderBrush = Brushes.Black;
                }

                textBlockRedPassword.Text = "Rellena los dos campos";
                textBlockRedPassword.Visibility = Visibility.Visible;
            }
            else
            {
                textBlockRedPassword.Text = "Error en el usuario y/o contraseña";
                textBlockRedPassword.Visibility = Visibility.Visible;
                //  MessageBox.Show("Error en el usuario y/o contraseña", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnLoginCancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
