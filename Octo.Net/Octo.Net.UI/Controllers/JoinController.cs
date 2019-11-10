using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Octo.Net.BL;

namespace Octo.Net.UI.Controllers
{
    public class JoinController : Controller
    {
        // GET: Join
        public ActionResult Index()
        {
            Net.Models.User user = new Net.Models.User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(Net.Models.User user, Net.Models.File file)
        {
            try
            {
                BL.User bluser = new BL.User();
                bluser.Insert(user, file);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View(user);   
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            Octo.Net.Models.User user = new Octo.Net.Models.User();
            return View(user);
        }

        // POST: BL.User/Create
        [HttpPost]
        public ActionResult Create(Octo.Net.Models.User user, Net.Models.File file, HttpPostedFileBase upload)
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
                            FileType = Net.Models.FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using(var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            file.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        user.Files = new List<Net.Models.File> { file };
                    }
                    User blUser = new User();
                    blUser.Insert(user, file);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

    }
}