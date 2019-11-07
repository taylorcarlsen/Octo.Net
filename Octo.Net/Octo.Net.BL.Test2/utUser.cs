using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octo.Net.BL;
using Octo.Net.Models;

namespace Octo.Net.BL.Test2
{
    [TestClass]
    public class utUser
    {
        private User manager;

        [TestInitialize()]
        public void InitializeBeforeEachTest()
        {
            manager = new User();
        }

        [TestCleanup()]
        public void CleanUpAfterEachTest()
        {
            manager.Dispose();
        }

        /*[TestMethod]
        public void InsertTest()
        {
            Models.User user = new Models.User();
            user.FirstName = "AnotherTest";
            user.LastName = "User";
            user.UserName = "TestUser";
            user.Password = "pass";
            user.Email = "Testemail@gmail.com";
            user.CommissionActive = true;
            user.JoinDate = DateTime.Now;

            User blUser = new User();
            int result = blUser.Insert(user);

            //Assert count is count + 1

            Assert.IsTrue(result > 0);
        }*/

        [TestMethod]
        public void UpdateTest()
        {
            User user = new User();
            List<Models.User> users = new List<Models.User>();
            users = user.Load();
            Models.User row = users.Where(u => u.FirstName == "AnotherTest").FirstOrDefault();

            row.UserName = "UpdatedUserName";
            user.Update(row);

            List<Models.User> updated = new List<Models.User>();
            updated = user.Load();
            Models.User updateRow = updated.Where(a => a.FirstName == "AnotherTest").FirstOrDefault();

            Assert.AreNotEqual(updateRow, row);
        }

        [TestMethod]
        public void DeleteTest()
        {
            User user = new User();
            List<Models.User> users = new List<Models.User>();
            users = user.Load();
            Models.User row = users.Where(u => u.UserName == "UpdatedUserName").FirstOrDefault();
            if (row != null)
            {
                bool actual = user.Delete(row.Id);
                Assert.IsTrue(actual == true);
            }
        }

        [TestMethod]
        public void LoadByUserNameTest()
        {
            User user = new User();
            var actual = user.LoadByUsername("TestUser");

            Assert.IsTrue(actual.UserName == "TestUser");
        }

        /*[TestMethod]
        public void LoginTest()
        {
            Models.User user = new Models.User();
            user.FirstName = "LoginF";
            user.LastName = "LoginL";
            user.UserName = "LoginUser";
            user.Password = "pass";
            user.Email = "Testemail@gmail.com";
            user.CommissionActive = true;
            user.JoinDate = DateTime.Now;
            int id = manager.Insert(user);

            var actual = manager.Login("LoginUser", "pass");

            Assert.IsTrue(actual == true);
        }*/
    }
}
