using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDinhDuong.ModelView
{
    public class FoodView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> Calo { get; set; }
        public Nullable<double> Carb { get; set; }
        public Nullable<double> Fat { get; set; }
        public Nullable<double> Protein { get; set; }
        public string ThongTin { get; set; }
        [NotMapped]
        public HttpPostedFileBase HinhAnh { get; set; }

    }
}