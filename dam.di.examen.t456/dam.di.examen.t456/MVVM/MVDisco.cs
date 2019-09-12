using dam.di.examen.t456.Modelo;
using dam.di.examen.t456.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam.di.examen.t456.MVVM
{
    public class MVDisco : MVBase
    {
        private musicaEntities mEnt;

        private disco disco;
        private ServicioDisco servDisco;
        private ServicioCompanyia servCompany;
        private ServicioGrupo servGrupo;

        private grupo grup;

        //Constructor
        public MVDisco (musicaEntities ent)
        {
            mEnt = ent;
            inicializa();
        }

        //Metodo inicializador
        private void inicializa()
        {
            servDisco = new ServicioDisco(mEnt);
            disco = new disco();
            servCompany = new ServicioCompanyia(mEnt);
            servGrupo = new ServicioGrupo(mEnt);
            grup = new grupo();
        }

        public disco nuevoDisco
        {
            get
            {
                return disco;
            }
            set
            {
                disco = value;
                OnPropertyChanged("nuevoDisco");
            }
        }
    

        public List<companyia> listaCompany
        {
            get
            {
                return servCompany.getAll().ToList();
            }
        }

        public List<grupo> listaGrupo
        {
            get
            {
                return servGrupo.getAll().ToList();
            }
        }

        public grupo grupoSeleccionado
        {
            get
            {
                return grup;
            }
            set
            {
                grup = value;
                OnPropertyChanged("grupoSeleccionado");
            }
        }

        /// METODO PARA VALIDAR Y GUARDAR ///////////////////////////////////////////////////////
        /// Metodo para validar y guardar el objeto modeloarticulo en la BD
        public bool guarda()
        {
            //Generamos variable boolena a devolver si es valida o no
            bool correcto = true;
            //añadimos el objeto nuevo modelo al servicio modelo
            servDisco.add(nuevoDisco);
            try
            {
                //Guardmos el servicio en la BD y guardamos el log
                servDisco.save();
            }
            //Si salta excepción
            catch (DbUpdateException)
            {
                //cambiamos la variable devolución a false y guardamos en log
                correcto = false;
            }
            //Devolvemos resultado true si todo ok false si ha saltado excepción
            return correcto;
        }

    }
}
