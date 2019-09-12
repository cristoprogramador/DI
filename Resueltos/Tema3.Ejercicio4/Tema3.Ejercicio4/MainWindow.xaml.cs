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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema3.Ejercicio4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /*
         * Constructor de la clase principal
         * Inicializa los componentes gráficos
         */
        public MainWindow()
        {
            InitializeComponent();
        }



        /*
         * Manejadores de eventos 
         * --------------------------------------------------------------------------------------------------------
         */

        /**
         * Manejador del evento del cambio de la pestaña
         */
        private void tabControlPrincipal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblTitulo.Content = ((TabItem)((TabControl)tabControlPrincipal).SelectedItem).Name;
        }


        /*
        * Manejador de eventos del cambio en la selección del combobox
        */
        private void comboFormato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (FrameworkElement f in gridDashboard.Children)
            {
                if (f.GetType().Equals(typeof(TextBox)))
                {
                    string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
                    cambiaFormato((TextBox)f, text);
                }
            }
        }

        /// <summary>
        /// Cambia el formato de la letra de un textbox
        /// </summary>
        /// <param name="txt">Objeto textbox al que se le cambia el formato</param>
        /// <param name="formato">Formato al que se cambia</param>
         private void cambiaFormato(TextBox txt, string formato)
        {
            switch (formato)
            {
                case "Negrita":
                    txt.FontWeight = FontWeights.Bold;
                    txt.FontStyle = FontStyles.Normal;
                    break;
                case "Cursiva":
                    txt.FontStyle = FontStyles.Italic;
                    txt.FontWeight = FontWeights.Normal;
                    break;
                case "Normal":
                    txt.FontWeight = FontWeights.Normal;
                    txt.FontStyle = FontStyles.Normal;
                    break;
            }
        }

    }
}
