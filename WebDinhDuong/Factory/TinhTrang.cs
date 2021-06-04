using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
    abstract class TinhTrang
    {
        public abstract void setTinhTrang(string tinhtrang);
        public abstract string ChiSoBMI();
    }
}