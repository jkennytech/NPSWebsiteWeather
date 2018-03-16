using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DALS;
using NPGeek.Web.Models;
using NPGeek.Web.Models.ViewModels;

namespace NPGeek.Web.Controllers
{
    public class HomeController : Controller
    {
        private ISurveyResultDAL dal;
        public HomeController(ISurveyResultDAL dal)
        {
            this.dal = dal;
        }

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

            if (park.Fahrenheit != true)
            {
                foreach (var temp in park.WeatherModels)
                {

                    temp.high = (int)((temp.high - 32) * 5 / 9);
                    temp.low = (int)((temp.low - 32) * 5 / 9);

                }
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

        [HttpPost]
        public ActionResult Survey(SurveyModel theSurvey)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ParkSystemDatabaseEntities())
                {
                    context.survey_result.Add(theSurvey.Survey);
                    context.SaveChanges();

                }
                return RedirectToAction("SurveyResult");
            }
            else
            {
                SurveyModel survey = new SurveyModel();
                survey.Fahrenheit = CheckTemp();
                using (var context = new ParkSystemDatabaseEntities())
                {
                    survey.Parks = context.parks.ToList();
                }
                survey.Survey = theSurvey.Survey;
                return View(survey);
            }
        }

        public ActionResult SurveyResult()
        {
            SurveyResultsModel surveyResult = new SurveyResultsModel();
            surveyResult.ParkSurveyList = new List<park>();
            surveyResult.Fahrenheit = CheckTemp();

            List<string> parkCodes = dal.GetParkCodeByVote();

            using (var context = new ParkSystemDatabaseEntities())
            {

                foreach(string code in parkCodes)
                {
                    surveyResult.ParkSurveyList.Add(context.parks.Where(p => p.parkCode == code).FirstOrDefault());
                }

                //var query = from survey_result in context.survey_result
                //            group survey_result by survey_result.parkCode into grouping
                //            orderby grouping.Count() descending
                //            select new { parkCode = grouping.Key, Total = grouping.Count() };
                //foreach(var parkCodeFound in query)
                //{
                //    surveyResult.ParkSurveyList.Add(context.parks.Where(p => p.parkCode == parkCodeFound.ToString()).FirstOrDefault());
                //}
            }
            
            return View(surveyResult);
        }

        [HttpPost]
        public ActionResult SubmitSurvey(survey_result survey)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ParkSystemDatabaseEntities())
                {
                    context.survey_result.Add(survey);
                    context.SaveChanges();

                }
                return RedirectToAction("SurveyResult");
            }
            else
            {
                return View("Survey", survey);
            }
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
            if (Session["Fahrenheit"] == null)
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