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
    public class utArtworkTag
    {
        [TestMethod]
        public void InsertTest()
        {
            Models.ArtworkTag artworkTag = new Octo.Net.Models.ArtworkTag();
            artworkTag.ArtworkId = 1;
            artworkTag.TagId = 1;

            ArtworkTag blArtworkTag = new ArtworkTag();
            int result = blArtworkTag.Insert(artworkTag);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            ArtworkTag artworkTag = new ArtworkTag();
            List<Models.ArtworkTag> artworkTags = new List<Models.ArtworkTag>();
            artworkTags = artworkTag.Load();
            Models.ArtworkTag row = artworkTags.Where(m => m.Id == 3).FirstOrDefault();

            row.ArtworkId = 1;
            artworkTag.Update(row);

            List<Models.ArtworkTag> updated = new List<Models.ArtworkTag>();
            updated = artworkTag.Load();
            Models.ArtworkTag updatedArtworkTag = updated.Where(x => x.Id == 3).FirstOrDefault();

            Assert.AreNotEqual(updatedArtworkTag, row);
        }

        [TestMethod]
        public void DeleteTest()
        {
            ArtworkTag artworkTag = new ArtworkTag();
            List<Models.ArtworkTag> artworkTags = new List<Models.ArtworkTag>();
            artworkTags = artworkTag.Load();
            Models.ArtworkTag row = artworkTags.Where(x => x.Id == 2).FirstOrDefault();
            if (row != null)
            {
                bool actual = artworkTag.Delete(row.Id);
                Assert.IsTrue(actual == true);
            }
        }
    }
}
