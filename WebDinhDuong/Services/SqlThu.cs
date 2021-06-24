using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Services
{
    public class SqlThu
    {
        public IEnumerable<Thu> getAll()
        {
            using (var db = new QuanLyDinhDuongEntities())
            {
                return db.Thus;
            }

        }
    }
}