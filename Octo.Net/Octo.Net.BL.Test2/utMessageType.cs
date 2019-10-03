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
    public class utMessageType
    {
        [TestMethod]
        public void InsertTest()
        {
            Models.MessageType messageType = new Octo.Net.Models.MessageType();
            messageType.Id = 1;
            messageType.Description = "Test MessageType";

            MessageType blMessageType = new MessageType();
            int result = blMessageType.Insert(messageType);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            MessageType messageType = new MessageType();
            List<Models.MessageType> messageTypes = new List<Models.MessageType>();
            messageTypes = messageType.Load();
            Models.MessageType row = messageTypes.Where(m => m.Id == 1).FirstOrDefault();

            row.Description = "UPDATED: MessageType.";
            messageType.Update(row);

            List<Models.MessageType> updated = new List<Models.MessageType>();
            updated = messageType.Load();
            Models.MessageType updatedMessageType = updated.Where(x => x.Id == 1).FirstOrDefault();

            Assert.AreNotEqual(updatedMessageType, row);
        }

        [TestMethod]
        public void DeleteTest()
        {
            MessageType messageType = new MessageType();
            List<Models.MessageType> messageTypes = new List<Models.MessageType>();
            messageTypes = messageType.Load();
            Models.MessageType row = messageTypes.Where(x => x.Id == 2).FirstOrDefault();
            if (row != null)
            {
                bool actual = messageType.Delete(row.Id);
                Assert.IsTrue(actual == true);
            }
        }
    }
}
