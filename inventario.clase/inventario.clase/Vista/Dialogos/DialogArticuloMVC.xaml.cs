using dam.di.inventario.Servicios;
using inventario.clase.Modelo;
using inventario.clase.Validacion;
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
    /// Lógica de interacción para DialogArticuloMVC.xaml
    /// </summary>
    /// 

    //numero de serie tiene que ser único

    public partial class DialogArticuloMVC : Window
    {
        private diinventarioEntities invEnt;
        private usuario usuLogin;
        private UsuarioServicio usuServ;
        private ArticuloServicio artServ;
        private EspacioServicio espServ;
        private ModeloArticuloServicio modServ;
        private DptoServicio dptoServicio;
        private List<string> listaEstados = new List<string> { "Operativo", "Mantenimiento", "Baja" };
        private ValidaMVC valMVC;
        private static Logger log = LogManager.GetCurrentClassLogger();
        private bool listo = false;


        //si le pasamos aqui el usuario podemos gestionarlo en el dialog, en un combo
        public DialogArticuloMVC(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            //usuLogin = usu;
            inicializa();

        }




        private void inicializa()
        {
            usuServ = new UsuarioServicio(invEnt);
            dptoServicio = new DptoServicio(invEnt);
            modServ = new ModeloArticuloServicio(invEnt);
            artServ = new ArticuloServicio(invEnt);
            espServ = new EspacioServicio(invEnt);

            comboUsuarioAlta.ItemsSource = usuServ.getAll().ToList();
            comboDept.ItemsSource = dptoServicio.getAll().ToList();
            comboEspacio.ItemsSource = espServ.getAll().ToList();
            comboModelo.ItemsSource = modServ.getAll().ToList();
            comboDentrode.ItemsSource = artServ.getAll().ToList();
            dpFechaAlta.SelectedDate = DateTime.Now;
            valMVC = new ValidaMVC();

        }
        private void recogeArticulo(articulo art)
        {
            //para los que no son auto incremento
            art.idarticulo = artServ.getLastId() + 1;
            art.fechaalta = dpFechaAlta.DisplayDateStart;

            if (comboUsuarioAlta.SelectedItem != null)
            {
                art.usuarioalta = ((usuario)(comboUsuarioAlta.SelectedItem)).idusuario;
            }

            
           
            art.dentrode = ((articulo)comboDentrode.SelectedItem).idarticulo;
            art.modelo = ((modeloarticulo)comboModelo.SelectedItem).idmodeloarticulo;
            art.espacio = ((espacio)comboEspacio.SelectedItem).idespacio;
            art.departamento = ((departamento)comboDept.SelectedItem).iddepartamento;

            art.estado = tbEstado.Text;
            art.observaciones = tbObserv.Text;

            //en tipo tengo que hacer un casting es un combobox con el elemento seleccionado(propiedad selecteditem)

        }

        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            if (valida())
            {
                articulo art = new articulo();
                recogeArticulo(art);

                try
                {
                    artServ.add(art); //es un insert
                    artServ.save(); //commit, el que puede dar error(bd caida por ejemplo)
                    MessageBox.Show("Modelo de articulo guardado correctamente", "GESTIÓN MODELO ARTÍCULOS",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                    log.Info("\nInsertando un modelo de articulo ... Todo correcto");


                    //Devuelve true y cierra el dialogo
                    DialogResult = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar en la base de datos",
                        "GESTIÓN MODELO ARTÍCULO",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    log.Error("Insertando un modelo de articulo: " + ex.StackTrace);
                    //Poner la excepcion en StackTrace para ver que esta pasando

                }
            }
        }

        //Asi validams los textbox
        private bool valida() {
            bool listo = true;

            if (valMVC.objetoNoNulo(comboModelo.SelectedItem))
            {
                ValidaMVC.muestraError(comboModelo);
                listo = false;

            }
            else {
                ValidaMVC.quitaError(comboModelo);
               
            }

            if (valMVC.objetoNoNulo(comboEspacio.SelectedItem))
            {
                ValidaMVC.muestraError(comboEspacio);
                listo = false;

            }
            else
            {
                ValidaMVC.quitaError(comboEspacio);
               
            }
            return listo;
        }
     

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        //asi validamos los combobox
        private void comboModelo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidaMVC.quitaError(comboModelo);
        }

        private void comboEspacio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidaMVC.quitaError(comboEspacio);
        }
    }

}

