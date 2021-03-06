﻿using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class Message : IDisposable
    {
        private readonly OctoNetDbContext db;

        public Message()
        {
            db = new OctoNetDbContext();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public List<Models.Message> LoadByCollection(int collectionId)
        {
            BL.User user = new BL.User();
            List<Models.Message> messages = new List<Models.Message>();
            db.Messages.Where(x => x.CollectionId == collectionId)
                .ToList()
                .ForEach(x => messages
            .Add(new Models.Message
            {
                Id = x.Id,
                FromUserId = x.FromUserId,
                ToUserId = x.ToUserId,
                Body = x.Body,
                CollectionId = x.CollectionId,
                DateTime = x.DateTime,
                CritiqueId = x.CritiqueId,
                Rating = x.Rating,
                X = x.X,
                Y = x.Y,
                FromUsername = (user.LoadById(x.FromUserId).UserName == null || user.LoadById(x.FromUserId).UserName == String.Empty) ? "User Not Found" : user.LoadById(x.FromUserId).UserName
            }));
            return messages;
        }
        public List<Models.Message> Load()
        {
            BL.User user = new BL.User();
            List<Models.Message> messages = new List<Models.Message>();
            db.Messages
                .ToList()
                .ForEach(m => messages
                .Add(
                new Models.Message
                {
                    Id = m.Id,
                    FromUserId = m.FromUserId,
                    ToUserId = m.ToUserId,
                    Body = m.Body,
                    CollectionId = m.CollectionId,
                    DateTime = m.DateTime,
                    CritiqueId = m.CritiqueId,
                    Rating = m.Rating,
                    X = m.X,
                    Y = m.Y,
                    FromUsername = (user.LoadById(m.FromUserId).UserName == null || user.LoadById(m.FromUserId).UserName == String.Empty) ? "User Not Found" : user.LoadById(m.FromUserId).UserName
                }));

            return messages;
        }

        public int Insert(Models.Message message)
        {
            tblMessage newMessage = new tblMessage {
                Body = message.Body,
                CritiqueId = message.CritiqueId,
                DateTime = DateTime.Now,
                Rating = message.Rating,
                FromUserId = message.FromUserId,
                ToUserId = message.ToUserId,
                CollectionId = message.CollectionId,
                X = message.X,
                Y = message.Y
            };
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
