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

namespace Tema2.Ejercicio2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Brush colorOriginal;
        private Label lblOculta;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Ejercicio 2";
            creaInterfaz();
        }

        private void creaInterfaz()
        {
            colorOriginal = Brushes.DarkGray;
            creaGrid();
            creaTitulo();
            creaEtiquetaVisible();
            creaCheckCambiar();
            creaCheckMostrar();
            creaImagen();
        }

        /*
         * Crea el layout de la aplicación
         */
        private void creaGrid()
        {
            // Cambiamos el fondo del panel
            gridPrincipal.Background = colorOriginal;

            // Definimos las columnas
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();

            // Definimos las filas
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();

            // Añadimos las columnas al grid
            gridPrincipal.ColumnDefinitions.Add(col1);
            gridPrincipal.ColumnDefinitions.Add(col2);
            gridPrincipal.ColumnDefinitions.Add(col3);

            // Añadimos las filas
            gridPrincipal.RowDefinitions.Add(row1);
            gridPrincipal.RowDefinitions.Add(row2);
            gridPrincipal.RowDefinitions.Add(row3);
            gridPrincipal.RowDefinitions.Add(row4);
        }

        /*
         * Define las propiedades de la opción de cambiar de color
         */
        private void creaCheckCambiar()
        {
            CheckBox chkCambiar = new CheckBox();
            chkCambiar.Content = "Poner Color";
            Grid.SetColumn(chkCambiar,0);
            Grid.SetRow(chkCambiar, 1);
            chkCambiar.Margin = new Thickness(30,0,0,0);
            chkCambiar.Foreground = Brushes.White;
            chkCambiar.Checked += new RoutedEventHandler(chkCambiar_Check);
            chkCambiar.Unchecked += new RoutedEventHandler(chkCambiar_UnCheck);
            gridPrincipal.Children.Add(chkCambiar);
        }

        /*
         * Define las propiedades de la opción de mostrar etiqueta
         */
        private void creaCheckMostrar()
        {
            CheckBox chkMostrar = new CheckBox();
            chkMostrar.Content = "Mostrar cadena";
            Grid.SetColumn(chkMostrar, 0);
            Grid.SetRow(chkMostrar, 2);
            chkMostrar.Margin = new Thickness(30, 0, 0, 0);
            chkMostrar.Foreground = Brushes.White;
            chkMostrar.Checked += new RoutedEventHandler(chkMostrar_Check);
            chkMostrar.Unchecked += new RoutedEventHandler(chkMostrar_UnCheck);
            gridPrincipal.Children.Add(chkMostrar);
        }

        /*
* Define la etiqueta del título
*/
        private void creaTitulo()
        {
            Label lbl = new Label();
            Grid.SetColumn(lbl, 0);
            Grid.SetRow(lbl, 0);
            lbl.Content = "Ejercicio 2";
            lbl.FontSize = 20;
            lbl.Foreground = Brushes.White;
            lbl.Margin = new Thickness(10,0,0,0);
            gridPrincipal.Children.Add(lbl);
        }
        /*
         * Define la imagen a visualizar
         */
        private void creaImagen()
        {
            Image img = new Image();
            Grid.SetColumn(img,2);
            Grid.SetRow(img, 1);
            Grid.SetRowSpan(img,2);
            img.Height = 128;
            img.Source = new BitmapImage(new Uri("WPF.jpg", UriKind.RelativeOrAbsolute));
            img.VerticalAlignment = VerticalAlignment.Top;
            gridPrincipal.Children.Add(img);
        }
        /*
         * Define la etiqueta que cambia de estado a visible
         */
        private void creaEtiquetaVisible()
        {
            lblOculta = new Label();
            lblOculta.Content = "Hola esto es una prueba";
            lblOculta.Foreground = Brushes.White;
            Grid.SetColumn(lblOculta,0);
            Grid.SetRow(lblOculta, 3);
            lblOculta.Margin = new Thickness(30,0,0,0);
            lblOculta.Visibility = Visibility.Hidden;
            gridPrincipal.Children.Add(lblOculta);
        }

        /**************************************************************************************************
         * Eventos
         **************************************************************************************************/

        private void chkCambiar_Check(object sender, EventArgs e)
        {
            gridPrincipal.Background = Brushes.Coral;
        }

        private void chkCambiar_UnCheck(object sender, RoutedEventArgs e)
        {
            gridPrincipal.Background = colorOriginal;
        }

        private void chkMostrar_Check(object sender, EventArgs e)
        {
            lblOculta.Visibility = Visibility.Visible;
        }

        private void chkMostrar_UnCheck(object sender, RoutedEventArgs e)
        {
            lblOculta.Visibility = Visibility.Hidden;
        }

    }
}
