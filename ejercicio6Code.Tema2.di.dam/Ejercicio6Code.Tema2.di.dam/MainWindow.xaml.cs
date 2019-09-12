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

namespace Ejercicio6Code.Tema2.di.dam
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //VENTANA PRINCIPAL
        public MainWindow()
        {
            InitializeComponent();
            
            //llamamos al metodo que construirá el layout principal
            makeDock();

            //asignamos al contenido de la ventana principal el layout principal
            this.Content = dock;
        }

        //DECLARAMOS LAS VARIABLES DE LOS PANELES NECESARIOS
        private DockPanel dock;
        private Grid gridTop;
        private Grid gridCentral;
        private StackPanel stackLeft;
        private WrapPanel wrapRight;

        //DOCK PRINCIPAL
        private void makeDock()
        {
            //DECLARAMOS EL DOCK
            dock = new DockPanel();

            //LLAMAMOS A LOS METODOS PARA CONSTRUIR LOS 
            //DIFERENTES LAYOUTS DE CADA PARTE DEL DOCK
            topPart();
            leftPart();
            rightPart();
            centerPart();

            //ASIGNAMOS CADA LAYOUT A LA PARTE DEL DOC QUE CORRESPONDE
            DockPanel.SetDock(gridTop, Dock.Top);
            DockPanel.SetDock(stackLeft, Dock.Left);
            DockPanel.SetDock(wrapRight, Dock.Right);
            DockPanel.SetDock(gridCentral, Dock.Bottom);

            //AÑADIMOS LOS LAYOUTS AL DOCKPANEL
            dock.Children.Add(gridTop);
            dock.Children.Add(stackLeft);
            dock.Children.Add(wrapRight);
            dock.Children.Add(gridCentral);
        }

        //PANEL SUPERIOR DEL DOCK
        private void topPart()
        {
            //DECLARAMOS ELEMENTOS
            gridTop = new Grid();
            Button btCurrent = new Button();
            Button btProjected = new Button();
            Button btQuestion = new Button();

            //DEFINIMOS COLUMNAS
            gridTop.Background = Brushes.Blue;
            gridTop.ColumnDefinitions.Add(new ColumnDefinition());
            gridTop.ColumnDefinitions.Add(new ColumnDefinition());
            gridTop.ColumnDefinitions.Add(new ColumnDefinition());
            gridTop.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto});
            gridTop.ColumnDefinitions[0].Width = GridLength.Auto;
            gridTop.ColumnDefinitions[1].Width = GridLength.Auto;
            gridTop.ColumnDefinitions[2].Width = new GridLength(1, GridUnitType.Star);

            //DEFINIMOS ELEMENTOS Y SU POSICIÓN
            //Boton current
            btCurrent.Content = "Current";
            btCurrent.Width = 80;
            btCurrent.Height = 40;
            btCurrent.Margin = new Thickness(15);
            btCurrent.HorizontalAlignment = HorizontalAlignment.Left;  
            Grid.SetColumn(btCurrent, 0);           
            //Boton Projected
            btProjected.Content = "Projected";
            btProjected.Width = 80;
            btProjected.Height = 40;
            btProjected.Margin = new Thickness(15);
            btProjected.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetColumn(btProjected, 1);        
            //Boton Interrogante
            btQuestion.Content = new Image() { Source = new BitmapImage(new Uri("/Icons/Interrogante.png", UriKind.Relative)) };
            btQuestion.Width = 40;
            btQuestion.Margin = new Thickness(15);
            btProjected.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetColumn(btQuestion, 3);
           
            //AÑADIMOS COMPONENTES
            gridTop.Children.Add(btCurrent);
            gridTop.Children.Add(btProjected);
            gridTop.Children.Add(btQuestion);
        }

        //PANEL IZQUIERDO DEL DOCK
        private void leftPart()
        {
            //DECLARACIÓN DE COMPONENTES
            stackLeft = new StackPanel();
            TextBlock data = new TextBlock();
            TextBlock sales = new TextBlock();
            TextBlock marketing = new TextBlock();
            TextBlock distribution = new TextBlock();
            TextBlock costs = new TextBlock();

            //DEFINICIÓN DE COMPONENTES (TEXTOS)
            data.Text = "Data";
            data.Margin = new Thickness(10);
            data.FontSize = 15;
            data.FontWeight = FontWeights.Bold;

            sales.Text = "Sales";
            sales.Margin = new Thickness(20,10,10,10);

            marketing.Text = "Marketing";
            marketing.Margin = new Thickness(20, 10, 10, 10);

            distribution.Text = "Distribution";
            distribution.Margin = new Thickness(20, 10, 10, 10);

            costs.Text = "Costs";
            costs.Margin = new Thickness(20, 10, 10, 10);

            //AÑADIMOS COMPONENTES
            stackLeft.Children.Add(data);
            stackLeft.Children.Add(sales);
            stackLeft.Children.Add(marketing);
            stackLeft.Children.Add(distribution);
            stackLeft.Children.Add(costs);
        }

        //PANEL DERECHO DEL DOCK
        private void rightPart()
        {
            //DECLARAMOS LOS COMPONENETES
            wrapRight = new WrapPanel();
            Button btnBarchart = new Button();
            Button btnLineChart = new Button();
            Button btnComboChart = new Button();
            Button btnPieChart = new Button();
            Button btnLocation = new Button();
            Button btnRelative = new Button();

            //DEFINICIÓN DE COMPONENTES
            //Ancho del panel
            wrapRight.Width = 120;
            //imagenes dentro de los botones
            btnBarchart.Content = new Image() { Source = new BitmapImage(new Uri("/Icons/BarChart.png", UriKind.Relative)) };
            btnLineChart.Content = new Image() { Source = new BitmapImage(new Uri("/icons/linechart.png", UriKind.Relative)) };
            btnComboChart.Content = new Image() { Source = new BitmapImage(new Uri("/icons/combochart.png", UriKind.Relative)) };
            btnPieChart.Content = new Image() { Source = new BitmapImage(new Uri("/icons/piechart.png", UriKind.Relative)) };
            btnLocation.Content = new Image() { Source = new BitmapImage(new Uri("/icons/location.png", UriKind.Relative)) };
            btnRelative.Content = new Image() { Source = new BitmapImage(new Uri("/icons/relative.png", UriKind.Relative)) };
            //ancho de los botones
            btnBarchart.Width = 40;
            btnLineChart.Width = 40;
            btnComboChart.Width = 40;
            btnPieChart.Width = 40;
            btnLocation.Width = 40;
            btnRelative.Width = 40;
            //margenes de los botones
            btnBarchart.Margin = new Thickness(10);
            btnLineChart.Margin = new Thickness(10);
            btnComboChart.Margin = new Thickness(10);
            btnPieChart.Margin = new Thickness(10);
            btnLocation.Margin = new Thickness(10);
            btnRelative.Margin = new Thickness(10);
            //Background de los botones
            btnBarchart.Background = Brushes.Transparent;
            btnLineChart.Background = Brushes.Transparent;
            btnComboChart.Background = Brushes.Transparent;
            btnPieChart.Background = Brushes.Transparent;
            btnLocation.Background = Brushes.Transparent;
            btnRelative.Background = Brushes.Transparent;

            //AÑADIMOS LOS COMPONENTES
            wrapRight.Children.Add(btnBarchart);
            wrapRight.Children.Add(btnLineChart);
            wrapRight.Children.Add(btnComboChart);
            wrapRight.Children.Add(btnPieChart);
            wrapRight.Children.Add(btnLocation);
            wrapRight.Children.Add(btnRelative);

        }

        //PANEL CENTRAL DEL DOCK
        public void centerPart()
        {
            //DEFINICIÓN DE COLUMNAS Y FILAS
            gridCentral = new Grid();
            //Columnas
            gridCentral.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            gridCentral.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1,GridUnitType.Star) });
            gridCentral.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            gridCentral.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            //Filas
            gridCentral.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridCentral.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridCentral.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridCentral.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridCentral.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridCentral.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            //DECLARACIÓN DE COMPONENTES
            //Imagenes
            Image imgHouse = new Image();
            Image imgPie = new Image();
            //Textos
            TextBlock tbSales = new TextBlock();
            TextBlock tbGoods = new TextBlock();
            TextBlock tbServices = new TextBlock();
            TextBlock tbPercent = new TextBlock();
            //Botones            
            Button btCancel = new Button();
            Button btSave = new Button();

            //DEFINICIÓN Y POSICIÓN DE COMPONENTES
            //Imagen Casa
            imgHouse.Source = new BitmapImage(new Uri("/Icons/Casa.png", UriKind.Relative));
            Grid.SetRowSpan(imgHouse, 2);
            //Imagen Tarta
            imgPie.Source = new BitmapImage(new Uri("Icons/Principal.png", UriKind.Relative));
            imgPie.Margin = new Thickness(20,0,40,0);
            Grid.SetRow(imgPie, 3);
            Grid.SetColumn(imgPie, 1);
            Grid.SetColumnSpan(imgPie, 2);
            //Texto Sales
            tbSales.Text = "Sales: Current Year";
            tbSales.FontWeight = FontWeights.Bold;
            tbSales.FontSize = 20;
            tbSales.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(tbSales, 1);
            //Texto Goods
            tbGoods.Text = "Goods and Services";
            tbGoods.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(tbGoods, 1);
            Grid.SetRow(tbGoods, 1);
            //Texto Services
            tbServices.Text = "Services 20%";
            tbServices.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(tbServices, 2);
            Grid.SetColumn(tbServices, 3);
            //Texto Goods Porcentaje
            tbPercent.Text = "Goods 80%";
            Grid.SetRow(tbPercent, 4);
            //Boton Cancel
            btCancel.Content = "Cancel";
            btCancel.Width = 70;
            Grid.SetColumn(btCancel, 3);
            Grid.SetRow(btCancel, 5);
            //Boton Save
            btSave.Content = "Save";
            btSave.Width = 70;
            btSave.Margin = new Thickness(0,0,10,0);
            btSave.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(btSave, 5);
            Grid.SetColumn(btSave, 2);
            Grid.SetRowSpan(btSave, 3);

            //AÑADIMOS COMPONENTES
            gridCentral.Children.Add(imgHouse);
            gridCentral.Children.Add(imgPie);
            gridCentral.Children.Add(tbGoods);
            gridCentral.Children.Add(tbSales);
            gridCentral.Children.Add(tbPercent);
            gridCentral.Children.Add(tbServices);
            gridCentral.Children.Add(btCancel);
            gridCentral.Children.Add(btSave);

        }
    }


}
