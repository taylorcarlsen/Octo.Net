using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class File : IDisposable
    {
        private readonly OctoNetDbContext db;

        public File()
        {
            db = new OctoNetDbContext();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<Models.File> Load()
        {
            List<Models.File> files = new List<Models.File>();
            db.Files.ToList().ForEach(f => files
            .Add(new Models.File
            {
                Id = f.Id,
                FileName = f.FileName,
                ContentType = f.ContentType,
                Content = f.Content,
                UserId = f.UserId,
                ArtworkId = f.ArtworkId
            }));

            return files;
        }

        public int Insert(Models.File file)
        {
            tblFiles newFile = new tblFiles
            {
                FileName = file.FileName,
                Content = file.Content,
                ContentType = file.ContentType,
                UserId = file.UserId,
                ArtworkId = file.ArtworkId

            };

            db.Files.Add(newFile);
            db.SaveChanges();
            return newFile.Id;
        }
    }
}
