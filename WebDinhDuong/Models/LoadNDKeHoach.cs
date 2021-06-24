using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Models
{
    public class LoadNDKeHoach
    {
        public string Id { get; set; }
        public string IdMon { get; set; }
       public string TenMon { get; set; }
       public string GhiChu { get; set; }
       public DateTime Ngay { get; set; }
       public int SoLuong { get; set; }
    }
}