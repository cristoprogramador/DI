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
    
    public partial class club : MVBase
    {
        public int cod { get; set; }
        public string nombre { get; set; }
        public string sede { get; set; }
        public Nullable<short> num { get; set; }
        public int cod_gru { get; set; }
    
        public virtual grupo grupo { get; set; }
    }
}