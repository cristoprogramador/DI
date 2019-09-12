using dam.di.examen.t456.Modelo;
using dam.di.examen.t456.MVVM;
using dam.di.examen.t456.Servicios;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dam.di.examen.t456.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DiagInsertaDisco.xaml
    /// </summary>
    public partial class DiagInsertaDisco : MetroWindow
    {
        private musicaEntities mEnt;
        private MVDisco mvDisco;
        private ServicioDisco servDisco;

        public DiagInsertaDisco(musicaEntities ent)
        {
            InitializeComponent();
            mEnt = ent;

            mvDisco = new MVDisco(mEnt);
            DataContext = mvDisco;
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(mvDisco.OnErrorEvent));
            mvDisco.btnGuardar = btnGuardar;
            servDisco = new ServicioDisco(mEnt);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
           
            if (servDisco.nombreDiscoUnico(txtNombre.Text))
            {
                //si el metodo guardar del MV devuelve true
                if (mvDisco.guarda())
                {
                    //resultado del dialog es verdadero/correcto y cierra
                    DialogResult = true;
                    MessageBox.Show("Inserción realizada correctamente", "GESTIÓN DISCOS", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    //Si no, lanza mensaje de error
                    MessageBox.Show("Inserción realizada incorrectamente", "GESTIÓN DISCOS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("El nombre está duplicado", "GESTIÓN DISCOS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
