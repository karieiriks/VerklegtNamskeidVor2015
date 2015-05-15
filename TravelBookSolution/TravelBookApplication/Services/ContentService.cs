using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
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
	    public void AddNewComment(Comment comment, string userId, int contentId)
	    {
		    comment.DateCreated = DateTime.Now;
		    comment.UserId = userId;
		    comment.User = UserService.Service.GetUserById(userId);
		    comment.Content = GetContentById(contentId);

		    db.Comments.Add(comment);
		    db.SaveChanges();
	    }

	    public UserContent GetContentById(int contentId)
	    {
		    return (from c in db.Content
					where c.Id == contentId
					select c).SingleOrDefault();
	    }

	    public List<Comment> GetCommentsOnPost(int id)
	    {
		    var comments = (from c in db.Comments
							where c.ContentId == id
							select c).ToList();

		    return comments;
	    }
    }
}