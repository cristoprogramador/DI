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
    
    public partial class oficinas
    {
        public oficinas()
        {
            this.empleados = new HashSet<empleados>();
        }
    
        public string CodigoOficina { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Region { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string LineaDireccion1 { get; set; }
        public string LineaDireccion2 { get; set; }
    
        public virtual ICollection<empleados> empleados { get; set; }
    }
}
