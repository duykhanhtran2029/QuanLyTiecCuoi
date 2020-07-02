﻿using System;
using QuanLyTiecCuoi.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;

namespace QuanLyTiecCuoi.ViewModel
{
    class HoaDonViewModel : BaseViewModel
    {
        private static ObservableCollection<HOADON> _List;
        public static ObservableCollection<HOADON> List { get => _List; set { _List = value; } }

        private HOADON _SelectedItem;
        

        public HOADON SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {              
                    TongTienBan = SelectedItem.TongTienBan;
                    TongTienDichVu = SelectedItem.TongTienDichVu;
                    TongTienHoaDon = SelectedItem.TongTienHoaDon;
                    ConLai = SelectedItem.ConLai;
                    NgayThanhToan = SelectedItem.NgayThanhToan;
                }
            }
        }

        private decimal _TongTienBan;
        public decimal TongTienBan { get => _TongTienBan; set { _TongTienBan = value; OnPropertyChanged(); } }


        private decimal _TongTienDichVu;
        public decimal TongTienDichVu { get => _TongTienDichVu; set { _TongTienDichVu = value; OnPropertyChanged(); } }


        private decimal _TongTienHoaDon;
        public decimal TongTienHoaDon { get => _TongTienHoaDon; set { _TongTienHoaDon = value; OnPropertyChanged(); } }


        private decimal _ConLai;
        public decimal ConLai { get => _ConLai; set { _ConLai = value; OnPropertyChanged(); } }


        private DateTime _NgayThanhToan;
        public DateTime NgayThanhToan { get => _NgayThanhToan; set { _NgayThanhToan = value; OnPropertyChanged(); } }

        // command
        public ICommand DoubleClickCommand { get; set; }
        public ICommand LuuHoaDon { get; set; }
        public ICommand InHoaDon { get; set; }
        public ICommand DoubleClickCommandCT_Phieu { get; set; }

        // Get data
        private ObservableCollection<TIECCUOI> _ListTiecCuoi;
        public ObservableCollection<TIECCUOI> ListTiecCuoi { get => _ListTiecCuoi; set { _ListTiecCuoi = value; OnPropertyChanged(); } }

        public ObservableCollection<TIECCUOI> _ListTiecCuoi2;
        public ObservableCollection<TIECCUOI> ListTiecCuoi2 { get => _ListTiecCuoi2; set { _ListTiecCuoi2 = value; OnPropertyChanged(); } }

        public ObservableCollection<PHIEUDATBAN> _ListPhieuDatBan;
        public ObservableCollection<PHIEUDATBAN> ListPhieuDatBan { get => _ListPhieuDatBan; set { _ListPhieuDatBan = value; OnPropertyChanged(); } }

        public ObservableCollection<PHIEUDATDICHVU> _ListPhieuDatDichVu;
        public ObservableCollection<PHIEUDATDICHVU> ListPhieuDatDichVu { get => _ListPhieuDatDichVu; set { _ListPhieuDatDichVu = value; OnPropertyChanged(); } }

        public ObservableCollection<CT_PHIEUDATBAN> _ListCT_PhieuDatBan;
        public ObservableCollection<CT_PHIEUDATBAN> ListCT_PhieuDatBan { get => _ListCT_PhieuDatBan; set { _ListCT_PhieuDatBan = value; OnPropertyChanged(); } }

        public ObservableCollection<THAMSO> _ListThamSo;
        public ObservableCollection<THAMSO> ListThamSo { get => _ListThamSo; set { _ListThamSo = value; OnPropertyChanged(); } }


        // Create variable

        public int idTiecCuoi = 0;
        public string TongSoBan = "";
        public int id = 0;


        //public string TenChuRe { get; set; }

        //public string TenCoDau { get; set; }

        public System.DateTime NgayDaiTiec { get; set; }//= DateTime.Now;




        public int SoLuong { get; set; }
        public int SoLuongDuTru { get; set; }
        public decimal DonGiaBan { get; set; }


        public string TienDatCoc { get; set; }


        //public int MaDichVu { get; set; }
        //public string TenDichVu { get; set; }
        public decimal DonGia { get; set; }

        //public int MaTiecCuoi { get; set; }

        public decimal ThanhTien { get; set; }

        //public string TenMonAn { get; set; }
        //public string DonGiaMonAn { get; set; }

        //public string SoLuongMon { get; set; }

        private decimal _TienPhat;
        public decimal TienPhat { get => _TienPhat; set { _TienPhat = value; OnPropertyChanged(); } }

        public HoaDonViewModel()
        {
            this.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == "Model")
                {
                    OnPropertyChanged("HoaDonViewModelProperty");
                    // Add other properties "dependent" on Model here...
                }
            };
            ListTiecCuoi = new ObservableCollection<TIECCUOI>(DataProvider.Ins.DataBase.TIECCUOIs);
            List = new ObservableCollection<HOADON>(DataProvider.Ins.DataBase.HOADONs);

            DataGridCollection = CollectionViewSource.GetDefaultView(List);
            DataGridCollection.Filter = new Predicate<object>(Filter);
            DoubleClickCommand = new RelayCommand<DataGrid>((p) => { return true; },
                (p) => {
                    idTiecCuoi = _getMaTiecCuoi(p);
                    HoaDon hd = new HoaDon();
                    data();
                    
                    hd.DataContext = List;
                    hd.DataContext = ListTiecCuoi2;
                    hd.DataContext = ListTiecCuoi;
                    hd.DataContext = ListPhieuDatBan;
                    hd.DataContext = ListPhieuDatDichVu;                  
                    hd.ShowDialog();
                });
            LuuHoaDon = new RelayCommand<HoaDon>((p) =>
            {
                var hoadon = DataProvider.Ins.DataBase.HOADONs.Where(x => x.MaTiecCuoi == idTiecCuoi);
                if (hoadon == null || hoadon.Count() != 0)
                    return false;
                return true;

            }, (p) =>
            {
                MessageBox.Show("Done");
                var hoadon = new HOADON() { MaTiecCuoi = idTiecCuoi, TongTienBan = TongTienBan,
                    NgayThanhToan = NgayDaiTiec, ConLai = ConLai, TongTienDichVu = TongTienDichVu, TongTienHoaDon = TongTienHoaDon };
                DataProvider.Ins.DataBase.HOADONs.Add(hoadon);
                DataProvider.Ins.DataBase.SaveChanges();
                TinhLaiBaoCaoThang();
                TinhLaiBaoCaoNgay();
            });
            InHoaDon = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => 
            {
                
            });
            DoubleClickCommandCT_Phieu = new RelayCommand<DataGrid>((p) => { return true; },
                (p) =>
                {
                    id = _getMaPhieuDatBan(p);
                    CT_PhieuDatBanxaml ct_Phieu = new CT_PhieuDatBanxaml();
                    ListCT_PhieuDatBan = new ObservableCollection<CT_PHIEUDATBAN>(DataProvider.Ins.DataBase.CT_PHIEUDATBAN.Where(x => x.MaPhieuDatBan == id));
                    DataProvider.Ins.DataBase.SaveChanges();
                    if (ListCT_PhieuDatBan == null || ListCT_PhieuDatBan.Count() == 0) return;
                    ct_Phieu.DataContext = ListCT_PhieuDatBan;
                    ct_Phieu.ShowDialog();

                });
        }


        // Search box
        private ICollectionView _dataGridCollection;
        private string _filterString;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; OnPropertyChanged("DataGridCollection"); }
        }
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                OnPropertyChanged("FilterString");
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as TIECCUOI;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return data.SoDienThoai.Contains(_filterString) || data.TenChuRe.Contains(_filterString) || data.TenCoDau.Contains(_filterString);
                }
                return true;
            }
            return false;
        }

        private void data()
        {
            ListPhieuDatDichVu = new ObservableCollection<PHIEUDATDICHVU>(DataProvider.Ins.DataBase.PHIEUDATDICHVUs.Where(x => x.MaTiecCuoi == idTiecCuoi));
            DataProvider.Ins.DataBase.SaveChanges();
            if (ListPhieuDatDichVu == null || ListPhieuDatDichVu.Count() == 0) return;

            //ListPhieuDatDichVu = new ObservableCollection<object>(DataProvider.Ins.DataBase.PHIEUDATBANs.Join());
            
            if (ListPhieuDatDichVu != null)
            {
                //SoLuong = ListPhieuDatDichVu.FirstOrDefault().SoLuong;
                //DonGia = ListPhieuDatDichVu.FirstOrDefault().ThanhTien;

                //var sum = ListPhieuDatDichVu.FirstOrDefault().SoLuong
                //MessageBox.Show(ListPhieuDatDichVu[1].DICHVU.TenDichVu.ToString());
                ////TenDichVu = ListPhieuDatDichVu.SingleOrDefault().MaDichVu.ToString();
                //SoLuong = ListPhieuDatDichVu.SingleOrDefault().SoLuong;
                //DonGia = ListPhieuDatDichVu.SingleOrDefault().DonGia;
                ThanhTien = SoLuong * DonGia;
                TongTienDichVu = ListPhieuDatDichVu.Sum(x => x.ThanhTien);
                //MessageBox.Show(tongtiendichvu);
            }
            ListTiecCuoi2 = new ObservableCollection<TIECCUOI>(DataProvider.Ins.DataBase.TIECCUOIs.Where(x => x.MaTiecCuoi == idTiecCuoi));
            DataProvider.Ins.DataBase.SaveChanges();
            if (ListTiecCuoi2 == null || ListTiecCuoi2.Count() == 0) return;
            if (ListTiecCuoi2 != null)
            {
                //TenChuRe = ListTiecCuoi2.SingleOrDefault().TenChuRe;
                //TenCoDau = ListTiecCuoi2.SingleOrDefault().TenCoDau;
                //NgayDaiTiec = ListTiecCuoi2.SingleOrDefault().NgayDaiTiec; //Ngay thanh toan trung ngay dai tiec, qua han tinh phat (Neu co)
                //TienDatCoc = Convert.ToString(ListTiecCuoi2.SingleOrDefault().TienDatCoc);
            }
            ListPhieuDatBan = new ObservableCollection<PHIEUDATBAN>(DataProvider.Ins.DataBase.PHIEUDATBANs.Where(x => x.MaTiecCuoi == idTiecCuoi));
            DataProvider.Ins.DataBase.SaveChanges();
            if (ListPhieuDatBan == null || ListPhieuDatBan.Count() == 0) return;
            if (ListPhieuDatBan != null)
            {
                //TongSoBan = Convert.ToString(ListPhieuDatBan.FirstOrDefault().SoLuong + ListPhieuDatBan.FirstOrDefault().SoLuongDuTru); // Tong so ban =  So luong ban + So luong du tru
                //TongTienBan = ListPhieuDatBan.FirstOrDefault().DonGiaBan * Convert.ToInt32(TongSoBan);
              //  //DonGiaBan = ListPhieuDatBan.FirstOrDefault().DonGiaBan;
             //   LoaiBan = ListPhieuDatBan.FirstOrDefault().LoaiBan;



            }
            //ListCT_PhieuDatBan = new ObservableCollection<CT_PHIEUDATBAN>(DataProvider.Ins.DataBase.CT_PHIEUDATBANs.Where(x => x.PHIEUDATBAN.MaTiecCuoi == idTiecCuoi));
            //DataProvider.Ins.DataBase.SaveChanges();
            //if (ListCT_PhieuDatBan == null || ListCT_PhieuDatBan.Count() == 0) return;
            //if (ListCT_PhieuDatBan != null)
            //{
                
            //    SoLuong = ListCT_PhieuDatBan.FirstOrDefault().SoLuong;
            //    //MessageBox.Show(SoLuongMon.ToString());
            //    DonGia = ListCT_PhieuDatBan.FirstOrDefault().ThanhTien;
            //}

            ListThamSo = new ObservableCollection<THAMSO>(DataProvider.Ins.DataBase.THAMSOes.ToList());
            DataProvider.Ins.DataBase.SaveChanges();
            var TiLePhat = 0.0d;
            int IsPhat = 0;
            if (ListThamSo == null || ListThamSo.Count() == 0) return;
            if (ListThamSo != null)
            {
                IsPhat = (int)ListThamSo[0].GiaTri;
                //MessageBox.Show("Su dung phat: " + IsPhat);
                TiLePhat = ListThamSo[1].GiaTri;
                //MessageBox.Show(TiLePhat.ToString());
            }
            
            
            TongTienHoaDon = TongTienBan + TongTienDichVu;
            TienPhat = TongTienHoaDon * (decimal)IsPhat * (decimal)TiLePhat; // Con tinh ngay
            MessageBox.Show(TienPhat.ToString());
            ConLai = TongTienHoaDon + TienPhat - Convert.ToDecimal(TienDatCoc);
        }

        

        public int _getMaTiecCuoi(DataGrid dataGrid)
        {
            if (dataGrid.SelectedItem != null)
            {
                TIECCUOI IdTiecCuoi = dataGrid.SelectedItem as TIECCUOI;
                return IdTiecCuoi.MaTiecCuoi;

            }
            else
            {
                MessageBox.Show("Lỗi");
                return -1;
            }
        }

        public int _getMaPhieuDatBan(DataGrid dataGrid)
        {
            if (dataGrid.SelectedItem != null)
            {
                PHIEUDATBAN MaPhieu = dataGrid.SelectedItem as PHIEUDATBAN;
                return MaPhieu.MaPhieuDatBan;

            }
            else
            {
                MessageBox.Show("Lỗi");
                return -1;
            }
        }

        private void TinhLaiBaoCaoThang()
        {
            var BaoCaoThang = DataProvider.Ins.DataBase.BAOCAOTHANGs.Where(x => x.Thang == NgayDaiTiec.Month && x.Nam == NgayDaiTiec.Year).ToList();
            if(BaoCaoThang.Count() != 0)
            {
                BaoCaoThang[0].TongDoanhThu += TongTienHoaDon;
            }
            else
            {
                DataProvider.Ins.DataBase.BAOCAOTHANGs.Add(new BAOCAOTHANG()
                {
                    Thang = NgayDaiTiec.Month,
                    Nam = NgayDaiTiec.Year,
                    TongDoanhThu = TongTienHoaDon
                }) ;
                DataProvider.Ins.DataBase.SaveChanges();
            }
        }
        private void TinhLaiBaoCaoNgay()
        {
            var BaoCaoThang = DataProvider.Ins.DataBase.BAOCAOTHANGs.Where(x => x.Thang == NgayDaiTiec.Month && x.Nam == NgayDaiTiec.Year).ToList();
            if (BaoCaoThang.Count() != 0)
            {
                int id = BaoCaoThang[0].MaBaoCaoThang;
                var BaoCaoNgay = DataProvider.Ins.DataBase.BAOCAONGAYs.Where(x => x.MaBaoCaoThang == id && x.Ngay == NgayDaiTiec.Day).ToList();
                if(BaoCaoNgay.Count() != 0)
                {
                    BaoCaoNgay[0].SoLuongTiecCuoi += 1;
                    BaoCaoNgay[0].DoanhThu += TongTienHoaDon;
                    BaoCaoNgay[0].TiLe = Convert.ToDouble(BaoCaoNgay[0].DoanhThu) / Convert.ToDouble(BaoCaoThang[0].TongDoanhThu);
                }
                else
                {
                    DataProvider.Ins.DataBase.BAOCAONGAYs.Add(new BAOCAONGAY()
                    {
                        MaBaoCaoThang = id,
                        Ngay = NgayDaiTiec.Day,
                        SoLuongTiecCuoi = 1,
                        DoanhThu = TongTienHoaDon,
                        TiLe = 1
                    });
                    DataProvider.Ins.DataBase.SaveChanges();
                }
            }
            else
                return;
                
        }

    }
}
