using FitIndia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitIndia.Controllers
{
    public class ClaimController : Controller
    {
        //
        // GET: /Claim/
        [HttpGet]
        public ActionResult Index(int id)
        {
            string aadhaarNo = Session["aadhaarNo"] as String;
            if (aadhaarNo != null)
            {
                DataContext dataContext = new DataContext();
                List<BillReport> billReport = dataContext.BillReports.Where(x => x.ReportID == id).ToList();
                return View(billReport);
            }
            else
            {
                return RedirectToAction("Create", "AadhaarLogin");
            }
        }
        [HttpPost]
        public ActionResult Claim(int id,int reportID)
        {
            BusinessLayer businessLayer = new BusinessLayer();
            businessLayer.updateBillClaim(id, "Claimed");
            return RedirectToAction("Index", new { id=reportID});
        }

    }
}
