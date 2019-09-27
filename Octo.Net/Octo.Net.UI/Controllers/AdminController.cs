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
            return View();
        }

        public ActionResult Users()
        {
            _user = new BL.User();
            _users = new List<Net.Models.User>();
            _users = _user.Load();
            return View(_users);
        }
    }
}