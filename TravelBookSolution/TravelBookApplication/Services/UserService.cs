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
    public class UserService
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ApplicationUser GetUserByID( string Id )
        {
            var user = (from users in db.Users
                        where users.Id == Id
                        select users).SingleOrDefault();

            user.ProfileImageName = ConfigurationManager.AppSettings.Get("ImageDirectory") + user.ProfileImageName;

            return user;
        }/*
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