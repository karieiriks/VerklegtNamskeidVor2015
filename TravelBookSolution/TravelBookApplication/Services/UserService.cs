using System;
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

        public void CreateFriendship(string userOneId, string userTwoId)
        {
            ApplicationUser userOne = GetUserById(userOneId), userTwo = GetUserById(userTwoId);
            userOne.Friends.Add(new Friendship { User = userOne, Friend = userTwo });
            userTwo.Friends.Add(new Friendship { User = userTwo, Friend = userOne });
            db.SaveChanges();
        }

        public List<ApplicationUser> GetFriendsForUser( string userId )
        {
            var friends = (from friendships in db.Friendships
                           where friendships.UserId == userId
                           select friendships.Friend).ToList();

            return friends;
        }

        public List<ApplicationUser>GetFriendRequestsForUser( string userId )
        {
            return new List<ApplicationUser>();
        }

        public List<ApplicationUser> GetAllUsers()
        {
            var usersList = (from users in db.Users
                             select users).ToList();

            return usersList;
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