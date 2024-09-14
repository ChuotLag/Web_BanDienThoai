using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DOANTKW.Models;


namespace DOANTKW.Controllers
{
    public class HomeController : Controller
    {
        DBConnectDataContext db = new DBConnectDataContext();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KhachHang kh, FormCollection f)
        {
            var hoten = f["HoTen"];
            var taikoan = f["TaiKhoan"];
            var matkhau = f["MatKhau"];
            var dienthoai = f["DienThoai"];
            var email = f["Email"];
            var giotinh = f["GioiTinh"];
            var diachi = f["DiaChi"];
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string taiKhoan, string matKhau)
        {
            // Kiểm tra tài khoản và mật khẩu trong CSDL
            var user = db.KhachHangs.FirstOrDefault(u => u.TaiKhoan == taiKhoan && u.MatKhau == matKhau);

            if (user != null)
            {
                // Đăng nhập thành công, đặt giá trị Session
                Session["TaiKhoan"] = user.TaiKhoan;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            // Xóa Session khi đăng xuất
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }

        
    }
}