using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models.ViewModels
{
    public class ParkDetailModel : BaseViewModel
    {
        public park Park {get; set; }
        public List<weather> WeatherModels { get; set; }
        public string TodayRecommend
        {
            get
            {
                var snow = "It will be cold and snowy. If you come out, please bring snow shoes.";
                var rain = "Pack rain gear and wear waterproof shoes.";
                var thunderStorm = "Seek shelter and avoid hiking on exposed ridges.";
                var sun = "The sun will be out. Please wear sunscreen.";
                var hot = " Hot weather could lead to dehydration. Bring an extra gallon of water";
                var difference = " The weather may change. Please bring breathable layers";
                var cold = " It may be well below freezing. Hypothermia and frostbite are dangers that you will want to avoid.";
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