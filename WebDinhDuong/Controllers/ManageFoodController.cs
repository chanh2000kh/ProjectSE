using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
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
        public ActionResult Create(MonAn mon, HttpPostedFileBase Image)
        {
            if (String.IsNullOrEmpty(mon.Name))
            {
                ModelState.AddModelError(nameof(mon.Name), "The name is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Calo.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Calo), "Product's price is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Carb.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Carb), "Amount is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Fat.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Fat), "Branch is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.Protein.ToString()))
            {
                ModelState.AddModelError(nameof(mon.Protein), "Classify is required");
                //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(mon.ThongTin))
            {
                ModelState.AddModelError(nameof(mon.ThongTin), "Provider is required");      //thong bao loi khi Name co gia tri null/ rong
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
                    string image1 = food.Id  + Path.GetExtension(mon.Image.FileName);  //GetExstension
                    //item.Image1.SaveAs(filename: ("E:/LTWeb/BachHoaXanh_Update/BachHoaXanh/BachHoaXanh.Web/Images/" + image1));                 
                    var path = Path.Combine(Server.MapPath("~/Images"), image1);
                    //Neu thu muc chua hinh anh do roi thi xuat ra thong bao
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.upload = " Image has existed!";
                    }
                    else
                    {
                        item.Image1.SaveAs(path);
                    }
                    string temp = "~/Images/" + image1;
                    p.Image1 = temp;
                }
                else
                {
                    p.Image1 = null;
                }

                if (Image2.ContentLength > 0)
                {
                    //Lay ten hinh anh
                    string image2 = p.Id + ".2" + Path.GetExtension(item.Image2.FileName);  //GetExstension
                    //item.Image1.SaveAs(filename: ("E:/LTWeb/BachHoaXanh_Update/BachHoaXanh/BachHoaXanh.Web/Images/" + image1));                 
                    var path = Path.Combine(Server.MapPath("~/Images"), image2);
                    //Neu thu muc chua hinh anh do roi thi xuat ra thong bao
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.upload = " Image has existed!";
                        // p.Image2 = path.ToString();
                    }
                    else
                    {
                        item.Image2.SaveAs(path);
                        // p.Image2 = path.ToString();
                    }
                    string temp = "~/Images/" + image2;
                    p.Image2 = temp;
                }
                else
                {
                    p.Image2 = null;
                }


                if (Image3.ContentLength > 0)
                {
                    //Lay ten hinh anh
                    string image3 = p.Id + ".3" + Path.GetExtension(item.Image3.FileName);  //GetExstension
                    //item.Image1.SaveAs(filename: ("E:/LTWeb/BachHoaXanh_Update/BachHoaXanh/BachHoaXanh.Web/Images/" + image1));                 
                    var path = Path.Combine(Server.MapPath("~/Images"), image3);
                    //Neu thu muc chua hinh anh do roi thi xuat ra thong bao
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.upload = " Image has existed!";
                    }
                    else
                    {
                        item.Image3.SaveAs(path);
                    }
                    string temp = "~/Images/" + image3;
                    p.Image3 = temp;
                }
                else
                {
                    p.Image3 = null;
                }

                bhx.Products.Add(p);
                bhx.SaveChanges();
                return RedirectToAction("ProductDetails", "Admin", new { id = p.Id });
            }
            return RedirectToAction("Details", new { id = item.Id });
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {

            var item = dbProduct.Get(id);
            ViewBag.BranchName = new SelectList(bhx.Branchs, "Id", "Name", item.BranchId);
            ViewBag.ClassifyName = new SelectList(bhx.Classifys, "Id", "Name", item.ClassifyId);
            ViewBag.ProviderName = new SelectList(bhx.Providers, "Id", "Name", item.ProviderId);
            ItemProduct p = new ItemProduct();

            p.Id = dbProduct.GetIdMax().ToString();
            p.Name = item.Name;
            p.Amount = item.Amount;
            p.Details = item.Details;
            p.Discount = item.Discount;

            p.Price = item.Price;
            p.Date = item.Date;
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemProduct item, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3)
        {

            if (String.IsNullOrEmpty(item.Name))
            {
                ModelState.AddModelError(nameof(item.Name), "The name is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(item.Price.ToString()))
            {
                ModelState.AddModelError(nameof(item.Price), "Product's price is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(item.Amount.ToString()))
            {
                ModelState.AddModelError(nameof(item.Amount), "Amount is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(item.BranchName))
            {
                ModelState.AddModelError(nameof(item.BranchName), "Branch is required");      //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(item.ClassifyName))
            {
                ModelState.AddModelError(nameof(item.ClassifyName), "Classify is required");
                //thong bao loi khi Name co gia tri null/ rong
            }
            if (String.IsNullOrEmpty(item.ProviderName))
            {
                ModelState.AddModelError(nameof(item.ProviderName), "Provider is required");      //thong bao loi khi Name co gia tri null/ rong
            }

            if (ModelState.IsValid)
            {
                Product p = new Product();
                p.Id = dbProduct.GetIdMax().ToString();
                p.Name = item.Name;
                p.BranchId = item.BranchName;
                p.Amount = item.Amount;
                p.ClassifyId = item.ClassifyName;
                p.ProviderId = item.ProviderName;
                p.Details = item.Details;
                p.Discount = item.Discount;
                p.Price = item.Price;
                p.Date = item.Date;

                if (Image1.ContentLength > 0)
                {
                    //Lay ten hinh anh
                    string image1 = p.Id + ".1" + Path.GetExtension(item.Image1.FileName);  //GetExstension
                    //item.Image1.SaveAs(filename: ("E:/LTWeb/BachHoaXanh_Update/BachHoaXanh/BachHoaXanh.Web/Images/" + image1));                 
                    var path = Path.Combine(Server.MapPath("~/Images"), image1);
                    //Neu thu muc chua hinh anh do roi thi xuat ra thong bao
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.upload = " Image has existed!";
                    }
                    else
                    {
                        item.Image1.SaveAs(path);
                    }
                    //  string temp = 
                    p.Image1 = "~/Images/" + image1;
                }
                else
                {
                    p.Image1 = null;
                }

                if (Image2.ContentLength > 0)
                {
                    //Lay ten hinh anh
                    string image2 = p.Id + ".2" + Path.GetExtension(item.Image2.FileName);  //GetExstension
                    //item.Image1.SaveAs(filename: ("E:/LTWeb/BachHoaXanh_Update/BachHoaXanh/BachHoaXanh.Web/Images/" + image1));                 
                    var path = Path.Combine(Server.MapPath("~/Images"), image2);
                    //Neu thu muc chua hinh anh do roi thi xuat ra thong bao
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.upload = " Image has existed!";
                        // p.Image2 = path.ToString();
                    }
                    else
                    {
                        item.Image2.SaveAs(path);
                        // p.Image2 = path.ToString();
                    }
                    //  string temp =
                    p.Image2 = "~/Images/" + image2;
                }
                else
                {
                    p.Image2 = null;
                }


                if (Image3.ContentLength > 0)
                {
                    //Lay ten hinh anh
                    string image3 = p.Id + ".3" + Path.GetExtension(item.Image3.FileName);  //GetExstension
                    //item.Image1.SaveAs(filename: ("E:/LTWeb/BachHoaXanh_Update/BachHoaXanh/BachHoaXanh.Web/Images/" + image1));                 
                    var path = Path.Combine(Server.MapPath("~/Images"), image3);
                    //Neu thu muc chua hinh anh do roi thi xuat ra thong bao
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.upload = " Image has existed!";
                    }
                    else
                    {
                        item.Image3.SaveAs(path);
                    }
                    //  string temp = 
                    p.Image3 = "~/Images/" + image3;
                }
                else
                {
                    p.Image3 = null;
                }


                var temp = bhx.Products.Find(item.Id);
                bhx.Products.Remove(temp);
                bhx.Products.Add(p);
                bhx.SaveChanges();
                return RedirectToAction("Details", new { id = p.Id });
            }
            return RedirectToAction("Details", new { id = item.Id });
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var model = dbProduct.Get(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product model)
        {
            bhx.Products.Remove(model);
            bhx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
}