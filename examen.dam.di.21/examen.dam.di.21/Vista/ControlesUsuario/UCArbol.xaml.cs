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
using System.Windows.Navigation;
using System.Windows.Shapes;
using examen.dam.di._21.Modelo;
using examen.dam.di._21.Servicios;

namespace examen.dam.di._21.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCArbol.xaml
    /// </summary>
    public partial class UCArbol : UserControl
    {
        private aerolineasEntities aEnt;
        private ServicioAvion serAviones;
        private List<avion> listaAviones;

        public UCArbol(aerolineasEntities ent)
        {
            InitializeComponent();
            aEnt = ent;
            serAviones = new ServicioAvion(aEnt);
            listaAviones = serAviones.getAll().ToList();
            gridArbol.Children.Add(crearArbol());
        }

        //Metodo para construir arbol, recorre listas y añade nodos a las listas
        private TreeView crearArbol()
        {
            TreeView arbolOficinas = new TreeView();

            TreeViewItem nodoAv;
            foreach (avion av in listaAviones)
            {         
                nodoAv = nodoNuevo(av.Nombre, "avion.png");

                TreeViewItem nodoRev;
                foreach (revisiones rv in av.revisiones)
                {

                    nodoRev = nodoNuevo(rv.Matricula, null);
                    nodoAv.Items.Add(nodoRev);
  
                   
                }
                TreeViewItem nodoVu;
                foreach (vuelos vu in av.vuelos)
                {
                    nodoVu = nodoNuevo(vu.Codigo_Ciudad_Eixida, null); ;
                    nodoAv.Items.Add(nodoVu);
                }
                arbolOficinas.Items.Add(nodoAv);
            }
            return arbolOficinas;
        }

        //Metodos que genera nodo, le damos una serie de parametros y nos genera un nodo
        private TreeViewItem nodoNuevo(string texto, string path)
        {
            //Generar los objetos necesarios
            TreeViewItem nodo = new TreeViewItem();//objeto a devolver
            StackPanel stNodo = new StackPanel();
            Label lblNodo = new Label();
            Image imgNodo = new Image();

            //Configurar los objetos
            stNodo.Orientation = Orientation.Horizontal;
            lblNodo.Content = texto;
            imgNodo.Source = new BitmapImage(new Uri("pack://application:,,/Recursos/Iconos/" + path));
            // El pack://application: indica la dirección relativa a la palicación
            imgNodo.Height = 16;

            //Asignamos los objetos a nuestro panel
            stNodo.Children.Add(imgNodo);
            stNodo.Children.Add(lblNodo);
            //Añadimos el panel al nodo
            nodo.Header = stNodo;
            return nodo;
        }
    }
}
