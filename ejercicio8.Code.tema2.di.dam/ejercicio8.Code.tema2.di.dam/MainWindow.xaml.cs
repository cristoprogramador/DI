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

namespace ejercicio8.Code.tema2.di.dam
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            makeGrid();

            this.Content = gridPanel;
        }
        private Grid gridPanel;

        //CONSTRUIMOS EL GRID
        void makeGrid()
        {
            gridPanel = new Grid();

            //DEFINIMOS FILAS Y COLUMNAS
            gridPanel.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto});
            gridPanel.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            gridPanel.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            gridPanel.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            //DEFINIMOS Y DECLARAMOS COMPONENTES
            //Grid
            gridPanel.Background = Brushes.LightGray;

            //Imagenes
            Image imgWin = new Image();
            imgWin.Source = new BitmapImage(new Uri("/iconwin.png", UriKind.Relative));
            imgWin.Width = 40;
            imgWin.Margin = new Thickness(30, 20, 0, 0);

            //Textos columna uno
            TextBlock tbCabecera = new TextBlock();
            tbCabecera.Text = "Microsoft Azure Webjobs";
            tbCabecera.Margin = new Thickness(15, 0, 15, 5);
            tbCabecera.FontSize = 20;
            tbCabecera.VerticalAlignment = VerticalAlignment.Bottom;
            Grid.SetColumn(tbCabecera, 1);

            TextBlock tbProject = new TextBlock();
            tbProject.Text = "Project name:";
            tbProject.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbProject, 1);
            Grid.SetColumn(tbProject, 1);

            TextBlock tbWebjobName = new TextBlock();
            tbWebjobName.Text = "Webjob name:";
            tbWebjobName.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbWebjobName, 3);
            Grid.SetColumn(tbWebjobName, 1);

            TextBlock tbWebjobRun = new TextBlock();
            tbWebjobRun.Text = "Webjob run mode:";
            tbWebjobRun.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbWebjobRun, 5);
            Grid.SetColumn(tbWebjobRun, 1);

            TextBlock tbRecurrence = new TextBlock();
            tbRecurrence.Text = "Recurrence:";
            tbRecurrence.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbRecurrence, 7);
            Grid.SetColumn(tbRecurrence, 1);

            TextBlock tbRecur = new TextBlock();
            tbRecur.Text = "Recur every:";
            tbRecur.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbRecur, 9);
            Grid.SetColumn(tbRecur, 1);
            
            TextBlock tbLearn = new TextBlock();
            tbLearn.Text = "Learn more";
            tbLearn.Margin = new Thickness(15, 0, 0, 0);
            tbLearn.Foreground = Brushes.Blue;
            tbLearn.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(tbLearn, 11);
            Grid.SetColumn(tbLearn, 1);

            //Textos columna dos
            TextBlock tbStartOn = new TextBlock();          
            tbStartOn.Text = "Starting on:";
            tbStartOn.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbStartOn, 1);
            Grid.SetColumn(tbStartOn, 2);

            TextBlock tbStartTime = new TextBlock();
            tbStartTime.Text = "Starting time:";
            tbStartTime.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbStartTime, 7);
            Grid.SetColumn(tbStartTime, 2);

            TextBlock tbStartZone = new TextBlock();
            tbStartZone.Text = "Starting time zone:";
            tbStartZone.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbStartZone, 9);
            Grid.SetColumn(tbStartZone, 2);

            //Textos columna tres
            TextBlock tbEnding = new TextBlock();
            tbEnding.Text = "Ending on:";
            tbEnding.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbEnding, 1);
            Grid.SetColumn(tbEnding, 3);

            TextBlock tbEndingTime = new TextBlock();
            tbEndingTime.Text = "Ending time:";
            tbEndingTime.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbEndingTime, 7);
            Grid.SetColumn(tbEndingTime, 3);

            TextBlock tbEndingZone = new TextBlock();
            tbEndingZone.Text = "Ending time zone:";
            tbEndingZone.Margin = new Thickness(15, 0, 0, 0);
            Grid.SetRow(tbEndingZone, 9);
            Grid.SetColumn(tbEndingZone, 3);

            //Cajas de Textos
            TextBox tbxWebjobName = new TextBox();
            tbxWebjobName.Text = "WebjobTest1";
            tbxWebjobName.Margin = new Thickness(15, 5, 15, 25);
            Grid.SetRow(tbxWebjobName, 4);
            Grid.SetColumn(tbxWebjobName, 1);

            //Combo Box
            ComboBox cbProject = new ComboBox();
            cbProject.Margin = new Thickness(15, 5, 15, 25);
            Grid.SetRow(cbProject, 2);
            Grid.SetColumn(cbProject, 1);

            ComboBox cbWebjobRun = new ComboBox();
            cbWebjobRun.Items.Add("Run on a Schedule");
            cbWebjobRun.SelectedIndex = 0;
            cbWebjobRun.Margin = new Thickness(15, 5, 15, 25);
            Grid.SetRow(cbWebjobRun, 6);
            Grid.SetColumn(cbWebjobRun, 1);        

            ComboBox cbStartTime = new ComboBox();
            cbStartTime.Items.Add("12:00 AM");
            cbStartTime.SelectedIndex = 0;
            cbStartTime.Margin = new Thickness(15, 5, 15, 25);
            Grid.SetRow(cbStartTime, 8);
            Grid.SetColumn(cbStartTime, 2);

            ComboBox cbStartZone = new ComboBox();
            cbStartZone.Items.Add("(UTC-08:00) Pacific Time (US & Canada)");
            cbStartZone.SelectedIndex = 0;
            cbStartZone.Margin = new Thickness(15, 5, 15, 25);
            Grid.SetRow(cbStartZone, 10);
            Grid.SetColumn(cbStartZone, 2);

            ComboBox cbEndingTime = new ComboBox();
            cbEndingTime.Items.Add("12:00 AM");
            cbEndingTime.SelectedIndex = 0;
            cbEndingTime.Margin = new Thickness(15, 5, 15, 25);
            Grid.SetRow(cbEndingTime, 8);
            Grid.SetColumn(cbEndingTime, 3);

            ComboBox cbEndingZone = new ComboBox();
            cbEndingZone.Items.Add("(UTC-08:00) Pacific Time (US & Canada)");
            cbEndingZone.SelectedIndex = 0;
            cbEndingZone.Margin = new Thickness(15, 5, 15, 25);
            Grid.SetRow(cbEndingZone, 10);
            Grid.SetColumn(cbEndingZone, 3);

            //Calendars
            Calendar clStart = new Calendar();
            clStart.Margin = new Thickness(15, 0, 80, 20);
            Grid.SetRow(clStart, 2);
            Grid.SetColumn(clStart, 2);
            Grid.SetRowSpan(clStart, 5);

            Calendar clEnding = new Calendar();
            clEnding.Margin = new Thickness(15, 0, 80, 20);
            Grid.SetRow(clEnding, 2);
            Grid.SetColumn(clEnding, 3);
            Grid.SetRowSpan(clEnding, 5);

            //SUB-GRIDS

            //Generamos nuevo grid para la fila 9 columna 2
            Grid gridF9 = new Grid();
            gridF9.ColumnDefinitions.Add(new ColumnDefinition());
            gridF9.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            Grid.SetRow(gridF9, 8);
            Grid.SetColumn(gridF9, 1);
            //Añadimos compontentes
            ComboBox cbRecurrence = new ComboBox();
            cbRecurrence.Items.Add("Recurring Job");
            cbRecurrence.Margin = new Thickness(15, 5, 5, 25);
            cbRecurrence.SelectedIndex = 0;
            Grid.SetColumn(cbRecurrence, 0);

            CheckBox chbNoEnd = new CheckBox();
            chbNoEnd.Content = "No end date";
            chbNoEnd.Margin = new Thickness(5, 5, 15, 25);
            chbNoEnd.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(chbNoEnd, 1);

            //Generamos nuevo grid para la fila 11 columna 2
            Grid gridF11 = new Grid();
            gridF11.ColumnDefinitions.Add(new ColumnDefinition());
            gridF11.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            Grid.SetRow(gridF11, 10);
            Grid.SetColumn(gridF11, 1);
            //Añadimos compontentes
            TextBox tbxRecur = new TextBox();
            tbxRecur.Text = "1";
            tbxRecur.Margin = new Thickness(15, 5, 5, 25);
            Grid.SetColumn(tbxRecur, 0);

            ComboBox cbRecur = new ComboBox();
            cbRecur.Items.Add("Days");
            cbRecur.Margin = new Thickness(5, 5, 15, 25);
            cbRecur.SelectedIndex = 0;
            cbRecur.Width = 175;
            Grid.SetColumn(cbRecur, 1);

            //Generamos nuevo grid para la ultima columna de la ultima fila
            Grid gridButtons = new Grid();           
            gridButtons.ColumnDefinitions.Add(new ColumnDefinition());
            gridButtons.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            Grid.SetRow(gridButtons, 11);
            Grid.SetColumn(gridButtons, 3);
            //Grid.SetColumnSpan(gridButtons, 2);

            //Añadimos los botones
            Button btOk = new Button();
            btOk.Content = "OK";
            btOk.Margin = new Thickness(0, 5, 5, 25);
            btOk.HorizontalAlignment = HorizontalAlignment.Right;
            btOk.Width = 70;        
            Grid.SetColumn(btOk, 0);

            Button btCancel = new Button();
            btCancel.Content = "Cancel";
            btCancel.Margin = new Thickness(5, 5, 15, 25);
            btCancel.Width = 70;
            Grid.SetColumn(btCancel, 1);

            //AGREGAMOS LOS COMPONENTES AL GRID PRINCIPAL
            gridPanel.Children.Add(imgWin);
            gridPanel.Children.Add(tbCabecera);  
            gridPanel.Children.Add(tbProject);
            gridPanel.Children.Add(tbWebjobName);
            gridPanel.Children.Add(tbWebjobRun);
            gridPanel.Children.Add(tbRecurrence);
            gridPanel.Children.Add(tbRecur); 
            gridPanel.Children.Add(tbLearn); 
            gridPanel.Children.Add(tbStartOn);
            gridPanel.Children.Add(tbStartTime);
            gridPanel.Children.Add(tbStartZone);
            gridPanel.Children.Add(tbEnding);
            gridPanel.Children.Add(tbEndingTime);
            gridPanel.Children.Add(tbEndingZone);
            gridPanel.Children.Add(cbProject);
            gridPanel.Children.Add(cbWebjobRun);
            gridPanel.Children.Add(cbStartTime);
            gridPanel.Children.Add(cbStartZone);
            gridPanel.Children.Add(cbEndingTime);
            gridPanel.Children.Add(cbEndingZone); 
            gridPanel.Children.Add(tbxWebjobName);
            gridPanel.Children.Add(clStart);
            gridPanel.Children.Add(clEnding);

            //AGREGAMOS LOS SUBGRIDS Y SUS COMPONENTES
            gridPanel.Children.Add(gridF9);
            //Agregamos componentes del subgrid
            gridF9.Children.Add(chbNoEnd);
            gridF9.Children.Add(cbRecurrence);

            gridPanel.Children.Add(gridF11);
            //Agregamos componentes del subgrid
            gridF11.Children.Add(cbRecur);
            gridF11.Children.Add(tbxRecur);

            gridPanel.Children.Add(gridButtons);
            //Agregamos componentes del subgrid
            gridButtons.Children.Add(btOk);
            gridButtons.Children.Add(btCancel);



        }
    }
}
