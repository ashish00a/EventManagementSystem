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
        private IList<User> userdata = new List<User>();


        public User()
        {
           
        }

        public User(string name, string gender, string mobile, string email, string usertype, string username, string pass)
        {

            
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
            set
            {
                this._userID = value;
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
            UserData = UserAdo.GetAllUsers();
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
            UserData = UserAdo.GetAllUsers();
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
                User uobj = new User(name, gender, mobile, email, usertype, username, password);
                UserAdo.InsertUser(uobj);
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
