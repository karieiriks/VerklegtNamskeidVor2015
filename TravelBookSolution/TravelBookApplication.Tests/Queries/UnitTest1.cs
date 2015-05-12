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
        public void AlbumTest()
        {
            MockAlbumRepository app = new MockAlbumRepository();
            List<UserContent> allImages = new List<UserContent>();
            
            UserContent images = new UserContent {PhotoName = "derp.jpg"};
            allImages.Add(images);
            Album first = new Album { ID = 1, ImageCount = 2, Images = allImages, Name = "testAlbum"};
            app.Save(first);

            UserContent images2 = new UserContent { PhotoName = "homo.jpg" };
            allImages.Add(images2);
            Album second = new Album { ID = 2, ImageCount = 22, Images = allImages, Name = "spain" };
            app.Save(second);

            UserContent images3 = new UserContent { PhotoName = "nigger.jpg" };
            allImages.Add(images3);
            Album third = new Album { ID = 3, ImageCount = 32, Images = allImages, Name = "rome" };
            app.Save(third);

            UserContent images4 = new UserContent { PhotoName = "fat singer.jpg" };
            allImages.Add(images4);
            Album forth = new Album { ID = 4, ImageCount = 6, Images = allImages, Name = "space" };
            app.Save(forth);

            UserContent images5 = new UserContent { PhotoName = "racist.jpg" };
            allImages.Add(images5);
            Album fifth = new Album { ID = 5, ImageCount = 18, Images = allImages, Name = "ocean" };
            app.Save(fifth);

            //Assert.AreEqual(app.Albums.Count, 2);

            var results = UserService.GetAlbumById(1, app);
            var expectedID = 1;
            var expectedImageCount = 2;
            Assert.AreEqual(results.ID, expectedID);
            Assert.AreEqual(results.ImageCount, expectedImageCount);

            results = UserService.GetAlbumById(2, app);
            expectedID = 2;
            expectedImageCount = 22;
            Assert.AreEqual(results.ID, expectedID);
            Assert.AreEqual(results.ImageCount, expectedImageCount);

            results = UserService.GetAlbumById(3, app);
            expectedID = 3;
            expectedImageCount = 32;
            Assert.AreEqual(results.ID, expectedID);
            Assert.AreEqual(results.ImageCount, expectedImageCount);

            results = UserService.GetAlbumById(4, app);
            expectedID = 4;
            expectedImageCount = 6;
            Assert.AreEqual(results.ID, expectedID);
            Assert.AreEqual(results.ImageCount, expectedImageCount);

            results = UserService.GetAlbumById(5, app);
            expectedID = 5;
            expectedImageCount = 18;
            Assert.AreEqual(results.ID, expectedID);
            Assert.AreEqual(results.ImageCount, expectedImageCount);

        }
    }
}
