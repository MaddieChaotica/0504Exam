﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _05._04.Exam.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VideoProkatEntities : DbContext
    {
        public VideoProkatEntities()
            : base("name=VideoProkatEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClassificationCode> ClassificationCode { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<TurnoverSheet> TurnoverSheet { get; set; }
        public virtual DbSet<Videoteka> Videoteka { get; set; }
    }
}
