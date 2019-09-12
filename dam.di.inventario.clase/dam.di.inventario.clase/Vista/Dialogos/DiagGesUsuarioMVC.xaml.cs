using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using dam.di.inventario.clase.Modelo;
using dam.di.inventario.Servicios;
using NLog;

namespace dam.di.inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Interaction logic for DiagGesUsuarioMVVM.xaml
    /// </summary>
    public partial class DiagGesUsuarioMVC : Window
    {
        private diinventarioEntities invEnt;
        private UsuarioServicio usuServ;
        private ServicioGenerico<tipousuario> tipoServ;
        private DptoServicio dptoServ;
        private ServicioGenerico<rol> rolServ;
        private GrupoServicio grpServ;
        private Logger log = LogManager.GetCurrentClassLogger();

        public DiagGesUsuarioMVC(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            inicializa();
        }

        private void inicializa()
        {
            usuServ = new UsuarioServicio(invEnt);
            tipoServ = new ServicioGenerico<tipousuario>(invEnt);
            rolServ = new ServicioGenerico<rol>(invEnt);
            dptoServ = new DptoServicio(invEnt);
            grpServ = new GrupoServicio(invEnt);

            cbTipoUsuario.ItemsSource = tipoServ.getAll().ToList();
            cbRolUsuario.ItemsSource = rolServ.getAll().ToList();
            cbDepartamento.ItemsSource = dptoServ.getAll().ToList();
            cbGrupo.ItemsSource = grpServ.getAll().ToList();
        }

        private usuario recogeDatos()
        {
            usuario usu = new usuario();
            usu.apellido1 = txtApellido1.Text;
            usu.apellido2 = txtApellido2.Text;
            usu.codpostal = txtCodPostal.Text;
            usu.domicilio = txtDomicilio.Text;
            usu.email = txtMail.Text;
            usu.nombre = txtNombre.Text;
            usu.poblacion = txtPoblacion.Text;
            usu.telefono = txtTelefono.Text;
            usu.username = txtUsername.Text;
            usu.password = txtPassword.Password;
            usu.tipo = ((tipousuario)cbTipoUsuario.SelectedItem).idtipousuario;
            usu.rol = ((rol)cbRolUsuario.SelectedItem).idrol;
            if (cbDepartamento.SelectedItem != null)
                usu.departamento = ((departamento)cbDepartamento.SelectedItem).iddepartamento;
            if (cbGrupo.SelectedItem != null)
                usu.grupo = ((grupo)cbGrupo.SelectedItem).idgrupo;
            return usu;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            usuario usu = recogeDatos();
            if (usuServ.usuarioUnico(usu.username))
            {
                usuServ.add(usu);
                try
                {
                    usuServ.save();
                    MessageBox.Show("Usuario insertado correctamente", "GESTION USUARIOS", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
                catch (DbUpdateException dbex)
                {
                    log.Error("\nINSERTANDO UN USUARIO ... \n" + dbex.InnerException.Message + "\n" + dbex.StackTrace);
                    MessageBox.Show("Error al insertar el usuario", "GESTION USUARIOS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("El nombre de usuario está replicado\nCambia el nombre de usuario", "GESTION USUARIOS", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUsername.Focus();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void cbTipoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((tipousuario)cbTipoUsuario.SelectedItem).nombre.Equals("Profesor"))
            {
                cbDepartamento.IsEnabled = true;
                cbGrupo.IsEnabled = false;
            } else
            {
                cbDepartamento.IsEnabled = false;
                cbGrupo.IsEnabled = true;
            }
        }
    }
}
