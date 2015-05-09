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
            wallContent.UserDisplayed = UserService.Service.GetUserByID(User.Identity.GetUserId());
            wallContent.ProfileDisplayed = UserService.Service.GetUserByID(id);
            wallContent.Content = UserService.Service.GetNewsFeedItemsForUser(id);

            return View(wallContent);
        }
    }
}