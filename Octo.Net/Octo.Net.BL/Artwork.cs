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
                    CollectionMessageId = a.CollectionMessageId.GetValueOrDefault(),
                    DateCreated = a.DateCreated
                }));

            return artworks;
        }

        public List<Models.Artwork> LoadByGalleryId(int id)
        {
            List<Models.Artwork> artworks = new List<Models.Artwork>();
            db.Artworks.Where(a => a.GalleryId == id)
                .ToList()
                .ForEach(a => artworks
            .Add(new Models.Artwork
            {
                Id = a.Id,
                GalleryId = a.GalleryId.GetValueOrDefault(),
                Title = a.Title,
                Price = a.Price.GetValueOrDefault(),
                IsCommission = a.IsCommission.GetValueOrDefault(),
                TagId = a.TagId.GetValueOrDefault(),
                CollectionMessageId = a.CollectionMessageId.GetValueOrDefault(),
                DateCreated = a.DateCreated
            }));
            return artworks;
        }
        public Models.Artwork LoadById(int id)
        {
            var artwork = db.Artworks.FirstOrDefault(a => a.Id == id);
            if (artwork != null)
            {
                Models.Artwork a = new Models.Artwork
                {
                    Id = artwork.Id,
                    GalleryId = artwork.GalleryId.GetValueOrDefault(),
                    Title = artwork.Title,
                    Price = artwork.Price.GetValueOrDefault(),
                    IsCommission = artwork.IsCommission.GetValueOrDefault(),
                    TagId = artwork.TagId.GetValueOrDefault(),
                    CollectionMessageId = artwork.CollectionMessageId.GetValueOrDefault(),
                    DateCreated = artwork.DateCreated
                };
                return a;
            }
            else { return null; }
        }


        public int Insert(Models.Artwork artwork, Models.File file)
        {
            tblCollection newCollection = new tblCollection { 
                MessageTypeId = 3
            };

            db.Collections.Add(newCollection);
            db.SaveChanges();

            tblArtwork tblArtwork = new tblArtwork {
                GalleryId = artwork.GalleryId,
                Title = artwork.Title,
                Price = artwork.Price,
                IsCommission = artwork.IsCommission,
                TagId = artwork.TagId,
                CollectionMessageId = newCollection.Id,
                DateCreated = DateTime.Now
            };

            db.Artworks.Add(tblArtwork);
            db.SaveChanges();

            tblFiles tblFiles = new tblFiles
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                Content = file.Content,
                FileType = tblFileType.Photo,
                ArtworkId = artwork.Id,
                UserId = file.UserId,
                Artwork = tblArtwork
            };

            db.Files.Add(tblFiles);
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
                existing.DateCreated = artwork.DateCreated;
                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            BL.Artwork artwork = new BL.Artwork();
            Net.Models.Artwork _artwork = new Net.Models.Artwork();
            Net.Models.Message _message = new Net.Models.Message();

            _artwork = artwork.LoadById(id);

            var existArt = db.Artworks.SingleOrDefault(x => x.Id == id);
            var existFile = db.Files.SingleOrDefault(f => f.ArtworkId == id);
            var existCol = db.Collections.SingleOrDefault(f => f.Id == _artwork.CollectionMessageId);
            var existMsg = db.Messages.Where(a => a.CollectionId == _artwork.CollectionMessageId).ToList();

            if (existArt != null || existFile != null || existCol != null)
            {
                db.Artworks.Remove(existArt);
                db.Files.Remove(existFile);
                db.Collections.Remove(existCol);
                existMsg.ForEach(x => db.Messages.Remove(x));
                db.SaveChanges();
                return true;
            }
            else {
                return false;
            }
        }
    }
}
