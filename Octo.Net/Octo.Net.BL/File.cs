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
            BL.Artwork artwork = new BL.Artwork();
            db.Files.ToList().ForEach(f => files
            .Add(new Models.File
            {
                Id = f.Id,
                FileName = f.FileName,
                ContentType = f.ContentType,
                Content = f.Content,
                UserId = f.UserId,
                ArtworkId = f.ArtworkId,
                Artwork = artwork.LoadById(f.ArtworkId)
            }));

            return files;
        }

        public Models.File LoadByArtworkId(int id)
        {
            if (id != null)
            {
                List<Models.File> files = new List<Models.File>();

                var file = db.Files.FirstOrDefault(f => f.ArtworkId == id);
                if (file != null)
                {
                    Models.File f = new Models.File
                    {
                        Id = file.Id,
                        ArtworkId = file.ArtworkId,
                        UserId = file.UserId,
                        Content = file.Content,
                        ContentType = file.ContentType,
                        FileName = file.FileName
                    };
                    return f;
                }
                else { return null; }
            }
            else { return null; }
        }

        public List<Models.File> LoadByUserId(int id)
        {
            if(id != null)
            {
                List<Models.File> files = new List<Models.File>();
                BL.Artwork artwork = new BL.Artwork();
                db.Files.Where(f => f.UserId == id)
                    .ToList()
                    .ForEach(f => files
                    .Add(new Models.File
                    {
                        Id = f.Id,
                        ArtworkId = f.ArtworkId,
                        UserId = f.UserId,
                        FileName = f.FileName,
                        ContentType = f.ContentType,
                        Content = f.Content,
                        Artwork = artwork.LoadById(f.ArtworkId)
                    }));
                return files;
                
            }
            else { return null; }
        }

        public List<Models.File> LoadByUserGalleryId(int userId, int galleryId)
        {
            if (userId != null && galleryId != null)
            {
                List<Models.File> files = new List<Models.File>();
                BL.Artwork artwork = new BL.Artwork();

                var results = (from f in db.Files
                               join a in db.Artworks on f.ArtworkId equals a.Id
                               where (a.GalleryId == galleryId && f.UserId == userId)
                               select new
                               { 
                                   f.Id,
                                   f.ArtworkId,
                                   f.UserId,
                                   f.FileName,
                                   f.ContentType,
                                   f.Content,
                                   f.FileType
                               }).ToList();

                foreach (var r in results)
                {
                    files.Add(new Models.File
                     {
                         Id = r.Id,
                         ArtworkId = r.ArtworkId,
                         UserId = r.UserId,
                         FileName = r.FileName,
                         ContentType = r.ContentType,
                         Content = r.Content,
                         FileType = (Models.FileType)r.FileType,
                         Artwork = artwork.LoadById(r.ArtworkId) 
                     });;
                }
                return files;

            }
            else { return null; }
        }

        public List<Models.File> LoadByUserFileTypeId(int userId, Net.Models.FileType fileType)
        {
            if (fileType != null)
            {
                List<Models.File> files = new List<Models.File>();
                BL.Artwork artwork = new BL.Artwork();

                var results = (from f in db.Files
                               where (f.FileType == (tblFileType) fileType && f.UserId == userId)
                               select new
                               {
                                   f.Id,
                                   f.ArtworkId,
                                   f.UserId,
                                   f.FileName,
                                   f.ContentType,
                                   f.Content,
                                   f.FileType
                               }).ToList();

                foreach (var r in results)
                {
                    files.Add(new Models.File
                    {
                        Id = r.Id,
                        ArtworkId = r.ArtworkId,
                        UserId = r.UserId,
                        FileName = r.FileName,
                        ContentType = r.ContentType,
                        Content = r.Content,
                        FileType = (Models.FileType)r.FileType,
                        Artwork = artwork.LoadById(r.ArtworkId)
                    });
                }
                return files;

            }
            else { return null; }
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
