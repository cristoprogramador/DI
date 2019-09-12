using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using dam.di.inventario.Servicios;
using ejemplo_tema4.Modelo;
using NLog;

namespace ejemplo_tema4.MVVM
{
    public class MVModelo : MVBase
    {
        private modeloarticulo modNuevo;
        private diinventarioEntities invEnt;
        private ModeloArticuloServicio modServ;
        private modeloarticulo modeloSeleccionado;
        private static Logger log = LogManager.GetCurrentClassLogger();

        ListCollectionView lista;
        private tipoarticulo tipoArt;
        private ServicioGenerico<tipoarticulo> tipoServ;
        // Objeto auxiliar para guardar la interfaz
        // Constructor de clase
        public MVModelo(diinventarioEntities ent)
        {
            invEnt = ent;
            inicializa();
        }

        public List<modeloarticulo> listaModelos
        {
            get { return modServ.getAll().ToList(); }
        }

        // Lista tipo articulo
        public List<tipoarticulo> listaTipos
        {
            get
            {
                return tipoServ.getAll().ToList();
            }
        }

        public modeloarticulo modeloNuevo
        {
            get
            {
                return modNuevo;
            }

            set
            {
                modNuevo = value;
                OnPropertyChanged("modeloNuevo"); // Interfaz que permite que el binding se haga automaticamente
            }
        }

        public bool guarda()
        {
            bool correcto = true;
            modServ.add(modNuevo);

            try {
                modServ.save();
            }
            catch (DbUpdateException dbEx)
            {
                correcto = false;
                log.Error("INSERTANDO MODELO ARTICULO ... ERROR\n" +
                    dbEx.InnerException.Message + "\n" + dbEx.StackTrace);
            }

            return correcto;
        }

        public ListCollectionView listaCollectionModelos
        {
            get
            {
                return lista;
            }
        }

        public tipoarticulo tipoSeleccionado
        {
            get
            {
                return tipoArt;
            }
            set
            {
                tipoArt = value;
                OnPropertyChanged("tipoSeleccionado");
            }
        }

       public modeloarticulo modSeleccionado
        {
            get
            {
                return modeloSeleccionado;
            }
            set
            {
                modeloSeleccionado = value;

                OnPropertyChanged("modSeleccionado");
            }
        }

        // Metodos privados
        private void inicializa()
        {
            modServ = new ModeloArticuloServicio(invEnt);
            modNuevo = new modeloarticulo();
            tipoServ = new ServicioGenerico<tipoarticulo>(invEnt);
            tipoArt = new tipoarticulo();
            lista = new ListCollectionView(modServ.getAll().ToList());
            modeloSeleccionado = new modeloarticulo();
        }
    }
}
