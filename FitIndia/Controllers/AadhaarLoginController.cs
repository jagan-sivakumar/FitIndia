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
            AadhaarClientApi aadhaarClientApi = new AadhaarClientApi();
            AadhaarLogin aadhaarlogin = new AadhaarLogin();
            
            TryUpdateModel(aadhaarlogin);
            if (ModelState.IsValid)
            {
                DataContext dataContext = new DataContext();
                User user = dataContext.UserDetails.SingleOrDefault(x => x.AadhaarNo == aadhaarlogin.AadhaarNo);
                if(user==null)
                {
                    string url = "http://insurewithaadhar.herokuapp.com/users/auth/" + aadhaarlogin.AadhaarNo + "/" + aadhaarlogin.Pincode;
                    AadhaarData aadharData = aadhaarClientApi.DownloadPageAsync(url);
                    if (aadharData.otp != null && aadharData.user == null)
                    {
                        Session["aadhaarNo"] = aadhaarlogin.AadhaarNo;
                        return RedirectToAction("Authenticate");
                    }
                    else if (aadharData.user!=null)
                    {
                        if (aadharData.otp == null && aadharData.user != null)
                        {
                            user = new User();
                            user.AadhaarNo = aadharData.user.aadhar_id;

                            if (aadharData.user.name != null)
                                user.Name = aadharData.user.name;
                            else
                                user.Name = "";

                            if (aadharData.user.gender != null)
                                user.Sex = aadharData.user.gender;
                            else
                                user.Sex = "";

                            if (aadharData.user.date_of_birth != null)
                            {
                                user.DateOfBirth = Convert.ToDateTime(aadharData.user.date_of_birth);
                            }
                            else
                            {
                                user.DateOfBirth = DateTime.Now;
                            }

                            if (aadharData.user.address != null)
                                user.Address = aadharData.user.address;
                            else
                                user.Address = "";

                            if (aadharData.user.mobile != null)
                                user.MobileNo = aadharData.user.mobile;
                            else
                                user.MobileNo = "";

                            if (aadharData.user.email != null)
                                user.EmailID = aadharData.user.email;
                            else
                                user.EmailID = "";

                            user.ImageUrl = null;
                            BusinessLayer businessLayer = new BusinessLayer();
                            businessLayer.addUser(user);
                            return RedirectToAction("Index", "Treatment");
                        }
                        return View();
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
            AadhaarOtpAuth aadhaarOtpAuth = new AadhaarOtpAuth();
            aadhaarOtpAuth.AadhaarNo = aadhaarNo;
            return View(aadhaarOtpAuth);
        }
        [HttpPost]
        [ActionName("Authenticate")]
        public ActionResult Authenticate_Post()
        {
            AadhaarClientApi aadhaarClientApi = new AadhaarClientApi();
            AadhaarOtpAuth aadhaarOtpAuth = new AadhaarOtpAuth();
            TryUpdateModel(aadhaarOtpAuth);
            if (ModelState.IsValid)
            {
                aadhaarOtpAuth.AadhaarNo = Session["aadhaarNo"] as String;

                string url = "http://insurewithaadhar.herokuapp.com/users/auth/"+aadhaarOtpAuth.AadhaarNo+"/"+aadhaarOtpAuth.Otp;
                AadhaarData aadharData = aadhaarClientApi.DownloadPageAsync(url);
                if (aadharData.otp == null && aadharData.user != null)
                {
                    User user = new User();
                    user.AadhaarNo = aadharData.user.aadhar_id;

                    if (aadharData.user.name != null)
                        user.Name = aadharData.user.name;
                    else
                        user.Name = "";

                    if (aadharData.user.gender != null)
                        user.Sex = aadharData.user.gender;
                    else
                        user.Sex = "";

                    if (aadharData.user.date_of_birth != null)
                    {
                        user.DateOfBirth = Convert.ToDateTime(aadharData.user.date_of_birth);
                    }
                    else
                    {
                        user.DateOfBirth = DateTime.Now;
                    }

                    if (aadharData.user.address != null)
                        user.Address = aadharData.user.address;
                    else
                        user.Address = "";

                    if (aadharData.user.mobile != null)
                        user.MobileNo = aadharData.user.mobile;
                    else
                        user.MobileNo = "";

                    if (aadharData.user.email != null)
                        user.EmailID = aadharData.user.email;
                    else
                        user.EmailID = "";

                    user.ImageUrl = null;
                    BusinessLayer businessLayer = new BusinessLayer();
                    businessLayer.addUser(user);
                    return RedirectToAction("Index", "Treatment");
                }

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
