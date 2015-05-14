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
            Comment comment1 = new Comment { Id = 1, UserId = "12", ContentId = 1};
            repo.Save(comment1);
            Comment comment2 = new Comment { Id = 2, UserId = "12", ContentId = 1};
            repo.Save(comment2);
            Comment comment3 = new Comment { Id = 3, UserId = "14", ContentId = 2};
            repo.Save(comment3);
            Comment comment4 = new Comment { Id = 4, UserId = "11", ContentId = 3};
            repo.Save(comment4);
            Comment comment5 = new Comment { Id = 5, UserId = "13", ContentId = 4};
            repo.Save(comment5);
            return repo;
        }

        [TestMethod]
        public void CommentCountTest()
        {
            MockCommentRepository repo = Initialize();

            Assert.AreEqual(repo.Comments.Count, 5);
        }

        [TestMethod]
        public void CommentsOnPostTest()
        {
            MockCommentRepository repo = Initialize();
            var result = repo.GetCommentById(1, repo);
            var expectedResult = "12";
            Assert.AreEqual(result.UserId, expectedResult);
        }
        
        [TestMethod]
        public void CommentsOnPostCountTest()
        {
            MockCommentRepository repo = Initialize();

            var result = repo.GetAllCommentsForPost(1, repo);
            var expectedResult = 2;
            Assert.AreEqual(result.Count, expectedResult);

        }
    }
}
