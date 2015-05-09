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

            if(!string.IsNullOrEmpty(text))
            {
                newContent.PostContent = text;
            }

            if (uploadImage != null)
            {
                string imageDirectory = ConfigurationManager.AppSettings.Get("ImageDirectory");
                string pic = System.IO.Path.GetFileName(uploadImage.FileName);
                string path = System.IO.Path.Combine(Server.MapPath(imageDirectory), pic);
                
                if(System.IO.File.Exists(path))
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
                    }while(System.IO.File.Exists( String.Format( path ) ) );
                }

                uploadImage.SaveAs(path);
                newContent.PhotoName = System.IO.Path.GetFileName(path);
            }

            if(String.IsNullOrEmpty(newContent.PostContent) && String.IsNullOrEmpty(newContent.PhotoName))
            {
                // Placement should return a Json object
                return RedirectToAction("Index", "Home");
            }

            string userId = formCollection["user-id"];
            //newContent.grouId = formCollection["group-id"];

            UserService userService = new UserService();
            ContentService contentservice = new ContentService();

            newContent.Owner = userService.GetUserById(userId);
            contentservice.AddNewContent(newContent);
            //newContent.Owner = UserService.Service.GetUserByID(userId);
            // Get group! Should be implemented later!

            return RedirectToAction("Index", "Home");
        }
    }
}