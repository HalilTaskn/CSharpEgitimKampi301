﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSharpEgitimKampi301.EFProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EgitimKampiEfTravelDbEntities : DbContext
    {
        public EgitimKampiEfTravelDbEntities()
            : base("name=EgitimKampiEfTravelDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Guide> Guides { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
