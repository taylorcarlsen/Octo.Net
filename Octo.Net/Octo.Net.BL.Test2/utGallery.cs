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
    public class utGallery
    {
        private Gallery manager;

        [TestInitialize()]
        public void InitializeBeforeEachTest()
        {
            manager = new Gallery();
        }

        [TestCleanup()]
        public void CleanUpAfterEachTest()
        {
            manager.Dispose();
        }


        [TestMethod]
        public void InsertTest()
        {
            Models.Gallery gallery = new Octo.Net.Models.Gallery();
            gallery.UserId = 1;
            gallery.GalleryName = "Test Gallery";
            gallery.GalleryDescription = "Test Gallery Description";

        Gallery blGallery = new Gallery();
            int result = blGallery.Insert(gallery);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Gallery gallery = new Gallery();
            List<Models.Gallery> gallerys = new List<Models.Gallery>();
            gallerys = gallery.Load();
            Models.Gallery row = gallerys.Where(m => m.Id == 1).FirstOrDefault();

            row.GalleryName = "UPDATED: Test Gallery.";
            gallery.Update(row);

            List<Models.Gallery> updated = new List<Models.Gallery>();
            updated = gallery.Load();
            Models.Gallery updatedGallery = updated.Where(x => x.Id == 1).FirstOrDefault();

            Assert.AreNotEqual(updatedGallery, row);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Gallery gallery = new Gallery();
            List<Models.Gallery> gallerys = new List<Models.Gallery>();
            gallerys = gallery.Load();
            Models.Gallery row = gallerys.Where(x => x.Id == 2).FirstOrDefault();
            if (row != null)
            {
                bool actual = gallery.Delete(row.Id);
                Assert.IsTrue(actual == true);
            }
        }
    }
}
