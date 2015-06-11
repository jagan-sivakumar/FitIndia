using FitIndia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitIndia.Controllers
{
    public class UserController : Controller
    {
        // GET: /User/

        public ActionResult Index()
        {
            string AadhaarNo = Session["aadhaarNo"] as String;
            if (AadhaarNo != null)
            {
                DataContext dataContext = new DataContext();
                User user = dataContext.UserDetails.Single(x => x.AadhaarNo == AadhaarNo);
                return View(user);
            }
            else
            {
                return RedirectToAction("Create", "AadhaarLogin");
            }      
        }

    }
}
