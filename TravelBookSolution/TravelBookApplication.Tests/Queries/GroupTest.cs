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
            Group gru = new Group { Id = 1, Name = "gayBoyz", MemberCount = 100 };
            repo.Save(gru);
            Group gru2 = new Group { Id = 1231, Name = "gayBoyz", MemberCount = 1002 };
            repo.Save(gru2);
            Group gru3 = new Group { Id = 453, Name = "NegraStrákar", MemberCount = 1300 };
            repo.Save(gru3);
            Group gru4 = new Group { Id = 0, Name = "pedos", MemberCount = 900 };
            repo.Save(gru4);

            return repo;

        }
        [TestMethod]
        public void GroupCountTest()
        {
            MockGroupRepository repo = Initailize();

            Assert.AreEqual(repo.Groups.Count, 4);
            var results = repo.GetGroupById(1);
            var expected = "gayBoyz";
            Assert.AreEqual(results.Name, expected);
        }
    }
}
