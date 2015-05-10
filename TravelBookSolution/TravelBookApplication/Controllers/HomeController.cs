﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models.ViewModels;
using TravelBookApplication.Services;
using Microsoft.AspNet.Identity;

namespace TravelBookApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

		[HttpGet]
        [AllowAnonymous]
		public ActionResult Index()
		{
            
            /*var users = UserService.Service.GetAllUsers();
            ApplicationUser userOne = users[1];
            ApplicationUser userTwo = users[3];
            UserService.Service.CreateFriendship(userOne.Id, userTwo.Id);*/

            if(User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("UserNewsfeed", "Home", null);
            }

			return View();
		}

		[HttpGet]
		public ActionResult Search(string value)
        {
			var users = UserService.Service.GetUsersBySubstring(value);
			string imgDir = Url.Content(ConfigurationManager.AppSettings.Get("ImageDirectory"));
			var item = new {imageDirectory = imgDir, searchResults = users};
			
			return Json(item, JsonRequestBehavior.AllowGet);
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