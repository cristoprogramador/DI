using System.Data.Entity;
using dam.di.inventario.Servicios;
using ejemplo_tema4.Modelo;

namespace dam.di.inventario.Servicios
{
    public class DptoServicio : ServicioGenerico<departamento>
    {

        public DptoServicio(DbContext context) : base(context)
        {
        }
    }
}
