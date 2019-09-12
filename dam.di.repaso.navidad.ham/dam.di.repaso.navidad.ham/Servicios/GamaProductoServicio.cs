using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using dam.di.repaso.navidad.ham.Modelo;

namespace dam.di.repaso.navidad.ham.Servicios
{
    public class GamaProductoServicio : ServicioGenerico<gamasproductos>
    {
        public GamaProductoServicio(DbContext context) : base(context)
        {
        }
    }
}
