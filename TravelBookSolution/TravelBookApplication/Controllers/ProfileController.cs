using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBookApplication.Models.ViewModels;
using TravelBookApplication.Services;
using Microsoft.AspNet.Identity;

namespace TravelBookApplication.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public ActionResult CurrentUserWall()
        {
            return RedirectToAction("UserWall", new { id = User.Identity.GetUserId() });
        }

        public ActionResult UserWall(string id)
        {
            NewsFeedViewModel wallContent = new NewsFeedViewModel();
            wallContent.UserDisplayed = UserService.Service.GetUserById(User.Identity.GetUserId());
            wallContent.ProfileDisplayed = UserService.Service.GetUserById(id);
            wallContent.Content = UserService.Service.GetWallContentForUser(id);

            return View(wallContent);
        }

        public ActionResult UserFriends(string id)
        {
            FriendListViewModel model = new FriendListViewModel();
            model.FriendRequests = UserService.Service.GetFriendRequestsForUser(id);
            model.Friends = UserService.Service.GetFriendsForUser(id);
            model.ProfileDisplayed = UserService.Service.GetUserById(id);
            model.UserDisplayed = UserService.Service.GetUserById(User.Identity.GetUserId());
            return View(model);
        }
    }
}