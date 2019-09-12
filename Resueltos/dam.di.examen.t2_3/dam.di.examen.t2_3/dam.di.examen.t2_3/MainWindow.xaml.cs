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
        /// <summary>
        /// Número de columnas del grid central
        /// </summary>
        private int numCols = 2;
        /// <summary>
        /// Número de filas del grid central
        /// </summary>
        private int numFilas = 8;
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            // Inicializamos los componentes de XAML
            InitializeComponent();
            // Construimos la parte central de la aplicación
            parteCentral();
        }
        /// <summary>
        /// Construye la parte central de la aplicación
        /// </summary>
        private void parteCentral()
        {
            // Utilizad el nombre del panel central gridCentral para añadir los componentes
            // Crea las columnas
            generaColumnas();
            // Crea las filas
            generaFilas();
            // Crea el t´tulo de la parte central
            generaTitulo();
            // Genera los campos mediante un bucle
            generaCampos();
            // Añade el botón al panel central
            generaBoton();
        }
        /// <summary>
        /// Manejador de eventos para el botón salir del panel superior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Genera las columnas del Grid
        /// </summary>
        private void generaColumnas()
        {
            for (int i = 0; i < numCols; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                // No asignamos la anchura. Por defecto utiliza el * como ancho
                gridCentral.ColumnDefinitions.Add(col);
            }
        }
        /// <summary>
        /// Genera las filas del Grid
        /// </summary>
        private void generaFilas()
        {
            for (int i = 0; i < numFilas; i++)
            {
                RowDefinition fila = new RowDefinition();
                // Asignamos la altura de la fila a Auto
                fila.Height = GridLength.Auto;
                gridCentral.RowDefinitions.Add(fila);
            }
        }
        /// <summary>
        /// Método que añade las etiquetas y campos en el panel central mediante un bucle
        /// </summary>
        private void generaCampos()
        {
            // Se utiliza como indice de la lista de campos
            int numCampo = 0;
            // Comenzamos en la primera fila por el titulo
            int i = 1;
            // Bucle que recorre las filas
            while (i < numFilas - 1)
            {
                // Bucle que recorre las columnas
                for(int j = 0; j < numCols; j++)
                {
                    // Colocamos la etiqueta
                    colocaEtiqueta(j, i, numCampo);
                    // Colocamos el campo de texto
                    colocaCampo(j, i + 1);
                    // Incrementamos el indice para la siguiente etiqueta
                    numCampo++;
                }
                // Hacemos un salto de dos para añadir los componentes en la siguiente fila
                // Lo hacemos así  porque añadimos dos componentes de una vez
                // Debemos saltar una fila
                i = i + 2;
            }

            
        }
        /// <summary>
        /// Crea e inserta una etiqueta en el panel central
        /// </summary>
        /// <param name="col">Columna en la que se coloca</param>
        /// <param name="fila">Fila en la que se coloca</param>
        /// <param name="indice">Indice de la lista de campos</param>
        private void colocaEtiqueta(int col, int fila, int indice)
        {
            // Creamos el objeto
            TextBlock tb = new TextBlock();
            // Establecemos las propiedades
            tb.Margin = new Thickness(20,10,0,0);
            tb.Text = listaCampos[indice];
            // Colocamos el objeto
            Grid.SetColumn(tb,col);
            Grid.SetRow(tb,fila);
            gridCentral.Children.Add(tb);
        }
        /// <summary>
        /// Crea e inserta el campo de texto en el panel central
        /// </summary>
        /// <param name="col">Columna en la que se coloca</param>
        /// <param name="fila">Fila en la que se coloca</param>
        private void colocaCampo(int col, int fila)
        {
            TextBox txt = new TextBox();
            txt.Margin = new Thickness(20, 0, 20, 0);
            Grid.SetColumn(txt, col);
            Grid.SetRow(txt, fila);
            gridCentral.Children.Add(txt);
        }
        /// <summary>
        /// Crea los componentes del titulo del panel central
        /// </summary>
        private void generaTitulo()
        {
            // Creamos el campo de texto
            TextBlock tb = new TextBlock();
            // Establecemos las propiedades
            tb.FontSize = 24;
            tb.FontWeight = FontWeights.Bold;
            tb.Margin = new Thickness(10);
            tb.Text = "New Contact";
            // Añadimos el objeto
            gridCentral.Children.Add(tb);

            Separator sep = new Separator();
            sep.Margin = new Thickness(5, 0, 5, 0);
            sep.VerticalAlignment = VerticalAlignment.Bottom;
            Grid.SetColumnSpan(sep, 2);
            gridCentral.Children.Add(sep);
        }

        private void generaBoton()
        {
            Button btnCentral = new Button()
            {
                Content = new Image()
                {
                    Source = new BitmapImage(new Uri("Iconos/AddUser.png", UriKind.RelativeOrAbsolute)),
                    Height = 32,
                },
                Background = Brushes.Transparent,
                BorderBrush = Brushes.DarkBlue,
                Width = 40,
                Height = 40,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(10,10,20,0)
            };
            Grid.SetColumn(btnCentral, 1);
            Grid.SetRow(btnCentral, 7);
            gridCentral.Children.Add(btnCentral);

            btnCentral.Click += new RoutedEventHandler(handleBotonCentral);
        }
        /// <summary>
        /// Manejador de eventos del botón del panel central
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void handleBotonCentral(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contacto creado correctamente","GESTIÓN CONTACTOS",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
