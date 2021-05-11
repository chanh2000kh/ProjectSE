using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;

namespace WebDinhDuong.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        
         QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        public ActionResult Signup()
        {

            return View();
        }
        public ActionResult SignupFailed()
        {

            return View();
        }



        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(NguoiDung a)
        {
            
            var login = db.NguoiDungs.Where(s => s.Mail.Equals(a.Mail)).FirstOrDefault();
            var login2 = db.Admins.Where(s => s.Mail.Equals(a.Mail)).FirstOrDefault();
            if (login == null && login2==null)
            {
                
                a.Id = (db.NguoiDungs.Count() + 1).ToString();
                db.NguoiDungs.Add(a);
                db.SaveChanges();

                return View("~/Views/Login/Login.cshtml");
            }
            else return View("~/Views/Signup/SignupFailed.cshtml");

        }
       
    }
}