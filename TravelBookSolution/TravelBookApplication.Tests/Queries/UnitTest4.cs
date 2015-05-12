using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBookApplication.Models;
using TravelBookApplication.Services;
using TravelBookApplication.Tests.Mock;

namespace TravelBookApplication.Tests.Queries
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void UserTest()
        {
            // Hérna er rétta virknin
            #region
            MockUserRepository repo = new MockUserRepository();
            ApplicationUser user = new ApplicationUser {Id = "1", Gender = "Male"};
            repo.Save(user);
           
            Assert.AreEqual(repo.Users.Count, 1);
            var result = repo.GetUserById("1", repo);
            var expected = "1";

            Assert.AreEqual(result.Id, expected);
            #endregion
        }
    }
}
