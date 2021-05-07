using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FNLPRJ.VisualStudio.PodcastWebApp.Models;
using FNLPRJ.VisualStudio.PodcastWebApp.Domain.Abstract;

namespace FNLPRJ.VisualStudio.PodcastWebApp.Controllers
{
    
    public class HomeController : Controller
    {

        finalProjectDatabaseEntities dbConnection = new finalProjectDatabaseEntities();

        private IEpisodeRepository myrepository;

        public HomeController(IEpisodeRepository episodeRepository)
        {
            this.myrepository = episodeRepository;
        }

        public ViewResult HomeTest()
        {
            return View(myrepository.Episodes);
        }

        public ActionResult Index()
        {
            List<Episode> episodes = dbConnection.Episodes.ToList();
            return View(episodes);
        }

        public ActionResult Episodes()
        {
            List<Episode> episodes = dbConnection.Episodes.ToList();
            return View(episodes);
        }

        [Authorize]
        public ActionResult AdminSection()
        {
            List<Episode> episodes = dbConnection.Episodes.ToList();
            ViewBag.Message = "Your application description page.";

            return View(episodes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(Episode episodeInputData)
        {
            try
            {
                if (episodeInputData != null)
                {
                    Episode newEpisode = new Episode();
                    newEpisode.episodeNumber = episodeInputData.episodeNumber;
                    newEpisode.soundFileLocation = episodeInputData.soundFileLocation;
                    newEpisode.description = episodeInputData.description;
                    newEpisode.picFileLocation = episodeInputData.picFileLocation;

                    dbConnection.Episodes.Add(newEpisode);
                    dbConnection.SaveChanges();
                }
                return RedirectToAction("AdminSection");
            }
            catch (Exception)
            {
                ViewBag.msg = "There was some sort of error that occured - please look into it and come back!";
                return RedirectToAction("AdminSection");
            }

        }

        [HttpGet]
        public ActionResult EditUpdate(int epNum)
        {
            try
            {
                if (epNum != 0)
                {
                    Episode currentEpisode = dbConnection.Episodes.SingleOrDefault(x => x.episodeNumber == epNum);
                    return PartialView("_EditUpdate", currentEpisode);
                }
                else
                {
                    return RedirectToAction("AdminSection");
                }
            }
            catch (Exception)
            {
                ViewBag.msg = "Some type of error is occuring";
                return RedirectToAction("AdminSection");
            }
        }

        [HttpPost]
        public ActionResult EditUpdate(Episode epModified)
        {
            try
            {
                if (epModified != null)
                {
                    Episode epUpdate = dbConnection.Episodes.SingleOrDefault(x => x.episodeNumber == epModified.episodeNumber);
                    epUpdate.episodeNumber = epModified.episodeNumber;
                    epUpdate.soundFileLocation = epModified.soundFileLocation;
                    epUpdate.description = epModified.description;
                    epUpdate.picFileLocation = epModified.picFileLocation;
                    dbConnection.SaveChanges();
                }
                return RedirectToAction("AdminSection");
            }
            catch (Exception)
            {
                ViewBag.msg = "Some error has occured!";
                return RedirectToAction("AdminSection");
            }
        }

        [HttpPost]
        public ActionResult Delete(int epNum)
        {
            try
            {
                Episode toDelete = dbConnection.Episodes.SingleOrDefault(x => x.episodeNumber == epNum);
                
                if (toDelete != null)
                {
                    dbConnection.Episodes.Remove(toDelete);
                    dbConnection.SaveChanges();
                }
                return RedirectToAction("AdminSection");
            }   
            catch (Exception)
            {
                ViewBag.msg = "Some sort of error has occured here!";
                return RedirectToAction("AdminSection");
            }
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

     
    }
}