using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMusic.Web.Controllers
{
    public class ExitController : Controller
    {
        // GET: Exit
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClearCookies()
        {
            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("UserHome", "User");
        }
    }
}