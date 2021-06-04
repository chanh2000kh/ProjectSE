using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Factory
{
    class NguoiBinhThuong : Nguoi
    {
        public override void setTinhTrang(TinhTrang tinhtrang)
        {
            myTinhTrang = new ThuaCan("Thiếu cân");
        }
    }
}