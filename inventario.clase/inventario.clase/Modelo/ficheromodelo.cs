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
    
    public partial class ficheromodelo
    {
        public int idficheromodelo { get; set; }
        public int modelo { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public byte[] contenido { get; set; }
    
        public virtual modeloarticulo modeloarticulo { get; set; }
    }
}
