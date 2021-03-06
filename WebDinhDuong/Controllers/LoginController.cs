using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.Proxy;
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
                    ICore core = new CoreProxy((int) acc.Role);
                    if (acc.Role == 0)
                    {                                              
                        Admin admin = dbUser.GetAdmin(acc.Id);
                        Session["ID"] = admin.Id;
                        Session["Email"] = email; ;
                        Session["Password"] = password;                   
                        return Content(core.getLink());
                    }

                    if (acc.Role == 1)
                    {
                     //   CoreProxy core = new CoreProxy(acc.Role);
                        NguoiDung user = dbUser.GetUserFromIdLogin(acc.Id);
                        Session["ID"] = user.Id;
                        Session["Email"] = email; ;
                        Session["Password"] = password;
                        return Content(core.getLink());
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