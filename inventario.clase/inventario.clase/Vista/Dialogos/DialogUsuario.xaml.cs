using dam.di.inventario.Servicios;
using inventario.clase.Modelo;
using inventario.clase.Servicios;
using NLog;
using System;
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

namespace inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogUsuario.xaml
    /// </summary>
    public partial class DialogUsuario : Window
    {
        private diinventarioEntities invEnt;
     
        private UsuarioServicio usuServ;//las reglas de negocio
        private ServicioGenerico<tipousuario> tipoUsuServ; //heredamos de generico, sin hacer la clase
        private RolServicio rolServ;//hacemos la clase
        private GrupoServicio gruServ;
        private DptoServicio dptoServ;
         
        private static Logger log = LogManager.GetCurrentClassLogger();
        //en cada clase que se utiliza el log hay que poner uno para que sea mas exacta

     
        public DialogUsuario(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            usuServ = new UsuarioServicio(invEnt);
            tipoUsuServ = new ServicioGenerico<tipousuario>(invEnt);
            rolServ = new RolServicio(invEnt);
            gruServ = new GrupoServicio(invEnt);
            dptoServ = new DptoServicio(invEnt);
            comboDept.ItemsSource = dptoServ.getAll().ToList();
            comboGrupo.ItemsSource = gruServ.getAll().ToList();
            comboRol.ItemsSource = rolServ.getAll().ToList();
            comboTipo.ItemsSource = tipoUsuServ.getAll().ToList();
            
           
        }
        //aqui se recogen los que no pueden ser null
        public void recogeUsuario(usuario usu )
        {
            usu.username = tbUsername.Text;
            usu.password = pbPassword.Password;
            usu.tipo= ((tipousuario) comboTipo.SelectedItem).idtipousuario;
            usu.rol = ((rol) comboRol.SelectedItem).idrol; // en xaml displaymemberpath 
            usu.grupo = ((grupo)comboGrupo.SelectedItem).idgrupo;
            usu.departamento = ((departamento)comboDept.SelectedItem).iddepartamento;

            usu.nombre = tbName.Text;
            usu.apellido1 = tbApellido1.Text;
            usu.apellido2 = tbApellido2.Text;
            usu.domicilio = tbDomici.Text;
            usu.poblacion = tbPobl.Text;
            usu.codpostal = tbCodpos.Text;
            usu.email = tbEmail.Text;
            usu.telefono = tbTelf.Text;


        }

        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            usuario usu = new usuario();
            recogeUsuario(usu);

            try
            {
                usuServ.add(usu);
                usuServ.save();
                MessageBox.Show("Usuario guardado correctamente", "GESTIÓN USUARIOS",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                log.Info("\nInsertando un usuario... Todo correcto");

                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar en la base de datos",
                   "GESTIÓN USUARIO",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
               log.Error("Insertando un usuario: " + ex.StackTrace); 
            }


        }


        private void Button_Cancelar(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    //    private void ComboTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //    {
    //        if(((tipousuario)comboTipo.SelectedItem).nombre.Equals("Profesor"))
    //        {
    //            comboDept.IsEnabled = true;
    //            comboGrupo.IsEnabled = false;
    //        } else
    //        {
    //            comboDept.IsEnabled = false;
    //            comboGrupo.IsEnabled = true;
    //        }
    //    }
    }
}
