using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANTKW.Models;

namespace DOANTKW.Controllers
{
    public class SanPhamController : Controller
    {
        DBConnectDataContext db = new DBConnectDataContext();
        //
        // GET: /SanPham/
        public ActionResult Search(string ten)
        {
            List<SanPham> searchsp = db.SanPhams.Where(s => s.TenSP.Contains(ten)).ToList();
            return View(searchsp);
        }

        public ActionResult Detail(int id)
        {
            SanPham product = db.SanPhams.Where(s => s.MaSP == id).FirstOrDefault();
            return View(product);
        }
	}
}