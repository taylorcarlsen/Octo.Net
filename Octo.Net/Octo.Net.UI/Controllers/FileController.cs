using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Octo.Net.UI.Controllers
{
    public class FileController : Controller
    {
        private readonly Octo.Net.BL.File fileContext = new BL.File();
       
        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrive = fileContext.LoadByArtworkId(id);
            return File(fileToRetrive.Content, fileToRetrive.ContentType);
        }
    }
}