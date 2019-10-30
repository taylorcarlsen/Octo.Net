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
        private List<Net.Models.Gallery> _galleries;
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
                return View();
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
                GalleryArtwork ga = new GalleryArtwork();

                _gallery = new BL.Gallery();
                ga.Galleries = _gallery.LoadById(id);

                _artwork = new BL.Artwork();
                _artworks = new List<Net.Models.Artwork>();

                List<int> galleryIDs = new List<int>();
                foreach (Net.Models.Gallery gallery in ga.Galleries)
                {
                    galleryIDs.Add(gallery.Id);
                }

                foreach (int i in galleryIDs)
                {
                    _artworks.AddRange(_artwork.LoadByGalleryId(i));
                }

                ga.Artworks = _artworks;

                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Galleries";
                }
                return View(ga);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }
    }
}