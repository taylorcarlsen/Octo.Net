using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octo.Net.Data;

namespace Octo.Net.Data1
{
    public class OctoNetDBContext : DbContext
    {
        public OctoNetDBContext() : base()
        {
            Database.SetInitializer<OctoNetDBContext>(new CreateDatabaseIfNotExists<OctoNetDBContext>());
        }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<ArtworkTag> ArtworkTags { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Critique> Critiques { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
