using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octo.Net.Models;
using Octo.Net.BL;
using System.Text;

namespace Octo.Net.BL.Test2
{
    [TestClass]
    public class utFile
    {
        private File manager;

        [TestInitialize()]
        public void InitializeBeforeEachTest()
        {
            manager = new File();
        }

        [TestCleanup()]
        public void CleanupAfterEachTest()
        {
            manager.Dispose();
        }

        [TestMethod]
        public void FileInsertTest()
        {
            Models.File file = new Models.File();
            file.ArtworkId = 9999;
            file.Content = Encoding.UTF8.GetBytes("testFileUpload");
            file.ContentType = ".txt";
            file.FileName = "Text Test";
            file.FileType = FileType.Text;
            file.UserId = 9999;
        }

        [TestMethod]
        public void FileLoadAllTest()
        {
            File file = new File();
            file.Load();

            Assert.IsNotNull(file);
        }

        [TestMethod]
        public void FileLoadByArtworkId()
        {
            File file = new File();
            var actual = file.LoadByArtworkId(1);

            Assert.IsTrue(actual.ArtworkId == 1);

        }

        [TestMethod]
        public void FileLoadByUserId()
        {
            File file = new File();
            var actual = file.LoadByUserId(9999);

            Assert.IsTrue(actual.FileName == "Text Test");
        }
    }
}
