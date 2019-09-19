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
        private readonly OctoNetDbContext db;

        public User()
        {
            db = new OctoNetDbContext();
        }
        ~User()
        {
            db.Dispose();
        }
        public int Insert(Models.User user)
        {
            tblUser newUser = new tblUser { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email,
                JoinDate = user.JoinDate, UserName = user.UserName, CommissionActive = user.CommissionActive, Password = user.Password };
            db.Users.Add(newUser);

            db.SaveChanges();
            return newUser.Id;
        }
        public void Update(Models.User user)
        {
            var existing = db.Users.SingleOrDefault(x => x.Id == user.Id);
            
            if(existing != null)
            {
                existing.FirstName = user.FirstName;
                existing.LastName = user.LastName;
                existing.Email = user.Email;
                existing.JoinDate = user.JoinDate;
                existing.UserName = user.UserName;
                existing.CommissionActive = user.CommissionActive;
                existing.Password = user.Password;

                db.SaveChanges();
            }
        }
        public bool Delete(int id)
        {
            var existing = db.Users.SingleOrDefault(x => x.Id == id);
            if(existing != null)
            {
                db.Users.Remove(existing);
                db.SaveChanges();
                return true;
            }
            else { return false; }
        }
    }
}
