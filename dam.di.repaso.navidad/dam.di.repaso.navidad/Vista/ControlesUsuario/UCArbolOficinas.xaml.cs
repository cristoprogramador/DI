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
using dam.di.repaso.navidad.Modelo;
using dam.di.repaso.navidad.Servicios;

namespace dam.di.repaso.navidad.Vista.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para UCArbolOficinas.xaml
    /// </summary>
    public partial class UCArbolOficinas : UserControl
    {
        private jardineriaEntities jEnt; //Entidades
        private OficinaServicio ofServ; //Servicio 
        private List<oficinas> listaOficinas;

        public UCArbolOficinas(jardineriaEntities ent)
        {
            InitializeComponent();
            jEnt = ent;
            ofServ = new OficinaServicio(jEnt);
            listaOficinas = ofServ.getAll().ToList(); //obtenemos la lista de oficinas mediante el servicio
            gridArbol.Children.Add(crearArbol()); //Añadimos al grid el arbol creado en el metodo
        }

        //Metodo para construir arbol, recorre listas y añade nodos a las listas
        private TreeView crearArbol()
        {
            TreeView arbolOficinas = new TreeView();

            TreeViewItem nodoOf;
            foreach (oficinas of in listaOficinas)
            {
                //añadimos el nodo oficinas generado al Treeview del arbol de oficinas
                nodoOf = nodoNuevo(of.Ciudad,"Oficinas.png");
              
                //Añadimos nodos empeleado al nodo oficinas
                TreeViewItem nodoEmp;
                foreach(empleados emp in of.empleados)
                {
                    nodoEmp = nodoNuevo(emp.Nombre + " " + emp.Apellido1, "Empleado.png");

                    //Añadimos nodos clientes al nodo empleados
                    TreeViewItem nodoCli;
                    foreach (clientes cli in emp.clientes)
                    {
                        nodoCli = nodoNuevo(cli.NombreCliente, "Clientes.png");
                        nodoEmp.Items.Add(nodoCli);
                    }
                    nodoOf.Items.Add(nodoEmp);
                }
                arbolOficinas.Items.Add(nodoOf);
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
            imgNodo.Source = new BitmapImage(new Uri("pack://application:,,/Recursos/Iconos/"+ path));
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
