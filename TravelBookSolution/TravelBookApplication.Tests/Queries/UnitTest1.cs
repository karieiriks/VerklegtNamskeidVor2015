using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Services;
using TravelBookApplication.Tests.Mock;

namespace TravelBookApplication.Tests.Queries
{
    [TestClass]
    public class QueriesTest
    {
        //[TestInitialize]
        
        [TestMethod]
        public void prufa()
        {
            MockAlbumRepository app = new MockAlbumRepository();
            List<UserContent> allImages = new List<UserContent>();
            UserContent images = new UserContent {PhotoName = "derp.jpg"};
            allImages.Add(images);
            Album first = new Album { ID = 1, ImageCount = 2, Images = allImages, Name = "testAlbum"};

            app.Save(first);

            Assert.AreEqual(app.Albums.Count, 1);

            var results = UserService.GetAlbumById(1, app);
            var expectedID = 1;
            Assert.AreEqual(results.ID, expectedID);


        }
    }
}
