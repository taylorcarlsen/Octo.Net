using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octo.Net.Models;
using Octo.Net.BL;
using System.Linq;

namespace Octo.Net.BL.Test2
{
    [TestClass]
    public class utArtwork
    {
        private Artwork manager;

        [TestInitialize()]
        public void InitializeBeforeEachTest()
        {
            manager = new Artwork();
        }

        [TestCleanup()]
        public void CleanUpAfterEachTest()
        {
            manager.Dispose();
        }

        [TestMethod]
        public void InsertTest()
        {
            Models.Artwork artwork = new Octo.Net.Models.Artwork();
            artwork.GalleryId = 1;
            artwork.Title = "Test Art";
            artwork.Price = 39.99m;
            artwork.IsCommission = true;
            artwork.TagId = 1;
            artwork.CollectionMessageId = 1;
            artwork.ArtworkImagePath = "testartworkimage.png";

        Artwork blArtwork = new Artwork();
            int result = blArtwork.Insert(artwork);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Artwork artwork = new Artwork();
            List<Models.Artwork> artworks = new List<Models.Artwork>();
            artworks = artwork.Load();
            Models.Artwork row = artworks.Where(m => m.Id == 1).FirstOrDefault();

            row.Title = "UPDATED: Test Art.";
            artwork.Update(row);

            List<Models.Artwork> updated = new List<Models.Artwork>();
            updated = artwork.Load();
            Models.Artwork updatedArtwork = updated.Where(x => x.Id == 1).FirstOrDefault();

            Assert.AreNotEqual(updatedArtwork, row);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Artwork artwork = new Artwork();
            List<Models.Artwork> artworks = new List<Models.Artwork>();
            artworks = artwork.Load();
            Models.Artwork row = artworks.Where(x => x.Id == 2).FirstOrDefault();
            if (row != null)
            {
                bool actual = artwork.Delete(row.Id);
                Assert.IsTrue(actual == true);
            }
        }
    }
}
