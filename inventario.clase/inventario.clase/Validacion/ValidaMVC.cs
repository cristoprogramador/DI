using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace inventario.clase.Validacion
{
    public class ValidaMVC
    {


        public bool validaCadena(string cad)
        {
            bool correcto = false;
            if (string.IsNullOrEmpty(cad)) correcto = true;
            return correcto;
        }
        //para combobox
        public bool objetoNoNulo(object obj)
        {
            bool correcto = false;
            if (obj == null) correcto = true;
            return correcto;
        }
        public bool rango(int min, int max)
        {
            bool correcto = true;
            return correcto ;
        }
        public static void muestraError(Control ctrl)
        {
     
            ctrl.Effect = new DropShadowEffect
            {
                Color = new Color { A = 0, R = 210, G = 0, B = 0 },
                Direction = -30,
                ShadowDepth =2,
                BlurRadius = 0,
                Opacity = 1
            };
        }
        public static void quitaError(Control ctrl)
        {
           
            ctrl.Effect = null;
        }

    }
}
