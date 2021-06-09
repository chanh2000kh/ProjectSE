using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Adapter
{
    public interface IThucDon //cần thông dịch thực đơn hợp lệ
    {
        void send(ThucDon thucdon);
    }
}