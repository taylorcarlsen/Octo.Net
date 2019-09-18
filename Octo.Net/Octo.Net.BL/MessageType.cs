using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class MessageType
    {

        public int Insert()
        {
            try
            {
                using (OctoNetDbContext dc = new OctoNetDbContext())
                {
                    tblMessageType messageType = new tblMessageType();
                    messageType.Id = this.Id;
                    messageType.Description = this.Description;

                    dc.MessageTypes.Add(messageType);
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
                        tblMessageType messageType = dc.MessageTypes.FirstOrDefault(m => m.Id == this.Id);
                        if(messageType != null)
                        {
                            messageType.Id = this.Id;
                            messageType.Description = this.Description;

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
                        tblMessageType messageType = dc.MessageTypes.FirstOrDefault(m => m.Id == this.Id);
                        if(messageType != null)
                        {
                            dc.MessageTypes.Remove(messageType);
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
