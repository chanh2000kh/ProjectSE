using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDinhDuong.Models;

namespace WebDinhDuong.Builder
{
    class ReviewBuilder : AReviewBuilder
    {
        private string Id; 
        private string IdUser;
        private int Rating;
        private DateTime Ngay;
        private string Comment;
     

        public override void AddDanhGia(int rating)
        {
            this.Rating = rating;
        }

        public override void AddDate(DateTime ngay)
        {
            this.Ngay = ngay;
        }

        public override void AddId(string id)
        {
            this.Id = id;
        }

        public override void AddIdUser(string iduser)
        {
            this.IdUser = iduser;
        }
        public override void AddNhanXet(string comment)
        {
            this.Comment = comment;
        }
    }
}