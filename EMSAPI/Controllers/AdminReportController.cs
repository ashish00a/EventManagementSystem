using EMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EMSAPI.Controllers
{
    public class AdminReportController : Controller
    {
        private EmsContext _context;
        //Constructor for Admin Report controller class
        public AdminReportController()
        {
            _context = new EmsContext();
        }

        // Dispose method for releasing unmanaged resources
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        public ActionResult Index()
        {

            return View(_context.Reports.ToList());
        }
        //Get method for adding report.
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Reports.Add(report);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "User Addition Unsuccessfull");
            }
            return View(report);
        }
        // Edit method for checking report id for validation.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Report report = _context.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }
        // Edit method for editing reports if reports were aready added.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(report).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "User Editing Unsuccessfull");
            }
            return View(report);
        }
        // Details method for checking report id for validation.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Report report = _context.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);

        }
        // Delete method for checking report id for validation.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Report report = _context.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);

        }
        //Delete method if report id is correct then after deleting it will redirect to index page of Admin Report controller.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Report report = _context.Reports.Find(id);
            _context.Reports.Remove(report);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}