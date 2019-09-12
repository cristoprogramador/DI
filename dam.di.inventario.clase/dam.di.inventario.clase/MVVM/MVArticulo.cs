using dam.di.inventario.clase.Modelo;
using dam.di.inventario.Servicios;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam.di.inventario.clase.MVVM
{
    public class MVArticulo : MVBase
    { 
        private diinventarioEntities invEnt;
        private ArticuloServicio artServ;
        private DptoServicio dptoServ;
        private EspacioServicio espServ;
        private UsuarioServicio usuServ;
        private ModeloArticuloServicio modServ;
        private articulo artNuevo;
        private static Logger log = LogManager.GetCurrentClassLogger(); 

        public MVArticulo(diinventarioEntities ent)
        {
            invEnt = ent;
            inicializa();
        }

        private void inicializa()
        {
            artServ = new ArticuloServicio(invEnt);
            dptoServ = new DptoServicio(invEnt);
            espServ = new EspacioServicio(invEnt);
            usuServ = new UsuarioServicio(invEnt);
            modServ = new ModeloArticuloServicio(invEnt);

            artNuevo = new articulo();
        }

        public List<departamento> listaDptos
        {
            get
            {
                return dptoServ.getAll().ToList();
            }
        }

        public List<espacio> listaEspacios
        {
            get
            {
                return espServ.getAll().ToList();
            }
        }

        public List<usuario> listaUsuarios
        {
            get { return usuServ.getAll().ToList(); }
        }

        public List<modeloarticulo> listaModelos
        {
            get { return modServ.getAll().ToList(); }
        }

        public List<articulo> listaArticulos
        {
            get { return artServ.getAll().ToList(); }
        }

        public articulo articuloNuevo
        {
            get
            {
                return artNuevo;
            }
            set
            {
                artNuevo = value;
                OnPropertyChanged("articuloNuevo");
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
            catch (DbUpdateException dbex)
            {
                correcto = false;
                log.Error("\nINSERTANDO UN NUEVO ARTICULO ... ERROR\n" +
                    dbex.InnerException.Message + "\n" + dbex.StackTrace);
            }
            return correcto;
        }

        public int lastId
        {
            get
            {
                return artServ.getLastId();
            }
        }

        public bool numSerieUnico
        {
            get
            {
                return artServ.numserieUnico(artNuevo.numserie);
            }
        }
    }
}
