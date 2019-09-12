using dam.di.inventario.Servicios;
using inventario.clase.Modelo;
using inventario.clase.Validacion;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace inventario.clase.Vista.Dialogos
{
    /// <summary>
    /// Lógica de interacción 
    /// </summary>
    public partial class DialogModeloArticuloMVC : Window
    {
        private diinventarioEntities invEnt;
        private TipoArticuloServicio tipoServ;
        private ModeloArticuloServicio modServ;
        private ValidaMVC valMVC; 
        private static Logger log = LogManager.GetCurrentClassLogger();
        //en cada clase que se utiliza el log hay que poner uno para que sea mas exacta

        public DialogModeloArticuloMVC(diinventarioEntities ent)
        {
            InitializeComponent();
            invEnt = ent;
            inicializa();
        }

        private void inicializa()
        {
            tipoServ = new TipoArticuloServicio(invEnt);
            modServ = new ModeloArticuloServicio(invEnt);
            comboTipo.ItemsSource = tipoServ.getAll().ToList();
            //me hace un toString y me sale la referencia, vamos al combobox de xaml y le pongo displaymemberpath y que me enseñe el nombre
            valMVC = new ValidaMVC();
        
    }
        private void recogeModelo(modeloarticulo modelo)
        {
            modelo.nombre = txtNombre.Text;
            modelo.marca = txtMarca.Text;
            modelo.modelo = txtModelo.Text;
            modelo.descripcion = txtDescripcion.Text;
            //en tipo tengo que hacer un casting es un combobox con el elemento seleccionado(propiedad selecteditem)
            modelo.tipo = ((tipoarticulo) comboTipo.SelectedItem).idtipoarticulo;
        }


        private void btnGuardar_Click_1(object sender, RoutedEventArgs e)
        {
            if (valida()) { 
            modeloarticulo modelo = new modeloarticulo();
            recogeModelo(modelo);
            try
            {
                modServ.add(modelo); //es un insert
                modServ.save(); //commit, el que puede dar error(bd caida por ejemplo)
                MessageBox.Show("Modelo de articulo guardado correctamente", "GESTIÓN MODELO ARTÍCULOS",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                log.Info("\nInsertando un modelo de articulo ... Todo correcto");


                //Devuelve true y cierra el dialogo
                DialogResult = true;

            } catch (Exception ex)
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

        private bool valida()
        {
            bool correcto = true;
            if (valMVC.validaCadena( txtNombre.Text))
            {
                correcto = false;
                ValidaMVC.muestraError(txtNombre);
            }
            else
            {
                ValidaMVC.quitaError(txtNombre);
            }

            if (valMVC.objetoNoNulo(comboTipo.SelectedItem))
            {
                correcto = false;
                ValidaMVC.muestraError(comboTipo);
            }
            else
            {
                ValidaMVC.quitaError(comboTipo);
            }
            return correcto;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
