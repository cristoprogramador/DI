using dam.di.inventario.Servicios;
using ejemplo_tema4.Modelo;
using ejemplo_tema4.MVVM;
using NLog;
using System;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace ejemplo_tema4.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogModeloArticuloMVVM.xaml
    /// </summary>
    public partial class DialogModeloArticuloMVVM : MetroWindow
    {
        private diinventarioEntities invEnt;

        private MVModelo mvMod;

        public DialogModeloArticuloMVVM(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;

            // Aquí decimos que los objetos de los binding los 
            // Buscaremos en la clase MVModelo.
            mvMod = new MVModelo(invEnt);

            // En esta definiremos los objetos que se relacionen con nuestra vista
            DataContext =  mvMod;

            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvMod.OnErrorEvent));
            mvMod.btnGuardar = btnGuardarMod;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (mvMod.guarda())
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
