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
            parks.Fahrenheit = CheckTemp();
            using (var context = new ParkSystemDatabaseEntities())
            {
                parks.Parks = context.parks.ToList();
            }
            return View(parks);
        }

        public ActionResult Detail(string parkId)
        {
            ParkDetailModel park = new ParkDetailModel();
            park.Fahrenheit = CheckTemp();
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
            survey.Fahrenheit = CheckTemp();
            using (var context = new ParkSystemDatabaseEntities())
            {
                survey.Parks = context.parks.ToList();
            }
            return View(survey);
        }

        public ActionResult SurveyResult()
        {
            SurveyResultsModel surveyResult = new SurveyResultsModel();
            surveyResult.ParkSurveyList = new List<ParkSurveyCount>();
            surveyResult.Fahrenheit = CheckTemp();
            using (var context = new ParkSystemDatabaseEntities())
            {
                foreach(var park in context.survey_result)

                foreach (var survey in context.survey_result)
                {
                    
                    ParkSurveyCount count =  new ParkSurveyCount{
                        park = survey.park,
                        numberOfSurveys = survey.park.parkCode.Count()
                    };
                       
                    surveyResult.ParkSurveyList.Add(count);
                    
                }
            }
            surveyResult.ParkSurveyList.OrderBy(model => model.numberOfSurveys);
            return View(surveyResult);
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
        public ActionResult ChangeTemp(string type)
        {
            bool Fahrenheit = false;
            if (type == "f")
            {
                Fahrenheit = true;
            }

            Session["Fahrenheit"] = Fahrenheit;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public bool CheckTemp()
        {
            bool fahrenheit = true;
            if(Session["Fahrenheit"] == null)
            {
                Session["Fahrenheit"] = true;
            }
            else
            {
                fahrenheit = Convert.ToBoolean(Session["Fahrenheit"]);
            }

            return fahrenheit;
        }
    }
}