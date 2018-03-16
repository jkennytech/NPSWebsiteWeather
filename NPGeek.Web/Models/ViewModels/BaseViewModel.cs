using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models.ViewModels
{
    public class BaseViewModel
    {
        public park Park { get; set; }
        public bool Fahrenheit { get; set; }       
    }
}