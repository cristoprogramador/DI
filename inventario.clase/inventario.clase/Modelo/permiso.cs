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
    
    public partial class permiso
    {
        public permiso()
        {
            this.permiso1 = new HashSet<permiso>();
            this.permisosrol = new HashSet<permisosrol>();
        }
    
        public int idpermiso { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> permisopadre { get; set; }
    
        public virtual ICollection<permiso> permiso1 { get; set; }
        public virtual permiso permiso2 { get; set; }
        public virtual ICollection<permisosrol> permisosrol { get; set; }
    }
}
