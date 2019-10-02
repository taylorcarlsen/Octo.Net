using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octo.Net.Models;

namespace Octo.Net.BL
{
    public class ArtworkTag
    {
        private readonly OctoNetDbContext db;

        public ArtworkTag()
        {
            db = new OctoNetDbContext();
        }
        ~ArtworkTag()
        {
            db.Dispose();
        }

        public List<Models.ArtworkTag> Load()
        {
            List<Models.ArtworkTag> artworkTags = new List<Models.ArtworkTag>();
            db.ArtworkTags
                .ToList()
                .ForEach(a => artworkTags
                .Add(
                new Models.ArtworkTag
                {
                    Id = a.Id,
                    ArtworkId = a.ArtworkId.GetValueOrDefault(),
                    TagId = a.TagId.GetValueOrDefault()
        }));

            return artworkTags;
        }

        public int Insert(Models.ArtworkTag artworkTag)
        {
            tblArtworkTag newArtworkTag = new Data1.tblArtworkTag { ArtworkId = artworkTag.ArtworkId, TagId = artworkTag.TagId };
            db.ArtworkTags.Add(newArtworkTag);

            db.SaveChanges();
            return newArtworkTag.Id;
        }
        public void Update(Models.ArtworkTag artworkTag)
        {
            var existing = db.ArtworkTags.SingleOrDefault(x => x.Id == artworkTag.Id);

            if(existing != null)
            {
                existing.TagId = artworkTag.TagId;
                db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            var existing = db.ArtworkTags.SingleOrDefault(x => x.Id == id);

            if(existing!=null)
            {
                db.ArtworkTags.Remove(existing);
                db.SaveChanges();
                return true;
            }
            else{ return false; }
        }
    }
}
