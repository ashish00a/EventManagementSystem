using EMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EMSAPI.Controllers
{
    public class AdminEventController : Controller
    {
        private EmsContext _context;

        //Constructor for Admin Event controller class
        public AdminEventController()
        {
            _context = new EmsContext();
        }
        // Dispose method for releasing unmanaged resources
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        // GET: AdminEvent
        public ActionResult Index()
        {
            return View(_context.Events.ToList());
        }
        //Get method for adding events.
        public ActionResult Create()
        {
            return View();
        }
        //post method for adding events.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event events)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(events);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "event Addition Unsuccessfull");
            }
            return View(events);
        }
        // Edit method for checking event id for validation.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event events = _context.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }
        // Edit method for editing books if books were aready added after it will redirect to index page of Admin Event.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event events)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(events).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "event Editing Unsuccessfull");
            }
            return View(events);
        }
        // Details method for checking event id for validation.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event events = _context.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);

        }
        // Delete method for checking event id for validation.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event events = _context.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);

        }
        //Delete method if event id is correct then after deleting it will redirect to index page of event controller.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Event events = _context.Events.Find(id);
            _context.Events.Remove(events);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}