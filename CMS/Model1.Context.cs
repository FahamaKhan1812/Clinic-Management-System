﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class tempOfficeEntities : DbContext
    {
        public tempOfficeEntities()
            : base("name=tempOfficeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<emp> emps { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<CMS.Models.Memebership> Memeberships { get; set; }
    }
}
