using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    class Program
    {
        User obj = null;
        User userobj = new User();
        Events eobj = new Events();
        Admin aobj = new Admin();
        Manager mobj = new Manager();
        Consultant cnobj = new Consultant();
        Customer cobj = new Customer();

        public void Mainmenu()
        {
            Console.WriteLine("------------------>EVENT MANAGEMENT SYSTEM<------------------------");
            Console.WriteLine("\n 1.LOGIN\n 2.REGISTER\n 3.EXIT");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;

                case 3:
                    Console.WriteLine("you are exiting");
                    break;

                default:
                    Console.WriteLine("Enter correct option");
                    break;
            }

        }
        public void Login()
        {
            Console.WriteLine("Enter user name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter ur password:");
            string password = Console.ReadLine();
            int login = userobj.Login(name, password);
            if (login == 1)
            {
                Console.WriteLine("welcome to dashboard");
                Dashboard(name);
            }
            else
            {
                Console.WriteLine("DATA NOT FOND");
                Console.WriteLine("\n1.REGISTER\n 2.LOGIN MENU");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Console.WriteLine("going to login menu");
                        Mainmenu();
                        break;
                    default:
                        Console.WriteLine("Enter correct option");
                        break;
                }
            }
        }

        public void Dashboard(string name)
        {
            User obj = null;
            List<User> UserData = UserAdo.GetAllUsers();
            foreach (var el1 in UserData)
            {

                if (name == el1.UserName)
                {
                    obj = el1;
                }
            }
            if (obj.UserType.Equals("ADMIN"))
            {
                Console.WriteLine("Admin dashboard");

                Console.WriteLine("\n 1.check user \n 2.ADD user \n 3. check event \n 4. ADD event \n 5. Check payment \n 6. Remove event \n 7. Remove user \n 8.Check Bookings \n 9. logout");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Checkuser(obj.UserName);
                        break;
                    case 2:
                        Adduser(obj.UserName);
                        break;
                    case 3:
                        CheckEvent(obj.UserName);
                        break;
                    case 4:
                        AddEvent(obj.UserName);

                        break;
                    case 5:
                        Payment(obj.UserName);
                        break;
                    case 6:
                        RemoveEvent(obj.UserName);
                        break;
                    case 7:
                        Removeuser(obj.UserName);
                        break;
                    case 8:
                        Checkbookings(obj.UserName);
                        break;
                    case 9:
                        Mainmenu();
                        break;
                    default:
                        Console.WriteLine("Enter correct option");
                        break;
                }

            }
            if (obj.UserType.Equals("MANAGER"))
            {
                Console.WriteLine("manager dashboard");

                Console.WriteLine("\n 1.check user \n 2. Book event \n 3. payment \n 4. Cancel event \n 5. logout");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Checkuser(obj.UserName);
                        break;
                    case 2:
                        BookEvent(obj.UserName);
                        break;
                    case 3:
                        Payment1(obj.UserName);
                        break;
                    case 4:
                        CancelEvent(obj.UserName);
                        break;
                    case 5:
                        Mainmenu();
                        break;
                    default:
                        Console.WriteLine("Enter correct option");
                        break;
                }
            }
            if (obj.UserType.Equals("CONSULTANT"))
            {
                Console.WriteLine("consultant dashboard");

                Console.WriteLine("\n 1.check user \n  2.Book event \n 3.payment \n 4.Cancel Event   \n 5. logout");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Checkuser(obj.UserName);
                        break;
                    case 2:
                        BookEvent(obj.UserName);
                        break;
                    case 3:
                        Payment1(obj.UserName);
                        break;

                    case 4:
                        CancelEvent(obj.UserName);
                        break;
                    case 5:
                        Mainmenu();
                        break;
                    default:
                        Console.WriteLine("Enter correct option");
                        break;
                }
            }
            if (obj.UserType.Equals("CUSTOMER"))
            {
                Console.WriteLine("customer dashboard");

                Console.WriteLine("\n 1.check user \n 2. Book event \n 3. payment \n 4. Cancel event  \n 5. logout");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Checkuser(obj.UserName);
                        break;
                    case 2:
                        BookEvent(obj.UserName);
                        break;
                    case 3:
                        Payment1(obj.UserName);
                        break;
                    case 4:
                        CancelEvent(obj.UserName);
                        break;
                    case 5:
                        Mainmenu();
                        break;
                    default:
                        Console.WriteLine("Enter correct option");
                        break;
                }
            }

            Console.ReadLine();
        }

        public void Checkuser(string name1)
        {
            List<User> UserData = UserAdo.GetAllUsers();
            foreach (var el1 in UserData)
            {
                Console.WriteLine(el1.ToString1());
            }
            Console.WriteLine("enter the username");
            int name = Convert.ToInt32(Console.ReadLine());
            User result = aobj.Checkuser(name);
            if(result == null)
            {
                Console.WriteLine("Data not found");
            }
            else
            {
                User obj = null;
                foreach( var el in UserData)
                {
                    if (el.UserName.Equals(name1))
                    {
                        obj = el;
                        break;
                    }
                }
                if(obj.UserType.Equals("ADMIN"))
                {
                    Console.WriteLine(result.ToString());
                }
                else
                {
                    Console.WriteLine(result.ToString1());
                }
                
            }
            
            Dashboard(name1);

        }
        public void CheckEvent(string name1)
        {
            List<Events> EventsData = EventsAdo.GetAllEvents();
            foreach (var el1 in EventsData)
            {
                Console.WriteLine(el1.ToStringa());
            }
            Console.WriteLine("enter event Id");
            int name = Convert.ToInt32(Console.ReadLine());
            Events result = eobj.CheckEvent(name);
            if(result == null)
            {
                Console.WriteLine("Data Not Found");
            }
            else
            {
                Console.WriteLine(result.ToStringa());
            }
            Dashboard(name1);

        }
        public void Payment(string name1)
        {
            List<Events> BookingData = BookingAdo.GetAllBookings();
            foreach (var el1 in BookingData)
            {
                Console.WriteLine(el1.ToStringb());
            }
            Console.WriteLine("enter booking Id");
            int name = Convert.ToInt32(Console.ReadLine());
            Events result = eobj.CheckPayment(name);
            Console.WriteLine(result.ToStringb());
            Dashboard(name1);

        }
        public void Payment1(string name1)
        {
            int name;
            int amount;
            string result;
            List<User> UserData = UserAdo.GetAllUsers();
            List<Events> BookingData = BookingAdo.GetAllBookings();
            foreach (var el in UserData)
            {
                if (el.UserName.Equals(name1))
                {
                    obj = el;
                    break;
                }
            }

            if (obj.UserType.Equals("MANAGER"))
            {
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
                Console.WriteLine("enter booking Id");
                name = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter amount");
                amount = Convert.ToInt32(Console.ReadLine());
                result = mobj.payment(name, amount);
                Console.WriteLine(result);
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
            }
            else if (obj.UserType.Equals("CONSULTANT"))
            {
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
                Console.WriteLine("enter booking Id");
                name = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter amount");
                amount = Convert.ToInt32(Console.ReadLine());
                result = cnobj.payment(name, amount);
                Console.WriteLine(result);
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
            }
            else if (obj.UserType.Equals("CUSTOMER"))
            {
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
                Console.WriteLine("enter booking Id");
                name = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter amount");
                amount = Convert.ToInt32(Console.ReadLine());
                result = cobj.payment(name, amount);
                Console.WriteLine(result);
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
            }
            else
            {
                Console.WriteLine("check user type");
            }
           
            Dashboard(name1);

        }
        public void Checkbookings(string name1)
        {
            int name;
          
            List<Events> BookingData = BookingAdo.GetAllBookings();
       
            Events result;
         
  
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
                Console.WriteLine("enter booking Id");
                name = Convert.ToInt32(Console.ReadLine());
                result = mobj.CheckBooking(name);

                Console.WriteLine(result.ToStringb());
   
 
            Dashboard(name1);

        }
        public void Adduser(string name1)
        {
            Console.WriteLine("Enter ur name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter ur gender:");
            string gender = Console.ReadLine();
            Console.WriteLine("Enter ur mobile:");
            string mobile = Console.ReadLine();
            Console.WriteLine("Enter ur email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter ur username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter ur usertype:");
            string usetype = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string pass = Console.ReadLine();
            String register = aobj.Adduser(name, gender, mobile, email, usetype, username, pass);
            Console.WriteLine(register);
            List<User> UserData = UserAdo.GetAllUsers();
            foreach (var el1 in UserData)
            {

                Console.WriteLine(el1.ToString());
            }
            Dashboard(name1);

        }
        public void AddEvent(string name1)
        {
            Console.WriteLine("Enter event name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter event type:");
            string type = Console.ReadLine();
            Console.WriteLine("Enter event price:");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter event consultant price:");
            int cprice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter event managing price:");
            int mprice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter wallet amount:");
            int wallet = Convert.ToInt32(Console.ReadLine());
            String register = eobj.AddEvent(name, type, price, cprice, mprice, wallet);
            Console.WriteLine(register);
            List<Events> EventsData = EventsAdo.GetAllEvents();
            foreach (var el1 in EventsData)
            {

                Console.WriteLine(el1.ToStringa());
            }
            Dashboard(name1);

        }
        public void BookEvent(string name1)
        {
            List<User> UserData = UserAdo.GetAllUsers();
            List<Events> BookingData = BookingAdo.GetAllBookings();
            foreach (var el in UserData)
            {
                if (el.UserName.Equals(name1))
                {
                    obj = el;
                    break;
                }
            }
            List<Events> EventsData = EventsAdo.GetAllEvents();
            foreach (var el1 in EventsData)
            {

                Console.WriteLine(el1.ToString());
            }
            if (obj.UserType.Equals("MANAGER"))
            {
                Console.WriteLine("Enter user id:");
                int uid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter event id:");
                int eid = Convert.ToInt32(Console.ReadLine());
                String register = mobj.BookEvent(uid, eid);
                Console.WriteLine(register);
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
            }
            else if (obj.UserType.Equals("CONSULTANT"))
            {
                Console.WriteLine("Enter user id:");
                int uid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter event id:");
                int eid = Convert.ToInt32(Console.ReadLine());
                String register = cnobj.BookEvent(uid, eid);
                Console.WriteLine(register);
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
            }
            else if (obj.UserType.Equals("CUSTOMER"))
            {
                Console.WriteLine("Enter user id:");
                int uid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter event id:");
                int eid = Convert.ToInt32(Console.ReadLine());
                String register = cobj.BookEvent(uid, eid);
                Console.WriteLine(register);
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
            }
            else
            {
                Console.WriteLine("check user type");
            }
            Dashboard(name1);

        }
        public void Removeuser(string name1)
        {
            List<User> UserData = UserAdo.GetAllUsers();
            foreach (var el1 in UserData)
            {

                Console.WriteLine(el1.ToString1());
            }
            Console.WriteLine("enter the user Id");
            int name = Convert.ToInt32(Console.ReadLine());
            string result = aobj.Removeuser(name);
            Console.WriteLine(result);
            foreach (var el1 in UserData)
            {

                Console.WriteLine(el1.ToString1());
            }
            Dashboard(name1);
        }

        public void RemoveEvent(string name1)
        {
            List<Events> EventsData = EventsAdo.GetAllEvents();
            foreach (var el1 in EventsData)
            {

                Console.WriteLine(el1.ToStringa());
            }
            Console.WriteLine("enter the event id");
            int name = Convert.ToInt32(Console.ReadLine());
            string result = eobj.RemoveEvent(name);
            Console.WriteLine(result);
            
            foreach (var el1 in EventsData)
            {

                Console.WriteLine(el1.ToStringa());
            }
            Dashboard(name1);
        }
        public void CancelEvent(string name1)
        {
            int name;
            string result;
            List<User> UserData = UserAdo.GetAllUsers();
            List<Events> BookingData = BookingAdo.GetAllBookings();
            foreach (var el in UserData)
            {
                if (el.UserName.Equals(name1))
                {
                    obj = el;
                    break;
                }
            }
           
            if (obj.UserType.Equals("MANAGER"))
            {
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
                Console.WriteLine("enter the Booking id");
                 name = Convert.ToInt32(Console.ReadLine());
                 result = mobj.CancelEvent(name);
                Console.WriteLine(result);
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
            }
            else if (obj.UserType.Equals("CONSULTANT"))
            {
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
                Console.WriteLine("enter the Booking id");
                name = Convert.ToInt32(Console.ReadLine());
                result = cnobj.CancelEvent(name);
                Console.WriteLine(result);
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
            }
            else if (obj.UserType.Equals("CUSTOMER"))
            {
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
                Console.WriteLine("enter the Booking id");
                name = Convert.ToInt32(Console.ReadLine());
                result = cobj.CancelEvent(name);
                Console.WriteLine(result);
                foreach (var el1 in BookingData)
                {
                    Console.WriteLine(el1.ToStringb());
                }
            }
            else
            {
                Console.WriteLine("check user type");
            }
            
            Dashboard(name1);
        }

        public void Register()
        {

            Console.WriteLine("Enter ur name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter ur gender:");
            string gender = Console.ReadLine();
            Console.WriteLine("Enter ur mobile:");
            string mobile = Console.ReadLine();
            Console.WriteLine("Enter ur email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter ur username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter ur usertype:");
            string usetype = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string pass = Console.ReadLine();
            String register = userobj.Register(name, gender, mobile, email, usetype, username, pass);
            Console.WriteLine(register);
            List<User> UserData = UserAdo.GetAllUsers();
            foreach (var el1 in UserData)
            {
                if (mobile.Equals(el1.Mobile))
                {
                    Console.WriteLine(el1.ToString());
                }
                else
                {
                    Console.WriteLine(el1.ToString1());
                }

            }
            Mainmenu();
        }
        static void Main(string[] args)
        {
            Program mainobj = new Program();
            mainobj.Mainmenu();
        }
    }
}
