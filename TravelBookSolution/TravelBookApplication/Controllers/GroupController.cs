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
    public class GroupController : Controller
    {
        public ActionResult GroupWall()
        {
            string currentUserId = User.Identity.GetUserId();
            UserService service = new UserService();
            NewsFeedViewModel model = new NewsFeedViewModel();
            model.UserDisplayed = service.GetUserByID(currentUserId);


            return View("Group", model);
        }
    }
}