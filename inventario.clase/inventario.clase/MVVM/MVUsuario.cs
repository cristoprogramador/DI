using dam.di.inventario.clase.MVVM;
using dam.di.inventario.Servicios;
using inventario.clase.Modelo;
using inventario.clase.Servicios;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventario.clase.MVVM
{
    public class MVUsuario : MVBase
        //hereda de MVBase para la validacion
    {
        private diinventarioEntities invEnt;
        private UsuarioServicio usuServ;
        private ServicioGenerico<tipousuario> tipoUsuServ;
        private static Logger log = LogManager.GetCurrentClassLogger();

        private RolServicio rolServ;
        private GrupoServicio gruServ;
        private DptoServicio dptoServ;



        //objeto auxiliar para guardar los datos recogidos
        //en la interfaz
        private usuario usuNuevo;




        // publicar lista de tipos de objetos(usuario)
        public MVUsuario(diinventarioEntities ent)
        {
            invEnt = ent;
            inicializa();
        }

        /// <summary>
        /// Almacena la lista de usuarios para la tabla
        /// </summary>
        public List<usuario> listaUsuarios
        {
            get
            {
                return usuServ.getAll().ToList();
            }
        }


        /// <summary>
        /// Almacena la lista de tipos
        /// </summary>
        public List<tipousuario> listaTipos
        {
            get
            {
                return tipoUsuServ.getAll().ToList();
            }
        }

        /// <summary>
        /// Almacena la lista de roles
        /// </summary>
        public List<rol> listaRoles
        {
            get
            {
                return rolServ.getAll().ToList();
            }
        }

        /// <summary>
        /// Almacena la lista de grupos
        /// </summary>
        public List<grupo> listaGrupos
        {
            get
            {
                return gruServ.getAll().ToList();
            }
        }
        /// <summary>
        /// Almacena la lista de departamentos
        /// </summary>
        public List<departamento> listaDepartamentos
        {
            get
            {
                return dptoServ.getAll().ToList();
            }
        }

        /// <summary>
        /// Objeto que recoge los datos de la interfaz
        /// </summary>
        public usuario usuarioNuevo //este es el que utilizamos en la capa vista
        {
            get
            {
                return usuNuevo;
            }
            set
            {
                //asi se pasa el objeto en c#
                usuNuevo = value;
                OnPropertyChanged("usuarioNuevo");
                //Esta implementacion de la interfaz hemos de ponerlo en el que recoge los datos, 
                //ponemos el nombre de la propiedad publica
            }
        }
        public bool guarda()
        {
            bool correcto = true;
            usuServ.add(usuNuevo);
            try
            {
                usuServ.save();

            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                log.Error("\nInsertando usuario ... ERROR\n" +
                    dbex.InnerException.Message + "\n" + dbex.StackTrace);
            }
            return correcto;
        }

        //Para que el usuario sea unico
        public bool usuarioUnico
        {
            get
            {
                return usuServ.usuarioUnico(usuNuevo.username);
            }
        }

        //******************************************
        //Métodos privados



        private void inicializa()
        {
            usuServ = new UsuarioServicio(invEnt);
            tipoUsuServ = new ServicioGenerico<tipousuario>(invEnt);

            rolServ = new RolServicio(invEnt);
            gruServ = new GrupoServicio(invEnt);
            dptoServ = new DptoServicio(invEnt);

        //generamos objeto nuevo
        usuNuevo = new usuario();

        }
    }
}
