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
namespace WebDinhDuong.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        [HttpGet]
        public ActionResult Index()
        {
            string mail = DisplayUsername.passusername;
            ViewBag.listuser = db.NguoiDungs.Where(x => x.Mail == mail).ToList();
            return View();
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {

            string name = form["Name"];
            string mail = form["Mail"];
            string gioitinh = form["Gioitinh"];
            string chieucao = (form["ChieuCao"]);
            string tansuathoatdong = form["TanSuatHoatDong"];
            string cannang = form["CanNang"];
            string cannangmongmuon = form["CanNangMongMuon"];
            string muctieu = form["MucTieu"];
            string thang = form["Thang"];

            NguoiDung editpro = new NguoiDung();
            editpro.Password = DisplayUsername.password;
            editpro.Id = db.NguoiDungs.Count().ToString();
            editpro.Name = name;
            editpro.Mail = mail;
            editpro.GioiTinh = gioitinh;
            editpro.ChieuCao = Int16.Parse(chieucao);
            editpro.CanNang = Int16.Parse(cannang);
            editpro.CanNangMongMuon = Int16.Parse(cannangmongmuon);
            editpro.MucTieu = muctieu;
            editpro.Thang = Int16.Parse(thang);
            editpro.TanSuatHoatDong = tansuathoatdong;
            Update(editpro);
            string email = DisplayUsername.passusername;
            ViewBag.listuser = db.NguoiDungs.Where(x => x.Mail == email).ToList();
            return View();
        }
        public void Update(NguoiDung login)
        {
            db.Entry(login).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
          

        }
    }
}