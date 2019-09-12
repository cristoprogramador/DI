using dam.di.inventario.Servicios;
using ejemplo_tema4.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo_tema4.Servicios
{
    public class RolServicio : ServicioGenerico<rol>
    {
    
        // Como la clase es generica, la clase va a heredar. Como el super() en Java
        public RolServicio(DbContext context) : base(context)
        {

        }
    }
}
