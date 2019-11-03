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

        public virtual DbSet<tblArtwork> Artworks { get; set; }
        public virtual DbSet<tblArtworkTag> ArtworkTags { get; set; }
        public virtual DbSet<tblCollection> Collections { get; set; }
        public virtual DbSet<tblCritique> Critiques { get; set; }
        public virtual DbSet<tblGallery> Galleries { get; set; }
        public virtual DbSet<tblMessage> Messages { get; set; }
        public virtual DbSet<tblMessageType> MessageTypes { get; set; }
        public virtual DbSet<tblTag> Tags { get; set; }
        public virtual DbSet<tblUser> Users { get; set; }
        public virtual DbSet<tblFollow> Follows { get; set; }
        public virtual DbSet<tblFlagOption> FlagOptions { get; set; }
        public virtual DbSet<tblArtworkFlag> ArtworkFlags { get; set; }
        public virtual DbSet<tblFiles> Files { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblArtwork>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtwork>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tblCritique>()
                .Property(e => e.CategoryDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tblGallery>()
                .Property(e => e.GalleryName)
                .IsUnicode(false);

            modelBuilder.Entity<tblGallery>()
                .Property(e => e.GalleryDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tblMessage>()
                .Property(e => e.Body)
                .IsUnicode(false);

            modelBuilder.Entity<tblMessageType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<tblTag>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblFollow>()
                .Property(e => e.ArtistId);
        }*/
    }
}
