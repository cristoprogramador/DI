  using dam.di.inventario.Servicios;
using ejemplo_tema4.Modelo;
using ejemplo_tema4.Validacion;
using MahApps.Metro.Controls;
using NLog;
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

namespace ejemplo_tema4.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogModeloArticuloMVC.xaml
    /// </summary>
    public partial class DialogModeloArticuloMVC : MetroWindow
    {
        private diinventarioEntities invEnt;

        private ModeloArticuloServicio modServ;

        private TipoArticuloServicio tipoServ;
       
        private static Logger log = LogManager.GetCurrentClassLogger();

        /*Creamos variables para validar objetos*/
        private ValidaMVC valMVC;

        public DialogModeloArticuloMVC(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            inicializa();
        }

        private void inicializa()
        {
            valMVC = new ValidaMVC();

            modServ = new ModeloArticuloServicio(invEnt);

            tipoServ = new TipoArticuloServicio(invEnt);
            comboTipo.ItemsSource = tipoServ.getAll().ToList();
        }

        private void recogeModelo (modeloarticulo modelo)
        {
            modelo.nombre = txtNombre.Text;
            modelo.marca = txtMarca.Text;
            modelo.modelo = txtModelo.Text;
            modelo.descripcion = txtDescripcion.Text;
            modelo.tipo = ((tipoarticulo)(comboTipo.SelectedItem)).idtipoarticulo;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (valida())
            {
                modeloarticulo modelo = new modeloarticulo();
                recogeModelo(modelo);

                try
                {
                    modServ.add(modelo); // Guarda en cache
                    modServ.save(); // Save para acceder a la bbdd
                    MessageBox.Show("Modelo de articulo guardado correctamente",
                        "GESTION MODELO ARTÍCULOS",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    log.Info("\nInsertando un modelo de articulo ... Todo correcto");
                    // Devuelve true y cierra el dialogo
                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    // Muestro un mensaje al usuario en caso de error
                    MessageBox.Show("Error al insertar en la base de datos",
                        "GESTIÓN MODELO ARTÍCULO",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    // Lo registra como un error. Importante poner el stack trace para saber que esta pasando
                    log.Error("\nInsertando un modelo de articulo: " + ex.StackTrace);
                }
            }
            
        }

        private bool valida()
        {
            bool correcto = true;
            if (valMVC.validaCadena(txtNombre.Text))
            {
                correcto = false;
                ValidaMVC.muestraError(txtNombre);
            }
            else
            {
                ValidaMVC.quitarError(txtNombre);

            }

            if (valMVC.objetoVacio(comboTipo.SelectedItem))
            {
                correcto = false;
                ValidaMVC.muestraError(comboTipo);
            }
            else
            {
                ValidaMVC.quitarError(comboTipo);
            }

            return correcto;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        /*Estos dos metodos sirven para cuando estas validando, conforme escribes
         el recuadro rojo desaparezca por que dejara de estar a null automaticamente*/
        private void txt_Nombre_TextChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                ValidaMVC.muestraError(txtNombre);
            }
            else
            {
                ValidaMVC.quitarError(txtNombre);
            }
        }

        private void comboTipo_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ValidaMVC.quitarError(comboTipo);
        }
    }
}
