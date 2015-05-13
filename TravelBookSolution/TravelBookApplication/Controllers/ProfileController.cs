using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using TravelBookApplication.Models.ViewModels;
using TravelBookApplication.Services;
using Microsoft.AspNet.Identity;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models.Repositories;

namespace TravelBookApplication.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly AlbumService _albumService = new AlbumService();
        
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
            wallContent.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            wallContent.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            wallContent.RouteValue = wallContent.ProfileDisplayed.Id;

            return View(wallContent);
        }

        public ActionResult UserFriends(string id)
        {
            FriendListViewModel model = new FriendListViewModel();
            model.ProfileDisplayed = UserService.Service.GetUserById(id);
            model.FriendRequests = UserService.Service.GetFriendRequestsForUser(id);
            model.Friends = UserService.Service.GetFriendsForUser(id);
            model.UserDisplayed = UserService.Service.GetUserById(User.Identity.GetUserId());
            return View(model);
        }

        public ActionResult UserStories(string id)
        {
            NewsFeedViewModel model = new NewsFeedViewModel();
            model.UserDisplayed = UserService.Service.GetUserById(id);
            model.ProfileDisplayed = UserService.Service.GetUserById(User.Identity.GetUserId());
            model.Content = UserService.Service.GetUserImages(id);
            return View("UserStories", model);
        }

        [HttpPost]
        public ActionResult SendFriendRequestToUser(string toUserId)
        {
            string fromUserId = User.Identity.GetUserId();

            if (UserService.Service.HasFriendRequestFromUser(toUserId, fromUserId))
            {
                return Json(true);
            }

            UserService.Service.AddFriendRequest(toUserId, fromUserId);

            return Json(true);
        }

        [HttpPost]
        public ActionResult AcceptFriendRequestFromUser(string fromUserId)
        {
            string userId = User.Identity.GetUserId();
            UserService.Service.CreateFriendship(userId, fromUserId);
            return Json(true);
        }

        [HttpPost]
        public ActionResult DeclineFriendRequestFromUser(string fromUserId)
        {
            string userId = User.Identity.GetUserId();
            UserService.Service.DeleteFriendRequest(userId, fromUserId);
            return Json(true);
        }

        [HttpGet]
        public ActionResult UserImages(string id)
        {
            ImageListingViewModel model = new ImageListingViewModel();
            model.Images = UserService.Service.GetUserImages(id);
            model.ProfileDisplayed = UserService.Service.GetUserById(id);
            model.UserDisplayed = UserService.Service.GetUserById(User.Identity.GetUserId());
            return View(model);
        }

        public void Albums(Album album)
        {
            UserService.AddAlbum(album, _albumService);
        }
    }
}