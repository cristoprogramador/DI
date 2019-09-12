using examen.dam.di._21.Modelo;
using examen.dam.di._21.MVVM;
using examen.dam.di._21.Vista.ControlesUsuario;
using MahApps.Metro.Controls;
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

namespace examen.dam.di._21
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private aerolineasEntities aEnt;
        private MVVuelos mvVuelos;

        public MainWindow()
        {
            InitializeComponent();
            conectar();
            aEnt = new aerolineasEntities();
            mvVuelos = new MVVuelos(aEnt);
            DataContext = mvVuelos;
        }

        private void conectar()
        {
            aEnt = new aerolineasEntities();
            aEnt.Database.Connection.Open();
        }

        private void BtnAviones_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnPersonal_Click(object sender, RoutedEventArgs e)
        {
            UCVuelos ucVuelos = new UCVuelos(aEnt);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(ucVuelos);
        }
    }
}
