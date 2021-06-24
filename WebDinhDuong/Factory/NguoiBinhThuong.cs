using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
   public class NguoiBinhThuong : IPeopleStatus
    {

        public string getTinhTrang()
        {
            string tinhtrang= "Bình thường";
            return tinhtrang;
        }
     
    }
}