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
        public int GetIdMax()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                var list = db.DanhGiaNhanXets.Select(r => r.Id).ToList();
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