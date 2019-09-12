 using dam.di.inventario.clase.Modelo;
using dam.di.inventario.clase.Validacion;
using dam.di.inventario.Servicios;
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

namespace dam.di.inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DiagModeloArticulo.xaml
    /// </summary>
    public partial class DiagModeloArticuloMVC : Window
    {
        // Contexto de la base de datos
        private diinventarioEntities invEnt;
        // Clase de servicio para la tabla ModeloArticulo
        private ModeloArticuloServicio modServ;
        // Clase de servicio para la tabla TipoArticulo
        private TipoArticuloServicio tipServ;
        // Variable para el Log
        private static Logger log = LogManager.GetCurrentClassLogger();

        private const int NUMCAMPOSOBLIGATORIOS = 2;
        private const int CAMPO_NOMBRE = 0;
        private const int CAMPO_TIPO = 1;
        private int numerrores;
        private bool[] listaErrores = new bool[NUMCAMPOSOBLIGATORIOS];
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ent"></param>
        public DiagModeloArticuloMVC(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            inicializa();
        }
        /// <summary>
        /// Inicializa las principales variables de la clase
        /// </summary>
        private void inicializa()
        {
            modServ = new ModeloArticuloServicio(invEnt);
            tipServ = new TipoArticuloServicio(invEnt);
            comboTipo.ItemsSource = tipServ.getAll().ToList();
            numerrores = NUMCAMPOSOBLIGATORIOS;
            ErrorMVC.inicializaLista(listaErrores);
        }
        /// <summary>
        /// Manejador de eventos para el botón cancelar.
        /// Simplemente devuelve false para el dialogo del resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        /// <summary>
        /// Manejador de eventos para el botón guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (valida())
            {
                modeloarticulo modelo = new modeloarticulo();
                recogeDatos(modelo);
                try
                {
                    // Guarda el objeto en caché del ORM
                    modServ.add(modelo);
                    // Realiza el commit contra la base de datos
                    modServ.save();
                    MessageBox.Show("Modelo de artículo insertado correctamente", "GESTION MODELO ATICULOS", MessageBoxButton.OK, MessageBoxImage.Information);
                    log.Info("Insertando un modelo de articulo ... Todo correcto");
                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    log.Error("Insertando un modelo de articulo ... \n" + ex.StackTrace);
                    MessageBox.Show("Error al insertar el modelo de artículo", "GESTION MODELO ATICULOS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Recoge los datos de los componentes de la interfaz
        /// </summary>
        /// <param name="modelo"></param>
        private void recogeDatos(modeloarticulo modelo)
        {
            modelo.nombre = txtNombre.Text;
            modelo.marca = txtMarca.Text;
            modelo.modelo = txtModelo.Text;
            modelo.descripcion = txtDescripcion.Text;
            // Recoge el identificador del tipo de artículo del elemento seleccionado del combo
            modelo.tipo = ((tipoarticulo)(comboTipo.SelectedItem)).idtipoarticulo;
        }

        private bool valida()
        {
            bool correcto = true;
            // En caso de que haya errores
            if (numerrores > 0)
            {
                // Si el campo nombre está vacío
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    // Muestro el error
                    ErrorMVC.muestraError(imgErrorNombre, txtNombre);
                    // Si no está activo
                    if (!listaErrores[CAMPO_NOMBRE])
                    {
                        numerrores++;
                        listaErrores[CAMPO_NOMBRE] = true;
                    }
                }
                // Si no selecciono nada 
                if (comboTipo.SelectedItem == null)
                {
                    // muestro el error
                    ErrorMVC.muestraError(imgErrorTipo, comboTipo);
                    if (!listaErrores[CAMPO_TIPO])
                    {
                        numerrores++;
                        listaErrores[CAMPO_TIPO] = true;
                    }
                }
                correcto = false;
            }
            return correcto;
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Si el campo está vacío
            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                // Si no hay error
                if (!listaErrores[CAMPO_NOMBRE])
                {
                    // Mostramos el error
                    ErrorMVC.muestraError(imgErrorNombre, txtNombre);
                    numerrores++;
                    listaErrores[CAMPO_NOMBRE] = true;
                }
            } else // Si el campo no está vacío
            {
                // Si hay error
                if (listaErrores[CAMPO_NOMBRE])
                {
                    // Quitamos el error
                    ErrorMVC.quitaError(imgErrorNombre, txtNombre);
                    numerrores--;
                    listaErrores[CAMPO_NOMBRE] = false;
                }
            }
        }

        private void comboTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboTipo.SelectedItem == null)
            {
                if (!listaErrores[CAMPO_TIPO])
                {
                    ErrorMVC.muestraError(imgErrorTipo, comboTipo);
                    numerrores++;
                    listaErrores[CAMPO_TIPO] = true;
                }
            } else
            {
                if (listaErrores[CAMPO_TIPO])
                {
                    ErrorMVC.quitaError(imgErrorTipo, comboTipo);
                    numerrores--;
                    listaErrores[CAMPO_TIPO] = false;
                }
            }
        }
    }
}
