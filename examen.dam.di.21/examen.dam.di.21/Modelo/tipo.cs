//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace examen.dam.di._21.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipo
    {
        public tipo()
        {
            this.avion = new HashSet<avion>();
        }
    
        public string Clase { get; set; }
        public string Nombre_Fabricante { get; set; }
        public int Peso { get; set; }
        public long Alcance { get; set; }
        public long Numero_asientos { get; set; }
        public float Longitud { get; set; }
    
        public virtual ICollection<avion> avion { get; set; }
    }
}
