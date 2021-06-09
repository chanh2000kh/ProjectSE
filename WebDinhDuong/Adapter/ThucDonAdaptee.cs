using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Adapter
{
    public class ThucDonAdaptee     //nhận thông dịch từ adapter
    {
        private ThucDon thucdon;
        public void receive(ThucDon thucdon)
        {
            this.thucdon = thucdon;
        }
        public ThucDon getThucDonHopLe()
        {
            return this.thucdon;
        }
    }
}