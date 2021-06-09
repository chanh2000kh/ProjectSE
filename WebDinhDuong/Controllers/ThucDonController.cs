using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Adapter;
using WebDinhDuong.Models;
using WebDinhDuong.ModelView;
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
            var listthucdon = dbThucDon.GetThucDonNguoiDungHienTai(Session["ID"].ToString(), DateTime.Now.Date);
            List<ThucDon> model = new List<ThucDon>();
            //foreach (var item in thucdon)
            //{
            //    var mon = dbMonAn.GetMonAn(item.IdMonAn);

            //    ThucDonView itemview = new ThucDonView();
            //    itemview.Id = item.Id;
            //    itemview.HinhAnh = item.HinhAnh;
            //    itemview.Calo = (double)mon.Calo;
            //    itemview.IdMonAn = item.IdMonAn;
            //    itemview.SoLuong = (int)item.SoLuong;
            //    itemview.Name = item.Name;
            //    model.Add(itemview);

            //}
            foreach(ThucDon item in listthucdon )
            {
                ThucDonAdaptee adaptee = new ThucDonAdaptee();
                IThucDon ithucdon = new ThucDonAdapter(adaptee);
                ithucdon.send(item);
                model.Add(adaptee.getThucDonHopLe());

            }    

            if (model.Count() != 0)
            {
                ViewBag.TotalCalo = dbThucDon.GetTotalCalo(Session["ID"].ToString(), DateTime.Now.Date);
            }
            else
            {
                ViewBag.TotalCalo = 0;
            }
            return View(model);
        }

        public ActionResult Add(string idmonan, int quality)
        {
            //string sl = form["Amount"];
            var mon = dbMonAn.GetMonAn(idmonan);
            var thucdon = dbThucDon.getThucDonFromMonAn(Session["ID"].ToString(), DateTime.Now.Date, idmonan);
            var nguoidung = dbUser.GetUser(Session["ID"].ToString());

            if (thucdon == null)
            {
                ThucDon td = new ThucDon();
                td.Id = (dbThucDon.getCount() + 1).ToString();
                td.Carb = mon.Carb * quality;
                td.Calo = mon.Calo * quality;
                td.Protein = mon.Protein * quality;
                td.Fat = mon.Fat * quality;
                td.Name = mon.Name;
                td.HinhAnh = mon.HinhAnh;
                td.IdMonAn = idmonan;
                td.Ngay = DateTime.Now.Date;
                // td.NguoiDung = new NguoiDung();
                //td.NguoiDung.Id = nguoidung.Id;

                td.IdNguoiDung = Session["ID"].ToString();

                td.SoLuong = quality;
                td.GhiChu = "";
                dbThucDon.Add(td);
            }
            else
            {
                thucdon.SoLuong += quality;
                thucdon.Carb += mon.Carb * quality;
                thucdon.Calo += mon.Calo * quality;
                thucdon.Protein += mon.Protein * quality;
                thucdon.Fat += mon.Fat * quality;
                dbThucDon.Update(thucdon);
            }

            return RedirectToAction("Index");
        }
        public ActionResult AddMenuJson(string id, int amount)
        {
            //string sl = form["Amount"];
         
            var thucdon = dbThucDon.getThucDon(id);
            var mon = dbMonAn.GetMonAn(thucdon.IdMonAn);
            var nguoidung = dbUser.GetUser(Session["ID"].ToString());

            //if (thucdon == null)
            //{
            //    ThucDon td = new ThucDon();
            //    td.Id = (dbThucDon.getCount() + 1).ToString();
            //    td.Carb = mon.Carb * amount;
            //    td.Calo = mon.Calo * amount;
            //    td.Protein = mon.Protein * amount;
            //    td.Fat = mon.Fat * amount;
            //    td.Name = mon.Name;
            //    td.HinhAnh = mon.HinhAnh;
            //    td.IdMonAn = id;
            //    // td.MonAn = mon;
            //    td.Ngay = DateTime.Now.Date;
            //    // td.NguoiDung = new NguoiDung();
            //    //td.NguoiDung.Id = nguoidung.Id;

            //    td.IdNguoiDung = Session["ID"].ToString();

            //    td.SoLuong = amount;
            //    td.GhiChu = "";
            //    dbThucDon.Add(td);
            //}
            //else
            //{
                thucdon.SoLuong += amount;
                thucdon.Carb += mon.Carb * amount;
                thucdon.Calo += mon.Calo * amount;
                thucdon.Protein += mon.Protein * amount;
                thucdon.Fat += mon.Fat * amount;
                dbThucDon.Update(thucdon);
         //   }
            var results = new ResultOfThucDon
            {
                TotalCalo = dbThucDon.GetTotalCalo(Session["ID"].ToString(), DateTime.Now.Date),
                successful = true
            };
            return Json(results);
        }
        public JsonResult DeleteAll()
        {
            dbThucDon.DeleteAllThucDonTrongNgay(Session["ID"].ToString(), DateTime.Now.Date);
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Delete(string id)
        {
            dbThucDon.Delete(id, Session["ID"].ToString(), DateTime.Now.Date);
            var results = new ResultOfThucDon
            {
                TotalCalo = dbThucDon.GetTotalCalo(Session["ID"].ToString(), DateTime.Now.Date),
                successful = true
            };
            return Json(results);
        }
        public ActionResult DeleteItemJson(string id)
        {
            var thucdon = dbThucDon.getThucDon(id);
            var mon = dbMonAn.GetMonAn(thucdon.IdMonAn);
            if (thucdon.SoLuong > 1)
            {
                thucdon.SoLuong -= 1;
                thucdon.Protein -= mon.Protein;
                thucdon.Calo -= mon.Calo;
                thucdon.Carb -= mon.Carb;
                thucdon.Fat -= mon.Fat;
                dbThucDon.Update(thucdon);
                var results = new ResultOfThucDon
                {
                    TotalCalo = dbThucDon.GetTotalCalo(Session["ID"].ToString(), DateTime.Now.Date),
                    successful = true
                };
                return Json(results);
            }
            var results2 = new ResultOfThucDon
            {
               // TotalCalo = dbThucDon.GetTotalCalo(Session["ID"].ToString(), DateTime.Now.Date),
                successful = false
            };
            return Json(results2);
        }
    }

}