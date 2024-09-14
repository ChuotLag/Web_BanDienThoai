using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANTKW.Models;

namespace DOANTKW.Controllers
{
    public class GioHangController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public List<GioHang> LayGioHang()
        {
            List<GioHang> list = Session["GioHang"] as List<GioHang>;
            if (list == null)
            {
                list = new List<GioHang>();
                Session["GioHang"] = list;
            }
            return list;
        }
        public ActionResult ThemGioHang(int ms, string strURL)
        {
            List<GioHang> list = LayGioHang();
            GioHang SanPham = list.Find(sp => sp.iMaSP == ms);
            if (SanPham == null)
            {
                SanPham = new GioHang(ms);
                list.Add(SanPham);
                return Redirect(strURL);
            }
            else
            {
                SanPham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            if (lst != null)
            {
                tsl = lst.Sum(sp => sp.iSoLuong);
            }
            return tsl;
        }
        private double TongThanhTien()
        {
            double ttt = 0;
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            if (ttt != null)
            {
                ttt = lst.Sum(sp => sp.dThanhTien);
            }
            return ttt;
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> list = LayGioHang();

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(list);
        }
        public ActionResult PartialGioHang()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            return PartialView();
        }
        public ActionResult XoaGioHang(int ms)
        {
            List<GioHang> list = LayGioHang();
            GioHang sp = list.Single(s => s.iMaSP == ms);

            if (sp != null)
            {
                list.RemoveAll(s => s.iMaSP == ms);
                return RedirectToAction("GioHang", "GioHang");
            }
            if (list.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang", "GioHang");
        }
    }
       
}