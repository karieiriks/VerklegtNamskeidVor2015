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
        { // This function has to be modified to get all content by friends and the content which friends shared
            // Currently the function only selects items that the user posted

            var newsfeedItems = (from content in db.Content
                                 where content.OwnerID == userId
                                 orderby content.DateCreated descending
                                 select content).ToList();
            
            return newsfeedItems;
        }

        public List<UserContent> GetWallContentForUser(string userId)
        {
            var wallContent = (from content in db.Content
                                where content.ProfileID == userId
                                orderby content.DateCreated descending
                                select content).ToList();

            return wallContent;
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