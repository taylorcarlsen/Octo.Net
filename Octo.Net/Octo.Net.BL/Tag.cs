using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class Tag : IDisposable
    {
        private readonly OctoNetDbContext db;

        public Tag()
        {
            db = new OctoNetDbContext();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public List<Models.Tag> Load()
        {
            List<Models.Tag> tags = new List<Models.Tag>();
            db.Tags.ToList().ForEach(x => tags
            .Add(new Models.Tag
            {
                Id = x.Id,
                Name = x.Name,
            }));

            return tags;
        }

        public int Insert(Models.Tag tag)
        {
            tblTag newTag = new tblTag { Name = tag.Name };
            db.Tags.Add(newTag);

            db.SaveChanges();
            return newTag.Id;
        }
        public void Update(Models.Tag tag)
        {
            var existing = db.Tags.SingleOrDefault(x => x.Id == tag.Id);

            if(existing != null)
            {
                existing.Name = tag.Name;
                db.SaveChanges();
            }
        }
        public bool Delete(int Id)
        {
            var existing = db.Tags.SingleOrDefault(x => x.Id == Id);

            if(existing != null)
            {
                db.Tags.Remove(existing);
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
