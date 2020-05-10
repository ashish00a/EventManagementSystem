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

        public AdminReportController()
        {
            _context = new EmsContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        public ActionResult Index()
        {

            return View(_context.Reports.ToList());
        }

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