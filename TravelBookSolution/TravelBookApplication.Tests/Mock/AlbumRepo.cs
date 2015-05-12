using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Services;
using TravelBookApplication.Tests.Mock;

namespace TravelBookApplication.Tests.Mock
{
    class AlbumRepo
    {
        MockAlbumRepository repo = new MockAlbumRepository();
            List<UserContent> allImages = new List<UserContent>();
            UserContent images = new UserContent {PhotoName = "derp.jpg"};
            allImages
        
            //Album first = new Album { ID = 1, ImageCount = 2, Images = allImages, Name = "testAlbum"};
            //app.Save(first);
            Album a = new Album { ID = 6, ImageCount = 76, Images = allImages, Name = "island" };
            app.Save(a);
            //Album b = new Album { ID = 2, ImageCount = 16, Images = allImages, Name = "spain" };
            //app.Save(b);
            //Album c = new Album { ID = 3, ImageCount = 4, Images = allImages, Name = "usa" };
            //app.Save(c);
            //Album d = new Album { ID = 4, ImageCount = 23, Images = allImages, Name = "space" };
            //app.Save(d);
            //Album e = new Album { ID = 5, ImageCount = 20, Images = allImages, Name = "narnia" };
            //app.Save(e);
    }
}
