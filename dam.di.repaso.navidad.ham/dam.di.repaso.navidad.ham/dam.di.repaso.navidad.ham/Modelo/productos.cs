//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dam.di.repaso.navidad.ham.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class productos
    {
        public productos()
        {
            this.detallepedidos = new HashSet<detallepedidos>();
        }
    
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Gama { get; set; }
        public string Dimensiones { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public short CantidadEnStock { get; set; }
        public decimal PrecioVenta { get; set; }
        public Nullable<decimal> PrecioProveedor { get; set; }
    
        public virtual ICollection<detallepedidos> detallepedidos { get; set; }
        public virtual gamasproductos gamasproductos { get; set; }
    }
}
