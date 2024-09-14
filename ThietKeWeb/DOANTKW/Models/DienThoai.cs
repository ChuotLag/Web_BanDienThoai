using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOANTKW.Models;

namespace DOANTKW.Models
{
    public class DienThoai
    {
        DBConnectDataContext db = new DBConnectDataContext();
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sAnh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public DienThoai(int MaSP)
        {
            iMaSP = MaSP;
            SanPham sanpham = db.SanPhams.Single(s => s.MaSP == iMaSP);
            sTenSP = sanpham.TenSP;
            sAnh = sanpham.Anh;
            dDonGia = double.Parse(sanpham.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}