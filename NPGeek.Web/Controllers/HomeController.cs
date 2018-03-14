using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.Models;

namespace NPGeek.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<park> parks;
            using (var context = new ParkSystemDatabaseEntities())
            {
                parks = context.parks.ToList();
            }
                return View(parks);
        }
    }
}