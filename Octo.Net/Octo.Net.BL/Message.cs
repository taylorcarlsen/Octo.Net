using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class Message
    {
        private readonly OctoNetDbContext db;

        public Message()
        {
            db = new OctoNetDbContext();
        }
        ~Message()
        {
            db.Dispose();
        }

        public int Insert(Models.Message message)
        {
            tblMessage newMessage = new tblMessage { Body = message.Body, CritiqueId = message.CritiqueId,
                DateTime = message.DateTime, Rating = message.Rating, UserId = message.UserId, X = message.X, Y = message.Y };
            db.Messages.Add(newMessage);

            db.SaveChanges();
            return newMessage.Id;
        }
        public void Update(Models.Message message)
        {
            var existing = db.Messages.SingleOrDefault(x => x.Id == message.Id);

            if(existing != null)
            {
                existing.Body = message.Body;
                existing.CritiqueId = message.CritiqueId;
                existing.DateTime = message.DateTime;
                existing.Rating = message.Rating;
                existing.X = message.X;
                existing.Y = message.Y;

                db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            var existing = db.Messages.SingleOrDefault(x => x.Id == id);

            if(existing != null)
            {
                db.Messages.Remove(existing);
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
