using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    public class Events
    {
        private int _eventId;
        private string _eventName;
        private string _eventType;
        private int _eventPrice;
        private int _eventConsultantPrice;
        private int _eventManagingPrice;
        private int _eventWallet;
        private int _userId;
        private int _bookingId;
        private DateTime _bookingDate;
        private string _paymentStatus;
        private static int eventIdNo = 2000;
        private static int bookingIdno = 3000;
        private IList<Events> eventdata = new List<Events>();
        private IList<Events> bookingdata = new List<Events>();

        public Events()
        {
            eventIdNo++;
            bookingIdno++;
            this._eventId = this._eventId + eventIdNo;
            this._bookingId = this._bookingId + bookingIdno;
            EventsData.Add(new Events("uthsav", "cultural", 50000, 15000, 30000, 0));
            BookingData.Add(new Events(1004, 2002, DateTime.Now , "nopayment"));
        }
        public Events(string eventName, string eventType, int eventPrice, int ecPrice, int emPrice, int eWallet)
        {
            eventIdNo++;

            this._eventId = this._eventId + eventIdNo;
            this._eventName = eventName;
            this._eventType = eventType;
            this._eventPrice = eventPrice;
            this._eventConsultantPrice = ecPrice;
            this._eventManagingPrice = emPrice;
            this._eventWallet = eWallet;

        }

        public Events(int userId, int eventid, DateTime bookDate, string payStatus)
        {
            bookingIdno++;
            this._bookingId = this._bookingId + bookingIdno;
            this._userId = userId;
            this._eventId = eventid;
            this._bookingDate = bookDate;
            this._paymentStatus = payStatus;
        }
        public int EventId
        {
            get
            {
                return this._eventId;
            }
            set
            {
                this._eventId = value;
            }
        }
        public int BookingId
        {
            get
            {
                return this._bookingId;
            }
            set
            {
                this._bookingId = value;
            }
        }
        public string EventName
        {
            get
            {
                return this._eventName;
            }
            set
            {
                this._eventName = value;
            }
        }
        public string EventType
        {
            get
            {
                return this._eventType;
            }
            set
            {
                this._eventType = value;
            }
        }
        public int EventPrice
        {
            get
            {
                return this._eventPrice;
            }
            set
            {
                this._eventPrice = value;
            }
        }
        public int EventConsultantPrice
        {
            get
            {
                return this._eventConsultantPrice;
            }
            set
            {
                this._eventConsultantPrice = value;
            }
        }
        public int EventManagementPrice
        {
            get
            {
                return this._eventManagingPrice;
            }
            set
            {
                this._eventManagingPrice = value;
            }
        }
        public int EventWallet
        {
            get
            {
                return this._eventWallet;
            }
            set
            {
                this._eventWallet = value;
            }
        }
        public int UserId
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }
        public DateTime BookingDate
        {
            get
            {
                return this._bookingDate;
            }
            set
            {
                this._bookingDate = value;
            }
        }
        public string PaymentStatus
        {
            get
            {
                return this._paymentStatus;
            }
            set
            {
                this._paymentStatus = value;
            }
        }

        public IList<Events> EventsData
        {
            get
            {
                return this.eventdata;
            }
            set
            {
                this.eventdata = value;
            }
        }
        public IList<Events> BookingData
        {
            get
            {
                return this.bookingdata;
            }
            set
            {
                this.bookingdata = value;
            }
        }

        public Events CheckEvent(int name)
        {
            Events obj = null;
            foreach (var el1 in EventsData)
            {

                if (name == el1.EventId)
                {
                    obj = el1;
                }
            }
            return obj;
        }
        public virtual Events CheckBooking(int name)
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
        public Events CheckPayment(int name)
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
        public  string AddEvent(String name, string Type, int price, int ecprice, int emPrice, int ewal)
        {

            int i = 0;
            foreach (var el in EventsData)
            {

                if (name == el.EventName)
                {
                    i = 0;
                    return "Events already exists";
                }
                else
                {
                    i = 1;
                }
            }
            if (i == 1)
            {
                EventsData.Add(new Events(name, Type, price, ecprice, emPrice, ewal));

            }

            return "Event added";

        }
        public virtual string BookEvent(int userId, int eventId)
        {

            string tempPay = "no payment";
            DateTime tempDate = DateTime.Now;
            BookingData.Add(new Events(userId,eventId,tempDate,tempPay));

            return "booking added";

        }
        public virtual string payment(int bookId, int amount)
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
        public string RemoveEvent(int name)
        {
            string result = "ss";
            foreach (var el1 in EventsData)
            {

                if (name == el1.EventId)
                {
                    EventsData.Remove(el1);
                    result = "Event removed";
                    break;

                }
                else
                {
                    result = "event not found";
                }
            }
            return result;
        }
        public virtual string CancelEvent(int name)
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

        public override string ToString()
        {
            return string.Format("\n Event Id {0}   Event Name {1}   Event Type {2}  Event Price {3}  Event Consultant Price {4}  Event Management Price {5} \n", this._eventId, this._eventName, this._eventType, this._eventPrice, this._eventConsultantPrice, this._eventManagingPrice);
        }

        public string ToStringa()
        {
            return string.Format("\n Event Id {0}   Event Name {1}   Event Type {2}  Event Price {3}  Event Consultant Price {4}  Event Management Price {5}  Event Wallet {6} \n", this._eventId, this._eventName, this._eventType, this._eventPrice, this._eventConsultantPrice, this._eventManagingPrice, this._eventWallet);

        }

        public string ToStringb()
        {
            return string.Format("\n Booking Id {0}   User Id {1}   Event Id {2}  Bookig Date {3}  Payment Status {4}  Event Wallet {5} \n", this._bookingId, this._userId, this._eventId, this._bookingDate, this._paymentStatus, this._eventWallet);

        }


    }
}
