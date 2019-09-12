using dam.di.inventario.clase.Modelo;
using dam.di.inventario.clase.MVVM;
using dam.di.inventario.Servicios;
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

namespace dam.di.inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DiagModeloArticulo.xaml
    /// </summary>
    public partial class DiagModeloArticuloMVVM : Window
    {
        // Contexto de la base de datos
        private diinventarioEntities invEnt;
        private MVModeloArticulo mvModelo;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ent"></param>
        public DiagModeloArticuloMVVM(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            mvModelo = new MVModeloArticulo(invEnt);
            DataContext = mvModelo;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvModelo.OnErrorEvent));
            mvModelo.btnGuardar = btnGuardar;

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

                if (mvModelo.guarda())
                {
                    DialogResult = true;
                } else
                {
                    MessageBox.Show("Inserción realizada correctamente", "GESTIÓN ARTÍCULOS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
