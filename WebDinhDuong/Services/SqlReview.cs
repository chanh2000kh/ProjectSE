using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlReview
    {
        public void Add(DanhGiaNhanXet review)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                db.DanhGiaNhanXets.Add(review);
                db.SaveChanges();
            }
        }
        public DanhGiaNhanXet GetReview(string iduser)
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.DanhGiaNhanXets.Where(s => s.IdUser.Equals(iduser)).FirstOrDefault();
            }
        }
        public int getCount()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                int size = db.DanhGiaNhanXets.Count();
                return size;
            }
        }
    }
}