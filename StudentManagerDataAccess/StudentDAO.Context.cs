﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagerDataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebAdminDBEntities : DbContext
    {
        public WebAdminDBEntities()
            : base("name=WebAdminDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountStudent> AccountStudents { get; set; }
        public virtual DbSet<ClassDetail> ClassDetails { get; set; }
        public virtual DbSet<ClassDetailSlot> ClassDetailSlots { get; set; }
        public virtual DbSet<ClassDetailStudent> ClassDetailStudents { get; set; }
        public virtual DbSet<ClassRequest> ClassRequests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
    }
}
