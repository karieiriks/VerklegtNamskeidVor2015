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
    public class AlbumTest
    {
        [TestInitialize]
        public MockAlbumRepository Initialize()
        {
            MockAlbumRepository repo = new MockAlbumRepository();
            List<UserContent> allImages = new List<UserContent>();

            UserContent images = new UserContent { PhotoName = "Mountain.jpg" };
            allImages.Add(images);
            Album first = new Album { ID = 1, ImageCount = 2, Images = allImages, Name = "London" };
            repo.Save(first);

            Album second = new Album { ID = 2, ImageCount = 22, Images = allImages, Name = "spain" };
            repo.Save(second);

            Album third = new Album { ID = 3, ImageCount = 32, Images = allImages, Name = "rome" };
            repo.Save(third);

            Album forth = new Album { ID = 4, ImageCount = 6, Images = allImages, Name = "space" };
            repo.Save(forth);

            Album fifth = new Album { ID = 5, ImageCount = 18, Images = allImages, Name = "ocean" };
            repo.Save(fifth);

            return repo;
        }

        [TestMethod]
        public void GetAlbumCountTest()
        {
            MockAlbumRepository repo = Initialize();
            var result = repo.Albums.Count;
            var expectedResult = 5;
            Assert.AreEqual(result, expectedResult);

        }

        [TestMethod]
        public void GetAlbumByIdTest()
        {
            MockAlbumRepository repo = Initialize();
            var result = repo.GetAlbumById(1);
            var expectedResult = 1;
            Assert.AreEqual(result.ID, expectedResult);

        }

        [TestMethod]
        public void GetAlbumByName()
        {
            MockAlbumRepository repo = Initialize();
            var result = repo.GetAlbumByName("spain", repo);
            var expectedResult = "spain";
            Assert.AreEqual(result.Name, expectedResult);
        }

        [TestMethod]
        public void GetImagesInAlbumCount()
        {
            MockAlbumRepository repo = Initialize();
            var result = repo.GetAlbumById(3);
            var expectedResult = 32;
            Assert.AreEqual(result.ImageCount, expectedResult);
        }

    }
}
