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
    
    public partial class TIECCUOI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIECCUOI()
        {
            this.HOADONs = new HashSet<HOADON>();
            this.PHIEUDATBANs = new HashSet<PHIEUDATBAN>();
            this.PHIEUDATDICHVUs = new HashSet<PHIEUDATDICHVU>();
        }
    
        public string MaTiecCuoi { get; set; }
        public string TenChuRe { get; set; }
        public string TenCoDau { get; set; }
        public string SoDienThoai { get; set; }
        public Nullable<System.DateTime> NgayDatTiec { get; set; }
        public Nullable<System.DateTime> NgayDaiTiec { get; set; }
        public Nullable<decimal> TienDatCoc { get; set; }
        public string GhiChu { get; set; }
        public string MaSanh { get; set; }
        public string MaCa { get; set; }
    
        public virtual CA CA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDATBAN> PHIEUDATBANs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDATDICHVU> PHIEUDATDICHVUs { get; set; }
        public virtual SANH SANH { get; set; }
    }
}
