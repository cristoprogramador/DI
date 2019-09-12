

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
    /// Lógica de interacción para UCGesModeloArticulo.xaml
    /// </summary>
    public partial class UCGesModeloArticulo : UserControl
    {
        private diinventarioEntities invEnt;
        private MVModelo mvModelo;


        public UCGesModeloArticulo(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent; 
            mvModelo = new MVModelo(ent);
            DataContext = mvModelo;
            
        }
    }
}
