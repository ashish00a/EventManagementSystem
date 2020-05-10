using EMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EMSAPI.Controllers
{
    public class BookingController : Controller
    {
        private EmsContext _context;

        public BookingController()
        {
            _context = new EmsContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        public ActionResult Index()
        {

            return View(_context.Events.ToList());
        }

        public ActionResult Book(int? id)
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
            Session["EVENTID"] = events.EVENTID.ToString();
            Booking bk = new Booking();
            bk.USERID = Convert.ToInt32(Session["USERID"]);
            bk.EVENTID = events.EVENTID;
            bk.PAYMENTSTATUS = "PENDING";
            bk.BOOKINGDATE = DateTime.Now;
            _context.Bookings.Add(bk);
            _context.SaveChanges();
            return RedirectToAction("Bookings");
        }

        public ActionResult Bookings()
        {
            return View(_context.Bookings.ToList());
        }


        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking Book = _context.Bookings.Find(id);
            if (Book == null)
            {
                return HttpNotFound();
            }
            return View(Book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id)
        {
            Booking book = _context.Bookings.Find(id);
            if (book.PAYMENTSTATUS.Equals("PENDING"))
            {
                _context.Bookings.Remove(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking Book = _context.Bookings.Find(id);
            if (Book == null)
            {
                return HttpNotFound();
            }

            return View(Book);
        }

        public ActionResult Payment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking Book = _context.Bookings.Find(id);
            Session["BOOKINGID"] = id.ToString();
            Event events = _context.Events.Find(Book.EVENTID);

            if (Book == null)
            {
                return HttpNotFound();
            }

            //if (Book.PAYMENTSTATUS.Equals("PENDING"))
            //{
            //    Book.PAYMENTSTATUS = "PAYMENT DONE";
            //    Event es = _context.Events.Find(Book.EVENTID);

            //    if (Session["USERTYPE"].Equals("CUSTOMER"))
            //    {
            //        es.EVENTWALLET = es.EVENTWALLET + es.EVENTCOST;
            //    }
            //    if (Session["USERTYPE"].Equals("CONSULTANT"))
            //    {
            //        es.EVENTWALLET = es.EVENTWALLET + es.EVENTCONSULTANTCOST;
            //    }
            //    if (Session["USERTYPE"].Equals("MANAGER"))
            //    {
            //        es.EVENTWALLET = es.EVENTWALLET + es.EVENTMANAGEMENTCOST;
            //    }
            //    _context.SaveChanges();
            //    return RedirectToAction("Bookings");

            //}
            return View(events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(Event es)
        {
            if (ModelState.IsValid)
            {
                var book = _context.Bookings.Find(Convert.ToInt32(Session["BOOKINGID"]));
                if (book.PAYMENTSTATUS.Equals("PENDING"))
                {

                    Event es1 = _context.Events.Find(es.EVENTID);

                    if (Session["USERTYPE"].Equals("CUSTOMER") && es.EVENTWALLET.Equals(es1.EVENTCOST))
                    {
                        book.PAYMENTSTATUS = "PAYMENT DONE";
                        es1.EVENTWALLET = es1.EVENTWALLET + es.EVENTWALLET;
                    }
                    if (Session["USERTYPE"].Equals("CONSULTANT") && es.EVENTWALLET.Equals(es1.EVENTCONSULTANTCOST))
                    {
                        book.PAYMENTSTATUS = "PAYMENT DONE";
                        es1.EVENTWALLET = es1.EVENTWALLET + es.EVENTWALLET;
                    }
                    if (Session["USERTYPE"].Equals("MANAGER") && es.EVENTWALLET.Equals(es1.EVENTMANAGEMENTCOST))
                    {
                        book.PAYMENTSTATUS = "PAYMENT DONE";
                        es1.EVENTWALLET = es1.EVENTWALLET + es.EVENTWALLET;
                    }
                    _context.SaveChanges();
                    return RedirectToAction("Bookings");
                }
            }
            else
            {
                ModelState.AddModelError("", "unable to do payment");
            }

            return View(es);
        }
    }
}