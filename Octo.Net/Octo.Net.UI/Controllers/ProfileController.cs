using Octo.Net.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Octo.Net.UI.ViewModels;

namespace Octo.Net.UI.Controllers
{
    public class ProfileController : Controller
    {
        private List<Net.Models.Artwork> _artworks;
        private BL.Gallery _gallery;
        private BL.Artwork _artwork;

        // GET: Profile
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Profile";
                }

                UserGalleryArtwork uga = new UserGalleryArtwork();

                uga.User = (Octo.Net.Models.User)Session["user"];

                _gallery = new BL.Gallery();
                uga.Galleries = _gallery.LoadById(uga.User.Id);

                _artwork = new BL.Artwork();
                _artworks = new List<Net.Models.Artwork>();

                List<int> galleryIDs = new List<int>();
                foreach (Net.Models.Gallery gallery in uga.Galleries)
                {
                    galleryIDs.Add(gallery.Id);
                }

                foreach (int i in galleryIDs)
                {
                    _artworks.AddRange(_artwork.LoadByGalleryId(i));
                }

                uga.Artworks = _artworks;

                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Galleries";
                }
                return View(uga);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }

        // GET: Gallery
        public ActionResult Galleries(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                UserGalleryArtwork uga = new UserGalleryArtwork();

                _gallery = new BL.Gallery();
                uga.Galleries = _gallery.LoadById(id);

                _artwork = new BL.Artwork();
                _artworks = new List<Net.Models.Artwork>();

                List<int> galleryIDs = new List<int>();
                foreach (Net.Models.Gallery gallery in uga.Galleries)
                {
                    galleryIDs.Add(gallery.Id);
                }

                foreach (int i in galleryIDs)
                {
                    _artworks.AddRange(_artwork.LoadByGalleryId(i));
                }

                uga.Artworks = _artworks;

                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Galleries";
                }
                return View(uga);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }

        public ActionResult Artwork(int id)
        {
            Net.Models.Artwork artwork = new Net.Models.Artwork();
            artwork = _artwork.LoadById(id);

            return View();
        }


        #region Profile Edit
        public ActionResult Edit()
        {
            if (Authenticate.IsAuthenticated())
            {
                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Profile";
                }

                UserGalleryArtwork uga = new UserGalleryArtwork();

                uga.User = (Net.Models.User)Session["user"];

                _gallery = new BL.Gallery();
                uga.Galleries = _gallery.LoadById(uga.User.Id);

                _artwork = new BL.Artwork();
                _artworks = new List<Net.Models.Artwork>();

                List<int> galleryIDs = new List<int>();
                foreach (Net.Models.Gallery gallery in uga.Galleries)
                {
                    galleryIDs.Add(gallery.Id);
                }

                foreach (int i in galleryIDs)
                {
                    _artworks.AddRange(_artwork.LoadByGalleryId(i));
                }

                uga.Artworks = _artworks;

                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Galleries";
                }
                return View(uga);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }


        [HttpPost]
        public ActionResult Edit(int id, UserGalleryArtwork uga)
        {
            try
            {
                uga.User = (Net.Models.User)Session["user"];
                uga.User.Id = id;
                Net.Models.User user = uga.User;
                Net.BL.User userHelper = new BL.User();
                userHelper.Update(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(uga);
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

                UserGalleryArtwork uga = new UserGalleryArtwork();

                uga.User = (Net.Models.User)Session["user"];

                _gallery = new BL.Gallery();
                uga.Galleries = _gallery.LoadById(uga.User.Id);

                _artwork = new BL.Artwork();
                _artworks = new List<Net.Models.Artwork>();

                List<int> galleryIDs = new List<int>();
                foreach (Net.Models.Gallery gallery in uga.Galleries)
                {
                    galleryIDs.Add(gallery.Id);
                }

                foreach (int i in galleryIDs)
                {
                    _artworks.AddRange(_artwork.LoadByGalleryId(i));
                }

                uga.Artworks = _artworks;

                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Galleries";
                }
                return View(uga);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }

        [HttpPost]
        public ActionResult ImageUpload(Net.Models.File file,Net.Models.User user, UserGalleryArtwork uga)
        {
            try
            {
                uga.User = (Net.Models.User)Session["user"];
                user = uga.User;
                user.Files.Add(file);
                BL.File fileHelper = new BL.File();
                file.UserId = user.Id;
                file.FileName = user.UserName + "-Avatar";
                fileHelper.Insert(file);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(uga);
            }
        }

        #endregion

    }
}