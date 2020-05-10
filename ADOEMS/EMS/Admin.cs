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
            List<User> UserData1 = UserAdo.GetAllUsers();
            foreach (var el in UserData1)
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

            return "user added";

        }
        public User Checkuser(int name)
        {
            User obj = UserAdo.GetByIdUsers(name);
            return obj;
        }
        public string Removeuser(int name)
        {
            
            try
            {
                UserAdo.RemoveUser(name);
                return "user deleted";


            }
            catch(Exception e)
            {
                return "user not found"+e.ToString();
            }
            
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

