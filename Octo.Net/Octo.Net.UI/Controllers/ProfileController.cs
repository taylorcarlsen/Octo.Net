using Octo.Net.BL;
using Octo.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Octo.Net.UI.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        // GET: Gallery
        public ActionResult Galleries(int id)
        {
            BL.Gallery _gallery = new BL.Gallery();
            _gallery.Load(id);
            return PartialView(_gallery);
        }
    }
}