using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public DateTime DateTime { get; set; }
        public int CritiqueId { get; set; }
        public int Rating { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int Insert()
        {
            try
            {
                using (OctoNetDbContext dc = new OctoNetDbContext())
                {
                    tblMessage message = new tblMessage();
                    message.Id = this.Id;
                    message.UserId = this.UserId;
                    message.Body = this.Body;
                    message.DateTime = this.DateTime;
                    message.CritiqueId = this.CritiqueId;
                    message.Rating = this.Rating;
                    message.X = this.X;
                    message.Y = this.Y;

                    dc.Messages.Add(message);
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
                        tblMessage message = dc.Messages.FirstOrDefault(m => m.Id == this.Id);
                        if(message != null)
                        {
                            message.Id = this.Id;
                            message.UserId = this.UserId;
                            message.Body = this.Body;
                            message.DateTime = this.DateTime;
                            message.CritiqueId = this.CritiqueId;
                            message.Rating = this.Rating;
                            message.X = this.X;
                            message.Y = this.Y;

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
                        tblMessage message = dc.Messages.FirstOrDefault(m => m.Id == this.Id);
                        if(message != null)
                        {
                            dc.Messages.Remove(message);
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
