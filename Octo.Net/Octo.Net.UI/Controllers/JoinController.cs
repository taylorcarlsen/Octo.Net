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
        public ActionResult Create(Octo.Net.Models.User user, Net.Models.File file)
        {
            try
            {
                // TODO: Add insert logic here
                User blUser = new User();
                blUser.Insert(user, file);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }

    }
}