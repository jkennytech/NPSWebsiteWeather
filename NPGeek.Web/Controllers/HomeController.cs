using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.Models;
using NPGeek.Web.Models.ViewModels;

namespace NPGeek.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ParkIndexModel parks = new ParkIndexModel();
            using (var context = new ParkSystemDatabaseEntities())
            {
                parks.Parks = context.parks.ToList();
            }
                return View(parks);
        }

        public ActionResult Detail(string parkId)
        {
            ParkDetailModel park = new ParkDetailModel();
            using (var context = new ParkSystemDatabaseEntities())
            {
                park.Park = context.parks.Where(p => p.parkCode == parkId).FirstOrDefault();
                park.WeatherModels = context.weathers.Where(w => w.parkCode == parkId).ToList();
            }
                return View(park);
        }

        public ActionResult Survey()
        {
            SurveyModel survey = new SurveyModel();
            using (var context = new ParkSystemDatabaseEntities())
            {
                survey.Parks = context.parks.ToList();
            }
                return View(survey);
        }

        public ActionResult SurveyResult()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitSurvey(survey_result survey)
        {
            using (var context = new ParkSystemDatabaseEntities())
            {
                context.survey_result.Add(survey);
                context.SaveChanges();

            }
                return RedirectToAction("SurveyResult");
        }
   

        [HttpPost]
        public ActionResult Index(string temperature)
        {
            return RedirectToAction("Index");
        }
    }
}