using dam.di.examen.t456.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam.di.examen.t456.Servicios
{
    public class ServicioDisco : ServicioGenerico<disco>
    {
        private DbContext contexto;

        public ServicioDisco(DbContext context) : base(context)
        {
            contexto = context;
        }

        public Boolean nombreDiscoUnico(string dis)
        {
            bool unico = true;
            if (contexto.Set<disco>().Where(d => d.nombre == dis).Count() > 0)
            {
                unico = false;
            }
            return unico;
        }
    }
}
