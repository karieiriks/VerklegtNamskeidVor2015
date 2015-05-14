﻿using System;
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
            ApplicationUser user = new ApplicationUser {Id = "1", Gender = "Male",FullName = "Sverrir Magnússon"};
            repo.Save(user);
            ApplicationUser user2 = new ApplicationUser {Id = "2", Gender = "Male",FullName = "Kári Eiríksson"};
            repo.Save(user2);
            ApplicationUser user3 = new ApplicationUser {Id = "3", Gender = "Male",FullName = "Björgvin Jóhannsson"};
            repo.Save(user3);
            ApplicationUser user4 = new ApplicationUser {Id = "4", Gender = "Male",FullName = "Andri Ómarsson"};
            repo.Save(user4);
            ApplicationUser user5 = new ApplicationUser {Id = "5", Gender = "Male",FullName = "King DABS"};
            repo.Save(user5);
            ApplicationUser user6 = new ApplicationUser {Id = "6", Gender = "Female",FullName = "Ada Lovalace"};
            repo.Save(user6);
            return repo;

            #endregion
        }
        
        [TestMethod]
        public void UserCountTest()
        {
            MockUserRepository repo = Initialize();
            var expectedCount = 6;
            Assert.AreEqual(repo.Users.Count, expectedCount);
        }
        [TestMethod]
        public void UserByIdTest()
        {
            MockUserRepository repo = Initialize();
            var result = repo.GetUserById("5", repo);
            var expected = "5";
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