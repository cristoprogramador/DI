using dam.di.examen.t456.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam.di.examen.t456.Servicios
{
    public class ServicioGrupo : ServicioGenerico<grupo>
    {
        private DbContext contexto;

        public ServicioGrupo(DbContext context) : base(context)
        {
            contexto = context;
        }

        public List<string> listaPaises()
        {
            var lista = contexto.Database.SqlQuery<string>("SELECT pais FROM grupo group by pais").ToList();
            return lista;
        }
    }
}
