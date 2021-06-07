using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
    class ThieuCan : TinhTrang
    {
        private string tinhtrang;
        private int bmi;
        public override void setTinhTrang(string tinhtrang)
        {
            this.tinhtrang = tinhtrang;
        }
        public override int ChiSoBMI()
        {
            return bmi;
        }
        public ThieuCan(string tinhtrang)
        {
            this.tinhtrang = tinhtrang;
        }
    }
}