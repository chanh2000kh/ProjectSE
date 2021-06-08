using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.ModelView;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class ManageFoodController : Controller
    {      
        SqlMonAn dbMonAn = new SqlMonAn();
        public ActionResult Index()
        {
            var model = dbMonAn.GetAll();
            return View(model);
        }
       
        public ActionResult Details(string id)
        {
            var model = dbMonAn.GetMonAn(id);
            return View(model);
        }
        [HttpGet]   // use to edit, create restaurant
        public ActionResult Create()
        { 
            return View();
        }

        [HttpPost]  //use to post, write restaurant
        [ValidateInput(false)]
        public ActionResult Create(FoodView mon, HttpPostedFileBase Image)
        {
            if (String.IsNullOrEmpty(mon.Name))
            {
                ModelState.AddModelError(nameof(mon.Name), "The name is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Calo.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Calo), "Food's calo is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Carb.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Carb), "Food's carb is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Fat.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Fat), "Food's fat is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Protein.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Protein), "Food's protein is required");
                //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.ThongTin))
            {
                ModelState.AddModelError(nameof(mon.ThongTin), "Food's information is required");      //thong bao loi khi Name co gia tri null/ rong
            }

            if (ModelState.IsValid)
            {
                MonAn food = new MonAn();
                food.Id = (dbMonAn.getCount() + 1).ToString();
                food.Name = mon.Name;
                food.Calo = mon.Calo;
                food.Carb = mon.Carb;
                food.Fat = mon.Fat;
                food.Protein = mon.Protein;
                food.ThongTin = mon.ThongTin;
          


                if (Image.ContentLength > 0)
                {
                    //Lay ten hinh anh
                    string image1 = food.Id  + Path.GetExtension(Image.FileName);  //GetExstension
                    //item.Image1.SaveAs(filename: ("E:/LTWeb/BachHoaXanh_Update/BachHoaXanh/BachHoaXanh.Web/Images/" + image1));                 
                    var path = Path.Combine(Server.MapPath("~/Images"), image1);
                    //Neu thu muc chua hinh anh do roi thi xuat ra thong bao
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.upload = " Image has existed!";
                    }
                    else
                    {
                        Image.SaveAs(path);
                    }
                    string temp = "~/Images/" + image1;
                    food.HinhAnh = temp;
                }
                else
                {
                    food.HinhAnh = null;
                }


                dbMonAn.Add(food);              
                return RedirectToAction("Details", "ManageFood", new { id = food.Id });
            }
            return View(mon);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {

            var mon=dbMonAn.GetMonAn(id);
            FoodView food = new FoodView();
            food.Id = mon.Id;
            food.Name = mon.Name;
            food.Calo = mon.Calo;
            food.Carb = mon.Carb;
            food.Fat = mon.Fat;
            food.Protein = mon.Protein;
            food.ThongTin = mon.ThongTin;
            return View(food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FoodView mon, HttpPostedFileBase Image)
        {

            if (String.IsNullOrEmpty(mon.Name))
            {
                ModelState.AddModelError(nameof(mon.Name), "The name is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Calo.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Calo), "Food's calo is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Carb.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Carb), "Food's carb is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Fat.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Fat), "Food's fat is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Protein.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Protein), "Food's protein is required");
                //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.ThongTin))
            {
                ModelState.AddModelError(nameof(mon.ThongTin), "Food's information is required");      //thong bao loi khi Name co gia tri null/ rong
            }

            if (ModelState.IsValid)
            {
                MonAn food = new MonAn();
                food.Id = mon.Id;
                food.Name = mon.Name;
                food.Calo = mon.Calo;
                food.Carb = mon.Carb;
                food.Fat = mon.Fat;
                food.Protein = mon.Protein;
                food.ThongTin = mon.ThongTin;

                if (Image != null)
                {
                    if (Image.ContentLength > 0)
                    {
                        //Lay ten hinh anh
                        string image1 = food.Id + Path.GetExtension(mon.HinhAnh.FileName);  //GetExstension
                                                                                            //item.Image1.SaveAs(filename: ("E:/LTWeb/BachHoaXanh_Update/BachHoaXanh/BachHoaXanh.Web/Images/" + image1));                 
                        var path = Path.Combine(Server.MapPath("~/Images"), image1);
                        //Neu thu muc chua hinh anh do roi thi xuat ra thong bao
                        if (System.IO.File.Exists(path))
                        {
                            ViewBag.upload = " Image has existed!";
                        }
                        else
                        {
                            mon.HinhAnh.SaveAs(path);
                        }
                        string temp = "~/Images/" + image1;
                        food.HinhAnh = temp;
                    }
                    else
                    {
                        food.HinhAnh = null;
                    }
                }


                dbMonAn.Update(food);
                return RedirectToAction("Details", "ManageFood", new { id = food.Id });
            }
            return View(mon);
        }

      
        public ActionResult Delete(string id)
        {
            dbMonAn.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
