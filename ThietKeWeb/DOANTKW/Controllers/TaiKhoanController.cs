using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANTKW.Models;
using System.Data.SqlClient;
using Microsoft.

namespace DOANTKW.Controllers
{
    public class TaiKhoanController : Controller
    {
        //GET: TaiKhoan
       DBConnectDataContext db = new DBConnectDataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(KhachHang kh, FormCollection f)
        {
            var hoten = f["HoTen"];
            var taikoan = f["TaiKhoan"];
            var matkhau = f["MatKhau"];
            var dienthoai = f["DienThoai"];
            var email = f["Email"];
            var giotinh = f["GioiTinh"];
            var diachi = f["DiaChi"];

            // Kiểm tra và thêm các thông báo lỗi vào ModelState
            if (string.IsNullOrEmpty(hoten))
            {
                ModelState.AddModelError("HotenKH", "Họ tên không được để trống.");
            }

            if (string.IsNullOrEmpty(giotinh))
            {
                ModelState.AddModelError("GioiTinh", "Tên đăng nhập không được để trống.");
            }

            if (string.IsNullOrEmpty(matkhau))
            {
                ModelState.AddModelError("MatKhau", "Mật khẩu không được để trống.");
            }

            if (string.IsNullOrEmpty(dienthoai))
            {
                ModelState.AddModelError("DienThoai", "Số điện thoại không được để trống.");
            }

            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("Email", "Email không được để trống.");
            }

            if (string.IsNullOrEmpty(diachi))
            {
                ModelState.AddModelError("Diachi", "Địa chỉ không được để trống.");
            }

            // Kiểm tra ModelState để xem có lỗi nào không
            if (ModelState.IsValid)
            {
                kh.HoTen = hoten;
                kh.DienThoai = dienthoai;
                kh.TaiKhoan = taikoan;
                kh.MatKhau = matkhau;
                kh.Email = email;
                kh.DiaChi = diachi;
                kh.GioiTinh = giotinh;

                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return View(kh);
            }
            
            // Nếu có lỗi, trả về View với thông tin lỗi
            return View();
            
        }



        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            var tendn = f["TenDN"];
            var matkhau = f["MatKhau"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewBag["Loi1"] = "Tên đăng nhập không bỏ trống";
            }
            if (String.IsNullOrEmpty(matkhau))
            {
                ViewBag["Loi2"] = "Vui lòng nhập mật khẩu";
            }
            if (!String.IsNullOrEmpty(tendn) && !String.IsNullOrEmpty(matkhau))
            {
                KhachHang kh = db.KhachHangs.SingleOrDefault(c => c.TaiKhoan == tendn && c.MatKhau == matkhau);
                if (kh != null)
                {
                    ViewBag.TB = "Đăng nhập thành công";
                    Session["taikhoan"] = kh;
                }
                else
                {
                    ViewBag.TB = "Sai tên Đăng nhập hoặc sai mật khẩu! Vui lòng nhập lại";
                }
            }
            return View();
        }
        //public ActionResult DangKy()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult DangKy(KhachHang p)
        //{



        //}
    }
}