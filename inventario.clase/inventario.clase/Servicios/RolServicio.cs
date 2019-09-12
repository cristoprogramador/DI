using dam.di.inventario.Servicios;
using inventario.clase.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventario.clase.Servicios
{
    public class RolServicio : ServicioGenerico<rol> //hacerlo publico
    {
        public RolServicio(DbContext context) : base(context) //por la genericidad, como un super
        {

        }
    }
}
