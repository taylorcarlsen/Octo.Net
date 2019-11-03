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
        public ActionResult Login(string returnUrl)
        {
            ViewBag.Message = "Login";
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Net.Models.User user, string returnurl)
        {
            ViewResult result = View(user);
            try
            {
                ViewBag.ReturnUrl = returnurl;
                BL.User blUser = new BL.User();

                //ViewBag.ReturnUrl = returnUrl;
                if (blUser.Login(user.UserName, user.Password))
                {
                    BL.User useree = new BL.User();
                    user = useree.LoadByUsername(user.UserName);

                    HttpContext.Session["user"] = user;
                    //return result;
                    if (!string.IsNullOrEmpty(returnurl))
                    {
                        return Redirect(returnurl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Profile");
                    }
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

        public ActionResult Logout()
        {
            //Logged out
            HttpContext.Session["user"] = null;
            return RedirectToAction("Login", "Login");
        }

    }
}