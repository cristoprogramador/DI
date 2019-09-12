using dam.di.inventario.Servicios;
using inventario.clase.Modelo;
using inventario.clase.MVVM;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

namespace inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Esta clase nos servira para recoger errores
    /// </summary>
    public partial class DialogModeloArticuloMVVM : Window
    {
        private diinventarioEntities invEnt;
        //enlazar capa vista con MVVM
        private MVModelo mvMod;
      

        public DialogModeloArticuloMVVM(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            //los enlazo
            mvMod = new MVModelo(invEnt);
            //Aqui decimos que los objetos de los Binding los buscaremos en la clase MVModelo
            //En esta definiremos los objetos que se relacionen con nuestra Vista
            DataContext = mvMod;
           
        }
      


        private void btnGuardar_Click_1(object sender, RoutedEventArgs e)
        {
            if (mvMod.IsValid(this))
            {
                if (mvMod.guarda())
                {
                    MessageBox.Show("Inserción realizada correctamente", "GESTION INVENTARIO", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Error al realizar inserción", "GESTION INVENTARIO",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
