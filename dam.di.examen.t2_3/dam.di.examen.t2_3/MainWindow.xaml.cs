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

namespace dam.di.examen.t2_3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declaración de variables -----------------------------------------------------------------------------------------
        /// <summary>
        /// Lista con los nombres de los campos del grid ceentral
        /// </summary>
        private List<string> listaCampos = new List<string> {"Name","Lastname","Phone","Sign","Direction","Postal Code" };
        
        public MainWindow()
        {
            // Inicializamos los componentes de XAML
            InitializeComponent();
            // Construimos la parte central de la aplicación
            parteCentral();
                        
        }


        private void parteCentral()
        {
            //Utilizad el nombre del panel central gridCentral para añadir los componentes
            //Definicion

            gridCentral = new Grid();
            DockPanel.SetDock(gridCentral, Dock.Top);
            dock.Children.Add(gridCentral);

            gridCentral.ColumnDefinitions.Add(new ColumnDefinition());
            gridCentral.ColumnDefinitions.Add(new ColumnDefinition());
            gridCentral.ColumnDefinitions.Add(new ColumnDefinition());
            gridCentral.ColumnDefinitions.Add(new ColumnDefinition());

            gridCentral.RowDefinitions.Add(new RowDefinition());
            gridCentral.RowDefinitions.Add(new RowDefinition());
            gridCentral.RowDefinitions.Add(new RowDefinition());
            gridCentral.RowDefinitions.Add(new RowDefinition());
            gridCentral.RowDefinitions.Add(new RowDefinition());

            TextBlock tbPrincipal = new TextBlock();

            tbPrincipal.Text = "New Contact";
            tbPrincipal.Foreground = Brushes.Black;

            Grid.SetColumnSpan(tbPrincipal, 4);
            gridCentral.Children.Add(tbPrincipal);


            Button btnAñadir = new Button();

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
