using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Services
{
    public class ContentService : BaseService
    {
        private static ContentService service = null;

        public static ContentService Service 
        { 
            get
            {
                if(service == null)
                {
                    service = new ContentService();
                }

                return service;
            }
        }

        public void AddNewContent(UserContent content, string ownerId, string profileId)
        {
            content.DateCreated = DateTime.Now;
            content.OwnerID = ownerId;
            content.ProfileID = profileId;
            db.Content.Add(content);
            db.SaveChanges();
        }
    }
}