using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class User
    {

        public int Insert()
        {
            try
            {
                using (OctoNetDbContext dc = new OctoNetDbContext())
                {
                    tblUser user = new tblUser();
                    user.Id = this.Id;
                    user.FirstName = this.FirstName;
                    user.LastName = this.LastName;
                    user.Email = this.Email;
                    user.Password = this.Password;
                    user.UserName = this.UserName;
                    user.JoinDate = this.JoinDate;
                    user.CommissionActive = this.CommissionActive;

                    dc.Users.Add(user);
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
                        tblUser user = dc.Users.FirstOrDefault(u => u.Id == this.Id);
                        if(user != null)
                        {
                            user.Id = this.Id;
                            user.FirstName = this.FirstName;
                            user.LastName = this.LastName;
                            user.Email = this.Email;
                            user.Password = this.Password;
                            user.UserName = this.UserName;
                            user.JoinDate = this.JoinDate;
                            user.CommissionActive = this.CommissionActive;

                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    }
                    else
                    {
                        throw new Exception ("Id was not set.");
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
                        tblUser user = dc.Users.FirstOrDefault(u => u.Id == this.Id);
                        if(user != null)
                        {
                            dc.Users.Remove(user);
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
