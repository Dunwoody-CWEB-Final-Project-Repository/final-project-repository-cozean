using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FNLPRJ.VisualStudio.PodcastWebApp.Domain.Abstract;

namespace FNLPRJ.VisualStudio.PodcastWebApp.Controllers
{
    public class EpisodeController : Controller
    {
        private IEpisodeRepository myrepository;

        public EpisodeController(IEpisodeRepository episodeRepository)
        {
            this.myrepository = episodeRepository;
        }

        public ViewResult List()
        {
            return View(myrepository.Episodes);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}