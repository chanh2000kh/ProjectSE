using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
    class ThuaCan : TinhTrang
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
        public ThuaCan(string tinhtrang)
        {
            this.tinhtrang = tinhtrang;
        }
    }