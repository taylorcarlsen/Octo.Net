using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Insert()
        {
            try
            {
                using (OctoNetDbContext dc = new OctoNetDbContext())
                {
                    tblTag tag = new tblTag();
                    tag.Id = this.Id;
                    tag.Name = this.Name;

                    dc.Tags.Add(tag);
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
                    if (this.Id != null)
                    {
                        tblTag tag = dc.Tags.FirstOrDefault(t => t.Id == this.Id);
                        if(tag != null)
                        {
                            tag.Id = this.Id;
                            tag.Name = this.Name;

                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Row was not found");
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
                        tblTag tag = dc.Tags.FirstOrDefault(t => t.Id == this.Id);
                        if(tag != null)
                        {
                            dc.Tags.Remove(tag);
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
