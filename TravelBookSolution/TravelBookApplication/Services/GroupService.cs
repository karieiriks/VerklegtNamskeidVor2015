using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models.Repositories;

namespace TravelBookApplication.Services
{
    public class GroupService : BaseService
    {
        private static GroupService service = null;

        public static GroupService Service
        {
            get
            {
                if (service == null)
                {
                    service = new GroupService();
                }

                return service;
            }
        }

        public void AddNewGroup(Group group, string userId)
        {
            ApplicationUser creator = UserService.Service.GetUserById(userId);
            db.Groups.Add(group);

            Membership membership = new Membership
            {
                GroupId = group.Id,
                UserId = creator.Id,
                User = creator,
                Group = group
            };

            group.Members.Add(membership);
            group.MemberCount = 1;
            db.SaveChanges();
        }

        public List<Group> GetAllGroups()
        {
            var allGroups = (from groups in db.Groups
                          where groups.IsPublic == true
                          select groups).ToList();

            return allGroups;
        }

        public List<Group> GetGroupsForUser(string userId)
        {
            var userGroups = (from memberships in db.Memberships
                              where memberships.UserId == userId
                              select memberships.Group).ToList();

            return userGroups;
        }

        public Group GetGroupById(int id, IGroupRepository db)
        {
            var group = (from x in db.Groups
                        where x.Id == id
                        select x).SingleOrDefault();

            return group;
        }
    }
}