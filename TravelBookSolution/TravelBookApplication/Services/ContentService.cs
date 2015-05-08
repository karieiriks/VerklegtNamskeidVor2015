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

        public void AddNewContent(UserContent content)
        {
            content.DateCreated = DateTime.Now;
            db.Content.Add(content);
            db.SaveChanges();
        }
    }
}