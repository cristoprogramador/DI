using dam.di.examen.t456.Modelo;
using dam.di.examen.t456.Vista.ControlesUsuario;
using dam.di.examen.t456.Vista.Dialogos;
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

namespace dam.di.examen.t456
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private musicaEntities mEnt;

        public MainWindow()
        {
            InitializeComponent();
            mEnt = new musicaEntities();
        }

        private void menuInsertarDisco_Click(object sender, RoutedEventArgs e)
        {
            DiagInsertaDisco diag = new DiagInsertaDisco(mEnt);
            diag.ShowDialog();
        }

        private void menuListaClubs_Click(object sender, RoutedEventArgs e)
        {
            UCListaGrupo ucLista = new UCListaGrupo(mEnt);
            if (panelCentral.Children != null) panelCentral.Children.Clear();
            panelCentral.Children.Add(ucLista);
        }
    }
}
