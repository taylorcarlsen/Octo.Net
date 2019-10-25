using Octo.Net.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Octo.Net.UI.Controllers
{
    public class ProfileController : Controller
    {
        private List<Net.Models.Gallery> _galleries;
        private BL.Gallery _gallery;

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
                    _gallery = new BL.Gallery();
                _galleries = new List<Net.Models.Gallery>();
                _galleries = _gallery.LoadById(id);
                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Galleries";
                }
                return View(_galleries);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }
    }
}