using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlKeHoach
    {
             
        public void Add(KeHoach Kehoach)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                db.KeHoaches.Add(Kehoach);
                db.SaveChanges();
            }
        }
        public KeHoach GetKeHoach(string id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
               var kh= db.KeHoaches.Find(id);
                db.SaveChanges();
                return kh;
            }
        }
        public int getCount()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                int size = db.KeHoaches.Count();
                return size;
            }
        }
        public void Delete(string id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var kehoach = db.KeHoaches.Find(id);
                db.KeHoaches.Remove(kehoach);
                db.SaveChanges();
            }
        }

        public void Update(KeHoach kehoach)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var entry = db.Entry(kehoach);   //provides information, ability to perform actions on the entity
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public int GetIdMax()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var list = db.KeHoaches.Select(r => r.Id).ToList();
                if (list.Count() == 0)
                {
                    return 1;
                }
                //Doi BillId kieu string sang int
                List<int> intlist = list.Select(s => int.Parse(s)).ToList();
                return intlist.Max() + 1;
            }
        }
        public KeHoach GetKeHoachTheoMonAn(string idmon,string thu, string buoi, string iduser)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.KeHoaches.Where(s => s.IdNguoiDung.Equals(iduser) &&s.IdThu==thu&&s.IdBuoi==buoi&& s.IdMonAn == idmon).FirstOrDefault();
            }
        }

    }
}