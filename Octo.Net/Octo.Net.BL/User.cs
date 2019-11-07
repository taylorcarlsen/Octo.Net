﻿using Octo.Net.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.Net.BL
{
    public class User : IDisposable
    {
        private readonly OctoNetDbContext db;

        public User()
        {
            db = new OctoNetDbContext();
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public List<Models.User> Load()
        {
            List<Models.User> users = new List<Models.User>();
            db.Users.ToList().ForEach(u => users
            .Add(new Models.User
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                UserName = u.UserName,
                JoinDate = u.JoinDate ?? DateTime.Now,
                CommissionActive = u.CommissionActive ?? true,
                Password = u.Password
            }));

            return users;

        }



        public int Insert(Models.User user, Models.File file)
        {
            tblUser newUser = new tblUser { 
                FirstName = user.FirstName, 
                LastName = user.LastName, 
                Email = user.Email,
                JoinDate = DateTime.Now, 
                UserName = user.UserName, 
                CommissionActive = user.CommissionActive, 
                Password = GetHash(user.Password)
            };

            db.Users.Add(newUser);

            tblFiles newFile = new tblFiles()
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                Content = file.Content,
                UserId = newUser.Id
            };

            db.Files.Add(newFile);

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

        private string GetHash(string password)
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        public Models.User LoadByUsername(string userName)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == userName);
            if(user != null)
            {
                Models.User u = new Models.User
                {
                    Id = user.Id,
                    CommissionActive = user.CommissionActive ?? true,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    JoinDate = user.JoinDate ?? DateTime.Now,
                    LastName = user.LastName,
                    Password = user.Password,
                    UserName = user.UserName
                };
                return u;
            }
            else { return null; }
        }

        public bool Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                if (!string.IsNullOrEmpty(password))
                {
                    tblUser user = db.Users.FirstOrDefault(u => u.UserName == userName);
                    if (user != null)
                    {
                        if (user.Password == this.GetHash(password))
                        {
                            userName = user.UserName;
                            return true;
                        }
                        else {return false; }
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}
