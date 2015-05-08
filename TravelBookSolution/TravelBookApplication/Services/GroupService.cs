using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Services
{
    public class GroupService
    {
         ApplicationDbContext db = new ApplicationDbContext();

<<<<<<< HEAD
         public Group GetGroupByID(string Id)
=======
         /*public ApplicationUser GetGroupByID(string Id)
>>>>>>> e01c73735003f28d17983514b8fa4bf6c1f410fb
         {
            /* var group = (from groups in db.Groups
                          where groups.Id == Id
                          select groups).SingleOrDefault();

             group.ProfileImageName = ConfigurationManager.AppSettings.Get("ImageDirectory") + group.ProfileImageName;
             
             return group;*/
             return new Group();
         }/*
         public ApplicationUser GetGroupByName(string groupName)
         {
             var group = (from groups in db.Groups
                          where groups.UserName == groupName
                         select groupName).FirstOrDefault();

             return group;
         }

         public void UpdateUser(Models.ApplicationDbContext user)
         {

<<<<<<< HEAD
         }


         internal ApplicationUser GetUserByID(string currentUserId)
         {
             throw new NotImplementedException();
         }*/
=======
         }*/
      
>>>>>>> e01c73735003f28d17983514b8fa4bf6c1f410fb
    }
}