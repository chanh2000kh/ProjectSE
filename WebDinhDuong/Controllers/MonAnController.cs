using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
namespace WebDinhDuong.Controllers
{
    public class MonAnController : Controller
    {
        QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        // GET: MonAn
        public ActionResult MonAn(string Search)
        {
     
            if (Search != null)
            {
                ViewBag.listMon = db.MonAns.SqlQuery("Select * from MonAn where Name  like '%" + Search + "%'").ToList();

                return View();
            }
            else
            {
                ViewBag.listMon = db.MonAns.ToList();
                return View();
            }
        }
        public ActionResult Detail(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn dSSP = db.MonAns.Find(id);
            if (dSSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.RelatedProducts = new MonAn().ListRelatedProduct(id);

            return View(dSSP);
          
        }
    }
}