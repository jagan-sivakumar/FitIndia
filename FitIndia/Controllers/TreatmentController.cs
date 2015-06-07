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
            DataContext dataContext = new DataContext();
            List<TreatmentReport> treatmentReports = dataContext.TreatmentReports.Where(x => x.AadhaarNo == aadhaarNo).ToList();
            return View(treatmentReports);
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
            TreatmentReport treatmentReport = new TreatmentReport();
            TryUpdateModel(treatmentReport);
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
