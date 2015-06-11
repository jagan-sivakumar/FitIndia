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
                DataContext dataContext = new DataContext();
                User user = dataContext.UserDetails.SingleOrDefault(x => x.AadhaarNo == aadhaarlogin.AadhaarNo);
                if(user==null)
                {
                    AadhaarClientApi aadhaarClientApi = new AadhaarClientApi();
            
                    string url = "http://insurewithaadhar.herokuapp.com/users/auth/" + aadhaarlogin.AadhaarNo + "/" + aadhaarlogin.Pincode;
                    AadhaarData aadhaarData = aadhaarClientApi.DownloadPageAsync(url);
                    if (aadhaarData.otp != null && aadhaarData.user == null)
                    {
                        Session["aadhaarNo"] = aadhaarlogin.AadhaarNo;
                        return RedirectToAction("Authenticate");
                    }
                    else if (aadhaarData.user!=null)
                    {
                        if (aadhaarData.otp == null && aadhaarData.user != null)
                        {
                            BusinessLayer businessLayer = new BusinessLayer();
                            user=businessLayer.jsonToObject(aadhaarData);
                            businessLayer.addUser(user);
                            return RedirectToAction("Index", "Treatment");
                        }
                        else
                        {
                            return View();
                        }
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    Session["aadhaarNo"] = aadhaarlogin.AadhaarNo;
                    return RedirectToAction("Index", "Treatment");
                }
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        [ActionName("Authenticate")]
        public ActionResult Authenticate_Get()
        {
            string aadhaarNo = Session["aadhaarNo"] as String;
            if (aadhaarNo != null)
            {
                AadhaarOtpAuth aadhaarOtpAuth = new AadhaarOtpAuth();
                aadhaarOtpAuth.AadhaarNo = aadhaarNo;
                return View(aadhaarOtpAuth);
            }
           else
            {
                return RedirectToAction("Create", "AadhaarLogin");
            }
        }
        [HttpPost]
        [ActionName("Authenticate")]
        public ActionResult Authenticate_Post()
        { 
            AadhaarOtpAuth aadhaarOtpAuth = new AadhaarOtpAuth();
            TryUpdateModel(aadhaarOtpAuth);
            if (ModelState.IsValid)
            {
                aadhaarOtpAuth.AadhaarNo = Session["aadhaarNo"] as String;
                AadhaarClientApi aadhaarClientApi = new AadhaarClientApi();
                string url = "http://insurewithaadhar.herokuapp.com/users/auth/"+aadhaarOtpAuth.AadhaarNo+"/"+aadhaarOtpAuth.Otp;
                AadhaarData aadhaarData = aadhaarClientApi.DownloadPageAsync(url);
                if (aadhaarData.otp == null && aadhaarData.user != null)
                {
                    BusinessLayer businessLayer = new BusinessLayer();
                    User user = businessLayer.jsonToObject(aadhaarData);
                    businessLayer.addUser(user);
                    return RedirectToAction("Index", "Treatment");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
