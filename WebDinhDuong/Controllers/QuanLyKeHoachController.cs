using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class QuanLyKeHoachController : Controller
    {

        QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();
        private SqlKeHoach dbkehoach = new SqlKeHoach();
        // GET: QuanLyKeHoach
        public ActionResult ThemMoi(string id, FormCollection model)
        {
            //kiểm tra tham số truyền vào có rổng hay không
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //nếu không truy xuất csdl lấy ra sản phẩm tướng ứng
            MonAn monAn = db.MonAns.SingleOrDefault(n => n.Id == id);
            if (monAn == null)
            {
                //Thôn báo nếu không có sản phẩm đó
                return HttpNotFound();
            }
            //ViewBag.Thu = new SelectList(db.Thus.OrderBy(n => n.Name), "Id", "Name");
            //ViewBag.Buoi = new SelectList(db.Buois.OrderBy(n => n.Name), "Id", "Name");
            if (model["GhiChu"] == null)
            {
                Session["IDMon"] = id;
            }
            else
            {
                string idkh = (dbkehoach.getCount() + 1).ToString();
                string ghichu = model["GhiChu"];
                string soluong = model["SoLuong"];
                string date = model["datepicker"];
                string buoi = model["select"];
                string thu = model["select2"];
                //Add a ke hoach in table Login
                KeHoach kehoach = new KeHoach();
                kehoach.Id = idkh;
                kehoach.IdMonAn = (string)Session["IDMon"];
                kehoach.IdNguoiDung = (string)Session["ID"];
                kehoach.IdThu = thu;
                kehoach.IdBuoi = buoi;
                kehoach.NgayLapKeHoach = Convert.ToDateTime(date);
                kehoach.GhiChu = ghichu;
                kehoach.SoLuong = int.Parse(soluong.ToString());
                dbkehoach.Add(kehoach);

            }
            //Session["IDMon"] = id;
            return View();
        }
        //[HttpGet]
        //public ActionResult ThemMoi(FormCollection model)
        //{
        //    string name = model["Name"];
        //    string ghichu = model["GhiChu"];
        //    string soluong = model["SoLuong"];
        //    string idthucdon = (dbthucdon.getCount() + 1).ToString();
        //    //add thực đơn
        //    //Add a account in table Login                   
        //    ThucDon thucdon = new ThucDon();
        //    thucdon.Id = idthucdon;
        //    thucdon.IdMonAn = (string)Session["IDMon"];
        //    thucdon.IdNguoiDung = (string)Session["ID"];
        //    thucdon.Name = (string)Session["Name"];
        //    thucdon.SoLuong = 2;
        //    //thucdon.SoLuong = int.Parse(soluong.ToString());
        //    thucdon.GhiChu = ghichu;
        //    dbthucdon.Add(thucdon);
        //    return View();
        //}

        public ActionResult LoadKeHoach(FormCollection model)
        {

            return View();

        }

        public ActionResult Buoi()
        {
            //Truy vấn lấy list Món
            var lstMon = db.Buois;
            return PartialView(lstMon);
        }

        public ActionResult Thu()
        {
            //Truy vấn lấy list Món
            var lstMon = db.Thus;
            return PartialView(lstMon);
        }
        public ActionResult CNSang()
        {
            var ls = TimKiemND("1", "1");
            return PartialView(ls);
        }
        public ActionResult CNTrua()
        {
            var ls = TimKiemND("1", "2");
            return PartialView(ls);
        }
        public ActionResult CNChieu()
        {
            var ls = TimKiemND("1", "3");
            return PartialView(ls);
        }
        public ActionResult Thu2Sang()
        {
            var ls = TimKiemND("2", "1");
            return PartialView(ls);
        }
        public ActionResult Thu2Trua()
        {
            var ls = TimKiemND("2", "2");
            return PartialView(ls);
        }
        public ActionResult Thu2Chieu()
        {
            var ls = TimKiemND("2", "3");
            return PartialView(ls);
        }
        public ActionResult Thu3Sang()
        {
            var ls = TimKiemND("3", "1");
            return PartialView(ls);
        }
        public ActionResult Thu3Trua()
        {
            var ls = TimKiemND("3", "2");
            return PartialView(ls);
        }
        public ActionResult Thu3Chieu()
        {
            var ls = TimKiemND("3", "3");
            return PartialView(ls);
        }
        public ActionResult Thu4Sang()
        {
            var ls = TimKiemND("4", "1");
            return PartialView(ls);
        }
        public ActionResult Thu4Trua()
        {
            var ls = TimKiemND("4", "2");
            return PartialView(ls);
        }
        public ActionResult Thu4Chieu()
        {
            var ls = TimKiemND("4", "3");
            return PartialView(ls);
        }
        public ActionResult Thu5Sang()
        {
            var ls = TimKiemND("5", "1");
            return PartialView(ls);
        }
        public ActionResult Thu5Trua()
        {
            var ls = TimKiemND("5", "2");
            return PartialView(ls);
        }
        public ActionResult Thu5Chieu()
        {
            var ls = TimKiemND("5", "3");
            return PartialView(ls);
        }
        public ActionResult Thu6Sang()
        {
            var ls = TimKiemND("6", "1");
            return PartialView(ls);
        }
        public ActionResult Thu6Trua()
        {
            var ls = TimKiemND("6", "2");
            return PartialView(ls);
        }
        public ActionResult Thu6Chieu()
        {
            var ls = TimKiemND("6", "3");
            return PartialView(ls);
        }
        public ActionResult Thu7Sang()
        {
            var ls = TimKiemND("7", "1");
            return PartialView(ls);
        }
        public ActionResult Thu7Trua()
        {
            var ls = TimKiemND("7", "2");
            return PartialView(ls);
        }
        public ActionResult Thu7Chieu()
        {
            var ls = TimKiemND("7", "3");
            return PartialView(ls);
        }
        //Tìm kiếm nội dung theo thứ và buổi
        public IQueryable<LoadNDKeHoach> TimKiemND(string thu, string buoi)
        {
            string id = (string)Session["ID"];
            var ls = from a in db.KeHoaches
                     join b in db.MonAns
                     on a.IdMonAn equals b.Id
                     where a.IdThu == thu
                     && a.IdBuoi == buoi
                     && a.IdNguoiDung == id
                     select new LoadNDKeHoach
                     {
                         IdMon = a.IdMonAn,
                         TenMon = b.Name,
                         GhiChu = a.GhiChu,
                         Ngay = (DateTime)a.NgayLapKeHoach,
                         SoLuong = (int)a.SoLuong
                     };
            return ls;
        }

        public ActionResult Xoa(string idmon, string idthu, string idbuoi)
        {
            string id = (string)Session["ID"];
            dbkehoach.Delete(idmon, id, idthu, idbuoi);
            return Redirect("/QuanLyKeHoach/LoadKeHoach");
        }
        public ActionResult Sua(string idmon, string idthu, string idbuoi, string date, string ghichu, FormCollection model)
        {
            if (model["SoLuong"] == null)
            {
                var ls = db.KeHoaches.Find(idmon, "1", idthu, idbuoi);
                //ViewBag.soluong = ls.SoLuong;
                return View(ls);
            }
            string id = (string)Session["ID"];
            string soluong = model["SoLuong"];
            KeHoach kehoach = new KeHoach();
            kehoach.IdMonAn = idmon;
            kehoach.IdNguoiDung = id;
            kehoach.IdThu = idthu;
            kehoach.IdBuoi = idbuoi;
            kehoach.NgayLapKeHoach = Convert.ToDateTime(date);
            kehoach.GhiChu = ghichu;
            kehoach.SoLuong = int.Parse(soluong.ToString());
            dbkehoach.Update(kehoach);
            return Redirect("/QuanLyKeHoach/LoadKeHoach");
        }
    }
}