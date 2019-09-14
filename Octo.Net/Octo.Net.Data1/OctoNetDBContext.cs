namespace Octo.Net.Data1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OctoNetDbContext : DbContext
    {
        public OctoNetDbContext()
            : base("name=OctoNetDbContext")
        {
        }

        public virtual DbSet<Artwork> Artworks { get; set; }
        public virtual DbSet<ArtworkTag> ArtworkTags { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Critique> Critiques { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageType> MessageTypes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artwork>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Artwork>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Critique>()
                .Property(e => e.CategoryDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Gallery>()
                .Property(e => e.GalleryName)
                .IsUnicode(false);

            modelBuilder.Entity<Gallery>()
                .Property(e => e.GalleryDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Body)
                .IsUnicode(false);

            modelBuilder.Entity<MessageType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);
        }
    }
}
