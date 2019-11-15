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
        private List<Net.Models.File> _files;
        private BL.Gallery _gallery;
        private BL.Artwork _artwork;
        private BL.File _file;

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
        public ActionResult Edit(int id, UserGalleryArtworkFile ugaf)
        {
            try
            {
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

    }
}