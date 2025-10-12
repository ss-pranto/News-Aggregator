using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PresentationMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var data = FilterNewsService.FilterByPage(page);
            return View(data);
        }
        [HttpGet]
        public ActionResult Recommend()
        {
            var email = (string)Session["Log_user"];
            var userData = UserLoginService.GetUser(email);
            var data = RecommendationService.RecommendedNews(userData.ID);
            return View(data);
        }
        [HttpGet]
        public ActionResult Popular()
        {
            var data = RecommendationService.PopularNews();
            return View(data);
        }
        public ActionResult NewsByID(int id)
        {
            var data = NewsService.GetByID(id);
            var email = (string)Session["Log_user"];
            var userData = UserLoginService.GetUser(email).ID;
            var ActivityData = NewsService.GetActivity(id, userData);
            TempData["activity"] = ActivityData;
            var BookmarkData = RecommendationService.GetBookmark(userData, id);
            TempData["bookmark"] = BookmarkData;
            return View(data);
        }
        [HttpPost]
        public ActionResult AddActivity(int nid, string activity)
        {
            var email = (string)Session["Log_user"];
            var userData = UserLoginService.GetUser(email).ID;
            NewsService.AddActivity(nid, userData, activity);

            return RedirectToAction("NewsByID", new { id = nid });
        }
        [HttpPost]
        public ActionResult RemoveActivity(int nid)
        {
            var email = (string)Session["Log_user"];
            var userData = UserLoginService.GetUser(email).ID;
            NewsService.RemoveActivity(nid, userData);

            return RedirectToAction("NewsByID", new { id = nid });
        }
        [HttpPost]
        public ActionResult AddBookmark(int nid)
        {
            var email = (string)Session["Log_user"];
            var userData = UserLoginService.GetUser(email).ID;
            RecommendationService.BookmarkNews(userData, nid);

            return RedirectToAction("NewsByID", new { id = nid });
        }
        [HttpPost]
        public ActionResult RemoveBookmark(int nid)
        {
            var email = (string)Session["Log_user"];
            var userData = UserLoginService.GetUser(email).ID;
            RecommendationService.RemoveBookmark(userData, nid);

            return RedirectToAction("NewsByID", new { id = nid });
        }
    }
}