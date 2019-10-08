namespace Octo.Net.Data1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Octo.Net.Data1.OctoNetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Octo.Net.Data1.OctoNetDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            List<tblArtwork> defaultArtwork = new List<tblArtwork>();

            defaultArtwork.Add(new tblArtwork { CollectionMessageId = 1, GalleryId = 1, IsCommission = true, Price = 5, TagId = 1, Title = "Testing title" });
            context.Artworks.AddRange(defaultArtwork);

            List<tblArtworkTag> defaultArtworkTag = new List<tblArtworkTag>();

            defaultArtworkTag.Add(new tblArtworkTag { ArtworkId = 1, TagId = 1 });
            context.ArtworkTags.AddRange(defaultArtworkTag);

            List<tblCollection> defaultCollection = new List<tblCollection>();

            defaultCollection.Add(new tblCollection { MessageTypeId = 1 });
            context.Collections.AddRange(defaultCollection);

            List<tblCritique> defaultCritique = new List<tblCritique>();
            defaultCritique.Add(new tblCritique { CategoryDescription = "Test critique" });
            context.Critiques.AddRange(defaultCritique);

            List<tblGallery> defaultGallery = new List<tblGallery>();
            defaultGallery.Add(new tblGallery { GalleryDescription = "Test gallery description", GalleryName = "Test gallery name", UserId = 1 });
            context.Galleries.AddRange(defaultGallery);

            List<tblMessage> defaultMessage = new List<tblMessage>();
            defaultMessage.Add(new tblMessage { Body = "Testing the message body", DateTime = DateTime.Now, ToUserId = 1, FromUserId = 2 }); //this is the regular private message
            defaultMessage.Add(new tblMessage { Body = "Testing the comment body", CritiqueId = 1, ToUserId = 1, FromUserId = 2, DateTime = DateTime.Now, Rating = 3 });
            context.Messages.AddRange(defaultMessage);

            List<tblMessageType> defaultMessageType = new List<tblMessageType>();
            defaultMessageType.Add(new tblMessageType { Description = "Private" });
            defaultMessageType.Add(new tblMessageType { Description = "Comment" });
            context.MessageTypes.AddRange(defaultMessageType);

            List<tblTag> defaultTag = new List<tblTag>();
            defaultTag.Add(new tblTag { Name = "Testing tag" });
            context.Tags.AddRange(defaultTag);

            List<tblUser> defaultUser = new List<tblUser>();
            defaultUser.Add(new tblUser
            {
                CommissionActive = true,
                Email = "test@test.net",
                FirstName = "FirstNameTest",
                LastName = "LastNameTest",
                JoinDate = DateTime.Now.Date,
                Password = "12345678",
                UserName = "Test User Name"
            });
            context.Users.AddRange(defaultUser);

            List<tblFollow> defaultFollow = new List<tblFollow>();
            defaultFollow.Add(new tblFollow
            {
                ArtistId = 1,
                FollowerId = 2
            });
            context.Follows.AddRange(defaultFollow);

            //base.Seed(context);
        }
    }
}
