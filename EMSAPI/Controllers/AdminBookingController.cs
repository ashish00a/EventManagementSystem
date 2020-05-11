using EMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EMSAPI.Controllers
{
    public class AdminBookingController : Controller
    {
        private EmsContext _context;
        //Constructor for Admin Booking controller class
        public AdminBookingController()
        {
            _context = new EmsContext();
        }
        // Dispose method for releasing unmanaged resources
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        // GET: AdminBooking
        public ActionResult Index()
        {
            return View(_context.Bookings.ToList());
        }
        //Get method for adding books
        public ActionResult Create()
        {
            return View();
        }
        
        //post method for adding books.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Booking Addition Unsuccessfull");
            }
            return View(booking);
        }
        // Edit method for checking book id for validation.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Booking book = _context.Bookings.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        // Edit method for editing books if books were aready added.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booking book)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(book).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Booking Editing Unsuccessfull");
            }
            return View(book);
        }
        // Details method for checking book id for validation.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Booking book = _context.Bookings.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);

        }
        // Delete method for checking book id for validation.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Booking book = _context.Bookings.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);

        }
        //Delete method if booking id is correct then after deleting it will redirect to index page of Booking controller.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Booking book = _context.Bookings.Find(id);
            _context.Bookings.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}