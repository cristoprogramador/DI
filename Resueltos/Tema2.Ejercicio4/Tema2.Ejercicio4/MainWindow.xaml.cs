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

namespace Tema2.Ejercicio4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declaración de constantes -----------------------------------------------------------------------------------------
        private const int NOMBRE = 0;
        private const int APELLIDOS = 1;
        private const int NOTAS = 2;
        private const int PASS = 3;
        private const int NUMCOLS = 3;
        private const int NUMFILAS = 4;
        private const int FILAETIQUETAS = 0;
        private const int FILACAMPOS = 1;
        private const int FILABOTONES = 2;
        // Declaración de variables -------------------------------------------------------------------------------------------
        // Lista que contiene las etiquetas
        private List<string> listaEtiquetas = new List<string> { "Nombre", "Apellidos", "Notas", "Password" };
        // Lista que contiene los títulos de los botones
        private List<string> listaBotones = new List<string> { "Solo Lectura", "Activar / Desactivar", "Foco Nombre", "Mostrar Contraseña" };
        // Generamos una lista donde guardamos los campos de texto para luego acceder a ellos desde los manejadores de eventos de los botones
        private List<Control> listaCampos = new List<Control>();
        // Panel Principal de la ventana
        private DockPanel dockPrincipal;
        // Panel central de la ventana
        private Grid gridCentral;
        // Panel que contiene la parte de arriba
        private Grid gridTop;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MainWindow()
        {
            // Propiedades de la ventana
            this.Title = "Ejercicio 4";
            this.Width = 500;
            this.Height = 400;
            panelPrincipal();
            // Asigna el panel principal a la ventana
            this.Content = dockPrincipal;
        }
        /// <summary>
        /// Genera los objetos principales de ela interfaz
        /// </summary>
        private void panelPrincipal()
        {
            // Generamos los paneles de la aplicación
            dockPrincipal = new DockPanel();
            gridCentral = new Grid();
            gridTop = new Grid();
            listaCampos = new List<Control>();

            // Llamamos a los métodos que generan las partes de la aplicación
            panelTop();
            panelCentral();

            // Añadimos los paneles al principal
            dockPrincipal.Children.Add(gridTop);
            dockPrincipal.Children.Add(gridCentral);
            // Colocamos los paneles en su lugar dentro de la ventana
            DockPanel.SetDock(gridTop, Dock.Top);
        }    
        /// <summary>
        /// Coloca los elementos del panel superior
        /// </summary>
        private void panelTop()
        {
            gridTop.Background = Brushes.Green;
            // Creamos los controles necesarios
            TextBlock tbTitulo = new TextBlock();
            Image imgTitulo = new Image();

            // Configuramos las propiedades del titulo
            tbTitulo.Text = "Ejercicio 4";
            tbTitulo.Margin = new Thickness(20);
            tbTitulo.FontWeight = FontWeights.Bold;
            tbTitulo.FontSize = 20;
            tbTitulo.Foreground = Brushes.White;
            // Configuramos las propiedades de la imagen
            imgTitulo.HorizontalAlignment = HorizontalAlignment.Right;
            imgTitulo.Source = new BitmapImage(new Uri("iconos/ejercicio3.png", UriKind.RelativeOrAbsolute));
            imgTitulo.Height = 32;
            imgTitulo.Margin = new Thickness(0,0,10,0);

            // Añadimos los componentes al panel
            gridTop.Children.Add(tbTitulo);
            gridTop.Children.Add(imgTitulo);
        }
        /// <summary>
        /// Coloca los elementos del panel central
        /// </summary>
        private void panelCentral()
        {
            // Generamos las filas del grid
            generaFilas(NUMFILAS,gridCentral);
            // Generamos las columnas del grid
            generaColumnas(NUMCOLS, gridCentral);

            // Generamos y añadimos el resto de componentes mediante un buble anidado
            for (int i = 0; i < NUMCOLS; i++)
            {
                for (int j = 0; j < NUMFILAS; j++)
                {
                    switch (i) {
                        case FILAETIQUETAS:
                            insertaEtiqueta(j,i);
                            break;
                        case FILACAMPOS:
                            insertaCampo(j, i);
                            break;
                        case FILABOTONES:
                            insertaBoton(j, i);
                            break;
                    }
                }
            }

        }
        /// <summary>
        /// Inserta una etiqueta en la fila y columna que se indica
        /// </summary>
        /// <param name="fila">fila de la etiqueta</param>
        /// <param name="col">columna de la etiqueta</param>
        private void insertaEtiqueta(int fila, int col)
        {
            // Añadimos la etiqueta
            TextBlock tb = new TextBlock();
            tb.Text = listaEtiquetas[fila];
            tb.Margin = new Thickness(20);
            tb.Foreground = Brushes.Green;
            tb.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(tb, col);
            Grid.SetRow(tb, fila);
            gridCentral.Children.Add(tb);
        }
        /// <summary>
        /// Inserta un botón en el panel
        /// </summary>
        /// <param name="fila">fila en la que se inserta</param>
        /// <param name="col">columna en la que se inserta</param>
        private void insertaBoton(int fila, int col)
        {
            Button btn = new Button();
            btn.Content = listaBotones[fila];
            btn.Margin = new Thickness(20);
            btn.Width = 150;
            btn.Height = 25;
            btn.Background = Brushes.Transparent;
            btn.Foreground = Brushes.Green;
            btn.BorderBrush = Brushes.Green;
            // Le ponemos el nombre
            btn.Name = listaEtiquetas[fila];
            // Añadimos un manejadorde eventos al botón
            btn.Click += new RoutedEventHandler(handleBotones);
            Grid.SetColumn(btn, col);
            Grid.SetRow(btn, fila);
            gridCentral.Children.Add(btn);
        }
        /// <summary>
        /// Añadimos los campos de texto
        /// </summary>
        /// <param name="fila">fila donde se insertan</param>
        /// <param name="col">columna donde se insertan</param>
        private void insertaCampo(int fila, int col)
        {
            Control txt;
            if (fila != PASS)
            {
                txt = new TextBox();
                ((TextBox)txt).Text = listaEtiquetas[fila];
                if (fila == NOTAS)
                {
                    txt.Height = 40;
                }
            }
            else
            {
                txt = new PasswordBox();
            }
            // Añadimos los campos de texto a la lista que hemos creado
            // para poder acceder a ellos
            listaCampos.Add(txt);
            txt.Margin = new Thickness(20);
            txt.Width = 150;
            Grid.SetColumn(txt, col);
            Grid.SetRow(txt, fila);
            gridCentral.Children.Add(txt);
        }
        /// <summary>
        /// Genera las filas de un grid
        /// </summary>
        /// <param name="filas">Número de filas que se generan</param>
        /// <param name="grid">Panel al que se le asignan las filas</param>
        private void generaFilas(int filas, Grid grid)
        {
            for (int i = 0; i < filas; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                grid.RowDefinitions.Add(row);
            }
        }
        /// <summary>
        /// Genera las columnas de un Grid
        /// </summary>
        /// <param name="cols">Número de columnas</param>
        /// <param name="grid">Panel al que se le asignan las columnas</param>
        private void generaColumnas(int cols, Grid grid)
        {
            for (int i = 0; i < cols; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(col);
            }
        }

        private void handleBotones(object sender, RoutedEventArgs args)
        {
            // Obtenemos el nombre del botón
            string nombre = ((Control)sender).Name;
            // En función del botón realizaremos una acción u otra
            switch (nombre)
            {
                case "Nombre":
                    soloLectura();
                    break;
                case "Apellidos":
                    activaDesactiva();
                    break;
                case "Notas":
                    foco();
                    break;
                case "Password":
                    muestraPass();
                    break;
            }
        }

        private void soloLectura()
        {
            TextBox texto = listaCampos[0] as TextBox;
            if (texto.IsReadOnly) texto.IsReadOnly = false;
            else texto.IsReadOnly = true;
        }

        private void activaDesactiva()
        {
            TextBox texto = listaCampos[1] as TextBox;
            if (texto.IsEnabled) texto.IsEnabled = false;
            else texto.IsEnabled = true;
        }

        private void foco()
        {
            TextBox texto = listaCampos[0] as TextBox;
            texto.Focus();
        }

        private void muestraPass()
        {
            TextBox texto = listaCampos[2] as TextBox;
            texto.Text = ((PasswordBox)listaCampos[3]).Password;
        }
    }
}
