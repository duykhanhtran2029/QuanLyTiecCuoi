﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTiecCuoi.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyTiecCuoiEntities : DbContext
    {
        public QuanLyTiecCuoiEntities()
            : base("QuanLyTiecCuoiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAOCAONGAY> BAOCAONGAYs { get; set; }
        public virtual DbSet<BAOCAOTHANG> BAOCAOTHANGs { get; set; }
        public virtual DbSet<CA> CAs { get; set; }
        public virtual DbSet<CHUCNANG> CHUCNANGs { get; set; }
        public virtual DbSet<DICHVU> DICHVUs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<LOAIBAN> LOAIBANs { get; set; }
        public virtual DbSet<LOAISANH> LOAISANHs { get; set; }
        public virtual DbSet<MONAN> MONANs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
        public virtual DbSet<PHIEUDATBAN> PHIEUDATBANs { get; set; }
        public virtual DbSet<PHIEUDATDICHVU> PHIEUDATDICHVUs { get; set; }
        public virtual DbSet<SANH> SANHs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TIECCUOI> TIECCUOIs { get; set; }
    }
}
