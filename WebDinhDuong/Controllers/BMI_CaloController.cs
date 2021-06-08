using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Factory;
using WebDinhDuong.Models;
using WebDinhDuong.ModelView;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class BMI_CaloController : Controller
    {
        // GET: BMI_Calo
        SqlUserInfo db = new SqlUserInfo();      
        public ActionResult Bmi()
        {
            //string mail = DisplayUsername.passusername;
            //ViewBag.listuser = db.NguoiDungs.Where(x => x.Mail == mail).ToList();

            NguoiDung user = db.GetUser(Session["ID"].ToString());

            double bmi = (double)((double)user.CanNang / (((double)user.ChieuCao/100) * ((double)user.ChieuCao/100)));
            bmi = Math.Round(bmi, 2);
            PeopleFactory peoplefactory = new PeopleFactory();
            IPeopleStatus peoplestatus = peoplefactory.getPeopleStatus(bmi);
            
            var model = new BMIView();
            model.Nguoidung = user;
            model.Tinhtrang = peoplestatus.getTinhTrang();
            model.BMI = bmi;

            return View(model);
        }
       
    }
}