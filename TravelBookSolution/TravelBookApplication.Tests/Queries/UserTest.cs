using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBookApplication.Models;
using TravelBookApplication.Services;
using TravelBookApplication.Tests.Mock;

namespace TravelBookApplication.Tests.Queries
{
    [TestClass]
    public class UserTest
    {
        [TestInitialize]
        public MockUserRepository Initialize()
        {
            #region
            MockUserRepository repo = new MockUserRepository();
            ApplicationUser user = new ApplicationUser {Id = "13", Gender = "Male",FullName = "Sverrir Magnússon"};
            repo.Save(user);
            ApplicationUser user2 = new ApplicationUser {Id = "24", Gender = "Male",FullName = "Kári Eiríksson"};
            repo.Save(user2);
            ApplicationUser user3 = new ApplicationUser {Id = "35", Gender = "Male",FullName = "Björgvin Jóhannsson"};
            repo.Save(user3);
            ApplicationUser user4 = new ApplicationUser {Id = "46", Gender = "Male",FullName = "Andri Ómarsson"};
            repo.Save(user4);
            ApplicationUser user5 = new ApplicationUser {Id = "57", Gender = "Male",FullName = "Daníel Brandur Sigurgeirsson"};
            repo.Save(user5);
            ApplicationUser user6 = new ApplicationUser {Id = "68", Gender = "Female",FullName = "Princess Leia"};
            repo.Save(user6);
            ApplicationUser user7 = new ApplicationUser { Id = "79", Gender = "Male", FullName = "Darth Vader" };
            repo.Save(user7);
            ApplicationUser user8 = new ApplicationUser { Id = "80", Gender = "Female", FullName = "Han Solo" };
            repo.Save(user8);
            
            return repo;

            #endregion
        }
        
        [TestMethod]
        public void UserCountTest()
        {
            MockUserRepository repo = Initialize();
            var expectedCount = 8;
            Assert.AreEqual(repo.Users.Count, expectedCount);
        }
        [TestMethod]
        public void UserByIdTest()
        {
            MockUserRepository repo = Initialize();
            var result = repo.GetUserById("13", repo);
            var expected = "13";
            Assert.AreEqual(result.Id, expected);
        }

        [TestMethod]
        public void UserSearchTest()
        {
            MockUserRepository repo = Initialize();
            var result = repo.GetUsersBySubstring("Kári", repo);
                Assert.AreEqual(result.Count, 1);
        }
    }
}
