using FitIndia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitIndia.Controllers
{
    public class TreatmentController : Controller
    {
        //
        // GET: /Treatment/

        public ActionResult Index()
        {
            string aadhaarNo = Session["aadhaarNo"] as String;
            if(aadhaarNo!=null)
            {
                DataContext dataContext = new DataContext();
                List<TreatmentReport> treatmentReports = dataContext.TreatmentReports.Where(x => x.AadhaarNo == aadhaarNo).ToList();
                return View(treatmentReports);
            }
            else
            {
                return RedirectToAction("Create", "AadhaarLogin");
            }
        }
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            string aadhaarNo = Session["aadhaarNo"] as String;
            if (aadhaarNo != null)
            {
                TreatmentReport treatmentReport = new TreatmentReport();
                treatmentReport.AadhaarNo = aadhaarNo;
                treatmentReport.DateOfTreatment = DateTime.Now;
                return View(treatmentReport);
            }
            else
            {
                return RedirectToAction("Create", "AadhaarLogin");
            }
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            TreatmentReport treatmentReport = new TreatmentReport();
            TryUpdateModel(treatmentReport);
            string aadhaarNo = Session["aadhaarNo"] as String;
            treatmentReport.AadhaarNo = aadhaarNo;
            if (ModelState.IsValid)
            {
                BusinessLayer businessLayer = new BusinessLayer();
                businessLayer.addTreatment(treatmentReport);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}
