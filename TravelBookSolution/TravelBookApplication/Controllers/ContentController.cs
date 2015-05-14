﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Services;

namespace TravelBookApplication.Controllers
{
    public class ContentController : Controller
    {
        [HttpPost]
        public ActionResult SubmitPost(FormCollection formCollection, HttpPostedFileBase uploadImage)
        {
            UserContent newContent = new UserContent();
            string text = formCollection["post-text-area"];

            if (!string.IsNullOrEmpty(text))
            {
                newContent.PostContent = text;
            }

            if (uploadImage != null)
            {
                string imageDirectory = ConfigurationManager.AppSettings.Get("ImageDirectory");
                string pic = System.IO.Path.GetFileName(uploadImage.FileName);
                string path = System.IO.Path.Combine(Server.MapPath(imageDirectory), pic);

                if (System.IO.File.Exists(path))
                {
                    path = GetNewPathForFile(path);
                }

                uploadImage.SaveAs(path);
                newContent.PhotoName = System.IO.Path.GetFileName(path);
            }

            if (!String.IsNullOrEmpty(newContent.PostContent) || !String.IsNullOrEmpty(newContent.PhotoName))
            {
                string userId = formCollection["user-id"];
                string profileId = formCollection["profile-id"];
                string grId = formCollection["group-id"];
                int groupId;

                if(Int32.TryParse(grId, out groupId))
                {
                    ContentService.Service.AddNewContent(newContent, userId, profileId, groupId);
                }
                else
                {
                    ContentService.Service.AddNewContent(newContent, userId, profileId, null);
                }
            }

            string controllerName = formCollection["controller-name"];
            string actionName = formCollection["action-name"];
            string routeValue = formCollection["route-value"]; 

            if (String.IsNullOrEmpty(routeValue))
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction(actionName, controllerName, new { id = routeValue });
        }

        [HttpPost]
        public ActionResult SubmitStory(FormCollection formCollection, IEnumerable<HttpPostedFileBase> fileUpload)
        {
            string storyDirectory = Server.MapPath(ConfigurationManager.AppSettings.Get("StoryDirectory"));
            List<string> descriptions = new List<string>();
            List<FileInfo> imageInfo = new List<FileInfo>();
            int index = 0;
            string filename;

            foreach(var file in fileUpload)
            {
                descriptions.Add(formCollection["description-" + index.ToString()]);
                filename = Path.GetFileName(file.FileName);
                filename = Path.Combine(storyDirectory, filename);

                if(System.IO.File.Exists(filename))
                {
                    filename = GetNewPathForFile(filename);
                }

                imageInfo.Add(new FileInfo(filename));
                file.SaveAs(filename);
                index++;
            }

            StoryService service = new StoryService();
            FileInfo Story = service.CreateStory(descriptions, imageInfo, "Story.jpg", storyDirectory);
            return RedirectToAction("Index", "Home");
        }

        private string GetNewPathForFile( string path )
        {
            int index = 0;
            string directory = System.IO.Path.GetDirectoryName(path) + "\\",
                filename = System.IO.Path.GetFileNameWithoutExtension(path),
                extension = System.IO.Path.GetExtension(path);

            StringBuilder builder = new StringBuilder();

            do
            {
                index++;
                builder.Clear();
                builder.Append(directory);
                builder.Append(filename);
                builder.Append("(" + index + ")");
                builder.Append(extension);
                path = builder.ToString();
            } while (System.IO.File.Exists(String.Format(path)));

            return path;
        }

		[HttpPost]
	    public ActionResult SubmitComment(FormCollection formCollection)
	    {
		    Comment newComment = new Comment();
		    string text = formCollection["comment-text-area"];

		    if (!string.IsNullOrEmpty(text))
		    {
			    newComment.Body = text;
		    }

		    if (!String.IsNullOrEmpty(newComment.Body))
		    {
				string userId = formCollection["user-id"];
				string contentId = formCollection["content-id"];
			
				ContentService.Service.AddNewComment(newComment, userId, contentId);
		    }

			string controllerName = formCollection["controller-name"];
			string actionName = formCollection["action-name"];
			string routeValue = formCollection["route-value"];

			if (String.IsNullOrEmpty(routeValue))
			{
				return RedirectToAction("Index", "Home");
			}

			return RedirectToAction(actionName, controllerName, new { id = routeValue });
	    }

	    public List<Comment> GetAllComments(int id)
	    {
		    var comments = ContentService.Service.GetCommentsOnPost(id);
			List<Comment> postComments = new List<Comment>();

		    foreach (var comment in comments)
		    {
			    postComments.Add( new Comment
			    {
				    Body = comment.Body,
					ContentId = comment.ContentId,
					UserId = comment.UserId,
					DateCreated = comment.DateCreated
			    });
				postComments.Add(comment);
		    }
		    return postComments;
	    }
    }
}