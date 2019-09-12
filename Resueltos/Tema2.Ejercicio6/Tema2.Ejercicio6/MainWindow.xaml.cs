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

namespace Tema2.Ejercicio6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Declaración de variables ---------------------------------------------------------------------------------------------
        // Declaramos una lista con las etiquetas de la parte izquierda
        private List<string> listaEtiquetas = new List<string> {"Sales","Marketing","Distribution","Costs"};
        // Declaramos una lista con los contenidos de los botones de la parte derecha
        private List<string> listaBotones = new List<string> {"BarChart","ComboChart","LineChart","PieChart","Location","Relative"};
        // Número de filas de la parte derecha
        private int numCols;
        // Número de filas de la parte derecha
        private int numRows;

        /*
         * Constructor del programa principal
         */
        public MainWindow()
        {
            InitializeComponent();
            // Añadimos el panel principal a la ventana
            Application.Current.MainWindow.Content = principal();
            Application.Current.MainWindow.Width = 640;
            Application.Current.MainWindow.Height = 480;
            Application.Current.MainWindow.Title = "Ejercicio 6";
        }

        /*
         * Construimos el panel principal
         * Generamos un nuevo Dock Panel y le añadimos las distintas partes de la aplicación
         */
        private DockPanel principal()
        {
            // Situamos los paneles en el dock principal
            // Cada zona de la ventana tiene su propio método
            DockPanel dckPanel = new DockPanel();
            dckPanel.LastChildFill = true;
            // Añadimos los paneles al dockpanel principal
            dckPanel.Children.Add(parteTop());
            dckPanel.Children.Add(parteIzquierda());
            dckPanel.Children.Add(parteDerechaGrid());
            dckPanel.Children.Add(parteCentral());

            return dckPanel;
        }

        /*
         * En este método generamos la parte de arriba de la interfaz
         */
        private Grid parteTop()
        {
            // Generamos la parte arriba
            Grid gridTop = new Grid();
            gridTop.Background = Brushes.Blue;

            // Asignamos la cantidad de filas y columnas que vamos a 
            numCols = 4;
            numRows = 1;

            /* Definimos las filas
             * Utilizamos un método al que le pasamos:
             *      El número de filas
             *      El nombre que daremos a las filas
             *      El panel donde añadiremos las filas
             */
            generaFilas(numRows, "rowTop", gridTop);

            /* Definimos las columnas
             * Utilizamos un método. Utiliza los siguientes parámetros
             *      El número de columnas
             *      El nombre que daremos a las columnas
             *      El panel donde añadiremos las columnas
             */
            generaColumnas(numCols, "colTop", gridTop);

            // Obtenemos la columna número tres para asignarle una anchura que ocupe todo loq ue pueda
            gridTop.ColumnDefinitions.ElementAt<ColumnDefinition>(2).Width = new GridLength(1, GridUnitType.Star);


            // Definimos los botones
            Button btnCurrent = new Button();
            Button btnProjected = new Button();
            // En este ejemplo definimos el botón y configuramos las propiedades que nos interesa, 
            // como por ejemplo, la imagen que se verá
            Button btnInterrogante = new Button()
            {
                Width = 32,
                Height = 32,
                Content = new Image
                {
                    Source = new BitmapImage(new Uri("icons/Interrogante.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center
                }
            };

            // Configuramos los botones
            btnCurrent.Content = "Current";
            btnCurrent.Margin = new Thickness(15);
            btnCurrent.Width = 100;
            btnProjected.Content = "Projected";
            btnProjected.Margin = new Thickness(15);
            btnProjected.Width = 100;
            btnInterrogante.Margin = new Thickness(15);
            


            // Añadimos los botones al Grid
            // Primero los situamos en las celdas correspondientes
            Grid.SetRow(btnCurrent, 0);
            Grid.SetColumn(btnCurrent, 0);
            Grid.SetRow(btnProjected, 0);
            Grid.SetColumn(btnProjected, 1);
            Grid.SetRow(btnInterrogante, 0);
            Grid.SetColumn(btnInterrogante, 3);
            // Ahora los añadimos al panel
            gridTop.Children.Add(btnCurrent);
            gridTop.Children.Add(btnProjected);
            gridTop.Children.Add(btnInterrogante);

            // Situamos el panel en la parte de arriba
            gridTop.SetValue(DockPanel.DockProperty,Dock.Top);
            
            return gridTop;
        }

        /*
         * Generamos el panel izquierdo
         * Utilizamos un bucle para añadir las etiquetas
         */
        private StackPanel parteIzquierda()
        {
            StackPanel stackIzquierda = new StackPanel();
            // Definimos la etiqueta del título
            Label lblData = new Label()
            {
                Content = "Data",
                FontSize = 18,
                FontWeight = FontWeights.Bold
            };
            // Añadimos la etiqueta al panel
            stackIzquierda.Children.Add(lblData);

            /*
             * Mediante un bucle creamos, configuramos y añadimos los botones
             */
            foreach (var etq in listaEtiquetas)
            {
                Label lbl = new Label();
                lbl.Name = "lbl" + etq;
                lbl.Content = etq;
                lbl.Margin = new Thickness(15,5,5,5);
                // Añadimos el botón al evento
                stackIzquierda.Children.Add(lbl);
            }

            // Situamos el panel en la parte de la izquierda
            stackIzquierda.SetValue(DockPanel.DockProperty, Dock.Left);
            return stackIzquierda;
        }

        /*
         * En este caso añadimos un wrap panel a la derecha
         * Utilizamos un bucle para generarlos y configurarlos
         */
        private WrapPanel parteDerecha()
        {
            WrapPanel wrapDerecha = new WrapPanel();
            // Utilizamos una anchura predefinida para conseguir visualizar los botones en dos columnas
            wrapDerecha.Width = 130;

            foreach (var btn in listaBotones)
            {
                Button boton = new Button()
                {
                    Width = 32,
                    Height = 32,
                    Content = new Image
                {
                    Source = new BitmapImage(new Uri("icons/" + btn + ".png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
                boton.Name = "btn" + btn;
                boton.Margin = new Thickness(15);
                boton.Background = Brushes.White;
                wrapDerecha.Children.Add(boton);
            }

            // Situamos el panel en la parte de arriba
            wrapDerecha.SetValue(DockPanel.DockProperty, Dock.Right);

            return wrapDerecha;
        }

        /*
         * Ahora vamos a configurar la parte derecha mediante un Grid
         * También lo haremos mediante un bucle
         */
        private Grid parteDerechaGrid()
        {
            // Definimos las variables que utilizamos
            Grid gridDerecha = new Grid();

            // En esta variable guardaremos el número de botones
            int numBotones;

            // Asignamos la cantidad de filas y columnas que vamos a 
            numCols = 2;
            numRows = 3;

            /* Definimos las filas
             * Utilizamos un método al que le pasamos:
             *      El número de filas
             *      El nombre que daremos a las filas
             *      El panel donde añadiremos las filas
             */
            generaFilas(numRows, "rowDerecha",gridDerecha);

            /* Definimos las columnas
             * Utilizamos un método. Utiliza los siguientes parámetros
             *      El número de columnas
             *      El nombre que daremos a las columnas
             *      El panel donde añadiremos las columnas
             */
            generaColumnas(numCols, "colDerecha", gridDerecha);

            //Obtenemos el número de botones
            numBotones = listaBotones.Count;
            // En el bucle generamos y configuramos los botones
            for (int i = 0; i < numBotones; i++)
            {
                Button btn = new Button();
                btn.Name = "btn" + listaBotones.ElementAt(i);
                btn.Margin = new Thickness(10);
                btn.Background = Brushes.Transparent;
                btn.Content = new Image()
                {
                    Width = 32,
                    Height = 32,
                    Source = new BitmapImage(new Uri("icons/" + listaBotones.ElementAt(i) + ".png", UriKind.Relative))
                };
                // Situamos el botón en la celda correspondiente
                // Para averiguarla utilizamos el resto de la división
                Grid.SetRow(btn, i % numRows);
                Grid.SetColumn(btn, i % numCols);

                // Añadimos el botón al panel
                gridDerecha.Children.Add(btn);
            }

            gridDerecha.SetValue(DockPanel.DockProperty, Dock.Right);

            return gridDerecha;
        }

        /*
         * Generamos la parte central
         * Lo hacemos con un Grid
         */
        private Grid parteCentral()
        {
            // Declaramos las variables
            Grid gridCentro = new Grid();

            // Asignamos los valores correspondientes al número de filas y columnas
            numRows = 6;
            numCols = 4;
            

            // Definimos las filas
            generaFilas(numRows, "gridCentro",gridCentro);


            // Definimos las columnas
            generaColumnas(numCols, "gridCentro",gridCentro);

            // Generamos el contenido del panel central
            Image imgCasa = new Image
            {
                Source = new BitmapImage(new Uri("icons/Casa.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetRow(imgCasa,0);
            Grid.SetColumn(imgCasa,0);
            Grid.SetRowSpan(imgCasa, 2);
            gridCentro.Children.Add(imgCasa);

            Label lblTitulo = new Label()
            {
                Content = "Sales: Current Year",
                FontSize = 20,
                FontWeight = FontWeights.Bold
            };
            Grid.SetRow(lblTitulo, 0);
            Grid.SetColumn(lblTitulo, 1);
            Grid.SetColumnSpan(lblTitulo, 2);
            gridCentro.Children.Add(lblTitulo);

            Label lblGS = new Label()
            {
                Content = "Goods and Services"
            };
            Grid.SetRow(lblGS, 1);
            Grid.SetColumn(lblGS, 1);
            gridCentro.Children.Add(lblGS);

            Label lblServices = new Label()
            {
                Content = "Services 20%"
            };
            Grid.SetRow(lblServices, 2);
            Grid.SetColumn(lblServices, 3);
            gridCentro.Children.Add(lblServices);

            Label lblGoods = new Label()
            {
                Content = "Goods 80%"
            };
            Grid.SetRow(lblGoods, 4);
            Grid.SetColumn(lblGoods, 1);
            gridCentro.Children.Add(lblGoods);

            Image imgCentral = new Image
            {
                Source = new BitmapImage(new Uri("icons/Principal.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetRow(imgCentral, 2);
            Grid.SetColumn(imgCentral, 1);
            Grid.SetRowSpan(imgCentral, 2);
            Grid.SetColumnSpan(imgCentral, 2);
            gridCentro.Children.Add(imgCentral);

            Button btnSave = new Button();
            btnSave.Content = "Save";
            btnSave.Width = 70;
            Grid.SetRow(btnSave, 5);
            Grid.SetColumn(btnSave, 2);
            gridCentro.Children.Add(btnSave);

            Button btnCancel = new Button();
            btnCancel.Content = "Cancel";
            btnCancel.Width = 70;
            btnCancel.Margin = new Thickness(5,0,0,0);
            Grid.SetRow(btnCancel, 5);
            Grid.SetColumn(btnCancel, 3);
            gridCentro.Children.Add(btnCancel);

            return gridCentro;
        }

        /*
         * Método que genera y añade las filas a un panel tipo Grid
         * Lo realiza con un bucle. Se pasan los parámetros siguientes
         *      El número de filas
         *      El nombre que se va a poner a las filas
         *      El panel al cual se añaden las filas
         */
        private void generaFilas(int numFilas, string nomFilas, Grid grid)
        {
            for (int i = 0; i < numFilas; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                grid.RowDefinitions.Add(row);
                row.Name = nomFilas + i;
            }
        }

       /*
        * Método que genera y añade las columnas a un panel tipo Grid
        * Lo realiza con un bucle. Se pasan los parámetros siguientes
        *      El número de columnas
        *      El nombre que se va a poner a las columnas
        *      El panel al cual se añaden las columnas
        */
        private void generaColumnas(int numCols, string nombreCols, Grid grid)
        {
            for (int i = 0; i < numCols; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(col);
                col.Name = nombreCols + i;
            }
        }
    }

}
