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
       
        

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(Admin a)
        {

            a.Role = "0";
            
            db.Admins.Add(a);
            db.SaveChanges();

            return View("~/Views/Login/Login.cshtml");

        }
    }
}