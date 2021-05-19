using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlThucDon
    {
        public SqlThucDon() { }
        public void Add(ThucDon thucdon)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                db.ThucDons.Add(thucdon);
                db.SaveChanges();
            }

        }
        public int getCount()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                int size = db.ThucDons.Count();
                return size;
            }
        }
        public void Delete(String id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var thucdon = db.ThucDons.Find(id);
                db.ThucDons.Remove(thucdon);
                db.SaveChanges();
            }
        }
        public ThucDon GetAccFormId(string id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.ThucDons.Where(s => s.Id.Equals(id)).FirstOrDefault();
            }
        }
        

        public void Update(ThucDon thucdon)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var entry = db.Entry(thucdon);   //provides information, ability to perform actions on the entity
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        
    }
}