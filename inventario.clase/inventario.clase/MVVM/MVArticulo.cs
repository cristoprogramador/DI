using dam.di.inventario.clase.MVVM;
using dam.di.inventario.Servicios;
using inventario.clase.Modelo;
using inventario.clase.Servicios;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventario.clase.MVVM
{
    class MVArticulo : MVBase
    {
        private diinventarioEntities invEnt;
        private ArticuloServicio artServ;
        private ServicioGenerico<tipousuario> tipoUsuServ;
        private TipoArticuloServicio tipoArtServ;
        private ModeloArticuloServicio modServ;
        private UsuarioServicio usuServ;
        private EspacioServicio espServ;

        private static Logger log = LogManager.GetCurrentClassLogger();

       
        //List departameti, esoacio usuario modelo articulo,
       

        

        //objeto auxiliar para guardar los datos recogidos
        //en la interfaz
        private articulo artNuevo;



        // publicar lista de tipos de objetos(usuario)
        public MVArticulo(diinventarioEntities ent)
        {
            invEnt = ent;
            inicializa();
        }


        /// <summary>
        /// Almacena la lista de modelos
        /// </summary>
        public List<modeloarticulo> listaModelo
        {
            get
            {
                return modServ.getAll().ToList();
            }
        }





        /// <summary>
        /// Almacena la lista de articulos para la tabla
        /// </summary>
        public List<espacio> listaEspacio
        {
            get
            {
                return espServ.getAll().ToList();
            }
        }

        /// <summary>
        /// Almacena la lista de tipos
        /// </summary>
        public List<usuario> listaUsuarios
        {
            get
            {
                return usuServ.getAll().ToList();
            }
        }



        /// <summary>
        /// Almacena la lista de articulos para la tabla
        /// </summary>
        public List<articulo> listaArticulos
        {
            get
            {
                return artServ.getAll().ToList();
            }
        }

        /// <summary>
        /// Almacena la lista de tiposArticulos
        /// </summary>
        public List<tipoarticulo> listaTipos
        {
            get
            {
                return tipoArtServ.getAll().ToList();
            }
        }



        private void inicializa()
        {
            artServ = new ArticuloServicio(invEnt);
            usuServ = new UsuarioServicio(invEnt);
            tipoUsuServ = new ServicioGenerico<tipousuario>(invEnt);
            espServ = new EspacioServicio(invEnt);
            tipoArtServ = new TipoArticuloServicio(invEnt);
       

            //generamos objeto nuevo
            artNuevo = new articulo();

        }

    }
}
