using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FNLPRJ.VisualStudio.PodcastWebApp.Models;

namespace FNLPRJ.VisualStudio.PodcastWebApp.Controllers
{
    
    public class HomeController : Controller
    {

        finalProjectDatabaseEntities dbConnection = new finalProjectDatabaseEntities();


        public ActionResult Index()
        {
            List<Episode> episodes = dbConnection.Episodes.ToList();
            return View(episodes);
        }

        public ActionResult IndexOG()
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