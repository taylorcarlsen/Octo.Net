using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octo.Net.Data1;
using Octo.Net.Models;

namespace Octo.Net.BL
{
    public class Collection
    {
        private readonly OctoNetDbContext db;

        public Collection()
        {
            db = new OctoNetDbContext();
        }
        ~Collection()
        {
            db.Dispose();
        }

        public int Insert(Models.Collection collection)
        {
            tblCollection newCollection = new tblCollection { MessageTypeId = collection.Id };
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
