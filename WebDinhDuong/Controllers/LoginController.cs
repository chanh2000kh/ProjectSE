using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class LoginController : Controller
    {
        private SqlLogin dbLogin = new SqlLogin();
        private SqlUserInfo dbUser = new SqlUserInfo();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
      
        public ActionResult Login(FormCollection model)
        {        
            string password = model["Password"];
            string email = model["Mail"];
          
            var acc = dbLogin.GetAcc(password, email);
            if (dbLogin.checkMailExist(email))
            {
                if (acc != null)
                {
                    
                    if (acc.Role == 0)
                    {
                        Admin admin = dbUser.GetAdmin(acc.Id);
                        Session["ID"] = admin.Id;
                        Session["Email"] = email; ;
                        Session["Password"] = password;
                        return Content("/ManageFood/Index");
                    }
                       
                    if (acc.Role == 1)
                    {
                        NguoiDung user = dbUser.GetUserFromIdLogin(acc.Id);
                        Session["ID"] = user.Id;
                        Session["Email"] = email; ;
                        Session["Password"] = password;
                        return Content("/Home/Index");
                    }
                       
                }
                else
                {
                    int temp = 0;
                    return Content(temp.ToString());
                }    
            }

            int temp2 = 1;
            return Content(temp2.ToString());
        }
        


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

    }


}