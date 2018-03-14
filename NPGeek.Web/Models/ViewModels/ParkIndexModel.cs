using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models.ViewModels
{
    public class ParkIndexModel : BaseViewModel
    {
        public override List<park> Parks { get; set; }
    }
}