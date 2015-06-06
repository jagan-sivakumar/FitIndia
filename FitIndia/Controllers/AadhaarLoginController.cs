using FitIndia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitIndia.Controllers
{
    public class AadhaarLoginController : Controller
    {
        
        // GET: /AadhaarLogin/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            AadhaarLogin aadhaarlogin = new AadhaarLogin();
            TryUpdateModel(aadhaarlogin);
            if (ModelState.IsValid)
            {
                ViewBag.AadhaarNo = "11";
                return RedirectToAction("Index","User");
            }
            else
            {
                return View();
            }
        }

    }
}
