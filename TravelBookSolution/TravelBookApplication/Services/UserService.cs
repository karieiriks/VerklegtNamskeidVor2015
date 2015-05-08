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

        public ApplicationUser GetUserByID( string Id )
        {
            
            var user = (from users in db.Users
                        where users.Id == Id
                        select users).SingleOrDefault();

            return user;
        }
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

        }
    }
}