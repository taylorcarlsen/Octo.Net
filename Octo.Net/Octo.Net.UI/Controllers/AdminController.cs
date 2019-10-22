using Octo.Net.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Octo.Net.UI.Controllers
{
    public class AdminController : Controller
    {
        private List<Net.Models.User> _users;
        private BL.User _user;

        // GET: Admin
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Admin";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }

        public ActionResult Users()
        {
            if (Authenticate.IsAuthenticated())
            {
                _user = new BL.User();
                _users = new List<Net.Models.User>();
                _users = _user.Load();
                if (ViewBag.Message == null)
                {
                    ViewBag.Message = "Users";
                }
                return View(_users);
            }
            else
            {
                return RedirectToAction("Login", "Login", new { returnurl = HttpContext.Request.Url });
            }
        }
    }
}