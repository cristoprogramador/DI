//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace inventario.clase.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class espacio
    {
        public espacio()
        {
            this.articulo = new HashSet<articulo>();
            this.espacio1 = new HashSet<espacio>();
        }
    
        public int idespacio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> padre { get; set; }
    
        public virtual ICollection<articulo> articulo { get; set; }
        public virtual ICollection<espacio> espacio1 { get; set; }
        public virtual espacio espacio2 { get; set; }
    }
}
