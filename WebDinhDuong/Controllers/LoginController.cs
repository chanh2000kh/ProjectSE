using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
namespace WebDinhDuong.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
       
        public ActionResult Login()
        {
            DisplayUsername.passusername = null;
            return View();
        }
        [HttpPost]
        public ActionResult Login(NguoiDung log_kh, Admin a)
        {

            var user_kh = db.NguoiDungs.Where(x => x.Mail == log_kh.Mail && x.Password == log_kh.Password ).Count();
            var admin = db.Admins.Where(x => x.Mail == log_kh.Mail && x.Password == log_kh.Password ).Count();

            string username = log_kh.Mail;
            string pass = log_kh.Password;
            string adminname = a.Mail;
            DisplayUsername.Getusername(username,pass);

            if (user_kh > 0)
                return View("~/Views/Home/Index.cshtml");


            else if (admin > 0) return View();
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Login_failed");
            }


        }
    }
}