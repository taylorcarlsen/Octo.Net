using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octo.Net.Models;
using Octo.Net.BL;
using System.Linq;

namespace Octo.Net.BL.Test2
{
    [TestClass]
    public class utTag
    {
        private Tag manager;

        [TestInitialize()]
        public void InitializeBeforeEachTest()
        {
            manager = new Tag();
        }

        [TestCleanup()]
        public void CleanUpAfterEachTest()
        {
            manager.Dispose();
        }

        [TestMethod]
        public void InsertTest()
        {
            Models.Tag tag = new Octo.Net.Models.Tag();
            tag.Name = "This is a test";

            Tag blTag = new Tag();
            int result = blTag.Insert(tag);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Tag tag = new Tag();
            List<Models.Tag> tags = new List<Models.Tag>();
            tags = tag.Load();
            Models.Tag row = tags.Where(m => m.Id == 1).FirstOrDefault();

            row.Name = "UPDATED: Update Test tag.";
            tag.Update(row);

            List<Models.Tag> updated = new List<Models.Tag>();
            updated = tag.Load();
            Models.Tag updatedTag = updated.Where(x => x.Id == 1).FirstOrDefault();

            Assert.AreNotEqual(updatedTag, row);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Tag tag = new Tag();
            List<Models.Tag> tags = new List<Models.Tag>();
            tags = tag.Load();
            Models.Tag row = tags.Where(x => x.Id == 2).FirstOrDefault();
            if (row != null)
            {
                bool actual = tag.Delete(row.Id);
                Assert.IsTrue(actual == true);
            }
        }
    }
}
