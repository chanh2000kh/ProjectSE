using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;
namespace WebDinhDuong.Models
{
    [Serializable]
    public class ListFoodView
    {
       
        public MonAn Product { get; set; }
        public int Quanlity { get; set; }
        public string Name { get; internal set; }
        public object Calo { get; internal set; }
        public object Carb { get; internal set; }
        public object Fat { get; internal set; }
        public object Protein { get; internal set; }
        public string ThongTin { get; internal set; }
        public object HinhAnh { get; internal set; }
    }
}