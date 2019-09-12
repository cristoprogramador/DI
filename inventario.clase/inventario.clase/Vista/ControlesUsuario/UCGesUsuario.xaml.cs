using inventario.clase.Modelo;
using inventario.clase.MVVM;
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

namespace inventario.clase.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCGesUsuario.xaml
    /// </summary>
    public partial class UCGesUsuario : UserControl
    {
        private diinventarioEntities invEnt;
        private MVUsuario mvUsuario;

        public UCGesUsuario(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            mvUsuario = new MVUsuario(ent);
            DataContext = mvUsuario;
        }
    }
}
