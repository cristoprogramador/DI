using dam.di.inventario.Servicios;
using inventario.clase.Modelo;
using inventario.clase.MVVM;
using inventario.clase.Servicios;
using NLog;
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

namespace inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogUsuario.xaml
    /// </summary>
    public partial class DialogUsuarioMVVM : Window
    {
        private diinventarioEntities invEnt;
        //las reglas de negocio
        //enlazar capa vista con MVVM
        private MVUsuario mvUsu;

        public DialogUsuarioMVVM(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            //los enlazo
            mvUsu = new MVUsuario(invEnt);
            //Aqui decimos que los objetos de los Binding los buscaremos en la clase MVUsuario
            //En esta definiremos los objetos que se relacionen con nuestra Vista
            DataContext = mvUsu;

            //deshabilito boton; creo un evento, hay que indicar en el binding NotifyOnvalidationOnproperty error

            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvUsu.OnErrorEvent));
            mvUsu.btnGuardar = btnGuardar;

        }



        private void BtnGuardar_Click_1(object sender, RoutedEventArgs e)
        {

            mvUsu.usuarioNuevo.password = pbPassword.Password;
           
            //Para comprobar los masked
            if (tbCodpos.IsMaskFull)
            {

                if (mvUsu.usuarioUnico)
                {
                    if (mvUsu.guarda())
                    {
                        MessageBox.Show("Inserción realizada correctamente", "GESTION USUARIO", MessageBoxButton.OK, MessageBoxImage.Information);
                        DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("Error al realizar inserción", "GESTION USUARIO",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El usuario está duplicado", "GESTION USUARIO",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("El codigo postal no está completo", "GESTION USUARIO",
                           MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }






    }
}
