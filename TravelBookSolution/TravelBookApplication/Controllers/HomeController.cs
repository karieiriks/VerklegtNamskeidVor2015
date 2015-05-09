using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models.ViewModels;
using TravelBookApplication.Services;
using Microsoft.AspNet.Identity;

namespace TravelBookApplication.Controllers
{
    public class HomeController : Controller
    {
		[HttpGet]
		public ActionResult Index()
		{
            if(User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("UserNewsfeed", "Home", null);
            }

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

        public ActionResult SearchForUser(FormCollection coll)
        {
            return View("Index");
        }

        public ActionResult UserNewsfeed()
        {
            string currentUserId = User.Identity.GetUserId();
            NewsFeedViewModel model = new NewsFeedViewModel();
            model.UserDisplayed = UserService.Service.GetUserById(currentUserId);
            model.ProfileDisplayed = model.UserDisplayed;
            model.Content = UserService.Service.GetNewsFeedItemsForUser(currentUserId);
            return View("UserNewsfeed", model);
        }
    }
}