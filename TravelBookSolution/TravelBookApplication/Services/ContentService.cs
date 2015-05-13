using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TravelBookApplication.Models;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Models.Repositories;

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

        public void AddNewContent(UserContent content, string ownerId, string profileId, int? groupId)
        {
            content.DateCreated = DateTime.Now;
            content.OwnerId = ownerId;

            if(groupId.HasValue)
            {
                content.GroupId = groupId;
            }
            else
            {
                content.ProfileId = profileId;
            }
            db.Content.Add(content);
            db.SaveChanges();
        }
        public static Comment GetCommentById(int id, ICommentRepository db)
        {
            return (from x in db.Comments
                    where x.ID == id
                    select x).SingleOrDefault();

        }
    }
}