﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JWConvention
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class wlakerstoursdbEntities : DbContext
    {
        public wlakerstoursdbEntities()
            : base("name=wlakerstoursdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<JW_GroupID> JW_GroupID { get; set; }
        public virtual DbSet<JW_Users> JW_Users { get; set; }
        public virtual DbSet<JW_Hotels> JW_Hotels { get; set; }
        public virtual DbSet<JW_Rooms> JW_Rooms { get; set; }
    }
}
