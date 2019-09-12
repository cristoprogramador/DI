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

namespace Tema3.Ejercicio4.di.dam
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void tabControlPrincipal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Primera opcion
            TabControl tab = sender as TabControl;
            TabItem ti = tab.SelectedItem as TabItem;
            textHead.Text = ti.Name;

            //Segunda opcion
            //textHead.Text = ((TabItem)(tapControlPrincipal.SelectedItem)).Name;

            //Tercera opción
        }

        private void comboFormato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (FrameworkElement f in gridDashboard.Children)
            {
                ComboBoxItem item = comboFormato.SelectedItem as ComboBoxItem;
                String formato = item.Content as string;

                TextBox t = f as TextBox;
                if (f.GetType().Equals(typeof(TextBox)) && !t.Name.Equals("lblCorreo"))
                {
                    // ((TextBox)f).Text = "Hola";
                    cambiaFormato((TextBox)f, formato);
                }
            }
        }

        /// <summary>
        /// Se utiliza para cambiar el formato a un objeto de tipo TextBox
        /// </summary>
        /// <param name="txt">Objeto Textbox al cual queremos cambiar el formato</param>
        /// <param name="formato">Formato al cual se quiere cambiar</param>
        private void cambiaFormato(TextBox txt, string formato)
        {
            switch (formato)
            {
                case "Negrita":
                    txt.FontWeight = FontWeights.Bold;
                    txt.FontStyle = FontStyles.Normal;
                    break;
                case "Cursiva":
                    txt.FontWeight = FontWeights.Normal;
                    txt.FontStyle = FontStyles.Italic;
                    break;
                case "Normal":
                    txt.FontWeight = FontWeights.Normal;
                    txt.FontStyle = FontStyles.Normal;
                    break;
            }
        }
    }
}
