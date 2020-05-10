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
       

        public Events()
        {
           
        }
        public Events(string eventName, string eventType, int eventPrice, int ecPrice, int emPrice, int eWallet)
        {
            this._eventName = eventName;
            this._eventType = eventType;
            this._eventPrice = eventPrice;
            this._eventConsultantPrice = ecPrice;
            this._eventManagingPrice = emPrice;
            this._eventWallet = eWallet;

        }

        public Events(int userId, int eventid, DateTime bookDate, string payStatus)
        {
           
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

        
      

        public Events CheckEvent(int name)
        {
            Events obj = EventsAdo.GetByIdevent(name);
            return obj;
        }
        public virtual Events CheckBooking(int name)
        {
            Events obj = BookingAdo.GetByIdBooking(name);
            return obj;
        }
        public Events CheckPayment(int name)
        {
            Events obj = BookingAdo.GetByIdBooking(name);
            return obj;
        }
        public  string AddEvent(String name, string Type, int price, int ecprice, int emPrice, int ewal)
        {

            int i = 0;
            List<Events> EventsData = EventsAdo.GetAllEvents();
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
                Events eobj = new Events(name, Type, price, ecprice, emPrice, ewal);
                EventsAdo.InsertEvents(eobj);

            }

            return "Event added";

        }
        public virtual string BookEvent(int userId, int eventId)
        {

            string tempPay = "no payment";
            DateTime tempDate = DateTime.Now;
            Events eobj = new Events(userId, eventId, tempDate, tempPay);
            BookingAdo.InsertBookings(eobj);
            return "booking added";

        }
        public virtual string payment(int bookId, int amount)
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
        public string RemoveEvent(int name)
        {
            string result = "ss";
            int i = 0;
            List<Events> EventsData = EventsAdo.GetAllEvents();
            foreach (var el1 in EventsData)
            {

                if (name == el1.EventId)
                {

                    i = 1;
                    break;

                }
                else
                {
                    result = "event not found";
                }
            }
            if(i == 1)
            {
                EventsAdo.RemoveEvent(name);
                result = "event removed";
            }
            return result;
        }
        public virtual string CancelEvent(int name)
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
            if(i == 1)
            {
                BookingAdo.RemoveBooking(name);
                result = "Booking removed";
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
            return string.Format("\n Booking Id {0}   User Id {1}   Event Id {2}  Bookig Date {3}  Payment Status {4}  \n", this._bookingId, this._userId, this._eventId, this._bookingDate, this._paymentStatus);

        }


    }
}
