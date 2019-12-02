using Octo.Net.UI.Models;
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
                ugaf.Galleries = _gallery.LoadById(ugaf.User.Id);

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
                ugaf.Galleries = _gallery.LoadById(id);

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

                BL.Message blMessage = new BL.Message();
                int result = blMessage.Insert(ucf.Comment);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(ucf);
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

                UserGalleryArtworkFile ugaf = new UserGalleryArtworkFile();

                ugaf.User = (Net.Models.User)Session["user"];

                /*_gallery = new BL.Gallery();
                ugaf.Galleries = _gallery.LoadById(ugaf.User.Id);*/

                _artwork = new BL.Artwork();
                _artworks = new List<Net.Models.Artwork>();

                /*List<int> galleryIDs = new List<int>();
                foreach (Net.Models.Gallery gallery in ugaf.Galleries)
                {
                    galleryIDs.Add(gallery.Id);
                }

                foreach (int i in galleryIDs)
                {
                    _artworks.AddRange(_artwork.LoadByGalleryId(i));
                }*/

                _file = new BL.File();
                _files = new List<Net.Models.File>();

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


        [HttpPost]
        public ActionResult Edit(int id, UserGalleryArtworkFile ugaf)
        {
            try
            {
                /*Editing
                User user = _user.LoadByUsername(ugaf.User.UserName);
                user.UserName = ugaf.User.UserName;
                user.FirstName = ugaf.User.FirstName;
                user.LastName = ugaf.User.LastName;
                user.Password = ugaf.User.Password;
                user.Files = ugaf.User.Files;*/

                ugaf.User = (Net.Models.User)Session["user"];
                ugaf.User.Id = id;
                Net.Models.User user = ugaf.User;
                Net.BL.User userHelper = new BL.User();
                userHelper.Update(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(ugaf);
            }
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
                ugaf.Galleries = _gallery.LoadById(ugaf.User.Id);

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
        public ActionResult ImageUpload(Net.Models.File file,Net.Models.User user, UserGalleryArtworkFile ugaf)
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
                ugfa.Galleries = galleryHelper.LoadById(user.Id);

                return View(ugfa);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }

        public ActionResult AddToGallery(UserGalleryArtworkFile ugfa, int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                BL.Gallery galleryHelper = new BL.Gallery();
                BL.Artwork artworkHeloper = new BL.Artwork();
                ugfa.User = (Net.Models.User)Session["user"];
                Net.Models.User user = ugfa.User;
                Net.Models.Gallery gallery = new Net.Models.Gallery();
                //Get the gallery.
                gallery = galleryHelper.LoadById(user.Id).Where(g=>g.Id == id).FirstOrDefault();



                return View(ugfa); 
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }

        [HttpPost]
        public ActionResult AddToGallery(Net.Models.User user, Net.Models.Artwork artwork, Net.Models.File file, HttpPostedFileBase upload, Net.Models.Gallery gallery)
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
                            FileType = Net.Models.FileType.Photo,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            file.Content = reader.ReadBytes(upload.ContentLength);
                        }

                        user.Files = new List<Net.Models.File> { file };
                    }
                    Net.Models.Artwork newArt = new Net.Models.Artwork();
                    newArt.DateCreated = DateTime.UtcNow;
                    newArt.Title = artwork.Title;
                    newArt.GalleryId = gallery.Id;
                    newArt.Price = artwork.Price;
                    newArt.IsCommission = artwork.IsCommission;
                    BL.Artwork artworkHelper = new BL.Artwork();
                    artworkHelper.Insert(newArt, file);
                    return RedirectToAction("Profile", "Profile", new { returnurl = HttpContext.Request.Url });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction("Profile", "Profile", new { returnurl = HttpContext.Request.Url });
            }
            return RedirectToAction("Profile", "Profile", new { returnurl = HttpContext.Request.Url });
        }
    }
}