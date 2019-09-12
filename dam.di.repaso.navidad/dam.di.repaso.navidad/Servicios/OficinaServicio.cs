using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using dam.di.repaso.navidad.Modelo;

namespace dam.di.repaso.navidad.Servicios
{
    public class OficinaServicio : ServicioGenerico<oficinas>
    {
        public OficinaServicio(DbContext context) : base(context)
        {
        }
    }
}
