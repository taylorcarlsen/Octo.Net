﻿using Octo.Net.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Octo.Net.UI.ViewModels;
using Octo.Net.BL;
using Octo.Net.Models;

namespace Octo.Net.UI.Controllers
{
    public class ProfileController : Controller
    {
        private List<Net.Models.Artwork> _artworks;
        private List<Net.Models.File> _files;
        private List<Net.Models.Message> _messages;
        private BL.Gallery _gallery;
        private BL.Artwork _artwork;
        private BL.File _file;
        private BL.Message _message;
        private BL.Message _comment;
        BL.User _user;
        Net.Models.User _mUser;

        #region Index
        // GET: Profile
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Profile";
                }

                UserGalleryArtworkFile ugaf = new UserGalleryArtworkFile();

                ugaf.User = (Octo.Net.Models.User)Session["user"];

                _gallery = new BL.Gallery();
                ugaf.Galleries = _gallery.LoadByUserId(ugaf.User.Id);

                _artwork = new BL.Artwork();
                _artworks = new List<Net.Models.Artwork>();

                _file = new BL.File();
                _files = new List<Net.Models.File>();

                List<int> galleryIDs = new List<int>();
                foreach (Net.Models.Gallery gallery in ugaf.Galleries)
                {
                    galleryIDs.Add(gallery.Id);
                }

                foreach (int id in galleryIDs)
                {
                    _files.AddRange(_file.LoadByUserGalleryId(ugaf.User.Id, id));
                }

                // Add avatar
                _files.AddRange(_file.LoadByUserFileTypeId(ugaf.User.Id, Net.Models.FileType.Avatar));

                ugaf.Files = _files;

                foreach (Net.Models.File file in _files)
                {
                    _artworks.Add(file.Artwork);
                }

                ugaf.Artworks = _artworks;

                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Galleries";
                }
                return View(ugaf);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }
        #endregion

        #region Galleries
        // GET: Gallery
        public ActionResult Galleries(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                UserGalleryArtworkFile ugaf = new UserGalleryArtworkFile();

                _gallery = new BL.Gallery();
                ugaf.Galleries = _gallery.LoadByUserId(id);

                _artwork = new BL.Artwork();
                _artworks = new List<Net.Models.Artwork>();

                _file = new BL.File();
                _files = new List<Net.Models.File>();

                List<int> galleryIDs = new List<int>();
                foreach (Net.Models.Gallery gallery in ugaf.Galleries)
                {
                    galleryIDs.Add(gallery.Id);
                }

                foreach (int galleryId in galleryIDs)
                {
                    _files.AddRange(_file.LoadByUserGalleryId(id, galleryId));
                }

                ugaf.Files = _files;

                foreach (Net.Models.File file in _files)
                {
                    _artworks.Add(file.Artwork);
                }

                ugaf.Artworks = _artworks;

                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Galleries";
                }
                return View(ugaf);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }
        #endregion

        #region Artwork
        public ActionResult Artwork(int id)
        {

            if (Authenticate.IsAuthenticated())
            {
                UserMessageCommentFile ucf = new UserMessageCommentFile();

                ucf.User = (Octo.Net.Models.User)Session["user"];

                _file = new BL.File();
                ucf.File = _file.LoadByArtworkId(id);

                _message = new BL.Message();

                ucf.Messages = _message.LoadByCollection(ucf.File.Artwork.CollectionMessageId);

                return View(ucf);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }

        }

        [HttpPost]
        public ActionResult Artwork(UserMessageCommentFile ucf)
        {
            try
            {
                ucf.User = (Octo.Net.Models.User)Session["user"];
                BL.Message blMessage = new BL.Message();
                ucf.Comment.CollectionId = ucf.File.Artwork.CollectionMessageId;
                ucf.Comment.FromUserId = ucf.User.Id;
                ucf.Comment.ToUserId = ucf.File.UserId;
                ucf.Comment.FromUserId = ucf.User.Id;
                /*
                ucf.Comment.CritiqueId = 1;
                ucf.Comment.X = 1;
                ucf.Comment.Y = 2;
                */
                blMessage.Insert(ucf.Comment);
                //return View(ucf);
                return Redirect(Request.UrlReferrer.ToString());

            }
            catch
            {
                System.Diagnostics.Debug.WriteLine(ucf);
                return View();
            }
        }

        

        #endregion

        #region Profile Edit


        public ActionResult Edit()
        {
            if (Authenticate.IsAuthenticated())
            {
                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Profile";
                }

                BL.User userManager;
                Net.Models.User user;
                UserGalleryArtworkFile ugaf = new UserGalleryArtworkFile();

                ugaf.User = (Net.Models.User)Session["user"];

                using (userManager = new BL.User())
                {
                    user = userManager.LoadByUsername(ugaf.User.UserName);
                }

                if (user == null)
                    return HttpNotFound();

                /*_file = new BL.File();
                _files = new List<Net.Models.File>();

                ugaf.Files = _file.LoadByUserId(ugaf.User.Id);

                foreach(var file in ugaf.Files)
                {
                    if(file.FileType == FileType.Avatar)
                    {
                        ugaf.Files.Add(file);
                    }
                }*/

                // Update avatar
                /*_files.AddRange(_file.LoadByUserFileTypeId(ugaf.User.Id, FileType.Avatar));

                ugaf.Files = _files;

                foreach (Net.Models.File file in _files)
                {
                    _artworks.Add(file.Artwork);
                }*/

                return View(ugaf);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }


        [HttpPost]
        public ActionResult Edit(UserGalleryArtworkFile ugaf, Net.Models.File file, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                ugaf.User = (Net.Models.User)Session["user"];
                Net.Models.User user = ugaf.User;
                BL.User userHelper = new BL.User();

                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        file = new Net.Models.File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            file.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        user.Files = new List<Net.Models.File> { file };
                    }
                    userHelper.Update(user, file);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(ugaf);
                }
            }
                return View();
        }
        #endregion

        #region Upload Image Area

        public ActionResult ImageUpload()
        {
            if (Authenticate.IsAuthenticated())
            {
                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Profile";
                }

                UserGalleryArtworkFile ugaf = new UserGalleryArtworkFile();

                ugaf.User = (Net.Models.User)Session["user"];

                _gallery = new BL.Gallery();
                ugaf.Galleries = _gallery.LoadByUserId(ugaf.User.Id);

                _artwork = new BL.Artwork();
                _artworks = new List<Net.Models.Artwork>();

                List<int> galleryIDs = new List<int>();
                foreach (Net.Models.Gallery gallery in ugaf.Galleries)
                {
                    galleryIDs.Add(gallery.Id);
                }

                foreach (int i in galleryIDs)
                {
                    _artworks.AddRange(_artwork.LoadByGalleryId(i));
                }

                ugaf.Artworks = _artworks;

                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Galleries";
                }
                return View(ugaf);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }

        [HttpPost]
        public ActionResult ImageUpload(Net.Models.File file, Net.Models.User user, UserGalleryArtworkFile ugaf)
        {
            try
            {
                ugaf.User = (Net.Models.User)Session["user"];
                user = ugaf.User;
                user.Files.Add(file);
                BL.File fileHelper = new BL.File();
                file.UserId = user.Id;
                file.FileName = user.UserName + "-Avatar";
                fileHelper.Insert(file);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(ugaf);
            }
        }

        #endregion

        public ActionResult GalleryAdd(UserGalleryArtworkFile ugfa)
        {
            if (Authenticate.IsAuthenticated())
            {
                try
                {
                    ugfa.User = (Net.Models.User)Session["user"];
                    Net.Models.User user = ugfa.User;
                    return View(ugfa);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }
        [HttpPost]
        public ActionResult GalleryAdd(UserGalleryArtworkFile ugfa, Net.Models.Gallery gallery)
        {
            try
            {
                ugfa.User = (Net.Models.User)Session["user"];
                Net.Models.User user = ugfa.User;
                BL.Gallery galleryHelper = new BL.Gallery();
                Net.Models.Gallery newGallery = new Net.Models.Gallery();
                newGallery.UserId = ugfa.User.Id;
                newGallery.GalleryDescription = gallery.GalleryDescription;
                newGallery.GalleryName = gallery.GalleryName;
                newGallery.DateCreated = DateTime.UtcNow;
                galleryHelper.Insert(newGallery);
                return View(ugfa);
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult AddArtwork(UserGalleryArtworkFile ugfa)
        {
            if (Authenticate.IsAuthenticated())
            {
                BL.Gallery galleryHelper = new BL.Gallery();


                ugfa.User = (Net.Models.User)Session["user"];
                Net.Models.User user = ugfa.User;
                ugfa.Galleries = galleryHelper.LoadByUserId(user.Id);

                return View(ugfa);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }

        public ActionResult AddToGallery(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                UserGalleryArtworkFile ugaf = new UserGalleryArtworkFile();

                ugaf.User = (Octo.Net.Models.User)Session["user"];
                _gallery = new BL.Gallery();
                System.Diagnostics.Debug.WriteLine(id);
                //ugaf.Galleries.Add(_gallery.LoadById(id));

                return View(ugaf); 
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }

        [HttpPost]
        public ActionResult AddToGallery(UserGalleryArtworkFile ugfa, Net.Models.File file, HttpPostedFileBase upload, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        file = new Net.Models.File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = Net.Models.FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            file.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        ugfa.User.Files = new List<Net.Models.File> { file };
                    }
                    ugfa.Artworks[0].DateCreated = DateTime.UtcNow;
                    ugfa.Artworks[0].GalleryId = id;

                    System.Diagnostics.Debug.WriteLine(ugfa.Artworks[0].Title);
                    System.Diagnostics.Debug.WriteLine(ugfa.Files[0].FileName);

                    BL.Artwork artworkHelper = new BL.Artwork();
                    artworkHelper.Insert(ugfa.Artworks[0], ugfa.Files[0]);

                    return RedirectToAction("Index");
                }
                else {
                    return View(ugfa);
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(ugfa);
            }
        }
    }
}