using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOANTKW.Models;

namespace DOANTKW.Controllers
{
    public class LapTopController : Controller
    {
        DBConnectDataContext db = new DBConnectDataContext();
        //
        // GET: /DienThoai/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetLapTop()
        {
            List<SanPham> lt = db.SanPhams.Where(s => s.MaLoai == 8).ToList();
            return View(lt);
        }
    }
}