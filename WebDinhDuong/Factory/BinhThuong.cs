using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
    class BinhThuong : TinhTrang
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
        public BinhThuong(string tinhtrang)
        {
            this.tinhtrang = tinhtrang;
        }

    }
}