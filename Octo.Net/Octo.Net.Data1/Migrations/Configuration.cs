namespace Octo.Net.Data1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Octo.Net.Data1.OctoNetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Octo.Net.Data1.OctoNetDbContext context)
        {
            try
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

                List<tblFlagOption> defaultFlagOptions = new List<tblFlagOption>();
                defaultFlagOptions.Add(new tblFlagOption
                {
                    Description = "Nudity or Pornography"
                });
                defaultFlagOptions.Add(new tblFlagOption
                {
                    Description = "Graphic Violence"
                });
                defaultFlagOptions.Add(new tblFlagOption
                {
                    Description = "Hate Speech or Symbols"
                });
                defaultFlagOptions.Add(new tblFlagOption
                {
                    Description = "Intellectual Property Violation"
                });
                defaultFlagOptions.Add(new tblFlagOption
                {
                    Description = "Other"
                });
                context.FlagOptions.AddRange(defaultFlagOptions);

                List<tblArtworkFlag> defaultArtworkFlags = new List<tblArtworkFlag>();
                defaultArtworkFlags.Add(new tblArtworkFlag
                {
                    ArtworkId = 1,
                    UserId = 1,
                    FlagId = 1,
                    Comment = "Default Flag for seed"
                });
                context.ArtworkFlags.AddRange(defaultArtworkFlags);

                List<tblFiles> defaultFiles = new List<tblFiles>();
                defaultFiles.Add(new tblFiles
                {
                    FileName = "Seed",
                    ContentType = ".txt",
                    Content = Encoding.UTF8.GetBytes("testFileUpload"),
                    UserId = 1,
                    ArtworkId = 1

                });
                context.Files.AddRange(defaultFiles);
                

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
