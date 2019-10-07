﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octo.Net.Data1;
using Octo.Net.Models;

namespace Octo.Net.BL
{
    public class Artwork : IDisposable
    {
        private readonly OctoNetDbContext db;

        public Artwork()
        {
            db = new OctoNetDbContext();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public List<Models.Artwork> Load()
        {
            List<Models.Artwork> artworks = new List<Models.Artwork>();
            db.Artworks
                .ToList()
                .ForEach(a => artworks
                .Add(
                new Models.Artwork
                {
                    Id = a.Id,
                    GalleryId = a.GalleryId.GetValueOrDefault(),
                    Title = a.Title,
                    Price = a.Price.GetValueOrDefault(),
                    IsCommission = a.IsCommission.GetValueOrDefault(),
                    TagId = a.TagId.GetValueOrDefault(),
                    CollectionMessageId = a.CollectionMessageId.GetValueOrDefault()
                }));

            return artworks;
        }

        public int Insert(Models.Artwork artwork)
        {
            Data1.tblArtwork tblArtwork = new Data1.tblArtwork {
                GalleryId = artwork.GalleryId, Title = artwork.Title, Price = artwork.Price, IsCommission = artwork.IsCommission,
                TagId = artwork.TagId, CollectionMessageId = artwork.CollectionMessageId };

            db.Artworks.Add(tblArtwork);
            db.SaveChanges();
            return tblArtwork.Id;

        }

        public void Update(Models.Artwork artwork)
        {
            var existing = db.Artworks.SingleOrDefault(x => x.Id == artwork.Id);

            if(existing != null)
            {
                existing.GalleryId = artwork.GalleryId;
                existing.Title = artwork.Title;
                existing.Price = artwork.Price;
                existing.IsCommission = artwork.IsCommission;
                existing.TagId = artwork.TagId;
                existing.CollectionMessageId = artwork.CollectionMessageId;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Delete artwork given the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if successful - false if it cannot find the ID</returns>
        public bool Delete(int id)
        {
            var existing = db.Artworks.SingleOrDefault(x => x.Id == id);

            if(existing != null)
            {
                db.Artworks.Remove(existing);
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
