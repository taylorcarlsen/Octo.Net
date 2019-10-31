using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class Follow : IDisposable
    {
        private readonly OctoNetDbContext db;

        public Follow()
        {
            db = new OctoNetDbContext();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public List<Models.Follow> Load()
        {
            List<Models.Follow> follows = new List<Models.Follow>();
            db.Follows
                .ToList()
                .ForEach(f => follows
                .Add(
                    new Models.Follow
                    {
                        Id = f.Id,
                        FollowerId = f.FollowerId,
                        ArtistId = f.ArtistId
                    }
                    ));
            return follows;
        }

        public List<Models.Follow> LoadByArtistId(int artistId)
        {
            List<Models.Follow> follows = new List<Models.Follow>();
            db.Follows
                .Where(f => f.ArtistId == artistId)
                .ToList()
                .ForEach(f => follows
                .Add(new Models.Follow
                {
                    Id = f.Id,
                    ArtistId = f.ArtistId,
                    FollowerId = f.FollowerId
                }
                    ));
            return follows;
                
        }

        public int Insert(Models.Follow follow)
        {
            tblFollow newFollow = new tblFollow { FollowerId = follow.FollowerId, ArtistId = follow.ArtistId };
            db.Follows.Add(newFollow);

            db.SaveChanges();
            return newFollow.Id;
        }
        
        public void Update(Models.Follow follow)
        {
            var existing = db.Follows.SingleOrDefault(f => f.Id == follow.Id);

            if(existing != null)
            {
                existing.ArtistId = follow.ArtistId;
                existing.FollowerId = follow.FollowerId;

                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var existing = db.Follows.SingleOrDefault(x => x.Id == id);

            if(existing != null)
            {
                db.Follows.Remove(existing);
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
