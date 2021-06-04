using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
    class ThieuCan : TinhTrang
    {
        private string tinhtrang;
        public override void setTinhTrang(string tinhtrang)
        {
            this.tinhtrang = tinhtrang;
        }
        public override string ChiSoBMI()
        {
            return tinhtrang;
        }
        public ThieuCan(string tinhtrang)
        {
            this.tinhtrang = tinhtrang;
        }
    }
}