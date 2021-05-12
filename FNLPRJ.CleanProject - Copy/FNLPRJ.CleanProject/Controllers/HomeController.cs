using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FNLPRJ.CleanProject.Models; //Using statement that allows the database connection to be made.


namespace FNLPRJ.VisualStudio.PodcastWebApp.Controllers
{

    public class HomeController : Controller
    {

        //  Statement that initializes the database connection and allows interaction with it
        EpisodesEntities dbConnection = new EpisodesEntities();

        //  Index page that serves as the landing page for the application - passes list of Episodes to View
        public ActionResult Index()
        {
            List<Episode> episodes = dbConnection.Episodes.ToList();
            return View(episodes);
        }

        //  AdminSection page to display Episodes - passes list of Episodes to View
        //  Protected with Authorization through AspNetUsers table
        [Authorize]
        public ActionResult AdminSection()
        {
            List<Episode> episodes = dbConnection.Episodes.ToList();
            ViewBag.Message = "Entry to the administration page";

            return View(episodes);
        }

        //  Get Create method to pull up Partial View to create a new Episode row in the Episodes table
        //  Protected with Authorization
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        //  Post Create method that takes an Episode object as a parameter, assigns values, and saves the new Episode
        //  Protected with Authorization
        //  Validation of the moodel is in place
        [Authorize]
        [HttpPost]
        public ActionResult Create(Episode episodeInputData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Episode newEpisode = new Episode();
                    newEpisode.episodeNumber = episodeInputData.episodeNumber;
                    newEpisode.soundFileLocation = episodeInputData.soundFileLocation;
                    newEpisode.description = episodeInputData.description;
                    newEpisode.picFileLocation = episodeInputData.picFileLocation;

                    dbConnection.Episodes.Add(newEpisode);
                    dbConnection.SaveChanges();
                }
                else
                {
                    return PartialView("_Create");
                }
                return RedirectToAction("AdminSection");
            }
            catch (Exception)
            {
                ViewBag.msg = "There was some sort of error that occured - please look into it and come back!";
                return RedirectToAction("AdminSection");
            }

        }

        //  Get EditUpdate method takes in the epiosdeNumber from a row based on where the admin clicks and returns the  
        //          editing interface for that row
        //  Protected with authorization
        [Authorize]
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

        //  Post EditUpdate method takes in an Episode object as a parameter (passed through the editing interface),
        //          searches for the matching row in the Episodes table, assigns values to fields, and saves to database
        //  Protected with Authorization
        //  Validation of the model is in place
        [Authorize]
        [HttpPost]
        public ActionResult EditUpdate(Episode epModified)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Episode epUpdate = dbConnection.Episodes.SingleOrDefault(x => x.episodeNumber == epModified.episodeNumber);
                    epUpdate.episodeNumber = epModified.episodeNumber;
                    epUpdate.soundFileLocation = epModified.soundFileLocation;
                    epUpdate.description = epModified.description;
                    epUpdate.picFileLocation = epModified.picFileLocation;
                    dbConnection.SaveChanges();
                }
                else
                {
                    return PartialView("_EditUpdate");
                }
                return RedirectToAction("AdminSection");
            }
            catch (Exception)
            {
                ViewBag.msg = "Some error has occured!";
                return RedirectToAction("AdminSection");
            }
        }

        //  Post Delete method that takes in an episodeNumber parameter based on the admin's click, queries the database, 
        //          and removes the row that correlates
        //  Protected with Authorization 
        [Authorize]
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

        //  Get Subscribe method to pull up a Partial view to create a new Subscriber row in the Subscribers table
        //  Authorization not required here becuase this is a user interaction
        [HttpGet]
        public ActionResult Subscribe()
        {
            return PartialView("_Subscribe");
        }

        //  Post Subscribe method that takes a Subscriber object as a parameter, assigns values, and saves the new Subscriber
        //  Authorization not required
        //  Validation of the model is in place
        [HttpPost]
        public ActionResult Subscribe(Subscriber subInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Subscriber newSubscriber = new Subscriber();
                    newSubscriber.prefName = subInfo.prefName;
                    newSubscriber.email = subInfo.email;

                    dbConnection.Subscribers.Add(newSubscriber);
                    dbConnection.SaveChanges();
                }
                else
                {
                    return PartialView("_Subscribe");
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.msg = "There was some sort of error that occurred - please look into it and come back.";
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult AdminEmails()
        {
            List<Subscriber> subscribers = dbConnection.Subscribers.ToList();
            ViewBag.msg = "Subscribers section of the administration page.";

            return View(subscribers);
        }

        //  Get Create method to pull up Partial View to create a new Episode row in the Episodes table
        //  Protected with Authorization
        [Authorize]
        [HttpGet]
        public ActionResult subCreate()
        {
            return PartialView("_subCreate");
        }

        //  Post Create method that takes an Episode object as a parameter, assigns values, and saves the new Episode
        //  Protected with Authorization
        //  Validation of the moodel is in place
        [Authorize]
        [HttpPost]
        public ActionResult subCreate(Subscriber subscriber)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Subscriber newSubscriber = new Subscriber();
                    newSubscriber.prefName = subscriber.prefName;
                    newSubscriber.email = subscriber.email;
                   
                    dbConnection.Subscribers.Add(newSubscriber);
                    dbConnection.SaveChanges();
                }
                else
                {
                    return PartialView("_subCreate");
                }
                return RedirectToAction("AdminEmails");
            }
            catch (Exception)
            {
                ViewBag.msg = "There was some sort of error that occured - please look into it and come back!";
                return RedirectToAction("AdminEmails");
            }

        }

        //  Get EditUpdate method takes in the epiosdeNumber from a row based on where the admin clicks and returns the  
        //          editing interface for that row
        //  Protected with authorization
        [Authorize]
        [HttpGet]
        public ActionResult subEditUpdate(int sID)
        {
            try
            {
                if (sID != 0)
                {
                    Subscriber currentSubscriber = dbConnection.Subscribers.SingleOrDefault(x => x.subID == sID);
                    return PartialView("_subEditUpdate", currentSubscriber);
                }
                else
                {
                    return RedirectToAction("AdminEmails");
                }
            }
            catch (Exception)
            {
                ViewBag.msg = "Some type of error is occuring";
                return RedirectToAction("AdminEmails");
            }
        }

        //  Post EditUpdate method takes in an Episode object as a parameter (passed through the editing interface),
        //          searches for the matching row in the Episodes table, assigns values to fields, and saves to database
        //  Protected with Authorization
        //  Validation of the model is in place
        [Authorize]
        [HttpPost]
        public ActionResult subEditUpdate(Subscriber subModified)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Subscriber subUpdate = dbConnection.Subscribers.SingleOrDefault(x => x.subID == subModified.subID);
                    subUpdate.prefName = subModified.prefName;
                    subUpdate.email = subModified.email;
                    dbConnection.SaveChanges();
                }
                else
                {
                    return PartialView("_subEditUpdate");
                }
                return RedirectToAction("AdminEmails");
            }
            catch (Exception)
            {
                ViewBag.msg = "Some error has occured!";
                return RedirectToAction("AdminEmails");
            }
        }

        //  Post Delete method that takes in an episodeNumber parameter based on the admin's click, queries the database, 
        //          and removes the row that correlates
        //  Protected with Authorization 
        [Authorize]
        [HttpPost]
        public ActionResult subDelete(int sID)
        {
            try
            {
                Subscriber toDelete = dbConnection.Subscribers.SingleOrDefault(x => x.subID == sID);

                if (toDelete != null)
                {
                    dbConnection.Subscribers.Remove(toDelete);
                    dbConnection.SaveChanges();
                }
                return RedirectToAction("AdminEmails");
            }
            catch (Exception)
            {
                ViewBag.msg = "Some sort of error has occured here!";
                return RedirectToAction("AdminEmails");
            }
        }



    }
}
