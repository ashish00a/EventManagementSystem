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
        //Constructor for Booking Controller controller class
        public BookingController()
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

            return View(_context.Events.ToList());
        }
        //Book method for adding and validating books by their book id and if it is valid book will be added to the database
        //and it status will be PENDING.
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

        //Cancel method for cancelling books using their booking id.
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
        //cencel method for cancel booking, if only payment status is pending.
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
        //Details method for showing the detail of the booking.
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
        //payment method for making the payment of pending bookings it will also checkthe user type if user is manager then
        //only manager payment amount can be paid and like wise for others also.
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