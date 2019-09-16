using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octo.Net.Data1;

namespace Octo.Net.BL
{
    public class Critique
    {
        public int Id { get; set; }
        public string CategoryDescription { get; set; }

        public int Insert()
        {
            try
            {
                using (OctoNetDbContext dc = new OctoNetDbContext())
                {
                    tblCritique critique = new tblCritique();
                    critique.Id = this.Id;
                    critique.CategoryDescription = this.CategoryDescription;

                    dc.Critiques.Add(critique);
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
                        tblCritique critique = dc.Critiques.FirstOrDefault(c => c.Id == this.Id);
                        if(critique != null)
                        {
                            critique.Id = this.Id;
                            critique.CategoryDescription = this.CategoryDescription;

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
                        tblCritique critique = dc.Critiques.FirstOrDefault(c => c.Id == this.Id);
                        if(critique != null)
                        {
                            dc.Critiques.Remove(critique);
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
