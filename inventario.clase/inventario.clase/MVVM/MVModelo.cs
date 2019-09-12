using dam.di.inventario.clase.MVVM;
using dam.di.inventario.Servicios;
using inventario.clase.Modelo;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace inventario.clase.MVVM
{
    //IMPORTANTE: publica 


    public class MVModelo : MVBase
    {
        private diinventarioEntities invEnt;
        private ModeloArticuloServicio modServ;
        private ServicioGenerico<tipoarticulo> modeServ;
        private static Logger log = LogManager.GetCurrentClassLogger();

        //Definimos una lista auxiliar
        private ListCollectionView lista;

        //objeto auxiliar para guardar los datos recogidos
        //en la interfaz
        private modeloarticulo modNuevo;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ent"></param>

        //publicar lista de tipos de objetos
        public MVModelo(diinventarioEntities ent)
        {
            invEnt = ent;
            iniciliza();

        }
        
        /// <summary>
        /// Almacena la lista de tipos
        /// </summary>
        public List<tipoarticulo> listaTipos
        {
            get
            {
                return modeServ.getAll().ToList();
            }
        }



        /// <summary>
        /// Almacena la lista de modelos para la tabla
        /// </summary>
        //public List<modeloarticulo> listaModelos
        //{
        //    get
        //    {
        //        return modServ.getAll().ToList();
        //    }
        //}


        /// <summary>
        // Almacena la lista de modelos , en un get devolver un new puede ser peligroso, solo se va a llamar una vez
        /// </summary>
        public ListCollectionView listaModelos
        {
            get
            {
                return lista;
            }
        }



        /// <summary>
        /// Objeto que recoge los datos de la interfaz
        /// </summary>
        public modeloarticulo modeloNuevo //este es el que utilizamos en la capa vista
        {
            get
            {
                return modNuevo;
            }
            set
            {
                modNuevo = value;
                OnPropertyChanged("modeloNuevo"); 
                //Esta implementacion de la interfaz hemos de ponerlo en el que recoge los datos
            }
        }


        public bool guarda() {
            bool correcto = true;
            modServ.add(modNuevo);
            try
            {
                modServ.save();

            }catch(DbUpdateException dbex)
            {
                correcto = false;
                log.Error("\nInsertando modelo articulo ... ERROR\n" +
                    dbex.InnerException.Message +"\n" +   dbex.StackTrace);
            }
            return correcto;
        }

        //******************************************
        //Métodos privados

        private void iniciliza()
        {
            modServ = new ModeloArticuloServicio(invEnt);
            modeServ = new ServicioGenerico<tipoarticulo>(invEnt);
            //generamos objeto nuevo
            modNuevo = new modeloarticulo();
            lista = new ListCollectionView(modServ.getAll().ToList());
        }

    }
}
