using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models.Repositories;

namespace TravelBookApplication.Services
{
    public class UserService : BaseService
    {
        private static UserService service = null;

        public static UserService Service
        {
            get
            {
                if (service == null)
                {
                    service = new UserService();
                }

                return service;
            }
        }

        public ApplicationUser GetUserById( string Id )
        {

            var user = (from users in db.Users
                        where users.Id == Id
                        select users).SingleOrDefault();

            return user;
        }

        public List<UserContent> GetNewsFeedItemsForUser(string userId)
        {
            var newsfeedItems = (from content in db.Content
                                 where content.OwnerId == userId && content.GroupId == null
                                 select content).ToList();

            var friends = GetFriendsForUser(userId);

            foreach( var friend in friends )
            {
                foreach(var content in friend.Content)
                {
                    if(content.GroupId == null)
                    {
                        newsfeedItems.Add(content);
                    }
                }
            }

            var groups = GroupService.Service.GetGroupsForUser(userId);

            foreach( var gr in groups)
            {
                foreach(var content in gr.GroupContent)
                {
                    newsfeedItems.Add(content);
                }
            }

            return newsfeedItems.OrderByDescending(c => c.DateCreated).ToList();
        }

        public List<UserContent> GetWallContentForUser(string userId)
        {
            var wallContent = (from content in db.Content
                                where content.ProfileId == userId
                                orderby content.DateCreated descending
                                select content).ToList();

            return wallContent;
        }

        public List<ApplicationUser> GetFriendsForUser( string userId )
        {
            var friends = (from friendships in db.Friendships
                           where friendships.UserId == userId
                           select friendships.Friend).OrderBy(f => f.FullName);

            return friends.ToList();
        }

        public List<ApplicationUser> GetFriendRequestsForUser(string userid)
        {
            var friendRequests = (from request in db.FriendRequests
                                 where request.ToUserId == userid
                                 select request.FromUser).OrderBy(f => f.FullName);
            return friendRequests.ToList();
        }

        public List<ApplicationUser> GetAllUsers()
        {
            var usersList = (from users in db.Users
                             select users).ToList();

            return usersList;
        }

        public bool IsFriends(string userOneId, string userTwoId )
        {
            var friendUser = (from friend in db.Friendships
                              where friend.UserId == userOneId
                              && friend.FriendId == userTwoId
                              select friend.Friend).SingleOrDefault();

            return friendUser == null ? false : true;
        }

        public bool HasFriendRequestFromUser(string userId, string requesterId)
        {
            var request = (from requests in db.FriendRequests
                           where requests.ToUserId == userId && requests.FromUserId == requesterId
                           select requests).SingleOrDefault();

            return request == null ? false : true;
        }

        public void AddFriendRequest(string userId, string fromUserId)
        {

            FriendRequest request = new FriendRequest { ToUserId = userId, FromUserId = fromUserId };
            request.FromUser = GetUserById(fromUserId);
            request.ToUser = GetUserById(userId);
            db.FriendRequests.Add(request);
            db.SaveChanges();
        }

        public void DeleteFriendRequest(string userId, string fromUserId )
        {
            var request = (from requests in db.FriendRequests
                           where requests.ToUserId == userId && requests.FromUserId == fromUserId
                           select requests).SingleOrDefault();

            if(request != null)
            {
                db.FriendRequests.Remove(request);
                db.SaveChanges();
            }   
        }

        public void CreateFriendship(string userOneId, string userTwoId)
        {
            ApplicationUser userOne = GetUserById(userOneId), userTwo = GetUserById(userTwoId);
            userOne.Friends.Add(new Friendship { User = userOne, Friend = userTwo });
            userTwo.Friends.Add(new Friendship { User = userTwo, Friend = userOne });
            DeleteFriendRequest(userOneId, userTwoId);
            DeleteFriendRequest(userTwoId, userOneId);
            db.SaveChanges();
        }

	    public List<ApplicationUser> GetUsersBySubstring(string value)
	    {
            var users = (from u in db.Users.Where(a => a.FullName.Contains(value))
						 select u).ToList();

		    return users;
	    }

        public List<UserContent> GetUserImages(string userId)
        {
            var contentList = (from userContent in db.Content
                               where userContent.OwnerId == userId
                               && userContent.GroupId == null
                               && userContent.PhotoName != null
                               orderby userContent.DateCreated descending
                               select userContent).ToList();
            return contentList; 
        }

        public List<UserContent> GetUserStories(string userId)
        {
            return (from userContent in db.Content
                    where userContent.OwnerId == userId
                    && userContent.StoryName != null && userContent.StoryTitle != null
                    orderby userContent.DateCreated descending
                    select userContent).ToList();
        }
    }
}