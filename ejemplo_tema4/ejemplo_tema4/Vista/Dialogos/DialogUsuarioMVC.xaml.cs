using System;
using MahApps.Metro.Controls;
using ejemplo_tema4.Modelo;
using System.Collections.Generic;
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
using NLog;
using dam.di.inventario.Servicios;
using ejemplo_tema4.Servicios;
using ejemplo_tema4.Validacion;
using System.Net.Mail;

namespace ejemplo_tema4.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogUsuarioMVC.xaml
    /// </summary>
    public partial class DialogUsuarioMVC : MetroWindow
    {
        private diinventarioEntities invEnt;

        private UsuarioServicio usuServ;
        // Definimos un servicio generico para tipoUsuario
        private ServicioGenerico<tipousuario> tipoUsuarioServ;
        // Hemos definido un servicio RolServicio
        private RolServicio rolServ;
        private DptoServicio departamentoServ;
        private GrupoServicio grupoServ;

        private static Logger log = LogManager.GetCurrentClassLogger();

        private ValidaMVC valMVC;

        public DialogUsuarioMVC(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            inicializa();
        }

        private void inicializa()
        {
            valMVC = new ValidaMVC();

            usuServ = new UsuarioServicio(invEnt);
            // Definiendo tipoUsuarioServ mediante Servicio genérico
            tipoUsuarioServ = new ServicioGenerico<tipousuario>(invEnt);
            cbTipoUsuario.ItemsSource = tipoUsuarioServ.getAll().ToList();

            rolServ = new RolServicio(invEnt);
            cbRol.ItemsSource = rolServ.getAll().ToList();

            grupoServ = new GrupoServicio(invEnt);
            cbGrupo.ItemsSource = grupoServ.getAll().ToList();

            departamentoServ = new DptoServicio(invEnt);
            cbDepartamento.ItemsSource = departamentoServ.getAll().ToList();

        }

        private void recogeUsuario(usuario usu)
        {
            // Grupo 1
            usu.username = tbUsername.Text;
            usu.password = pbPassword.Password;

            usu.tipo = ((tipousuario)cbTipoUsuario.SelectedItem).idtipousuario;
            usu.rol = ((rol)cbRol.SelectedItem).idrol;

            if (cbGrupo.SelectedItem != null)
            {
                usu.grupo = ((grupo)cbGrupo.SelectedItem).idgrupo;
            }
            
            if(cbDepartamento.SelectedItem != null)
            {
                usu.departamento = ((departamento)cbDepartamento.SelectedItem).iddepartamento;
            }
           
            // Grupo 2
            usu.nombre = tbNombre.Text;
            usu.apellido1 = tbApellido1.Text;
            usu.apellido2 = tbApellido2.Text;
            usu.email = tbEmail.Text;
            usu.poblacion = tbPoblacion.Text;
            usu.codpostal = tbCodPostal.Text;
            usu.domicilio = tbDomicilio.Text;
            usu.telefono = tbTelefono.Text;
        }
        
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (Valida())
            {
                usuario usu = new usuario();
                recogeUsuario(usu);

                try
                {
                    usuServ.add(usu);
                    usuServ.save();

                    MessageBox.Show("Usuario guardado correctamente", "GESTION MODELO ARTICULOS",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    log.Info("\nInsertando un usuario ... Todo correcto");
                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar en la base de datos", "GESTION USUARIOS",
                      MessageBoxButton.OK,
                      MessageBoxImage.Error);
                    log.Error("\nInsertando un usuario" + ex.StackTrace);
                }
            }
           
        }

        private bool Valida()
        {
            bool correcto = true;
            if (valMVC.validaCadena(tbUsername.Text))
            {
                correcto = false;
                ValidaMVC.muestraError(tbUsername);
            }
            else
            {
                ValidaMVC.quitarError(tbUsername);

            }

            if (valMVC.validaCadena(pbPassword.Password))
            {
                correcto = false;
                ValidaMVC.muestraError(pbPassword);
            }
            else
            {
                ValidaMVC.quitarError(pbPassword);
            }

            if (valMVC.objetoVacio(cbRol.SelectedItem))
            {
                correcto = false;
                ValidaMVC.muestraError(cbRol);
            }
            else
            {
                ValidaMVC.quitarError(cbRol);
            }

            if (valMVC.objetoVacio(cbTipoUsuario.SelectedItem))
            {
                correcto = false;
                ValidaMVC.muestraError(cbTipoUsuario);
            }
            else
            {
                ValidaMVC.quitarError(cbTipoUsuario);
            }

            return correcto;
        }

        static bool validarEmail(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboTipoUsu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String tipoUsuario = ((tipousuario)(cbTipoUsuario.SelectedItem)).nombre;
            if (tipoUsuario.Equals("Alumno"))
            {
                cbGrupo.IsEnabled = true;
                cbDepartamento.IsEnabled = false;
            }
            else if (tipoUsuario.Equals("Profesor"))
            {
                cbDepartamento.IsEnabled = true;
                cbGrupo.IsEnabled = false;
            }

            ValidaMVC.quitarError(cbTipoUsuario);
        }

        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                ValidaMVC.muestraError(tbUsername);
            }
            else
            {
                ValidaMVC.quitarError(tbUsername);
            }
        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pbPassword.Password))
            {
                ValidaMVC.muestraError(pbPassword);
            }
            else
            {
                ValidaMVC.quitarError(pbPassword);
            }
        }

        private void cbRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidaMVC.quitarError(cbRol);
        }
    }
}
