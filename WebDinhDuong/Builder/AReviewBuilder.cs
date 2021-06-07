using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Builder
{
    abstract class AReviewBuilder
    {
        protected DanhGiaNhanXet review;
        public DanhGiaNhanXet getReview
        {
            get{
                return review;
            }
        }
        public abstract void AddId(string id);
        public abstract void AddIdUser(string iduser);
        public abstract void AddDate(DateTime ngay);
        public abstract void AddDanhGia(int rating);
        public abstract void AddNhanXet(string comment);
    }
}