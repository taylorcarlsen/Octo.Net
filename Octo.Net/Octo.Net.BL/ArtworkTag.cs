using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class ArtworkTag
    {

        public int Insert()
        {
            try
            {
                using (OctoNetDbContext dc = new OctoNetDbContext())
                {
                    tblArtworkTag artworktag = new tblArtworkTag();
                    artworktag.Id = this.Id;
                    artworktag.ArtworkId = this.ArtworkId;
                    artworktag.TagId = this.TagId;

                    dc.ArtworkTags.Add(artworktag);
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
                        tblArtworkTag artworkTag = dc.ArtworkTags.FirstOrDefault(a => a.Id == this.Id);
                        if(artworkTag != null)
                        {
                            artworkTag.Id = this.Id;
                            artworkTag.TagId = this.TagId;
                            artworkTag.ArtworkId = this.ArtworkId;

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
                        tblArtworkTag artworkTag = dc.ArtworkTags.FirstOrDefault(a => a.Id == this.Id);
                        if(artworkTag != null)
                        {
                            dc.ArtworkTags.Remove(artworkTag);
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
