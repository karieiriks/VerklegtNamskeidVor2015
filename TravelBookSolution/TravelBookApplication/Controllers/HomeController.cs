using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Services;

namespace TravelBookApplication.Controllers
{
    public class HomeController : Controller
    {
		[HttpGet]
		public ActionResult Index()
		{
			return View();
			//return RedirectToAction("UserNewsFeed");
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

        public ActionResult UserNewsfeed()
        {
            List<UserContent> content = new List<UserContent>();
            ApplicationUser user = new ApplicationUser();
            user.UserName = "Sverrir Magnússon";
            UserContent contentInstance = new UserContent();
            contentInstance.Owner = user;
            contentInstance.PostConent = "Var að koma frá Róm!";

            UserContent contentInstance1 = new UserContent();
            contentInstance1.Owner = user;
            contentInstance1.StoryName = "12345";
            contentInstance1.StoryTitle = "Saga frá Róm";


            for (int i = 0; i < 10; i++)
            {
                content.Add(contentInstance);
                content.Add(contentInstance1);
            }

            return View("UserNewsfeed", content);
        }

		/*public ActionResult NewsFeed()
		{
			ViewBag.Message = "Your newsfeed.";

			return View();
		}*/

		[HttpPost]
		public ActionResult Register(RegisterViewModel r)
		{
			if(ModelState.IsValid)
			{
				ApplicationUser u = new ApplicationUser();
				UpdateModel(u);
				//service
				return RedirectToAction("UserNewsFeed");
			}
			else
			{
				return View(r);
			}
		}

		[HttpPost]
		public ActionResult Login(LoginViewModel l)
		{
			if(ModelState.IsValid)
			{
				ApplicationUser u = new ApplicationUser();
				UpdateModel(u);
				//service
				return RedirectToAction("UserNewsFeed");
			}
			else
			{
				return View(l);
			}
		}
    }
}