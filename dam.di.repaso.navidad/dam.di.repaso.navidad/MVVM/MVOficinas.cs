using dam.di.repaso.navidad.Modelo;
using dam.di.repaso.navidad.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam.di.repaso.navidad.MVVM
{
    public class MVOficinas : MVBase
    {
        jardineriaEntities jEnt;
        OficinaServicio ofiServ;

        public MVOficinas(jardineriaEntities ent)
        {
            jEnt = ent;
            ofiServ = new OficinaServicio(ent);
        }

        public List<oficinas> listaOficinas
        {
            get
            {
                return ofiServ.getAll().ToList();
            }
        }


    }
}
