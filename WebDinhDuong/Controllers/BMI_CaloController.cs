using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class BMI_CaloController : Controller
    {
        // GET: BMI_Calo
        SqlUserInfo db = new SqlUserInfo();      
        public ActionResult Index()
        {
            //string mail = DisplayUsername.passusername;
            //ViewBag.listuser = db.NguoiDungs.Where(x => x.Mail == mail).ToList();

            NguoiDung model = db.GetUser(Session["ID"].ToString());
            return View(model);
        }
       
    }
}