using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Services;
using TravelBookApplication.Tests.Mock;

namespace TravelBookApplication.Tests.Queries
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void CommentTest()
        {
            MockCommentRepository repo = new MockCommentRepository();
            Comment comment1 = new Comment {Id = 1};
            repo.Save(comment1);


            Assert.AreEqual(repo.Comments.Count, 1);
/*
            var results = ContentService.GetAlbumById(1, repo);
            var expectedID = 1;
            Assert.AreEqual(results.Id, expectedID);*/
        }
    }
}
