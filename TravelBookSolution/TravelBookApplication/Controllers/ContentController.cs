using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TravelBookApplication.Models;
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

            if(!string.IsNullOrEmpty(text))
            {
                newContent.PostContent = text;
            }

            if(uploadImage != null)
            {
                string imageDirectory = ConfigurationManager.AppSettings.Get("ImageDirectory");
                string pic = System.IO.Path.GetFileName(uploadImage.FileName);
                string path = System.IO.Path.Combine(Server.MapPath(imageDirectory), pic);

                if(System.IO.File.Exists(path))
                {
                    path = StoryService.Service.GetNewPathForFile(path);
                }

                uploadImage.SaveAs(path);
                newContent.PhotoName = System.IO.Path.GetFileName(path);
            }

            if(!String.IsNullOrEmpty(newContent.PostContent) || !String.IsNullOrEmpty(newContent.PhotoName))
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

            if(String.IsNullOrEmpty(routeValue))
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
                    filename = StoryService.Service.GetNewPathForFile(filename);
                }

                imageInfo.Add(new FileInfo(filename));
                file.SaveAs(filename);
                index++;
            }

            string storyTitle = formCollection["story-title"];
            StoryService service = new StoryService();
            filename = storyTitle.Substring(0 ,Math.Min(storyTitle.Length, 5)) + ".jpg";

            FileInfo Story = service.CreateStory(descriptions, imageInfo, filename, storyDirectory);

            UserContent newContent = new UserContent
            {
                StoryTitle = storyTitle,
                StoryName = Path.GetFileName(Story.FullName),
            };

            string userId = formCollection["user-id"];

            ContentService.Service.AddNewContent(newContent, userId, userId, null);

            return RedirectToAction("UserStories", "Profile", new { id = userId });
        }

		[HttpPost]
	    public ActionResult SubmitComment(Comment item)
	    {
		    string text = item.Body;

		    if(!string.IsNullOrEmpty(text))
		    {
			    item.Body = text;
		    }

		    if(!String.IsNullOrEmpty(item.Body))
		    {
				string userId = item.UserId;
				int contentId = item.ContentId;

				ContentService.Service.AddNewComment(item, userId, contentId);
			    var com = ContentService.Service.GetCommentsForPost(contentId);
				List<CommentInfo> commentList = new List<CommentInfo>();
			    string imageDirectory = Url.Content(ConfigurationManager.AppSettings.Get("ImageDirectory"));

			    foreach(var comment in com)
			    {
				    commentList.Add( new CommentInfo
				    {
					    Body = comment.Body,
						FullName = comment.User.FullName,
						Id = comment.User.Id,
						ProfileImageName = Path.Combine(imageDirectory, comment.User.ProfileImageName),
						TimePosted = comment.DateCreated.ToString("dd-MMMM-yy h:mm:ss tt")
				    });
			    }
				return Json(commentList);
		    }
			return Json(item);
	    }

	    public List<Comment> GetAllComments(int id)
	    {
		    var comments = ContentService.Service.GetCommentsForPost(id);
			List<Comment> postComments = new List<Comment>();

		    foreach(var comment in comments)
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

        [HttpGet]
        public ActionResult GetAllCommentsOfContent(int id)
        {
            var comments = ContentService.Service.GetCommentsForPost(id);

            List<CommentInfo> commentInfo = new List<CommentInfo>();

            string imageDirectory = Url.Content(ConfigurationManager.AppSettings.Get("ImageDirectory"));

            foreach (var comment in comments)
            {
                commentInfo.Add(new CommentInfo
                {
                    Body = comment.Body,
                    FullName = comment.User.FullName,
                    Id = comment.User.Id,
                    ProfileImageName = Path.Combine(imageDirectory, comment.User.ProfileImageName),
                    TimePosted = comment.DateCreated.ToString("dd-MMMM-yy h:mm:ss tt")
                });
            }

            return Json(commentInfo, JsonRequestBehavior.AllowGet);
        }
    }
}