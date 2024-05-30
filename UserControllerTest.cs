using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTest
    {
        private UserController _userController;
        private List<User> _users;

        [SetUp]
        public void Setup()
        {
            _userController = new UserController();
            _users = new List<User> {
                new User { Id = 1, Name = "Test1", Email = "test1@test.com" },
                new User { Id = 2, Name = "Test2", Email = "test2@test.com" }
            };
            UserController.userlist = _users;
        }

        [Test]
        public void Index_ReturnsCorrectView_WithAListOfUsers()
        {
            var result = _userController.Index() as ViewResult;
            var model = result.Model as List<User>;

            ClassicAssert.AreEqual("Index", result.ViewName);
            ClassicAssert.AreEqual(2, model.Count);
        }

        [Test]
        public void Details_ReturnsCorrectView_WithUser()
        {
            var user = _users[0];

            var result = _userController.Details(user.Id) as ViewResult;
            var model = result.Model as User;

            ClassicAssert.AreEqual("Details", result.ViewName);
            ClassicAssert.AreEqual(user, model);
        }

        // Add more tests for Create, Edit, and Delete actions
    }
}
