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
        public int getCount()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                int size = db.KeHoaches.Count();
                return size;
            }
        }
        public void Delete(String idmon, String idnguoidung, String idthu, String idbuoi)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var kehoach = db.KeHoaches.Find(idmon, idnguoidung, idthu, idbuoi);
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
        
    }
}