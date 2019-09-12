using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Tema2.Ejercicio4
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void AppStart(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow(); 
            window.Show();
        }
    }
}
