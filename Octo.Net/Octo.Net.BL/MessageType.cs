using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class MessageType : IDisposable
    {

        private readonly OctoNetDbContext db;

        public MessageType()
        {
            db = new OctoNetDbContext();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public List<Models.MessageType> Load()
        {
            List<Models.MessageType> messageTypes = new List<Models.MessageType>();
            db.MessageTypes
                .ToList()
                .ForEach(a => messageTypes
                .Add(
                new Models.MessageType
                {
                    Id = a.Id,
                    Description = a.Description
                }));

            return messageTypes;
        }

        public int Insert(Models.MessageType messageType)
        {
            tblMessageType newMessageType = new tblMessageType { Description = messageType.Description };
            db.MessageTypes.Add(newMessageType);

            db.SaveChanges();
            return newMessageType.Id;
        }

        public void Update(Models.MessageType messageType)
        {
            var existing = db.MessageTypes.SingleOrDefault(x => x.Id == messageType.Id);

            if(existing != null)
            {
                existing.Description = messageType.Description;
                db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            var existing = db.MessageTypes.SingleOrDefault(x => x.Id == id);

            if(existing != null)
            {
                db.MessageTypes.Remove(existing);
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
