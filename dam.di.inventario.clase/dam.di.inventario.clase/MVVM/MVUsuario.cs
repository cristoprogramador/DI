using dam.di.inventario.clase.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dam.di.inventario.Servicios;
using System.Data.Entity.Infrastructure;
using NLog;

namespace dam.di.inventario.clase.MVVM
{
    
    public class MVUsuario : MVBase
    {
        private diinventarioEntities invEnt;
        private DptoServicio dptoServ;
        private GrupoServicio grpServ;
        private ServicioGenerico<tipousuario> tipoServ;
        private ServicioGenerico<rol> rolServ;
        private UsuarioServicio usuServ;
        private usuario usuNuevo;
        private static Logger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MVUsuario(diinventarioEntities ent)
        {
            invEnt = ent;
            inicializa();
        }
        /// <summary>
        /// Método privado que inicializa las variables
        /// </summary>
        private void inicializa()
        {
            dptoServ = new DptoServicio(invEnt);
            grpServ = new GrupoServicio(invEnt);
            tipoServ = new ServicioGenerico<tipousuario>(invEnt);
            rolServ = new ServicioGenerico<rol>(invEnt);
            usuServ = new UsuarioServicio(invEnt);
            usuNuevo = new usuario();
        }
        /// <summary>
        /// Propiedad que contiene los departamentos
        /// </summary>
        public List<departamento> listaDptos
        {
            get
            {
                return dptoServ.getAll().ToList();
            }
        }
        /// <summary>
        /// Propiedad que contiene los grupos
        /// </summary>
        public List<grupo> listaGrupos
        {
            get
            {
                return grpServ.getAll().ToList();
            }
        }
        /// <summary>
        /// Propiedad que contiene los tipos de usuario
        /// </summary>
        public List<tipousuario> listaTipos
        {
            get
            {
                return tipoServ.getAll().ToList();
            }
        }
        /// <summary>
        /// Propiedad que contiene la lista de roles
        /// </summary>
        public List<rol> listaRoles
        {
            get
            {
                return rolServ.getAll().ToList();
            }
        }
        
        public usuario usuarioNuevo
        {
            get
            {
                return usuNuevo;
            }
            set
            {
                usuNuevo = value;
                OnPropertyChanged("usuarioNuevo");
            }
        }

        public bool guarda()
        {
            bool correcto = true;
            usuServ.add(usuNuevo);
            try
            {
                usuServ.save();
            } catch (DbUpdateException dbex)
            {
                correcto = false;
                log.Error("\nINSERTANDO UN NUEVO USUARIO ... ERROR\n" +
                    dbex.InnerException.Message + "\n" + dbex.StackTrace);
            }
            return correcto;
        }

        public bool usuarioUnico
        {
            get
            {
                return usuServ.usuarioUnico(usuNuevo.username);
            }
        }
    }
}
