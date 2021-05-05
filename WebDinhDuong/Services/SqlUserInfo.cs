using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlUserInfo
    {
        private QuanLyDinhDuongEntities db= new QuanLyDinhDuongEntities();
        public SqlUserInfo(QuanLyDinhDuongEntities db)
        {
            this.db = db;
        }
        public SqlUserInfo() { }
        public void Add(NguoiDung nguoiDung)
        {
            db.NguoiDungs.Add(nguoiDung);
            db.SaveChanges();

        }
        public void Delete(String id)
        {
            var nguoidung = db.NguoiDungs.Find(id);
            db.NguoiDungs.Remove(nguoidung);
            db.SaveChanges();
        }

        public NguoiDung GetUser(String id)
        {
            return db.NguoiDungs.FirstOrDefault(r => r.Id == id);
        }

        public void Update(NguoiDung nguoiDung)
        {
            var entry = db.Entry(nguoiDung);   //provides information, ability to perform actions on the entity
            entry.State = EntityState.Modified;
            db.SaveChanges();

        }

    }
}