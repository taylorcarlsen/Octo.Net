using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Octo.Net.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult Login(string returnUrl)
        {
            ViewBag.Message = "Login";
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        public ActionResult Login(Net.Models.User user, string returnUrl)
        {
            ViewResult result = View(user);
            try
            {
                BL.User blUser = new BL.User();

                ViewBag.ReturnUrl = returnUrl;
                if (blUser.Login(user.UserName, user.Password))
                {
                    HttpContext.Session["user"] = user;
                    return Redirect(returnUrl);
                }
                ViewBag.Message = "Login Failed";

                return result;
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View(user);
            }
        }
    }
}