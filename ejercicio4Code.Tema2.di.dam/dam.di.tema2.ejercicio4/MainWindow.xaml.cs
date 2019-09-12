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

namespace dam.di.tema2.ejercicio4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();
            creaDock();
            this.Content = dock;
        }

        // Definición de variables
        private DockPanel dock;
        private Grid gridTop;
        private Grid gridCentral;

        //Metodo para crear el DockPanel
        private void creaDock()
        {
            dock = new DockPanel();
            parteTop();
            DockPanel.SetDock(gridTop, Dock.Top);
            dock.Children.Add(gridTop);

            parteCentral();
          //  DockPanel.SetDock(gridCentral);
            dock.Children.Add(gridCentral);
        }

        //Formamos la parte top de la ventana
        private void parteTop()
        {
            //Crear los elementos
            gridTop = new Grid();
            TextBlock tbtop = new TextBlock();
            tbtop.VerticalAlignment = VerticalAlignment.Center;
            Image imgTop = new Image();

            gridTop.Background = Brushes.Green;

            //Configurar las propiedades de textblock
            tbtop.Text = "Ejercicio 4";
            tbtop.Foreground = Brushes.White;
            tbtop.FontSize = 16;
            tbtop.FontWeight = FontWeights.Bold;
            tbtop.Margin = new Thickness(10);

            //Propiedades de la imagen
            imgTop.Source = new BitmapImage(new Uri("iconsewer.png", UriKind.Relative));
            imgTop.Height = 32;
            imgTop.HorizontalAlignment = HorizontalAlignment.Right;
            imgTop.Margin = new Thickness(20);

            //Asocio los elementos al panel que los contiene
            gridTop.Children.Add(tbtop);
            gridTop.Children.Add(imgTop);
        }
        //para añadir un elemento, lo defino, propiedades y Asocio 

        //Formamos la parte central de la ventana
        private void parteCentral()

        {   //Definicion
            gridCentral = new Grid();
            TextBlock tbNombre = new TextBlock();
            TextBlock tbApellidos = new TextBlock();
            TextBlock tbNotas = new TextBlock();
            TextBlock tbPass = new TextBlock();

            TextBox textNombre = new TextBox();
            TextBox textApellidos = new TextBox();
            TextBox textNotas = new TextBox();
            PasswordBox textPass = new PasswordBox();

            Button btnNombre = new Button();
            Button btnApellidos = new Button();
            Button btnNotas = new Button();
            Button btnPass = new Button();

            //Columnas y Filas
            gridCentral.ColumnDefinitions.Add(new ColumnDefinition());
            gridCentral.ColumnDefinitions.Add(new ColumnDefinition());
            gridCentral.ColumnDefinitions.Add(new ColumnDefinition());

            gridCentral.RowDefinitions.Add(new RowDefinition());
            gridCentral.RowDefinitions.Add(new RowDefinition());
            gridCentral.RowDefinitions.Add(new RowDefinition());
            gridCentral.RowDefinitions.Add(new RowDefinition());

            //Propiedades
            //Propiedades Fila 1
            tbNombre.Text = "Nombre";
            tbNombre.Foreground = Brushes.Green;
            tbNombre.Margin = new Thickness(10);
            tbNombre.HorizontalAlignment = HorizontalAlignment.Center;
            tbNombre.VerticalAlignment = VerticalAlignment.Center;

            textNombre.Text = "Nombre";
            textNombre.Height = 20;
            textNombre.Margin = new Thickness(10);
            Grid.SetColumn(textNombre, 1);

            btnNombre.Content = "Solo Lectura";
            btnNombre.Height = 20;
            btnNombre.Margin = new Thickness(10);
            btnNombre.Background = Brushes.Transparent;
            btnNombre.Foreground = Brushes.Green;
            btnNombre.BorderBrush = Brushes.Green;
            Grid.SetColumn(btnNombre, 2);
            //Añado el evento al boton
            btnNombre.Click += new RoutedEventHandler(handleSoloLectura);

            //Propiedades Fila 2
            tbApellidos.Text = "Apellidos";
            tbApellidos.Foreground = Brushes.Green;
            tbApellidos.Margin = new Thickness(10);
            tbApellidos.HorizontalAlignment = HorizontalAlignment.Center;
            tbApellidos.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(tbApellidos, 1);

            textApellidos.Text = "Apellidos";
            textApellidos.Height = 20;
            textApellidos.Margin = new Thickness(10);
            Grid.SetColumn(textApellidos, 1);
            Grid.SetRow(textApellidos, 1);

            btnApellidos.Content = "Activar / Desactivar";
            btnApellidos.Height = 20;
            btnApellidos.Margin = new Thickness(10);
            btnApellidos.Background = Brushes.Transparent;
            btnApellidos.Foreground = Brushes.Green;
            btnApellidos.BorderBrush = Brushes.Green;
            Grid.SetColumn(btnApellidos, 2);
            Grid.SetRow(btnApellidos, 1);
            //Añado el evento al boton
            btnApellidos.Click += new RoutedEventHandler(handleActivaDesactiva);

            //Propiedades Fila 3
            tbNotas.Text = "Notas";
            tbNotas.Foreground = Brushes.Green;
            tbNotas.Margin = new Thickness(10);
            tbNotas.HorizontalAlignment = HorizontalAlignment.Center;
            tbNotas.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(tbNotas, 2);

            textNotas.Text = "Notas...";
            textNotas.Height = 40;
            textNotas.Margin = new Thickness(10);
            Grid.SetColumn(textNotas, 1);
            Grid.SetRow(textNotas, 2);

            btnNotas.Content = "Foco Nombre";
            btnNotas.Height = 20;
            btnNotas.Margin = new Thickness(10);
            btnNotas.Background = Brushes.Transparent;
            btnNotas.Foreground = Brushes.Green;
            btnNotas.BorderBrush = Brushes.Green;
            Grid.SetColumn(btnNotas, 2);
            Grid.SetRow(btnNotas, 2);
            //Añado el evento al boton
            btnNotas.Click += new RoutedEventHandler(handleFoco);

            //Propiedades Fila 4
            tbPass.Text = "Contraseña";
            tbPass.Foreground = Brushes.Green;
            tbPass.Margin = new Thickness(10);
            tbPass.HorizontalAlignment = HorizontalAlignment.Center;
            tbPass.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(tbPass, 3);

            textPass.Height = 20;
            textPass.Margin = new Thickness(10);
            Grid.SetColumn(textPass, 1);
            Grid.SetRow(textPass, 3);

            btnPass.Content = "Muestra contraseña";
            btnPass.Height = 20;
            btnPass.Margin = new Thickness(10);
            btnPass.Background = Brushes.Transparent;
            btnPass.Foreground = Brushes.Green;
            btnPass.BorderBrush = Brushes.Green;
            Grid.SetColumn(btnPass, 2);
            Grid.SetRow(btnPass, 3);
            //Añado el evento al boton
            btnPass.Click += new RoutedEventHandler(handleMuestraContrasenya);

            //Añadimos Componentes
            gridCentral.Children.Add(tbNombre);
            gridCentral.Children.Add(tbApellidos);
            gridCentral.Children.Add(tbNotas);
            gridCentral.Children.Add(tbPass);
            gridCentral.Children.Add(textNombre);
            gridCentral.Children.Add(textApellidos);
            gridCentral.Children.Add(textNotas);
            gridCentral.Children.Add(textPass);
            gridCentral.Children.Add(btnNombre);
            gridCentral.Children.Add(btnApellidos);
            gridCentral.Children.Add(btnNotas);
            gridCentral.Children.Add(btnPass);

            //DEFINIMOS LOS EVENTOS
            //Nombre solo lectura
            void handleSoloLectura(object sender, RoutedEventArgs args)
            {
                TextBox texto = textNombre as TextBox;
                if (texto.IsReadOnly) texto.IsReadOnly = false;
                else texto.IsReadOnly = true;
            }
            //Activar desactivar apellidos
            void handleActivaDesactiva(object sender, RoutedEventArgs args)
            {
                TextBox texto = textApellidos as TextBox;
                if (texto.IsEnabled) texto.IsEnabled = false;
                else texto.IsEnabled = true;
            }
            //Foco en nombre
            void handleFoco(object sender, RoutedEventArgs args)
            {
                TextBox texto = textNombre as TextBox;
                texto.Focus();
            }
            //Ver password
            void handleMuestraContrasenya(object sender, RoutedEventArgs args)
            {
                TextBox texto = textNotas as TextBox;
                texto.Text = ((PasswordBox)textPass).Password;
            }
        }
    }
}
