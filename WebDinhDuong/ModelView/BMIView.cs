using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.ModelView
{
    public class BMIView
    {
        public NguoiDung Nguoidung { get; set; }
        public string Tinhtrang { get; set; }
        public double BMI { get; set; }


    }
}