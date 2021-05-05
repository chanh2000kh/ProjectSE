using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class UserInformationController : Controller
    {
        SqlUserInfo db = new SqlUserInfo();

        // GET: UserInformation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit ()
        {
            return View();
        }
        [HttpGet]   // use to edit, create restaurant
        public ActionResult Edit(String id)
        {
            var model = db.GetUser("1");
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]  //use to post, write restaurant
        [ValidateAntiForgeryToken] //thuoc tinh ngan chan mot yeu cau gia mao
        public ActionResult Edit(NguoiDung nguoiDung)
        {
           
            if (String.IsNullOrEmpty(nguoiDung.Name))
            {
                ModelState.AddModelError(nameof(nguoiDung.Name), "The name is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(nguoiDung.Password.ToString()))
            {
                ModelState.AddModelError(nameof(nguoiDung.Password), "Password is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(nguoiDung.Mail.ToString()))
            {
                ModelState.AddModelError(nameof(nguoiDung.Mail), "Email is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(nguoiDung.ChieuCao.ToString()))
            {
                ModelState.AddModelError(nameof(nguoiDung.ChieuCao), "Your height is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(nguoiDung.CanNang.ToString()))
            {
                ModelState.AddModelError(nameof(nguoiDung.CanNang), "Your weight's ID is required");
                //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(nguoiDung.TanSuatHoatDong.ToString()))
            {
                ModelState.AddModelError(nameof(nguoiDung.TanSuatHoatDong), "Level of activity is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(nguoiDung.MucTieu.ToString()))
            {
                ModelState.AddModelError(nameof(nguoiDung.MucTieu), "Your goal is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(nguoiDung.CanNangMongMuon.ToString()))
            {
                ModelState.AddModelError(nameof(nguoiDung.CanNangMongMuon), "Goal of height is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(nguoiDung.Thang.ToString()))
            {
                ModelState.AddModelError(nameof(nguoiDung.Thang), "Time is required");      //thong bao loi khi Name co gia tri null/ rong
            }



            
            if (ModelState.IsValid)
            {
                db.Update(nguoiDung);
                TempData["Message"] = "You have saved the product!";
                return RedirectToAction("Details", new { id =nguoiDung.Id });
            }
            return View(nguoiDung);
          
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var model = db.GetUser(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

    }
}