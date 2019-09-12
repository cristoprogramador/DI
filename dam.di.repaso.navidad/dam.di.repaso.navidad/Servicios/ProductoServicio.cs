using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using dam.di.repaso.navidad.Modelo;

namespace dam.di.repaso.navidad.Servicios
{
    public class ProductoServicio : ServicioGenerico<productos>
    {
        private DbContext contexto;
        private List<productos> listaProductos;

        public ProductoServicio(DbContext context) : base(context)
        {
            contexto = context;
            listaProductos = new List<productos>();
        }

        public string getId(string gamaPro)
        {
            string idProducto = "";
            // Obtenemos los productos por gama 
            getProductosPorGama(gamaPro);
            // Obtenemos los dos primeros caracteres y añadimos el guión
            idProducto = gamaPro.Substring(0,2) + "-";
            idProducto = idProducto + getUltimoNumero().ToString();
            return idProducto.ToUpper();

        }

        private void getProductosPorGama(string gamaPro)
        {
            listaProductos = contexto.Set<productos>().Where(p => p.gamasproductos.Gama.Equals(gamaPro)).ToList();
        } 

        private int getUltimoNumero()
        {
            int max = 0;
            int numaux = 0;
            string[] palabras;
            foreach(productos p in listaProductos)
            {
                palabras = p.CodigoProducto.Split('-');
                if (palabras.Length > 1)
                {
                    numaux = Int32.Parse(palabras[1]);
                } else {
                    numaux = Int32.Parse(p.CodigoProducto);
                }
                if (numaux > max)
                    max = numaux;
            }
            return max + 1;
        }
    }
}
