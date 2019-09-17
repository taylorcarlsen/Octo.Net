using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    class Gallery
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GalleryName { get; set; }
        public string GalleryDescription { get; set; }

        public int Insert()
        {
            try
            {
                using (OctoNetDbContext dc = new OctoNetDbContext())
                {
                    tblGallery gallery = new tblGallery();
                    gallery.Id = this.Id;
                    gallery.UserId = this.Id;
                    gallery.GalleryName = this.GalleryName;
                    gallery.GalleryDescription = this.GalleryDescription;

                    dc.Galleries.Add(gallery);
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
                        tblGallery gallery = dc.Galleries.FirstOrDefault(g => g.Id == this.Id);
                        if(gallery != null)
                        {
                            gallery.Id = this.Id;
                            gallery.UserId = this.Id;
                            gallery.GalleryName = this.GalleryName;
                            gallery.GalleryDescription = this.GalleryDescription;

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
                        tblGallery gallery = dc.Galleries.FirstOrDefault(g => g.Id == this.Id);
                        if(gallery != null)
                        {
                            dc.Galleries.Remove(gallery);
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
