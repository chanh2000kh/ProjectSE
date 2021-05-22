using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Data.Entity.Validation;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class UserInformationController : Controller
    {
        // GET: Profile
        SqlUserInfo dbUser = new SqlUserInfo();
        SqlLogin dbLogin = new SqlLogin();
        [HttpGet]
        public ActionResult Edit()
        {
            NguoiDung user = dbUser.GetUserFromIdLogin(Session["ID"].ToString());
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            string password = form["Password"];
            string name = form["Name"];
          //  string mail = form["Mail"];
            string gioitinh = form["Gender"];
            string chieucao = (form["Height"]);
            string tansuathoatdong = form["Frequency"];
            string cannang = form["Weight"];
            string cannangmongmuon = form["Goalweight"];
            string muctieu = form["Goal"];
            string thang = form["Time"];

            //Update password
            Login acc = new Login();
              acc=  dbLogin.GetAcc(Session["Password"].ToString(), Session["Email"].ToString());
            acc.Password = password;
            dbLogin.Update(acc);
            Session["Password"] = password;

            //Update User
            NguoiDung user = dbUser.GetUser(Session["ID"].ToString());
            user.Name = name;
            user.GioiTinh = gioitinh;
            user.CanNang = int.Parse(cannang.ToString());
            user.ChieuCao = int.Parse(chieucao.ToString());
            user.CanNangMongMuon = int.Parse(cannangmongmuon.ToString());
            user.TanSuatHoatDong = tansuathoatdong;
            user.MucTieu = muctieu;
            user.Thang = int.Parse(thang.ToString());
            dbUser.Update(user);

            return RedirectToAction("Edit");
        }       
    }
}