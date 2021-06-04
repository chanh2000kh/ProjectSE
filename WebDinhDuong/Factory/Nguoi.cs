using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
   abstract class Nguoi
   {
       protected TinhTrang myTinhTrang;
        public abstract void setTinhTrang(TinhTrang tinhtrang);
        public string TinhTrangInfo()
        {
            return myTinhTrang.ChiSoBMI();
        }
      
   }
}