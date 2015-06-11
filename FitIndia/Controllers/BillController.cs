using FitIndia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitIndia.Controllers
{
    public class BillController : Controller
    {
        //
        // GET: /Bill/

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index_Get(int id)
        {
            BillReport billReport = new BillReport();
            string aadhaarNo = Session["aadhaarNo"] as String;
            if (aadhaarNo != null)
            {
                billReport.AadhaarNo = aadhaarNo;
                billReport.ReportID = id;
                billReport.BillDate = DateTime.Now;
                billReport.TreatmentCost = 0;
                return View(billReport);
            }
            else
            {
                return RedirectToAction("Create", "AadhaarLogin");
            }
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post()
        {
            BillReport billReport = new BillReport();
            string aadhaarNo = Session["aadhaarNo"] as String;
            TryUpdateModel(billReport);
            billReport.AadhaarNo = aadhaarNo;
            if (ModelState.IsValid)
            {
                BusinessLayer businessLayer = new BusinessLayer();
                businessLayer.addBill(billReport);
                return RedirectToAction("Index", "Treatment");
            }
            else
            {
                return View(billReport);
            }
        }





    }
}
