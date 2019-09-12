﻿using dam.di.inventario.clase.Modelo;
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

namespace dam.di.inventario.clase.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCGesUsuario.xaml
    /// </summary>
    public partial class UCGesArticulo : UserControl
    {
        private diinventarioEntities invEnt;

        public UCGesArticulo(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
        }
    }
}
