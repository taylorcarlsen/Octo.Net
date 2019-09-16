using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octo.Net.Data1;

namespace Octo.Net.BL
{
    public class Collection
    {
        public int Id { get; set; }
        public int MessageTypeId { get; set; }

        public int Insert()
        {
            try
            {
                using (OctoNetDbContext dc = new OctoNetDbContext())
                {
                    tblCollection collection = new Collection();
                    collection.Id = this.Id;
                    collection.MessageTypeId = this.Id;

                    dc.Collections.Add(collection);
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
                        tblCollection collection = dc.Collections.FirstOrDefault(c => c.Id == this.Id);
                        
                        if(collection != null)
                        {
                            collection.Id = this.Id;
                            collection.MessageTypeId = this.Id;

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
                        tblCollection collection = dc.Collections.FirstOrDefault(c => c.Id == this.Id);
                        if(collection != null)
                        {
                            dc.Collections.Remove(collection);
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
