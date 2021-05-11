using System;
using System.Linq;
using System.Web.Mvc;
using WebDinhDuong.Models;

namespace WebDinhDuong.Controllers
{
   

    public class HomeController : Controller
    {
        QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        public ActionResult Index()
        {
            return View();
        }

       

        
       
    }
}