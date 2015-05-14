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
	    public void AddNewComment(Comment comment, string userId, string contentId)
	    {
		    comment.DateCreated = DateTime.Now;
		    comment.UserId = userId;
		    comment.Content = GetCommentById(contentId);

		    db.Comments.Add(comment);
		    db.SaveChanges();
	    }

	    public UserContent GetCommentById(string CommentId)
	    {
		    var number = Convert.ToInt32(CommentId);

		    return (from c in db.Content
					where c.Id == number
					select c).SingleOrDefault();
	    }

	    public List<Comment> GetCommentsOnPost(int id)
	    {
		    var comments = (from c in db.Comments
							where c.Id == id
							select c).ToList();

		    return comments;
	    }

       /* public static Comment GetAlbumById(int id, ICommentRepository db)
        {
            return (from x in db.Comments
                    where x.Id == id
                    select x).SingleOrDefault();

        }*/
    }
}