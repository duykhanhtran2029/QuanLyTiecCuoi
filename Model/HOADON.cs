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
    
    public partial class HOADON
    {
        public string MaHoaDon { get; set; }
        public Nullable<decimal> TongTienBan { get; set; }
        public Nullable<decimal> TongTienDichVu { get; set; }
        public Nullable<decimal> TongTienHoaDon { get; set; }
        public Nullable<decimal> ConLai { get; set; }
        public Nullable<System.DateTime> NgayThanhToan { get; set; }
        public string MaDatTiec { get; set; }
    
        public virtual TIECCUOI TIECCUOI { get; set; }
    }
}
