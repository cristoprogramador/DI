using examen.dam.di._21.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen.dam.di._21.Servicios
{
    public class ServicioCiudades : ServicioGenerico<ciudades>
    {
        private DbContext contexto;

        public ServicioCiudades (DbContext context) : base(context)
        {
            contexto = context;
        }
    }
}
