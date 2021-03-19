using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FNLPRJ.VisualStudio.PodcastWebApp.Controllers
{
    //This is purely a symbolic gitpush, because this technical writing midterm is kicking my ass
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Episode()
        {
            ViewBag.Message = "The Episodes page";

            return View();
        }

        public ActionResult MessageUs()
        {
            ViewBag.Message = "The Message Us page";

            return View();
        }

        public ActionResult EpisodeContent()
        {
            ViewBag.Message = "The Episode content page";

            return View();
        }
    }
}