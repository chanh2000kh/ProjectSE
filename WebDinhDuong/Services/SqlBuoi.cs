using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlBuoi
    {
        public IEnumerable<Buoi> getAll()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.Buois;
            }

        }
    }
}