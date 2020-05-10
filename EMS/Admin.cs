using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
    public class Admin:User
    {
        public Admin() : base(){ }
        public Admin(String name, string gender,string mobile, string email,string type, string uname, string pass)  : base(name, gender, mobile, email, type, uname, pass) { }
        public string Adduser(string name, string gender, string mobile, string email, string usertype, string username, string password)
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

            return "user added";

        }
        public User Checkuser(int name)
        {
            User obj = null;
            foreach (var el1 in UserData)
            {

                if (name == el1.UserId)
                {
                    obj = el1;
                }
            }
            return obj;
        }
        public string Removeuser(int name)
        {
            string result = "ss";
            foreach (var el1 in UserData)
            {

                if (name == el1.UserId)
                {
                    UserData.Remove(el1);
                    result = "user removed";
                    break;

                }
                else
                {
                    result = "user not found";
                }
            }
            return result;
        }
        public override Int32 Login(string name, string password)
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
        public override string Register(string name, string gender, string mobile, string email, string usertype, string username, string password)
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
            return string.Format("\n user Id {0}  name {1}  gender {2}  mobile {3}  email {4}  usertype {5}  username {6}  password {7}", this.UserId, this.Name, this.Gender, this.Mobile, this.Email, this.UserType, this.UserName, this.Password);
        }
        public override string ToString1()
        {
            return string.Format("\n user Id {0}  name {1}  gender {2}  mobile {3}  email {4}  usertype {5}", this.UserId, this.Name, this.Gender, this.Mobile, this.Email, this.UserType);
        }
    }
}

