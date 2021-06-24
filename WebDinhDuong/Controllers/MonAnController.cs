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
        public ActionResult Index(string search)
        {
            if (search == null)
            {
                var model1 = dbMonAn.GetAll();
                return View(model1);              
            }
            var model2 = dbMonAn.getMonAnByName(search);

            return View(model2);

        }
        public ActionResult Details(string id)
        {
            var model = dbMonAn.GetMonAn(id);
            return View(model);
        }
    }
}