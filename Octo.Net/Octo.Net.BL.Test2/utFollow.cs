using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Octo.Net.BL.Test2
{
    [TestClass]
    public class utFollow
    {
        private Follow manager;

        [TestInitialize()]
        public void InitializeBeforeEachTest()
        {
            manager = new Follow();
        }

        [TestCleanup()]
        public void CleanUpAfterEachTest()
        {
            manager.Dispose();
        }

        [TestMethod]
        public void FollowInsertTest()
        {
            Models.Follow follow = new Models.Follow();
            follow.ArtistId = 9999;
            follow.FollowerId = 9998;

            Follow blFollow = new Follow();
            int result = blFollow.Insert(follow);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void FollowDeleteTest()
        {
            Follow follow = new Follow();
            List<Models.Follow> follows = new List<Models.Follow>();
            follows = follow.Load();
            Models.Follow row = follows.Where(x => x.FollowerId == 9998).FirstOrDefault();
            if (row != null)
            {
                bool actual = follow.Delete(row.Id);
                Assert.IsTrue(actual == true);
            }
        }
    }
}
