using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;
namespace WebDinhDuong.Models
{
    [Serializable]
    public class FoodItem
    {
       
        public MonAn Product { get; set; }
        public int Quanlity { get; set; }
    }
}