using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class ThucDonController : Controller
    {
        // GET: Food
       
        SqlMonAn dbMonAn = new SqlMonAn();
        SqlThucDon dbThucDon = new SqlThucDon();
        SqlUserInfo dbUser = new SqlUserInfo();
        public const string FoodSession = "FoodSession";
        // GET: Food
        public ActionResult Index()
        {

            var model = dbThucDon.GetThucDonNguoiDungHienTai(Session["ID"].ToString(), DateTime.Now);
            return View(model);
        }

        public ActionResult Add(string id,int amount)
        {
            //string sl = form["Amount"];
            var mon = dbMonAn.GetMonAn(id);
            var thucdon = dbThucDon.getThucDonFromMonAn(Session["ID"].ToString(), DateTime.Now, id);
            var nguoidung = dbUser.GetUser(Session["ID"].ToString());

            if (thucdon == null)
            {
                ThucDon td = new ThucDon();
                td.Id = (dbThucDon.getCount() + 1).ToString();
                td.Carb = mon.Carb * amount;
                td.Calo = mon.Carb * amount;
                td.Protein = mon.Protein * amount;
                td.Fat= mon.Fat * amount;
                td.Name = mon.Name;
                td.HinhAnh = mon.HinhAnh;
                td.IdMonAn = id;
               // td.MonAn = mon;
                td.Ngay = DateTime.Now.Date;
               // td.NguoiDung = new NguoiDung();
                //td.NguoiDung.Id = nguoidung.Id;
               
                td.IdNguoiDung = Session["ID"].ToString();
              
                td.SoLuong = amount;
                td.GhiChu = "";
                dbThucDon.Add(td);
            }
            else
            {
                thucdon.SoLuong += amount;
                thucdon.Carb += mon.Carb * amount;
                thucdon.Calo += mon.Carb * amount;
                thucdon.Protein += mon.Protein * amount;
                thucdon.Fat += mon.Fat * amount;
                dbThucDon.Update(thucdon);
            }

            return RedirectToAction("Index") ;
        }
        public JsonResult DeleteAll()
        {
            dbThucDon.DeleteAllThucDonTrongNgay(Session["ID"].ToString(), DateTime.Now);
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Delete(string id)
        {
            dbThucDon.Delete(id);
            return RedirectToAction("Index");
        }
    }
}