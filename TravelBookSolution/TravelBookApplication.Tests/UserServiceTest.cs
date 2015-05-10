using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TravelBookApplication.Services;
using TravelBookApplication.Models;
using NUnit;
using Moq;
using NCrunch.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBookApplication.Models.ViewModels;


namespace TravelBookApplication.Tests.Services
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void UserTest()
        {
            //Arrange
            UserService service = new UserService();

            //Act

            var result = service.GetUserById("048b8c7adde3");
            
            //Assert
            Assert.IsInstanceOfType(result, typeof(ApplicationUser));

        }
    }
}
