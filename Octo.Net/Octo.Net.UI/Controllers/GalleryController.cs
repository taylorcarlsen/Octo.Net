using Octo.Net.BL;
using Octo.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Octo.Net.UI.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Load(int id)
        {
            return View();
        }
    }
}