using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class Gallery
    {
        private readonly OctoNetDbContext db;

        public Gallery()
        {
            db = new OctoNetDbContext();
        }
        ~Gallery()
        {
            db.Dispose();
        }

        public List<Models.Gallery> Load()
        {
            List<Models.Gallery> galleries = new List<Models.Gallery>();
            db.Galleries
                .ToList()
                .ForEach(a => galleries
                .Add(
                new Models.Gallery
                {
                    Id = a.Id,
                    UserId = a.UserId.GetValueOrDefault(),
                    GalleryName = a.GalleryName,
                    GalleryDescription = a.GalleryDescription,
                }));

            return galleries;
        }

        public int Insert(Models.Gallery gallery)
        {
            tblGallery newGallery = new tblGallery { GalleryName = gallery.GalleryName, GalleryDescription = gallery.GalleryDescription, UserId = gallery.UserId };
            db.Galleries.Add(newGallery);

            db.SaveChanges();
            return newGallery.Id;
        }
        public void Update(Models.Gallery gallery)
        {
            var existing = db.Galleries.SingleOrDefault(x => x.Id == gallery.Id);

            if(existing != null)
            {
                existing.GalleryName = gallery.GalleryName;
                existing.GalleryDescription = gallery.GalleryDescription;
                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var existing = db.Galleries.SingleOrDefault(x => x.Id == id);

            if(existing != null)
            {
                db.Galleries.Remove(existing);
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
