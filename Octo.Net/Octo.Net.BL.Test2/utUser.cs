using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octo.Net.BL;
using Octo.Net.Models;

namespace Octo.Net.BL.Test2
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
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
        }

        [TestMethod]
        public void UpdateTest()
        {

        }
    }
}
