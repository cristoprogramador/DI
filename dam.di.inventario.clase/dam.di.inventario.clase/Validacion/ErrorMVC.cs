using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace dam.di.inventario.clase.Validacion
{
    public class ErrorMVC
    {
        public static void muestraError(Image img, UIElement uie)
        {
            img.Visibility = Visibility.Visible;
            uie.Effect = new DropShadowEffect
            {
                Color = new Color { A = 0, R = 210, G = 0, B = 0 },
                Direction = -30,
                ShadowDepth = 1,
                BlurRadius = 0,
                Opacity = 1
            };
        }

        public static void quitaError(Image img, FrameworkElement uie)
        {
            img.Visibility = Visibility.Hidden;
            uie.Effect = null;
        }

        public static void inicializaLista(bool[] lista)
        {
            int fin = lista.Length;
            for (int i = 0; i < fin; i++)
            {
                lista[i] = true;
            }
        }
    }
}
