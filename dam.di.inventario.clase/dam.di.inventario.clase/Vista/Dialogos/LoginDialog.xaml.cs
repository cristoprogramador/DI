using dam.di.inventario.clase.Modelo;
using dam.di.inventario.clase.Validacion;
using dam.di.inventario.Servicios;
using MahApps.Metro.Controls;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dam.di.inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : MetroWindow
    {
        /// <summary>
        /// Variable para inicializar el contexto de la base de datos
        /// </summary>
        private diinventarioEntities invEnt;
        /// <summary>
        /// Variable que nos permite trabajar con la 
        /// tabla usuario de la base de datos
        /// </summary>
        private UsuarioServicio usuServ;

        public LoginDialog()
        {
            InitializeComponent();
            // Inicializa el contexto de la base de datos
            invEnt = new diinventarioEntities();
            usuServ = new UsuarioServicio(invEnt);
        }

        private void btnLoginGuardar_Click(object sender, RoutedEventArgs e)
        {
            string usu = txtLogin.Text;
            string pass = passLogin.Password;
            if(string.IsNullOrEmpty(usu))
            {
                ErrorMVC.muestraError(imgErrorNombreUsuario, txtLogin);
                if (string.IsNullOrEmpty(pass))
                {
                    ErrorMVC.muestraError(imgErrorPass, passLogin);
                } else
                {
                    ErrorMVC.quitaError(imgErrorPass, passLogin);
                }
            } else
            {
                ErrorMVC.quitaError(imgErrorNombreUsuario, txtLogin);
                if(string.IsNullOrEmpty(pass))
                {
                    ErrorMVC.muestraError(imgErrorPass, passLogin);
                } else
                {
                    ErrorMVC.quitaError(imgErrorPass, passLogin);
                    if (usuServ.login(usu, pass))
                    {
                        MainWindow ventana = new MainWindow(invEnt, usuServ.usuLogin);
                        ventana.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error en el usuario y/o contraseña", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            } 
        }

        private void btnLoginCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtLogin.Text))
            {
                ErrorMVC.muestraError(imgErrorNombreUsuario, txtLogin);
            } else
            {
                ErrorMVC.quitaError(imgErrorNombreUsuario, txtLogin);
            }
        }

        private void passLogin_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(passLogin.Password))
            {
                ErrorMVC.muestraError(imgErrorPass, passLogin);
            }
            else
            {
                ErrorMVC.quitaError(imgErrorPass, passLogin);
            }
        }
    }
}
