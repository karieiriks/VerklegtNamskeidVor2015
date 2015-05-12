using System;
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
                {// an image with this name already exists so we need to create a new name for this image
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
    }
}