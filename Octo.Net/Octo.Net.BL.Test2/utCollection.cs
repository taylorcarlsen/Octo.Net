using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Octo.Net.BL.Test2
{
    [TestClass]
    public class utCollection
    {
        private Collection manager;

        [TestInitialize()]
        public void InitializeBeforeEachTest()
        {
            manager = new Collection();
        }

        [TestCleanup()]
        public void CleanUpAfterEachTest()
        {
            manager.Dispose();
        }

        [TestMethod]
        public void LoadTest()
        {
            Collection collection = new Collection();
            List<Models.Collection> collections = new List<Models.Collection>();
            collections = collection.Load();

            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void InsertTest()
        {
            Models.Collection collection = new Models.Collection();
            collection.MessageTypeId = 9999;

            Collection blCollection = new Collection();
            int result = blCollection.Insert(collection);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Collection dCollection = new Collection();
            List<Models.Collection> collections = new List<Models.Collection>();
            collections = dCollection.Load();
            Models.Collection row = collections.Where(x => x.MessageTypeId == 9999).FirstOrDefault();
            if(row != null)
            {
                bool actual = dCollection.Delete(row.Id);
                Assert.IsTrue(actual);
            }
        }
    }
}
