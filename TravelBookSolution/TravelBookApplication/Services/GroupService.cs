﻿using System;
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

         public Group GetGroupByID(string Id)
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
         }
        */
    }
}