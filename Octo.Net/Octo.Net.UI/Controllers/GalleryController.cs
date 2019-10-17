using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Octo.Net.BL;

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
            //Net.Models.Gallery galleries = new List<Models.Gallery>;
            //galleries.Load();



            return View();
        }
    }
}