using dam.di.inventario.clase.Modelo;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using dam.di.inventario.Servicios;
using System.Data.Entity.Infrastructure;

namespace dam.di.inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Interaction logic for DiagGesArticuloMVC.xaml
    /// </summary>
    public partial class DiagGesArticuloMVC : Window
    {
        private diinventarioEntities invEnt;
        private usuario usuLogin;
        private UsuarioServicio usuServ;
        private ArticuloServicio artServ;
        private ModeloArticuloServicio modServ;
        private DptoServicio dptoServ;
        private EspacioServicio espServ;
        private List<string> listaEstados = new List<string> { "Operativo", "Mantenimiento", "Baja" };
        private static Logger log = LogManager.GetCurrentClassLogger();

        public DiagGesArticuloMVC(diinventarioEntities ent, usuario usu)
        {
            InitializeComponent();
            invEnt = ent;
            usuLogin = usu;
            inicializa();
        }

        private void inicializa()
        {
            usuServ = new UsuarioServicio(invEnt);
            artServ = new ArticuloServicio(invEnt);
            modServ = new ModeloArticuloServicio(invEnt);
            dptoServ = new DptoServicio(invEnt);
            espServ = new EspacioServicio(invEnt);

            comboUsuarioAlta.SelectedItem = usuLogin;
            calFechaAlta.SelectedDate = DateTime.Now;

            comboModeloArticulo.ItemsSource = modServ.getAll().ToList();
            comboUsuarioAlta.ItemsSource = usuServ.getAll().ToList();
            comboEspacio.ItemsSource = espServ.getAll().ToList();
            comboEstadoArticulo.ItemsSource = listaEstados;
            comboArmario.ItemsSource = artServ.getAll().ToList();
            comboDepartamento.ItemsSource = dptoServ.getAll().ToList();
        }

        private articulo recogeDatos()
        {
            articulo art = new articulo();
            art.idarticulo = artServ.getLastId() + 1;
            art.modelo = ((modeloarticulo)comboModeloArticulo.SelectedItem).idmodeloarticulo;
            art.numserie = txtNumSerie.Text;
            art.observaciones = txtObservaciones.Text;
            if(comboEstadoArticulo.SelectedItem != null)
                art.estado = (string)comboEstadoArticulo.SelectedItem;
            art.espacio = ((espacio)comboEspacio.SelectedItem).idespacio;
            art.fechaalta = calFechaAlta.SelectedDate;
            art.usuarioalta = ((usuario)comboUsuarioAlta.SelectedItem).idusuario;
            if(comboDepartamento.SelectedItem != null)
                art.departamento = ((departamento)comboDepartamento.SelectedItem).iddepartamento;
            if(comboArmario.SelectedItem != null)
                art.dentrode = ((articulo)comboArmario.SelectedItem).idarticulo;
            return art;
        }

        private void btnGuardarArticulo_Click(object sender, RoutedEventArgs e)
        {
            articulo art = recogeDatos();
            if(artServ.numserieUnico(art.numserie))
            {
                artServ.add(art);
                try
                {
                    artServ.save();
                    MessageBox.Show("Artículo insertado correctamente","GESTIÓN DE ARTÍCULOS",MessageBoxButton.OK,MessageBoxImage.Information);
                    DialogResult = true;
                } catch (DbUpdateException dbex)
                {
                    log.Error("\nINSERTANDO UN NUEVO ARTICULO ... ERROR\n" + dbex.InnerException.Message + "\n" + dbex.StackTrace);
                    MessageBox.Show("Error al insertar un artículo", "GESTIÓN DE ARTÍCULOS", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Número de serie duplicado\nIntroduce otro número de serie","GESTIÓN DE ARTÍCULOS",MessageBoxButton.OK,MessageBoxImage.Warning);
                txtNumSerie.Focus();
            }
        }

        private void btnCancelarArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
