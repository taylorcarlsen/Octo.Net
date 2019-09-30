using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index(Net.Models.User user)
        {
            try
            {
                BL.User bluser = new BL.User();
                bluser.Insert(user);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View(user);   
            }
        }

    }
}