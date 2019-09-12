using dam.di.examen.t456.Modelo;
using dam.di.examen.t456.MVVM;
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

namespace dam.di.examen.t456.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCListaGrupo.xaml
    /// </summary>
    public partial class UCListaGrupo : UserControl
    {
        private musicaEntities mEnt;

        public UCListaGrupo(musicaEntities ent)
        {
            InitializeComponent();
            mEnt = ent;
        }
    }
}
