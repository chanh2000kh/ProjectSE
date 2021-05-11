using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
namespace WebDinhDuong.Controllers
{
    public class ThucDonController : Controller
    {
        // GET: Food
        QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        public const string FoodSession = "FoodSession";
        // GET: Food
        public ActionResult Index()
        {

            var food = Session[FoodSession];
            var list = new List<FoodItem>();
            if (food != null)
            {
                list = (List<FoodItem>)food;

            }
            return View(list);
        }

        public ActionResult AddItem(string id, int quantity = 1)
        {

            var product = new MonAn().ViewDetail(id);

            var food = Session[FoodSession];
            if (food != null)
            {
                var list = (List<FoodItem>)food;
                //var a = list.FirstOrDefault(x => x.Product.Maxe == id);
                if (list.Exists(x => x.Product.Id== product.Id))
                //if (a==null)
                {

                    foreach (var item in list)
                    {
                        if (item.Product.Id == product.Id)
                        {
                            item.Quanlity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng food item
                    var item = new FoodItem();
                    item.Product = product;
                    item.Quanlity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[FoodSession] = list;
            }
            else
            {
                //tạo mới đối tượng food item
                var item = new FoodItem();
                item.Product = product;
                item.Quanlity = quantity;
                var list = new List<FoodItem>();
                list.Add(item);
                //Gán vào session
                Session[FoodSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult DeleteAll()
        {
            Session[FoodSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Delete(string id)
        {
            var sessionFood = (List<FoodItem>)Session[FoodSession];
            sessionFood.RemoveAll(x => x.Product.Id == id);
            Session[FoodSession] = sessionFood;
            return RedirectToAction("Index");
        }
    }
}