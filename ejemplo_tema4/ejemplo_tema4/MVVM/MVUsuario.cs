using dam.di.inventario.Servicios;
using ejemplo_tema4.Modelo;
using ejemplo_tema4.Servicios;
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
    public class MVUsuario : MVBase
    {
        // Variable que accede a la base de datos
        private diinventarioEntities invEnt;
        // Objeto usuario, que será insertado en la base de datos
        private usuario usuNuevo;
        // Usuario Servicio (Metodos)
        private UsuarioServicio usuServ;
        
        // Definimos los servicios de los componentes que tienen combo box para poder
        // acceder a los metodos, y poder mostrar correctamente la laista de datos

        // Definimos un servicio generico para tipoUsuario
        private ServicioGenerico<tipousuario> tipoUsuarioServ;
       
        // Hemos definido un servicio RolServicio
        private RolServicio rolServ;
        private DptoServicio departamentoServ;
        private GrupoServicio grupoServ;

        private static Logger log = LogManager.GetCurrentClassLogger();
        ListCollectionView lista;
        private grupo grpo;

        public MVUsuario(diinventarioEntities ent)
        {
            invEnt = ent;
            inicializa();
        }

        // Metodos privados
        private void inicializa()
        {
            usuNuevo = new usuario();
            usuServ = new UsuarioServicio(invEnt);
            // Listas del combo Box
            departamentoServ = new DptoServicio(invEnt);
            grupoServ = new GrupoServicio(invEnt);
             // Definiendo tipoUsuarioServ mediante Servicio genérico
            tipoUsuarioServ = new ServicioGenerico<tipousuario>(invEnt);
            rolServ = new RolServicio(invEnt);

            lista = new ListCollectionView(usuServ.getAll().ToList());
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
                OnPropertyChanged("usuNuevo"); // Interfaz que permite que el binding se haga automaticamente
            }
        }

        public List<usuario> listaUsuarios
        {
            get { return usuServ.getAll().ToList(); }
        }

        public ListCollectionView listaCollectionUsuarios
        {
            get
            {
                return lista;
            }
        }

        public grupo grupoSeleccionado
        {
            get
            {
                return grpo;
            }
            set
            {
                grpo = value;
                OnPropertyChanged("grupoSeleccionado");
            }
        }

        public List<departamento> listaDepartamentos
        {
            get
            {
                return departamentoServ.getAll().ToList();
            }
        }

        public List<grupo> listaGrupos
        {
            get
            {
                return grupoServ.getAll().ToList();
            }
        }

        public List<tipousuario> listaTipoUsuario
        {
            get
            {
                return tipoUsuarioServ.getAll().ToList();
            }
        }

        public List<rol> listaRoles
        {
            get
            {
                return rolServ.getAll().ToList();
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
            catch (DbUpdateException dbEx)
            {
                correcto = false;
                log.Error("INSERTANDO USUARIO ... ERROR\n" +
                    dbEx.InnerException.Message + "\n" + dbEx.StackTrace);
            }

            return correcto;
        }

        // Creamos este metodo para que no se pueda introducir un usuario que ya existe
        public bool usuarioUnico
        {
            get
            {
                return usuServ.usuarioUnico(usuNuevo.username);
            }
        }
    }
}
