using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBookApplication.Models.Entities;
using TravelBookApplication.Tests.Mock;
using NCrunch.Framework;
using TravelBookApplication.Models.Repositories;
using TravelBookApplication.Services;

namespace TravelBookApplication.Tests.Queries
{
    [TestClass]
    public class GroupTest
    {
        [TestInitialize]
        public MockGroupRepository Initailize()
        {
            MockGroupRepository repo = new MockGroupRepository();
            Group gru = new Group { Id = 1, Name = "Heimsreisur", MemberCount = 100, IsPublic = true};
            repo.Save(gru);
            Group gru2 = new Group { Id = 1231, Name = "Alicante", MemberCount = 1002, IsPublic = true};
            repo.Save(gru2);
            Group gru3 = new Group { Id = 453, Name = "Florida", MemberCount = 1300, IsPublic = true};
            repo.Save(gru3);
            Group gru4 = new Group { Id = 25 , Name = "Alaska", MemberCount = 900, IsPublic = true};
            repo.Save(gru4);
            Group gru5 = new Group { Id = 4, Name = "Chile", MemberCount = 12, IsPublic = false};
            repo.Save(gru5);
            Group gru6 = new Group { Id = 36, Name = "Kína", MemberCount = 86, IsPublic = true};
            repo.Save(gru6);

            return repo;

        }

        [TestMethod]
        public void GroupCountTest()
        {
            MockGroupRepository repo = Initailize();
            var result = repo.Groups.Count;
            var expectedResult = 6;
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        
        public void GetGroupByIdTest()
        {
            MockGroupRepository repo = Initailize();
            var results = repo.GetGroupById(453);
            var expectedResult = "Florida";
            Assert.AreEqual(results.Name, expectedResult);
        }
    }
}

