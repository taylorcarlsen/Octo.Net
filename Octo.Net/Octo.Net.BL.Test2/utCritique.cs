using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octo.Net.Models;
using Octo.Net.BL;
using System.Linq;

namespace Octo.Net.BL.Test
{
    [TestClass]
    public class utCritique
    {
        private Critique manager;

        [TestInitialize()]
        public void InitializeBeforeEachTest()
        {
            manager = new Critique();
        }

        [TestCleanup()]
        public void CleanUpAfterEachTest()
        {
            manager.Dispose();
        }


        [TestMethod]
        public void InsertTest()
        {
            Models.Critique critique = new Octo.Net.Models.Critique();
            critique.CategoryDescription = "This is a test";

            Critique blCritique = new Critique();
            int result = blCritique.Insert(critique);

            Assert.IsTrue(result > 0);
        }

        public void UpdateTest()
        {
            Critique critique = new Critique();
            List<Models.Critique> critiques = new List<Models.Critique>();
            //critiques = critiques.Load();
            Models.Critique row = critiques.Where(m => m.CategoryDescription == "This is a test body of a private critique.").FirstOrDefault();

            row.CategoryDescription = "UPDATED: This is a test body of a private critique.";
            critique.Update(row);

            List<Models.Critique> updated = new List<Models.Critique>();
            //updated = critique.Load();
            Models.Critique updatedCritique = updated.Where(x => x.CategoryDescription == "This is a test body of a private critique.").FirstOrDefault();

            Assert.AreNotEqual(updatedCritique, row);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Critique critique = new Critique();
            List<Models.Critique> critiques = new List<Models.Critique>();
            critiques = critique.Load();
            Models.Critique row = critiques.Where(x => x.Id == 2).FirstOrDefault();
            if (row != null)
            {
                bool actual = critique.Delete(row.Id);
                Assert.IsTrue(actual == true);
            }
        }
    }
}
