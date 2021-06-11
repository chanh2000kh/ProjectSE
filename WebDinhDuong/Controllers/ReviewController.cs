using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDinhDuong.Builder;
using WebDinhDuong.Services;

namespace WebDinhDuong.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Comment
        SqlReview db = new SqlReview();
        public ActionResult Index()
        {
            var model = db.GetReview(Session["ID"].ToString());
            return View(model);
        }
        public ActionResult AddReview(int rating, string articleComment)
        {
            DateTime date = DateTime.Now.Date;
           string id= (db.getCount() + 1).ToString();

            ReviewBuilder reviewBuilder = new ReviewBuilder();
            reviewBuilder.AddId(id);
            reviewBuilder.AddIdUser(Session["ID"].ToString());
            reviewBuilder.AddNhanXet(articleComment);
            reviewBuilder.AddDate(date);
            reviewBuilder.AddDanhGia(rating);

            db.Add(reviewBuilder.GetReview());
            return RedirectToAction("Index");
        }
    }
}