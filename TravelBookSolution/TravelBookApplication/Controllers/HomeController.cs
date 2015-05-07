using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBookApplication.Models;

namespace TravelBookApplication.Controllers
{
    public class HomeController : Controller
    {
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public ActionResult Index(ApplicationUser p)
        {
			if(ModelState.IsValid)
			{
				ApplicationUser u = new ApplicationUser();
				UpdateModel(u);
				// service
				return RedirectToAction("NewsFeed");
			}
			else
			{
				return View(p);
			}
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SearchForUser(FormCollection coll)
        {

            return View("Index");
        }

		public ActionResult NewsFeed()
		{
			ViewBag.Message = "Your newsfeed.";

			return View();
		}
    }
}