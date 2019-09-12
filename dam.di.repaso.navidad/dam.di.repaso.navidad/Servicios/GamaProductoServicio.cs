using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using dam.di.repaso.navidad.Modelo;

namespace dam.di.repaso.navidad.Servicios
{
    public class GamaProductoServicio : ServicioGenerico<gamasproductos>
    {
        public GamaProductoServicio(DbContext context) : base(context)
        {
        }
    }
}
