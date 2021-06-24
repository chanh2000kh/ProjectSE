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
        public void Delete(string id, string iduser, DateTime date)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var thucdon = db.ThucDons.Where(s => s.Id.Equals(id)&&s.IdNguoiDung.Equals(iduser) && s.Ngay == date).FirstOrDefault();
                db.ThucDons.Remove(thucdon);
                db.SaveChanges();
            }
        }
        public void DeleteAllThucDonTrongNgay(string iduser,DateTime date)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var thucdon = db.ThucDons.Where(s => s.IdNguoiDung.Equals(iduser) && s.Ngay == date).ToList();
                foreach(var item in thucdon)
                {
                    db.ThucDons.Remove(item);
                }                    
                db.SaveChanges();
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
        public List<ThucDon> getThucDonOfNguoiDung(string iduser, DateTime date)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.ThucDons.Where(s => s.IdNguoiDung.Equals(iduser)&&s.Ngay==date).ToList();
            }
        }
        public ThucDon getThucDonFromMonAn(string iduser, DateTime date, string idfood)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.ThucDons.Where(s => s.IdNguoiDung.Equals(iduser) && s.Ngay == date&&s.IdMonAn.Equals(idfood)).FirstOrDefault();
            }
        }
        public IEnumerable<ThucDon> GetThucDonNguoiDungHienTai(string iduser, DateTime date)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.ThucDons.Where(s => s.IdNguoiDung.Equals(iduser) && s.Ngay == date).ToList();
            }
        }
        public double GetTotalCalo(string iduser, DateTime date)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                double ?total = (from td in db.ThucDons
                                 where td.IdNguoiDung == iduser && td.Ngay==date
                                 select (double?)td.Calo).Sum();

                return total??0;
            }
        }
        public ThucDon getThucDon(string id)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.ThucDons.Where(s => s.Id.Equals(id)).FirstOrDefault();
            }
        }
        public int GetIdMax()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var list = db.ThucDons.Select(r => r.Id).ToList();
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