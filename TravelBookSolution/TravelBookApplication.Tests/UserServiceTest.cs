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
using TravelBookApplication.Models.Entities;


namespace TravelBookApplication.Tests.Services
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void UserTest()
        {
            //Arrange
          /*  UserService service = new UserService();
            var user = new UserContent();
            {
                FullName = "derp";
            };

            //Act

           // var result = service.number();
            
            //Assert
            Assert.IsInstanceOfType(user, typeof(int));*/

        }
        [TestMethod]
        public void GetAllUsersTest()
        {
            UserService service = new UserService();
    
        }
    }
    
}
