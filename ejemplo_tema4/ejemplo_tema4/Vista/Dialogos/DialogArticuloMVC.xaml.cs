using dam.di.inventario.Servicios;
using ejemplo_tema4.Servicios;
using ejemplo_tema4.Modelo;
using MahApps.Metro.Controls;
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
using ejemplo_tema4.Validacion;

namespace ejemplo_tema4.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogArticuloMVC.xaml
    /// </summary>
    public partial class DialogArticuloMVC : MetroWindow
    {
        private diinventarioEntities invEnt;

        private usuario usu;

        // Vamos a definir los servicios de los comboBox

        private ArticuloServicio artServ;
        private UsuarioServicio usuServ;
        private ModeloArticuloServicio modServ;
        private DptoServicio dptoServ;
        private EspacioServicio espacioServ;

        private ValidaMVC valMVC;

        private static Logger log = LogManager.GetCurrentClassLogger();

        public DialogArticuloMVC(diinventarioEntities ent, usuario usu)
        {
            InitializeComponent();

            this.usu = usu;

            invEnt = ent;

            inicializar();
        }

        private void inicializar()
        {
            artServ = new ArticuloServicio(invEnt);
            cbEstado.ItemsSource = artServ.getAll().ToList();
            cbDentroDe.ItemsSource = artServ.getAll().ToList();

            usuServ = new UsuarioServicio(invEnt);
            cbUsuAlta.ItemsSource = usuServ.getAll().ToList();

            modServ = new ModeloArticuloServicio(invEnt);
            cbModelo.ItemsSource = modServ.getAll().ToList();

            dptoServ = new DptoServicio(invEnt);
            cbDepartamento.ItemsSource = dptoServ.getAll().ToList();

            espacioServ = new EspacioServicio(invEnt);
            cbEspacio.ItemsSource = espacioServ.getAll().ToList();

            valMVC = new ValidaMVC();
        }

        private void recogeArticulo (articulo articulo)
        {
            articulo.idarticulo = artServ.getLastId() + 1;

            if (cnrFechAlta.SelectedDate == null)
            {
                articulo.fechaalta = DateTime.Now;
            }
            else
            {
                articulo.fechaalta = cnrFechAlta.SelectedDate;
            }

            articulo.modelo = ((modeloarticulo)(cbModelo.SelectedItem)).idmodeloarticulo;
            articulo.numserie = tbNumSerie.Text;

            if (cbEstado.SelectedItem != null)
            {
                articulo.estado = ((articulo)(cbEstado.SelectedItem)).estado;
            }

            if (cbUsuAlta.SelectedItem != null)
            {
                articulo.usuarioalta = ((usuario)(cbUsuAlta.SelectedItem)).idusuario;
            }


            // Datos ubicación
            if (cbDepartamento.SelectedItem != null)
            {
                articulo.departamento = ((departamento)(cbDepartamento.SelectedItem)).iddepartamento;
            }

           
            articulo.espacio = ((espacio)(cbEspacio.SelectedItem)).idespacio;
            if (cbDentroDe.SelectedItem != null)
            {
                articulo.dentrode = ((articulo)(cbDentroDe.SelectedItem)).idarticulo;
            }
            
            articulo.observaciones = tbObservaciones.Text;
        }

        private void btnArtEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (valida())
            {
                articulo art = new articulo();
                recogeArticulo(art);

                try
                {
                    artServ.add(art);
                    artServ.save();
                    MessageBox.Show("Articulo guardado correctament", "GESTION ARTICULOS",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    log.Info("\nInsertando un articulo ... Todo correcto");
                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar en la base de datos", "GESTION MODELO ARTICULOS",
                      MessageBoxButton.OK,
                      MessageBoxImage.Error);
                    log.Error("\nInsertando un articulo" + ex.StackTrace);
                }
            }
        }

        private bool valida()
        {
            bool correcto = true;

            if (valMVC.objetoVacio(cbEspacio.SelectedItem))
            {
                correcto = false;
                ValidaMVC.muestraError(cbEspacio);
            }
            else
            {
                ValidaMVC.quitarError(cbEspacio);
            }

            if (valMVC.objetoVacio(cbModelo.SelectedItem))
            {
                correcto = false;
                ValidaMVC.muestraError(cbModelo);
            }
            else
            {
                ValidaMVC.quitarError(cbModelo);
            }

            return correcto;
        }

        private void btnArtCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbModelo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidaMVC.quitarError(cbModelo);
        }

        private void cbEspacio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidaMVC.quitarError(cbEspacio);
        }
    }
}
