﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octo.Net.BL;
using Octo.Net.Models;

namespace Octo.Net.BL.Test2
{
    [TestClass]
    public class utMessage
    {
        private Message manager;

        [TestInitialize()]
        public void InitializeBeforeEachTest()
        {
            manager = new Message();
        }

        [TestCleanup()]
        public void CleanUpAfterEachTest()
        {
            manager.Dispose();
        }


        [TestMethod]
        public void PrivateMessageInsertTest()
        {
            Models.Message message = new Models.Message();
            message.Body = "This is a test body of a private message.";
            message.DateTime = DateTime.Now;
            message.FromUserId = 1;
            message.ToUserId = 2;
            message.CollectionId = 1;

            Message blMessage = new Message();
            int result = blMessage.Insert(message);

            Assert.IsTrue(result > 0);
        }


        [TestMethod]
        public void CommentMessageInsertTest()
        {
            Models.Message message = new Models.Message();
            message.Body = "This is a test for the comment.";
            message.DateTime = DateTime.Now;
            message.FromUserId = 1;
            message.ToUserId = 2;
            message.CollectionId = 2;
            message.CritiqueId = 1;
            message.X = 1;
            message.Y = 2;
            message.Rating = 3;

            Message blMessage = new Message();
            int result = blMessage.Insert(message);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Message message = new Message();
            List<Models.Message> messages = new List<Models.Message>();
            messages = message.LoadByCollection(1);
            Models.Message row = messages.Where(m => m.Id == 1).FirstOrDefault();

            row.Body = "UPDATED: This is a test body of a private message.";
            message.Update(row);

            List<Models.Message> updated = new List<Models.Message>();
            updated = message.LoadByCollection(1);
            Models.Message updatedMessage = updated.Where(x => x.Id == 1).FirstOrDefault();

            Assert.AreNotEqual(updatedMessage, row);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Message message = new Message();
            List<Models.Message> messages = new List<Models.Message>();
            messages = message.Load();
            Models.Message row = messages.Where(x => x.CollectionId == 2).FirstOrDefault();
            if(row != null)
            {
                bool actual = message.Delete(row.Id);
                Assert.IsTrue(actual == true);
            }
        }

        [TestMethod]
        public void LoadByCollectionTest()
        {
            Models.Message message = new Models.Message();
            message.Body = "Testing Collection Get";
            message.CollectionId = 2;
            message.CritiqueId = 1;
            message.DateTime = DateTime.Now;
            message.FromUserId = 1;
            message.ToUserId = 2;
            message.X = 1;
            message.Y = 2;
            int id = manager.Insert(message);

            var actual = manager.LoadByCollection(id);
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count);
        }
    }

}
