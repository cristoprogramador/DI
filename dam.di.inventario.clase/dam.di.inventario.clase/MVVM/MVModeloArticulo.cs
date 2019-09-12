using dam.di.inventario.clase.Modelo;
using dam.di.inventario.Servicios;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace dam.di.inventario.clase.MVVM
{
    public class MVModeloArticulo : MVBase
    {
        // Variables privadas **************************************************************************
        // Contexto de la base de datos
        private diinventarioEntities iEnt;
        // Servicio de la tabla modelo articulo
        private ModeloArticuloServicio modServ;
        // Servicio de la tabla tipo servicio
        private TipoArticuloServicio tipServ;
        // Objeto auxiliar de nuevo modelo
        private modeloarticulo nuevoMod;
        // Variable para el Log
        private static Logger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ent"> Contexto de la base de datos </param>
        public MVModeloArticulo(diinventarioEntities ent)
        {
            iEnt = ent;
            inicializa();
        }
        // Objetos **************************************************************************************
        /// <summary>
        /// Lista de los tipos de articulo
        /// </summary>
        public List<tipoarticulo> listaTipos
        {
            get { return tipServ.getAll().ToList(); }
        }
        /// <summary>
        /// Objeto que guarda las propiedades del modelo articulo nuevo
        /// </summary>
        public modeloarticulo nuevoModelo
        {
            get { return nuevoMod; }
            set
            {
                nuevoMod = value;
                OnPropertyChanged("nuevoModelo");
            }
        }

        public List<modeloarticulo> listaModelos
        {
            get
            {
                return modServ.getAll().ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto modeloarticulo en la base de datos
        /// </summary>
        public bool guarda()
        {
            bool correcto = true;
            modServ.add(nuevoModelo);
            try
            {
                modServ.save();
                log.Error("\nInsertando un modelo de articulo ... Todo correcto");
            }
            catch (DbUpdateException ex)
            {
                correcto = false;
                log.Error("\nInsertando un modelo de articulo ... ERROR\n" 
                    + ex.StackTrace + "\n" + ex.InnerException.Message);
            }
            return correcto;
        }
        // Métodos privados *****************************************************************************
        /// <summary>
        /// Método que inicializa las variables que necesitamos
        /// </summary>
        private void inicializa()
        {
            // Objeto que accede a la capa de servicio de la tabla Modelo Articulo
            modServ = new ModeloArticuloServicio(iEnt);
            // Objeto que accede a la capa de servicio de la tabla Tipo Articulo
            tipServ = new TipoArticuloServicio(iEnt);
            // Guardamos las propiedades correspondientes del objeto modeloarticulo que vamos a guardar en la base de datos
            // Cada propiedad está enlazada con el correspondiente control de la interfaz
            nuevoMod = new modeloarticulo();
        }
        
    }
}
