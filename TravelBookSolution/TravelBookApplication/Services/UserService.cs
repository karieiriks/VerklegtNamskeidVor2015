﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;

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
                             where content.OwnerID == userId
                             select content).ToList();

            var friends = GetFriendsForUser(userId);

            foreach( var friend in friends )
            {
                foreach(var content in friend.Content)
                {
                    newsfeedItems.Add(content);
                }
            }

            return newsfeedItems.OrderByDescending(c => c.DateCreated).ToList();
        }

        public List<UserContent> GetWallContentForUser(string userId)
        {
            var wallContent = (from content in db.Content
                                where content.ProfileID == userId
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

        /*
        public ApplicationUser GetUserByName(string userName)
        {
            var user = (from users in db.Users
                        where users.UserName == userName
                        select users).FirstOrDefault();

            return user;
        }
       
        public void UpdateUser(Models.ApplicationDbContext user)
        {
            
        }
      
        public void RemoveUser(Models.ApplicationDbContext user)
        {
        }*/
    }
}