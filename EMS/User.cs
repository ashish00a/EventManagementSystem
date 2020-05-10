using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    public class User
    {
        private int _userID;
        private string _name;
        private string _gender;
        private string _mobile;
        private string _email;
        private string _userType;
        private string _userName;
        private string _pass;
        private static int userIdno = 1001;
        private IList<User> userdata = new List<User>();


        public User()
        {
            userIdno++;
            this._userID = this._userID + userIdno;
            UserData.Add(new User("siva", "Male", "9703940684", "siva@gmail.com", "ADMIN", "siva1212", "siva"));
            UserData.Add(new User("rajul", "Male", "9703940684", "rajul@gmail.com", "manager", "rajl1212", "rajul"));
            UserData.Add(new User("asish", "Male", "9703940684", "asish@gmail.com", "manager", "asish1212", "asish"));
            UserData.Add(new User("amritha", "Female", "9703940684", "amritha@gmail.com", "consultant", "amritha1212", "amritha"));
            UserData.Add(new User("samhitha", "Female", "9703940684", "samhitha@gmail.com", "consultant", "samhitha1212", "samhitha"));
        }

        public User(string name, string gender, string mobile, string email, string usertype, string username, string pass)
        {
            userIdno++;
            this._userID = this._userID + userIdno;
            this._name = name;
            this._gender = gender;
            this._mobile = mobile;
            this._email = email;
            this._userType = usertype;
            this._userName = username;
            this._pass = pass;
        }

        public int UserId
        {
            get
            {
                return this._userID;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public string Gender
        {
            get
            {
                return this._gender;
            }
            set
            {
                this._gender = value;
            }
        }

        public string Mobile
        {
            get
            {
                return this._mobile;
            }
            set
            {
                this._mobile = value;
            }
        }

        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        public string UserType
        {
            get
            {
                return this._userType;
            }
            set
            {
                this._userType = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                this._userName = value;
            }
        }

        public string Password
        {
            get
            {
                return this._pass;
            }
            set
            {
                this._pass = value;
            }
        }

        public IList<User> UserData
        {
            get
            {
                return this.userdata;
            }
            set
            {
                this.userdata = value;
            }
        }



        public virtual Int32 Login(string name, string password)
        {
            int result = 0;

            foreach (var el in UserData)
            {
                if (name == el.UserName && password == el.Password)
                {

                    result = 1;
                    break;

                }
                else
                {
                    result = 0;
                }
            }
            return result;

        }
        public virtual string Register(string name, string gender, string mobile, string email, string usertype, string username, string password)
        {

            int i = 0;
            foreach (var el in UserData)
            {

                if (mobile == el.Mobile)
                {
                    i = 0;
                    return "user already exists";
                }
                else
                {
                    i = 1;
                }
            }
            if (i == 1)
            {
                UserData.Add(new User(name, gender, mobile, email, usertype, username, password));

            }


            return "registered";

        }

       

       

       
        public override string ToString()
        {
            return string.Format("\n user Id {0}  name {1}  gender {2}  mobile {3}  email {4}  usertype {5}  username {6}  password {7}", this._userID, this._name, this._gender, this._mobile, this._email, this._userType, this._userName, this._pass);
        }
        public virtual string ToString1()
        {
            return string.Format("\n user Id {0}  name {1}  gender {2}  mobile {3}  email {4}  usertype {5}", this._userID, this._name, this._gender, this._mobile, this._email, this._userType);
        }
    }
}
