//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class PHIEUDATDICHVU
    {
        public string MaTiecCuoi { get; set; }
        public string MaDichVu { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> DonGia { get; set; }
    
        public virtual DICHVU DICHVU { get; set; }
        public virtual TIECCUOI TIECCUOI { get; set; }
    }
}
