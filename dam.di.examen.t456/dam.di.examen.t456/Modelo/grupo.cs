//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dam.di.examen.t456.Modelo
{
    using dam.di.examen.t456.MVVM;
    using System;
    using System.Collections.Generic;
    
    public partial class grupo : MVBase
    {
        public grupo()
        {
            this.club = new HashSet<club>();
            this.disco = new HashSet<disco>();
            this.pertenece = new HashSet<pertenece>();
        }
    
        public int cod { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string pais { get; set; }
    
        public virtual ICollection<club> club { get; set; }
        public virtual ICollection<disco> disco { get; set; }
        public virtual ICollection<pertenece> pertenece { get; set; }
    }
}
