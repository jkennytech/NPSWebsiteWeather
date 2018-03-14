using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models.ViewModels
{
    public class BaseViewModel
    {
        public virtual park Park { get; set; }
        public virtual List<weather> WeatherModels { get; set; }
        public virtual string TodayRecommend { get; }       
        public bool Fahrenheit { get; set; }    
        public virtual List<park> Parks { get; set; }
    }
}