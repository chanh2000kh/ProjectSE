using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Models;
using WebDinhDuong.ModelView;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class QuanLyKeHoachController : Controller
    {
              
        //private SqlThucDon dbThucdon = new SqlThucDon();
        //private SqlKeHoach dbKehoach = new SqlKeHoach();
        //private SqlMonAn dbMonAn = new SqlMonAn();
        //private SqlBuoi dbBuoi = new SqlBuoi();
        //private SqlThu dbThu = new SqlThu();
        //// GET: QuanLyKeHoach
        //public ActionResult ThemMoi(string id, FormCollection model)
        //{
        //    //kiểm tra tham số truyền vào có rổng hay không
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    }
        //    //nếu không truy xuất csdl lấy ra sản phẩm tướng ứng
        //    MonAn monAn = dbMonAn.GetMonAn(id);
        //    if (monAn == null)
        //    {
        //        //Thôn báo nếu không có sản phẩm đó
        //        return HttpNotFound();
        //    }
        //    //ViewBag.Thu = new SelectList(db.Thus.OrderBy(n => n.Name), "Id", "Name");
        //    //ViewBag.Buoi = new SelectList(db.Buois.OrderBy(n => n.Name), "Id", "Name");
        //    if (model["Name"] == null)
        //    {
        //        Session["IDMon"] = id;
        //    }
        //    else
        //    {
        //        string name = model["Name"];
        //        string ghichu = model["GhiChu"];
        //        string soluong = model["SoLuong"];
        //        string date = model["datepicker"];
        //        string buoi = model["select"];
        //        string thu = model["select2"];
        //        string idthucdon = (dbThucdon.getCount() + 1).ToString();
        //        //add thực đơn
        //        //Add a thuc don in table Login                   
        //        ThucDon thucdon = new ThucDon();
        //        thucdon.Id = idthucdon;
        //        thucdon.IdMonAn = (string)Session["IDMon"];
        //        thucdon.IdNguoiDung = (string)Session["ID"];
        //        thucdon.Name = name;
        //        thucdon.SoLuong = int.Parse(soluong.ToString());               
        //        thucdon.GhiChu = ghichu;
        //        dbThucdon.Add(thucdon);
        //        //Add a ke hoach in table Login
        //        KeHoach kehoach = new KeHoach();
        //        kehoach.IdThucDon = idthucdon;
        //        kehoach.IdThu = thu;
        //        kehoach.IdBuoi = buoi;
        //        kehoach.NgayLapKeHoach = Convert.ToDateTime(date);
        //        kehoach.GhiChu = ghichu;
        //        dbKehoach.Add(kehoach);               
                
        //    }
        //    //Session["IDMon"] = id;
        //    return View();
        //}
        ////[HttpGet]
        ////public ActionResult ThemMoi(FormCollection model)
        ////{
        ////    string name = model["Name"];
        ////    string ghichu = model["GhiChu"];
        ////    string soluong = model["SoLuong"];
        ////    string idthucdon = (dbthucdon.getCount() + 1).ToString();
        ////    //add thực đơn
        ////    //Add a account in table Login                   
        ////    ThucDon thucdon = new ThucDon();
        ////    thucdon.Id = idthucdon;
        ////    thucdon.IdMonAn = (string)Session["IDMon"];
        ////    thucdon.IdNguoiDung = (string)Session["ID"];
        ////    thucdon.Name = (string)Session["Name"];
        ////    thucdon.SoLuong = 2;
        ////    //thucdon.SoLuong = int.Parse(soluong.ToString());
        ////    thucdon.GhiChu = ghichu;
        ////    dbthucdon.Add(thucdon);
        ////    return View();
        ////}

        //public ActionResult LoadKeHoach(FormCollection model)
        //{
           
            
            
        //    return View();
            
        //}

        //public ActionResult Buoi()
        //{
        //    //Truy vấn lấy list Món
        //    var lstMon = dbBuoi.getAll();
        //    return PartialView(lstMon);
        //}

        //public ActionResult Thu()
        //{
        //    //Truy vấn lấy list Món
        //    var lstMon = dbThu.getAll();
        //    return PartialView(lstMon);
        //}
        //public ActionResult CNSang()
        //{
        //    var ls = TimKiemND("1", "1");
        //    return PartialView(ls);
        //}
        //public ActionResult CNTrua()
        //{
        //    var ls = TimKiemND("1", "2");
        //    return PartialView(ls);
        //}
        //public ActionResult CNChieu()
        //{
        //    var ls = TimKiemND("1", "3");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu2Sang()
        //{
        //    var ls = TimKiemND("2", "1");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu2Trua()
        //{
        //    var ls = TimKiemND("2", "2");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu2Chieu()
        //{
        //    var ls = TimKiemND("2", "3");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu3Sang()
        //{
        //    var ls = TimKiemND("3", "1");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu3Trua()
        //{
        //    var ls = TimKiemND("3", "2");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu3Chieu()
        //{
        //    var ls = TimKiemND("3", "3");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu4Sang()
        //{
        //    var ls = TimKiemND("4", "1");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu4Trua()
        //{
        //    var ls = TimKiemND("4", "2");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu4Chieu()
        //{
        //    var ls = TimKiemND("4", "3");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu5Sang()
        //{
        //    var ls = TimKiemND("5", "1");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu5Trua()
        //{
        //    var ls = TimKiemND("5", "2");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu5Chieu()
        //{
        //    var ls = TimKiemND("5", "3");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu6Sang()
        //{
        //    var ls = TimKiemND("6", "1");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu6Trua()
        //{
        //    var ls = TimKiemND("6", "2");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu6Chieu()
        //{
        //    var ls = TimKiemND("6", "3");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu7Sang()
        //{
        //    var ls = TimKiemND("7", "1");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu7Trua()
        //{
        //    var ls = TimKiemND("7", "2");
        //    return PartialView(ls);
        //}
        //public ActionResult Thu7Chieu()
        //{
        //    var ls = TimKiemND("7", "3");
        //    return PartialView(ls);
        //}
        ////Tìm kiếm nội dung theo thứ và buổi
        //public IQueryable<LoadNDKeHoach> TimKiemND(string thu, string buoi)
        //{
        //    string id = (string)Session["ID"];
        //    using (var db = new QuanLyDinhDuongEntities())
        //    {
        //        var ls = from a in db.KeHoaches
        //                 join b in db.ThucDons
        //                 on a.IdThucDon equals b.Id
        //                 join c in db.MonAns
        //                 on b.IdMonAn equals c.Id
        //                 where a.IdThu == thu
        //                 && a.IdBuoi == buoi
        //                 && b.IdNguoiDung == id /*"1"*/
        //                 select new LoadNDKeHoach
        //                 {
        //                     TenMon = c.Name,
        //                     SoLuong = (int)b.SoLuong
        //                 };
        //        return ls;
        //    }
        //}
    }
}