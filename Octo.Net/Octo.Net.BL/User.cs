using Octo.Net.Data1;
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
            try
            {
                using (var transactionContext = db.Database.BeginTransaction())
                {
                    tblUser newUser = new tblUser
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        JoinDate = DateTime.Now,
                        UserName = user.UserName,
                        CommissionActive = user.CommissionActive,
                        Password = GetHash(user.Password)
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    tblArtwork newArtwork = new tblArtwork
                    {
                        //GalleryId = newArtwork.GalleryId,
                        Title = file.FileName,
                        Price = 0,
                        IsCommission = false,
                        DateCreated = DateTime.Now
                    };

                    db.Artworks.Add(newArtwork);
                    db.SaveChanges();


                    tblFiles newFile = new tblFiles()
                    {
                        FileName = file.FileName,
                        ContentType = file.ContentType,
                        Content = file.Content,
                        UserId = newUser.Id,
                        User = newUser,
                        FileType = (Net.Data1.tblFileType)file.FileType,
                        ArtworkId = newArtwork.Id,
                        Artwork = newArtwork
                    };

                    db.Files.Add(newFile);

                    db.SaveChanges();

                    transactionContext.Commit();
                    return newUser.Id;
                }
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException;
                throw;
            }


        }
        public void Update(Models.User user, Models.File file)
        {
            var existing = db.Users.SingleOrDefault(x => x.Id == user.Id);

            if (existing != null)
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

            File blFile = new File();
            user.Files = blFile.LoadByUserId(user.Id);

            Models.File singleFile = new Models.File();

            foreach (var f in user.Files)
            {
                if (f.FileType == Models.FileType.Avatar)
                {

                    var existingFile = db.Files.SingleOrDefault(x => x.Id == f.Id);
                    if (existingFile != null)
                    {
                        existingFile.FileName = file.FileName;
                        existingFile.Content = file.Content;
                        existingFile.ContentType = file.ContentType;
                        existingFile.UserId = file.UserId;
                        existingFile.ArtworkId = file.ArtworkId;

                        db.SaveChanges();
                    }
                }
            }
        }
        public bool Delete(int id)
        {
            var existing = db.Users.SingleOrDefault(x => x.Id == id);
            if (existing != null)
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
            if (user != null)
            {
                BL.File file = new BL.File();
                Models.User u = new Models.User
                {
                    Id = user.Id,
                    CommissionActive = user.CommissionActive ?? true,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    JoinDate = user.JoinDate ?? DateTime.Now,
                    LastName = user.LastName,
                    Password = user.Password,
                    UserName = user.UserName,
                    Files = file.LoadByUserId(user.Id)
                };

                return u;
            }
            else { return null; }
        }

        public Models.User LoadById(int id)
        {
            var user = db.Users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                BL.File file = new BL.File();
                Models.User u = new Models.User
                {
                    Id = user.Id,
                    CommissionActive = user.CommissionActive ?? true,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    JoinDate = user.JoinDate ?? DateTime.Now,
                    LastName = user.LastName,
                    Password = user.Password,
                    UserName = user.UserName,
                    Files = file.LoadByUserId(user.Id)
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
                        else { return false; }
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}
