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
        //
        // GET: /User/

        public ActionResult Index()
        {
            ViewBag.AadhaarNo = "11";
            string AadhaarNo = ViewBag.AadhaarNo;
            DataContext dataContext = new DataContext();
            User user = dataContext.UserDetails.Single(x => x.AadhaarNo == AadhaarNo);

            return View(user);
        }

    }
}
