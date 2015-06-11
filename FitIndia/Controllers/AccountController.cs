using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitIndia.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Create", "AadhaarLogin");
        }

    }
}
