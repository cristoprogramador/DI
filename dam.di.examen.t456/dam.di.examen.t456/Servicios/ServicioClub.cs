using dam.di.examen.t456.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam.di.examen.t456.Servicios
{
    public class ServicioClub : ServicioGenerico<club>
    {
        private DbContext contexto;

        public ServicioClub(DbContext context) : base(context)
        {
            contexto = context;
        }
    }
}
