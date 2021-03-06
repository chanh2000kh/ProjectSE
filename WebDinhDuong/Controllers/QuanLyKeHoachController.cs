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
        private SqlMonAn dbMonAn = new SqlMonAn();
        // GET: QuanLyKeHoach
        public ActionResult ThemMoi(string id, FormCollection model)
        {
            //kiểm tra tham số truyền vào có rổng hay không
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //nếu không truy xuất csdl lấy ra sản phẩm tướng ứng
            MonAn monAn = dbMonAn.GetMonAn(id);
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
                string idkh = (dbkehoach.GetIdMax()).ToString();
                string ghichu = model["GhiChu"];
                string soluong = model["SoLuong"];
                string date = model["datepicker"];
                string buoi = model["select"];
                string thu = model["select2"];
                var kh = dbkehoach.GetKeHoachTheoMonAn(id,thu,buoi, Session["ID"].ToString());
                if (kh != null)
                {
                    kh.SoLuong += int.Parse(soluong.ToString());
                    dbkehoach.Update(kh);
                }
                else
                {
                    //Add a ke hoach in table Login
                    KeHoach kehoach = new KeHoach();
                    kehoach.Id = dbkehoach.GetIdMax().ToString();
                    kehoach.IdMonAn = (string)Session["IDMon"];
                    kehoach.IdNguoiDung = (string)Session["ID"];
                    kehoach.IdThu = thu;
                    kehoach.IdBuoi = buoi;
                    kehoach.NgayLapKeHoach = Convert.ToDateTime(date);
                    kehoach.GhiChu = ghichu;
                    kehoach.SoLuong = int.Parse(soluong.ToString());
                    dbkehoach.Add(kehoach);
                }

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
                             Id = a.Id,
                             IdMon = a.IdMonAn,
                             TenMon = b.Name,
                             GhiChu = a.GhiChu,
                             Ngay = (DateTime)a.NgayLapKeHoach,
                             SoLuong = (int)a.SoLuong
                         };
                return ls;
            
        }

        public ActionResult Xoa(string id)
        {
           // string id = (string)Session["ID"];
            dbkehoach.Delete(id);
            return Redirect("/QuanLyKeHoach/LoadKeHoach");
        }
        public ActionResult Sua(/*string idmon, string idthu, string idbuoi, DateTime date, string ghichu,*/string id, FormCollection model)
        {
            //var ls = from a in db.KeHoaches
            //         join b in db.MonAns
            //         on a.IdMonAn equals b.Id
            //         where a.IdThu == idthu
            //         && a.IdBuoi == idbuoi
            //         && a.IdNguoiDung == Session["ID"].ToString()
            //         select new LoadNDKeHoach
            //         {
            //             IdMon = a.IdMonAn,
            //             TenMon = b.Name,
            //             GhiChu = a.GhiChu,
            //             Ngay = (DateTime)a.NgayLapKeHoach,
            //             SoLuong = (int)a.SoLuong
            // 
            var kh = dbkehoach.GetKeHoach(id);
            var mon = dbMonAn.GetMonAn(kh.IdMonAn);
            //LoadNDKeHoach ls = new LoadNDKeHoach();
            //ls.Id = kh.Id;
            //ls.IdMon = kh.IdMonAn;
            //ls.Ngay = (DateTime)kh.NgayLapKeHoach;
            //ls.SoLuong =(int) kh.SoLuong;
            //ls.GhiChu = kh.GhiChu;
            //ls.TenMon = mon.Name;

            if (model["SoLuong"] == null)
            {
                
               
                //ViewBag.soluong = ls.SoLuong;
                return View(kh);
            }
           // string id = (string)Session["ID"];
            string soluong = model["SoLuong"];

            //KeHoach kehoach = new KeHoach();
            //kehoach.IdMonAn = idmon;
            //kehoach.IdNguoiDung = id;
            //kehoach.IdThu = idthu;
            //kehoach.IdBuoi = idbuoi;
            //kehoach.NgayLapKeHoach = Convert.ToDateTime(date);
            //kehoach.GhiChu = ghichu;
            kh.SoLuong = int.Parse(soluong.ToString());
            dbkehoach.Update(kh);
            return Redirect("/QuanLyKeHoach/LoadKeHoach");
        }
        //private DateTime TimNgayDauTuan()
        //{
        //    DateTime date = DateTime.Now.Date;
        //    if(DateTime.Now.DayOfWeek==DayOfWeek.Monday)
        //    {
        //        return date;
        //    }
        //    if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
        //    {
        //        return date.AddDays(-1);
        //    }
        //    if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
        //    {
        //        return date.AddDays(-2);
        //    }
        //    if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
        //    {
        //        return date.AddDays(-3);
        //    }
        //    if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
        //    {
        //        return date.AddDays(-4);
        //    }
        //    if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
        //    {
        //        return date.AddDays(-5);
        //    }
        //    return date.AddDays(-6);
        //}
    }
}