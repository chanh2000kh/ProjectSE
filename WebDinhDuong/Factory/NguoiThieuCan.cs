using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
   public class NguoiThieuCan:IPeopleStatus    
    {
        public string getTinhTrang()
        {
            string tinhtrang = "Thiếu cân";
            return tinhtrang;
        }
    }
}