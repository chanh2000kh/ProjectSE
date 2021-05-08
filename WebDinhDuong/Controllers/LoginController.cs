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
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin log_kh)
        {

            var user_kh = db.Admins.Where(x => x.Mail == log_kh.Mail && x.Password == log_kh.Password && x.Role == "0").Count();


            if (user_kh > 0)
                return View("~/Areas/Admin/Views/Home_admin/Home_admin.cshtml");
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Login_failed");
            }
        }
    }
}