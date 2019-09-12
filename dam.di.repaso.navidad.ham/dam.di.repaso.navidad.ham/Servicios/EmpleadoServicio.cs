using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using dam.di.repaso.navidad.ham.Modelo;

namespace dam.di.repaso.navidad.ham.Servicios
{
    public class EmpleadoServicio : ServicioGenerico<empleados>
    {
        private DbContext contexto;

        public EmpleadoServicio(DbContext context) : base(context)
        {
            contexto = context;
        }

        public int getLastId()
        {
            empleados emp = contexto.Set<empleados>().OrderByDescending(e => e.CodigoEmpleado).FirstOrDefault();
            return emp.CodigoEmpleado;
        }
    }
}
