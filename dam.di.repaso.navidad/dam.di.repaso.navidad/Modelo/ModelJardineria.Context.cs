﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dam.di.repaso.navidad.Modelo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class jardineriaEntities : DbContext
    {
        public jardineriaEntities()
            : base("name=jardineriaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<clientes> clientes { get; set; }
        public DbSet<detallepedidos> detallepedidos { get; set; }
        public DbSet<empleados> empleados { get; set; }
        public DbSet<gamasproductos> gamasproductos { get; set; }
        public DbSet<oficinas> oficinas { get; set; }
        public DbSet<pagos> pagos { get; set; }
        public DbSet<pedidos> pedidos { get; set; }
        public DbSet<productos> productos { get; set; }
    }
}
