using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Octo.Net.BL.Test2
{
    [TestClass]
    public class utCollection
    {
        [TestMethod]
        public void InsertTest()
        {
            Models.Collection collection = new Models.Collection();
            collection.MessageId = 9999;
            collection.MessageTypeId = 9998;

            Collection blCollection = new Collection();
            int result = blCollection.Insert(collection);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Models.Collection collection = new Models.Collection();
            List<Models.Collection> collections = new List<Models.Collection>();
            //collections = collection.Load();
        }
    }
}
