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
using dam.di.inventario.Servicios;
using inventario.clase.Modelo;


namespace inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : Window
    {
        /// <summary>
        /// Variable para inicializar el contexto de la base de datos (hacer último using de modelo)
        /// </summary>

        private diinventarioEntities invEnt;
        /// <summary>
        /// Variable que nos permite trabajar con la tabla usuario de la base de datos(hacer using de servicios)
        /// </summary>
        private UsuarioServicio usuServ;

        public LoginDialog()
        {
            InitializeComponent();
            //Inicializa el contexto de la base de datos
            invEnt = new diinventarioEntities();
            usuServ = new UsuarioServicio(invEnt);//le pasamos la conexion
        }

        /// <summary>
        /// creamos las 2 variables: usu y pass, las que queremos comprobar
        /// lo guardamos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            //si estan vacios estos dos campos
            if(string.IsNullOrEmpty(txtLogin.Text) | string.IsNullOrEmpty(passLogin.Password) )
            {
                txtLogin.BorderBrush = Brushes.Red;
                passLogin.BorderBrush = Brushes.Red;

                MessageBox.Show("El campo usuario y/o contraseña no pueden estar vacíos", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string usu = txtLogin.Text;
                string pass = passLogin.Password;
                if (usuServ.login(usu, pass))
                {
                    //Aqui es conveniente que pasemos los dos objetos que guardan estado
                    MainWindow ventana = new MainWindow(invEnt,usuServ.usuLogin);
                    ventana.Show();
                    //Mostramos la ventana principal
                    this.Close();
                }
                else
                {

                 
                    txtLogin.BorderBrush = Brushes.Red;
                    passLogin.BorderBrush = Brushes.Red;
                    //MessageBox.Show("Error en el usuario y/o contraseña", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Warning);
                    errorLogin.Visibility = Visibility.Visible;
  
                }
            }
       

        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
