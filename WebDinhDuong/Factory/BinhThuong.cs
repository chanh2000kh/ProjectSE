using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
    class BinhThuong : TinhTrang
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
        public BinhThuong(string tinhtrang)
        {
            this.tinhtrang = tinhtrang;
        }

    }
}