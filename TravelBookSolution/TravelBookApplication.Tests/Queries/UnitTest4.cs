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
<<<<<<< HEAD
            MockUserRepository repo = new MockUserRepository();
            ApplicationUser user = new ApplicationUser {Id = "1", Gender = "Male"};
            repo.Save(user);
=======
           /* MockUserRepository repo = new MockUserRepository();
            ApplicationUser user = new ApplicationUser {Id = 1, Gender = "Male"};
            repo.Users.Add(user);
>>>>>>> bc31232991b2357a2c41093fbc1e9686a8a02d55

            Assert.AreEqual(repo.Users.Count, 1);
            var result = repo.GetUserById("1", repo);
            var expected = "1";
<<<<<<< HEAD
            Assert.AreEqual(result.Id, expected);
=======
            Assert.AreEqual(result, expected);*/
>>>>>>> bc31232991b2357a2c41093fbc1e9686a8a02d55

        }
    }
}
