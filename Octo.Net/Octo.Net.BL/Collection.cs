using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octo.Net.Data1;
using Octo.Net.Models;

namespace Octo.Net.BL
{
    public class Collection : IDisposable
    {
        private readonly OctoNetDbContext db;

        public Collection()
        {
            db = new OctoNetDbContext();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public List<Models.Collection> Load()
        {
            List<Models.Collection> collections = new List<Models.Collection>();
            db.Collections.ToList().ForEach(x => collections.Add(
                new Models.Collection
                {
                    Id = x.Id,
                    MessageTypeId = x.MessageTypeId
                }
                ));
            return collections;
        }

        public int Insert(Models.Collection collection)
        {
            tblCollection newCollection = new tblCollection { MessageTypeId = collection.MessageTypeId};
            db.Collections.Add(newCollection);

            db.SaveChanges();
            return newCollection.Id;
        }
        public bool Delete(int id)
        {
            var existing = db.Collections.SingleOrDefault(x => x.Id == id);

            if(existing != null)
            {
                db.Collections.Remove(existing);
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
