using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models.ViewModels
{
    public class ParkSurveyCount
    {
        public park park { get; set; }
        public int numberOfSurveys { get; set; }
    }
}