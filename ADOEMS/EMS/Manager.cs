using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    public class Manager:Events
    {
        public Manager() : base() { }
        public Manager(string ename,string etype,int eprice,int ecprice,int emprice,int ewallet) : base(ename, etype, eprice, ecprice, emprice, ewallet) { }
        public Manager(int uid,int eid,DateTime bdate,string paystatus) : base(uid, eid, bdate, paystatus) { }
        public override string BookEvent(int userId, int eventId)
        {

            string tempPay = "no payment";
            DateTime tempDate = DateTime.Now;
            Events eobj = new Events(userId, eventId, tempDate, tempPay);
            BookingAdo.InsertBookings(eobj);
            return "booking added";

        }
        public override string payment(int bookId, int amount)
        {
            string result = "ss";
            int i = 0;
            List<Events> BookingData1 = BookingAdo.GetAllBookings();
            foreach (var el in BookingData1)
            {

                if (bookId == el.BookingId && !el.PaymentStatus.Equals("payment done"))
                {
                    i = 1;
                    break;
                }
                else
                {
                    result = "payment failed";
                }
            }
            if (i == 1)
            {
                Events obj = BookingAdo.GetByIdBooking(bookId);
                EventsAdo.UpdatewalletEvents(amount, obj.EventId);
                BookingAdo.UpdatePayStatusBookings("payment done", bookId);
                result = "payment succcess";
            }

            return result;
        }
        public override string CancelEvent(int name)
        {
            string result = "ss";
            int i = 0;
            List<Events> BookingData = BookingAdo.GetAllBookings();
            foreach (var el1 in BookingData)
            {
                if (name == el1.BookingId)
                {
                    i = 1;
                    break;

                }
                else
                {
                    result = "Booking not found";
                }
            }
            if (i == 1)
            {
                BookingAdo.RemoveBooking(name);
                result = "Booking removed";
            }
            return result;
        }
      
    }
}
