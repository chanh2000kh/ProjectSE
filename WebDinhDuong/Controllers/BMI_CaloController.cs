using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
namespace WebDinhDuong.Controllers
{
    public class BMI_CaloController : Controller
    {
        // GET: BMI_Calo
        QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        public ActionResult Index()
        {
            string mail = DisplayUsername.passusername;
            ViewBag.listuser = db.NguoiDungs.Where(x => x.Mail == mail).ToList();
            return View();
        }
       
    }
}