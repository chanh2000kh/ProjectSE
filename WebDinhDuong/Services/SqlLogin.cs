using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlLogin
    {                  
        public void Add(Login login)
        {
            using(var db= new QuanLyDinhDuongEntities()){
                db.Logins.Add(login);
                db.SaveChanges();
            }

        }
        public int getCount()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                int size = db.Logins.Count();
                return size;
            }
        }
        public void Delete(String id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var login = db.Logins.Find(id);
                db.Logins.Remove(login);
                db.SaveChanges();
            }
        }
        public Login GetAccFormId(string id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.Logins.Where(s => s.Id.Equals(id)).FirstOrDefault();
            }
        }
        public Login GetAcc(string pass, string mail)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.Logins.Where(s => s.Email.Equals(mail) && s.Password.Equals(pass)).FirstOrDefault();
            }
        }

        public void Update(Login login)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var entry = db.Entry(login);   //provides information, ability to perform actions on the entity
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }

        }
        public bool checkMailExist(string mail)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var login = db.Logins.Where(s => s.Email.Equals(mail)).FirstOrDefault();
                if (login != null) return true;
                return false;
            }
        }
        public int GetIdMax()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var list = db.Logins.Select(r => r.Id).ToList();
                if (list.Count() == 0)
                {
                    return 1;
                }
                //Doi BillId kieu string sang int
                List<int> intlist = list.Select(s => int.Parse(s)).ToList();
                return intlist.Max() + 1;
            }
        }

    }
}