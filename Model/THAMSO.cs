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
    using QuanLyTiecCuoi.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class THAMSO: BaseViewModel
    {
        private string _TenThamSo;
        private double _GiaTri;

        public string TenThamSo { get => _TenThamSo; set { _TenThamSo = value;OnPropertyChanged(); } }
        public double GiaTri { get => _GiaTri; set { _GiaTri = value;OnPropertyChanged(); } }
    }
}
