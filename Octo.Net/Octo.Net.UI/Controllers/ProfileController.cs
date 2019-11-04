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
        public ActionResult Edit(int id)
        {
            if (Authenticate.IsAuthenticated())
            {
                BL.User user = new BL.User();
                var loadedUser = user.Load().Where(u => u.Id == id).FirstOrDefault();
                return View(loadedUser);
            }
            return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
        }
        #endregion
    }
}