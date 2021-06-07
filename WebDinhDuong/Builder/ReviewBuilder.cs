using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Builder
{
    class ReviewBuilder : IReviewBuilder
    {
      
        DanhGiaNhanXet review = new DanhGiaNhanXet();

        public void AddDanhGia(int rating)
        {
            review.DanhGia = rating;
        }

        public void AddDate(DateTime ngay)
        {
            review.Ngay = ngay;
        }

        public void AddId(string id)
        {
            review.Id = id;
        }

        public void AddIdUser(string iduser)
        {
            review.IdUser = iduser;
        }
        public void AddNhanXet(string comment)
        {
            review.NhanXet = comment;
        }
        public DanhGiaNhanXet GetReview()
        {
            return review;
        }
    }
}