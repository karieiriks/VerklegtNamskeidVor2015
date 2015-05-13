using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Services;
using TravelBookApplication.Tests.Mock;

namespace TravelBookApplication.Tests.Queries
{
    [TestClass]
    public class CommentTest
    {
        [TestInitialize]
        public MockCommentRepository Initialize()
        {
            MockCommentRepository repo = new MockCommentRepository();
            Comment comment1 = new Comment { ID = 1, UserID = "12"};
            repo.Save(comment1);
            Comment comment2 = new Comment { ID = 2, UserID = "13" };
            repo.Save(comment2);
            Comment comment3 = new Comment { ID = 3, UserID = "14" };
            repo.Save(comment3);
            Comment comment4 = new Comment { ID = 4, UserID = "11111" };
            repo.Save(comment4);
            Comment comment5 = new Comment { ID = 5, UserID = "123" };
            repo.Save(comment5);
            return repo;
        }

        [TestMethod]
        public void CommentCountTest()
        {
            MockCommentRepository repo = Initialize();


            Assert.AreEqual(repo.Comments.Count, 5);

            var results = ContentService.GetCommentById(1, repo);
            var expectedID = 1;
            Assert.AreEqual(results.ID, expectedID);
        }
    }
}
