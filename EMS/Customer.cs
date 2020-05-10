using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    public class Customer:Events
    {
        public Customer() : base() { }
        public Customer(string ename, string etype, int eprice, int ecprice, int emprice, int ewallet) : base(ename, etype, eprice, ecprice, emprice, ewallet) { }
        public Customer(int uid, int eid, DateTime bdate, string paystatus) : base(uid, eid, bdate, paystatus) { }
        public override string BookEvent(int userId, int eventId)
        {

            string tempPay = "no payment";
            DateTime tempDate = DateTime.Now;
            BookingData.Add(new Events(userId, eventId, tempDate, tempPay));

            return "booking added";

        }
        public override string payment(int bookId, int amount)
        {
            string result = "ss";

            foreach (var el in BookingData)
            {

                if (bookId == el.BookingId && !el.PaymentStatus.Equals("payment done"))
                {
                    el.PaymentStatus = "payment done";
                    el.EventWallet = el.EventWallet + amount;
                    result = "payment done";
                    break;
                }
                else
                {
                    result = "payment failed";
                }
            }

            return result;
        }
        public override string CancelEvent(int name)
        {
            string result = "ss";
            foreach (var el1 in BookingData)
            {
                Console.WriteLine(name == el1.BookingId);
                if (name == el1.BookingId)
                {
                    BookingData.Remove(el1);
                    result = "Booking removed";
                    break;

                }
                else
                {
                    result = "Booking not found";
                }
            }
            return result;
        }
        public override Events CheckBooking(int name)
        {
            Events obj = null;
            foreach (var el1 in BookingData)
            {

                if (name == el1.BookingId)
                {
                    obj = el1;
                }
            }
            return obj;
        }

    }
}
