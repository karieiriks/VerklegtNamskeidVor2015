using System;
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
using System.Globalization;

namespace TravelBookApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
		[HttpGet]
        [AllowAnonymous]
		public ActionResult Index()
		{
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserNewsfeed", "Home", null);
            }

			return View();
		}

		[HttpGet]
		public ActionResult Search(string value)
        {
			var users = UserService.Service.GetUsersBySubstring(value);
            List<UserDisplayInfo> userInfo = new List<UserDisplayInfo>();

            foreach(var user in users)
            {
                userInfo.Add(new UserDisplayInfo
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    ProfileImageName = user.ProfileImageName
                });
            }

			string imgDir = Url.Content(ConfigurationManager.AppSettings.Get("ImageDirectory"));
			var item = new { imageDirectory = imgDir, searchResults = userInfo};

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

        [HttpGet]
        public ActionResult GetFriendListForUser( string userId, int groupid )
        {
            var user = UserService.Service.GetUserById( userId );

            List<UserDisplayInfo> friends = new List<UserDisplayInfo>();
            string ImageDirectory = Url.Content(ConfigurationManager.AppSettings.Get("ImageDirectory")); 

            foreach(var friend in user.Friends)
            {
                UserDisplayInfo info = new UserDisplayInfo
                {
                    Id = friend.FriendId,
                    FullName = friend.Friend.FullName,
                    ProfileImageName = ImageDirectory + friend.Friend.ProfileImageName,
                    IsGroupMember = GroupService.Service.IsMemberOfGroup(friend.FriendId, groupid)
                };

                friends.Add(info);
            }
            return Json(new { Friends = friends}, JsonRequestBehavior.AllowGet);
        }
    }
}