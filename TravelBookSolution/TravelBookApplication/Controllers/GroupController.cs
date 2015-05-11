using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBookApplication.Models.ViewModels;
using TravelBookApplication.Services;
using Microsoft.AspNet.Identity;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models;

namespace TravelBookApplication.Controllers
{
    public class GroupController : Controller
    {
        public ActionResult GroupList()
        {
            GroupListingViewModel model = new GroupListingViewModel();
            string userId = User.Identity.GetUserId();
            model.UserDisplayed = UserService.Service.GetUserById(userId);
            model.AllGroups = GroupService.Service.GetAllGroups();
            model.UserGroups = GroupService.Service.GetGroupsForUser(userId);
            return View("GroupList", model);
        }

        public ActionResult GroupWall()
        {
            string currentUserId = User.Identity.GetUserId();
            NewsFeedViewModel model = new NewsFeedViewModel();
            return View("Group", model);
        }

        [HttpPost]
        public ActionResult CreateGroup(FormCollection collection)
        {
            bool isPublic = collection["visibility"] == "1" ? true : false;
            string userId = User.Identity.GetUserId();

            Group group = new Group
            {
                Name = collection["group-name"],
                IsPublic = isPublic,
                Members = new List<Membership>(),
                MembersRequests = new List<MemberRequest>()
            };

            GroupService.Service.AddNewGroup(group, userId);

            return RedirectToAction("GroupList");
        }
    }
}