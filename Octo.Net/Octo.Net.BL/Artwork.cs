using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octo.Net.Data1;

namespace Octo.Net.BL
{
    public class Artwork
    {

        public int Insert()
        {
            try
            {
                using(OctoNetDbContext dc = new OctoNetDbContext())
                {
                    tblArtwork artwork = new tblArtwork();
                    artwork.Id = this.Id;
                    artwork.GalleryId = this.GalleryId;
                    artwork.Title = this.Title;
                    artwork.Price = this.Price;
                    artwork.IsCommission = this.IsCommission;

                    dc.Artworks.Add(artwork);
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update()
        {
            try
            {
                using (OctoNetDbContext dc = new OctoNetDbContext())
                {
                    if(this.Id != null)
                    {
                        tblArtwork artwork = dc.Artworks.FirstOrDefault(a => a.Id == this.Id);

                        if(artwork != null)
                        {
                            artwork.Id = this.Id;
                            artwork.GalleryId = this.GalleryId;
                            artwork.Title = this.Title;
                            artwork.Price = this.Price;
                            artwork.IsCommission = this.IsCommission;

                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    }
                    else
                    {
                        throw new Exception("Id was not set.");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Delete()
        {
            try
            {
                using (OctoNetDbContext dc = new OctoNetDbContext())
                {
                    if(this.Id != null)
                    {
                        tblArtwork artwork = dc.Artworks.FirstOrDefault(a => a.Id == this.Id);

                        if(artwork != null)
                        {
                            dc.Artworks.Remove(artwork);
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    }
                    else
                    {
                        throw new Exception("Id was not set.");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
