﻿using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class Gallery : IDisposable
    {
        private readonly OctoNetDbContext db;

        public Gallery()
        {
            db = new OctoNetDbContext();
        }
        public void Dispose()
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
                    DateCreated = a.DateCreated
                }));

            return galleries;
        }

        public Models.Gallery LoadById(int id)
        {
            var gallery = db.Galleries.FirstOrDefault(a => a.Id == id);
            if (gallery != null)
            {
                Models.Gallery a = new Models.Gallery
                {
                    Id = gallery.Id,
                    UserId = gallery.UserId.GetValueOrDefault(),
                    GalleryName = gallery.GalleryName,
                    GalleryDescription = gallery.GalleryDescription,
                    DateCreated = gallery.DateCreated
                };
                return a;
            }
            else { throw new Exception("Row was not found."); }
        }

        public List<Models.Gallery> LoadByUserId(int userId)
        {
            List<Models.Gallery> galleries = new List<Models.Gallery>();
            db.Galleries.Where(a => a.UserId == userId)
                .ToList()
                .ForEach(a => galleries
            .Add(new Models.Gallery
            {
                Id = a.Id,
                UserId = a.UserId.GetValueOrDefault(),
                GalleryName = a.GalleryName,
                GalleryDescription = a.GalleryDescription,
                DateCreated = a.DateCreated
            }));
            return galleries;
        }

        public int Insert(Models.Gallery gallery)
        {
            tblGallery newGallery = new tblGallery { GalleryName = gallery.GalleryName, GalleryDescription = gallery.GalleryDescription, UserId = gallery.UserId, DateCreated = gallery.DateCreated};
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
                existing.DateCreated = gallery.DateCreated;
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
