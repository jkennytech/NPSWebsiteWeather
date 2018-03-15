using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models.ViewModels
{
    public class SurveyResultsModel : BaseViewModel
    {
        public List<survey_result> SurveyResult { get; set; }
        public List<park> Parks { get; set; }
    }
}