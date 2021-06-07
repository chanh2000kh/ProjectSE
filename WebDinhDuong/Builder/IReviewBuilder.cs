using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Builder
{
    interface IReviewBuilder
    {
         DanhGiaNhanXet GetReview();       
        void AddId(string id);
        void AddIdUser(string iduser);
        void AddDate(DateTime ngay);
        void AddDanhGia(int rating);
        void AddNhanXet(string comment);
    }
}