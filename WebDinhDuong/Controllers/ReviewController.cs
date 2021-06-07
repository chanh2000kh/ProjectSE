using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            return RedirectToAction("Index");
        }
    }
}