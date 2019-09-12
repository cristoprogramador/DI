using dam.di.inventario.Servicios;
using ejemplo_tema4.Modelo;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ejemplo_tema4.MVVM 
{
    class MVArticulo : MVBase
    {
        private diinventarioEntities invEnt;

        private articulo artNuevo;
        // Vamos a definir los servicios de los comboBox
        private ArticuloServicio artServ;
        private UsuarioServicio usuServ;
        private ModeloArticuloServicio modServ;
        private DptoServicio dptoServ;
        private EspacioServicio espacioServ;
        ListCollectionView lista;
        private departamento dpto;
        private static Logger log = LogManager.GetCurrentClassLogger();

        public MVArticulo(diinventarioEntities ent)
        {
            invEnt = ent;
            inicializa();
        }

        private void inicializa()
        {
            artNuevo = new articulo();

            artServ = new ArticuloServicio(invEnt);

            usuServ = new UsuarioServicio(invEnt);

            modServ = new ModeloArticuloServicio(invEnt);

            dptoServ = new DptoServicio(invEnt);

            dpto = new departamento();
            
            espacioServ = new EspacioServicio(invEnt);
            lista = new ListCollectionView(artServ.getAll().ToList());
        }

        public articulo articuloNuevo
        {
            get
            {
                return artNuevo;
            }

            set
            {
                articuloNuevo = value;
                OnPropertyChanged("articuloNuevo");
            }
        }

        public departamento departamentoSeleccionado
        {
            get
            {
                return dpto;
            }
            set
            {
                dpto = value;
                OnPropertyChanged("departamentoSeleccionado");
            }
        }

        public List<espacio> listaEspacio
        {
            get
            {
                return espacioServ.getAll().ToList();
            }
        }

        public List<articulo> listaArticulos
        {
            get { return artServ.getAll().ToList(); }
        }

        public ListCollectionView listaCollectionArticulos
        {
            get { return lista; }
        }

        public List<departamento> listaDepartamentos
        {
            get
            {
                return dptoServ.getAll().ToList();
            }
        }

        public List<modeloarticulo> listaModeloArticulos
        {
            get
            {
                return modServ.getAll().ToList();
            }
        }

        public List<usuario> listaUsuarios
        {
            get
            {
                return usuServ.getAll().ToList();
            }
        }

        public bool guarda()
        {
            bool correcto = true;
            artServ.add(artNuevo);

            try
            {
                artServ.save();
            }
            catch (DbUpdateException dbEx)
            {
                correcto = false;
                log.Error("INSERTANDO ARTICULO ... ERROR\n" +
                    dbEx.InnerException.Message + "\n" + dbEx.StackTrace);
            }

            return correcto;
        }
    }
}
