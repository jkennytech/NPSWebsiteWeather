using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models.ViewModels
{
    public class ParkDetailModel
    {
        public park Park {get; set; }
        public List<weather> WeatherModels { get; set; }
        public string TodayRecommend
        {
            get
            {
                var snow = "Weather is expected to be cold, sad and overall terrible. If you really want to come out please bring snow shoes.";
                var rain = "Pack rain gear and wear waterproof shows.";
                var thunderStorm = "Please seek shelter and avoid hiking on exposed ridges.";
                var sun = "Please make sure to wear sunscreen.";
                var hot = " It is recommended to bring an extra gallon of water";
                var difference = " The weather may change, please bring breathable layers";
                var cold = " It may be well below freezing. Please just go home. Please.. You could get hypothermia. Or frostbite. Or Die.";
                string returnString = "";

                if(this.WeatherModels.FirstOrDefault().forecast == "snow")
                {
                    returnString += snow;
                }
                if (this.WeatherModels.FirstOrDefault().forecast == "rain")
                {
                    returnString += rain;
                }
                if (this.WeatherModels.FirstOrDefault().forecast == "thunderstorms")
                {
                    returnString += thunderStorm;
                }
                if (this.WeatherModels.FirstOrDefault().forecast == "sunny")
                {
                    returnString += sun;
                }
                if (this.WeatherModels.FirstOrDefault().high > 75)
                {
                    returnString += hot;
                }
                if ((this.WeatherModels.FirstOrDefault().high - this.WeatherModels.FirstOrDefault().low) > 20)
                {
                    returnString += difference;
                }
                if (this.WeatherModels.FirstOrDefault().low < 20)
                {
                    returnString += cold;
                }
                return returnString;
            }
        }
    }
}