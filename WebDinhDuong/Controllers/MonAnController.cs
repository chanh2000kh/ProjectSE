using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class MonAnController : Controller
    {
      
        SqlMonAn dbMonAn = new SqlMonAn();
        // GET: MonAn
        public ActionResult MonAn(string search)
        {
            if (search == null)
            {
                var model1 = dbMonAn.GetAll();
                return View(model1);              
            }
            var model2 = dbMonAn.getMonAnByName(search);

            return View(model2);

        }
        //public ActionResult TimKiem(string Search)
        //{
       
        //}
        //public ActionResult Detail(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MonAn dSSP = dbMonAn.GetMonAn(id);
        //    if (dSSP == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.RelatedProducts =dbMonAn.ListMonAn(id);

        //    return View(dSSP);
          
        //}
    }
}