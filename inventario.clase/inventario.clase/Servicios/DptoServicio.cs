using System.Data.Entity;

using dam.di.inventario.Servicios;
using inventario.clase.Modelo;

namespace dam.di.inventario.Servicios
{
    public class DptoServicio : ServicioGenerico<departamento>
    {

        public DptoServicio(DbContext context) : base(context)
        {
        }
    }
}
