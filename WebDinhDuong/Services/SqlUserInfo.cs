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
        QuanLyDinhDuongEntities db = new QuanLyDinhDuongEntities();

        public SqlUserInfo() { }
        public void Add(NguoiDung nguoiDung)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                db.NguoiDungs.Add(nguoiDung);
                db.SaveChanges();
            }

        }
        public void Delete(string id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var nguoidung = db.NguoiDungs.Find(id);
                db.NguoiDungs.Remove(nguoidung);
                db.SaveChanges();
            }
        }
        public int getCount()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.NguoiDungs.Count();
            }
        }

        public NguoiDung GetUser(string id )
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.NguoiDungs.FirstOrDefault(r => r.Id.Equals(id));
            }
        }

        public NguoiDung GetUserFromIdLogin(string idlogin)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.NguoiDungs.FirstOrDefault(r => r.IdLogin.Equals(idlogin));
            }
        }


        public void Update(NguoiDung nguoiDung)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var entry = db.Entry(nguoiDung);   //provides information, ability to perform actions on the entity
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public Admin GetAdmin(string id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.Admins.FirstOrDefault(r => r.IdLogin.Equals(id));
            }
        }

    }
}