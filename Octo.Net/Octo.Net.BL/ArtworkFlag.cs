using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class ArtworkFlag : IDisposable
    {
        private readonly OctoNetDbContext db;

        public ArtworkFlag()
        {
            db = new OctoNetDbContext();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public List<Models.ArtworkFlag> Load()
        {
            List<Models.ArtworkFlag> artworkFlags = new List<Models.ArtworkFlag>();
            db.ArtworkFlags
                .ToList()
                .ForEach(a => artworkFlags.Add(
                    new Models.ArtworkFlag
                    {
                        Id = a.Id,
                        ArtworkId = a.ArtworkId,
                        FlagId = a.FlagId,
                        Comment = a.Comment
                    }));

            return artworkFlags;
        }

        public int Insert(Models.ArtworkFlag artworkFlag)
        {
            tblArtworkFlag newArtworkFlag = new tblArtworkFlag
            {
                ArtworkId = artworkFlag.ArtworkId,
                FlagId = artworkFlag.FlagId,
                Comment = artworkFlag.Comment
            };
            db.ArtworkFlags.Add(newArtworkFlag);
            db.SaveChanges();
            return newArtworkFlag.Id;
        }

        public void Update(Models.ArtworkFlag artworkFlag)
        {
            var existing = db.ArtworkFlags.SingleOrDefault(x => x.Id == artworkFlag.Id);

            if(existing!=null)
            {
                existing.Comment = artworkFlag.Comment;
                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var existing = db.ArtworkFlags.SingleOrDefault(x => x.Id == id);

            if(existing!=null)
            {
                db.ArtworkFlags.Remove(existing);
                db.SaveChanges();
                return true;
            }
            else
            return false;
        }
    }
}
