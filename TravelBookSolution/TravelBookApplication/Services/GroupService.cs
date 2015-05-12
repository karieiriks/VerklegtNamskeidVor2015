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

        public Group GetGroupById(int groupId)
        {
            var group = (from groups in db.Groups
                         where groups.Id == groupId
                         select groups).SingleOrDefault();
            return group;
        }

        public List<Group> GetGroupsForUser(string userId)
        {
            var userGroups = (from memberships in db.Memberships
                              where memberships.UserId == userId
                              select memberships.Group).ToList();

            return userGroups;
        }

        public bool IsMemberOfGroup(string userId, int groupId)
        {
            var membership = (from memberships in db.Memberships
                              where memberships.UserId == userId
                              && memberships.GroupId == groupId
                              select memberships).SingleOrDefault();

            return membership == null ? false : true;
        }

        public bool HasMemberRequestFromUser(int groupId, string userId)
        {
            var memberRequest = (from memberrequest in db.MemberRequests
                                 where memberrequest.GroupId == groupId &&
                                 memberrequest.UserId == userId
                                 select memberrequest).SingleOrDefault();

            return memberRequest == null ? false : true;
        }

        public void addMemberRequestToGroup(int groupId, string userId)
        {
            var group = GetGroupById(groupId);

            if(group != null)
            {
                MemberRequest request = new MemberRequest
                {
                    GroupId = groupId,
                    Group = group,
                    UserId = userId,
                    User = UserService.Service.GetUserById(userId)
                };

                db.MemberRequests.Add(request);
                db.SaveChanges();
            }
        }

        public List<UserContent> GetNewsfeedItemsForGroup(int groupId)
        {
            var groupContent = (from content in db.Content
                                where content.GroupId == groupId
                                orderby content.DateCreated descending
                                select content).ToList();

            return groupContent;
        }

        public List<MemberRequest> GetMemberRequestsForGroup( int id )
        {
            var requests = (from request in db.MemberRequests
                            where request.GroupId == id
                            select request).ToList();

            return requests;
        }

        public List<Membership> GetMembershipsForGroup( int id)
        {
            var memberships = (from membership in db.Memberships
                               where membership.GroupId == id
                               select membership).ToList();

            return memberships;
        }

        public void DeleteMemberRequestFromUser( int groupId, string userId )
        {
            var request = (from requests in db.MemberRequests
                           where requests.GroupId == groupId &&
                           requests.UserId == userId
                           select requests).SingleOrDefault();

            if(request != null)
            {
                db.MemberRequests.Remove(request);
                db.SaveChanges();
            }
        }

        public void CreateMembership( int groupId, string userId)
        {
            ApplicationUser user = UserService.Service.GetUserById(userId);
            Group group = GetGroupById(groupId);
            Membership membership = new Membership
            {
                User = user,
                Group = group
            };

            DeleteMemberRequestFromUser(groupId, userId);
            group.MemberCount++;
            db.Memberships.Add(membership);
            db.SaveChanges();
        }
    }
}