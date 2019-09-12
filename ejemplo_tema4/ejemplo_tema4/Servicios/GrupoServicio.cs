using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ejemplo_tema4.Modelo;

namespace dam.di.inventario.Servicios
{
    public class GrupoServicio : ServicioGenerico<grupo>
    {
        public GrupoServicio(DbContext context) : base(context)
        {
        }
    }
}
