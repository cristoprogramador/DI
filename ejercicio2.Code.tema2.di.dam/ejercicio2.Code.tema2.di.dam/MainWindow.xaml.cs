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

namespace ejercicio2.Code.tema2.di.dam
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            makeDock();

            this.Content = dockPanel;
        }

        DockPanel dockPanel;
        Grid gridPanel;

        void makeDock()
        {
            dockPanel = new DockPanel();

            makeGrid();

            TextBlock tbEjercicio = new TextBlock();
            tbEjercicio.Text = "Ejercicio 1";
            tbEjercicio.Foreground = Brushes.DarkRed;
            tbEjercicio.FontSize = 30;
            tbEjercicio.Padding = new Thickness(20);          
            tbEjercicio.Background = Brushes.LightGray;
            
            DockPanel.SetDock(tbEjercicio, Dock.Top);
            DockPanel.SetDock(gridPanel, Dock.Bottom);

            dockPanel.Children.Add(tbEjercicio);
            dockPanel.Children.Add(gridPanel);

        }

        void makeGrid()
        {
            gridPanel = new Grid();
            CheckBox cbPoner = new CheckBox();
            CheckBox cbMostrar = new CheckBox();
            TextBlock cadenaOculta = new TextBlock();
            Image imgWin = new Image();

            gridPanel.Background = Brushes.Gray;
            gridPanel.ColumnDefinitions.Add(new ColumnDefinition());
            gridPanel.ColumnDefinitions.Add(new ColumnDefinition());
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition());
            

            cbPoner.Content = "Poner Color";
            cbPoner.Foreground = Brushes.White;
            cbPoner.FontWeight = FontWeights.Bold;
            cbPoner.FontSize = 20;
            cbPoner.Margin = new Thickness(20);
            cbPoner.Checked += new RoutedEventHandler(checkPonerColor_Checked);
            cbPoner.Unchecked += new RoutedEventHandler(checkPonerColor_Unchecked);

            void checkPonerColor_Checked(object sender, RoutedEventArgs e)
            {
                gridPanel.Background = Brushes.BurlyWood;
            }

            void checkPonerColor_Unchecked(object sender, RoutedEventArgs e)
            {
                gridPanel.Background = Brushes.Gray;
            }

            cbMostrar.Content = "Mostrar Cadena";
            cbMostrar.Foreground = Brushes.White;
            cbMostrar.FontWeight = FontWeights.Bold;
            cbMostrar.FontSize = 20;
            cbMostrar.Margin = new Thickness(20);
            Grid.SetRow(cbMostrar, 1);
            cbMostrar.Checked += new RoutedEventHandler(checkMostrarCadena_Checked);
            cbMostrar.Unchecked += new RoutedEventHandler(checkMostrarCadena_Unchecked);

            void checkMostrarCadena_Checked(object sender, RoutedEventArgs e)
            {
                cadenaOculta.Visibility = Visibility.Visible;
            }

            void checkMostrarCadena_Unchecked(object sender, RoutedEventArgs e)
            {
                cadenaOculta.Visibility = Visibility.Hidden;
            }

            cadenaOculta.Text = "Mostrando la cadena oculta...";
            cadenaOculta.FontSize = 27;
            cadenaOculta.FontStyle = FontStyles.Italic;
            cadenaOculta.Foreground = Brushes.White;
            cadenaOculta.Visibility = Visibility.Hidden;
            cadenaOculta.Margin = new Thickness(20);
            Grid.SetRow(cadenaOculta, 2);

            imgWin.Source = new BitmapImage(new Uri("/linuxkillwindows.jpg", UriKind.Relative));
            imgWin.Width = 300;
            imgWin.Margin = new Thickness(20);
            imgWin.HorizontalAlignment = HorizontalAlignment.Left;
            imgWin.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetColumn(imgWin, 1);
            Grid.SetRow(imgWin, 0);
            Grid.SetRowSpan(imgWin, 3);

            gridPanel.Children.Add(cbMostrar);
            gridPanel.Children.Add(cbPoner);
            gridPanel.Children.Add(cadenaOculta);
            gridPanel.Children.Add(imgWin);

        }

    }
}
