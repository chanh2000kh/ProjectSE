using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
    public class NguoiThuaCan : IPeopleStatus
    {
        public string getTinhTrang()
        {
            string tinhtrang = "Thừa cân";
            return tinhtrang;
        }
    }
}