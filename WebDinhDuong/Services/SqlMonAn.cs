using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlMonAn
    {       
        public void Add(MonAn mon )
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                db.MonAns.Add(mon);
                db.SaveChanges();
            }

        }
        public int getCount()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                int size = db.MonAns.Count();
                return size;
            }
        }
        public void Delete(String id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var mon = db.MonAns.Find(id);
                db.MonAns.Remove(mon);
                db.SaveChanges();
            }
        }
        public MonAn GetMonAn(string id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.MonAns.Where(s => s.Id.Equals(id)).FirstOrDefault();
            }
        }
        public List<MonAn> GetAll()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.MonAns.ToList();
            }
        }


        public void Update(MonAn mon)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var entry = db.Entry(mon);   //provides information, ability to perform actions on the entity
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public List<MonAn> ListMonAn(string id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
               // var product = db.MonAns.Find(id);
                return db.MonAns.Where(x => x.Id != id).ToList();
            }
        }
        public List<MonAn> getMonAnByName(string name)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
               return db.MonAns.SqlQuery("Select * from MonAn where Name  like '%" + name + "%'").ToList();
            }
        }
    }
}