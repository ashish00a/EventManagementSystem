using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS
{
   public class UserAdo
    {
        public static List<User> GetAllUsers()
        {
            List<User> ulist = new List<User>();

            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_getall_users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    User uobj = new User();
                    uobj.UserId = Convert.ToInt32(sdr["user_id"]);
                    uobj.Name = Convert.ToString(sdr["user_name"]);
                    uobj.Gender = Convert.ToString(sdr["gender"]);
                    uobj.Mobile = Convert.ToString(sdr["mobile"]);
                    uobj.Email = Convert.ToString(sdr["email"]);
                    uobj.UserType = Convert.ToString(sdr["user_type"]);
                    uobj.UserName = Convert.ToString(sdr["user_login_name"]);
                    uobj.Password = Convert.ToString(sdr["user_login_password"]);


                    ulist.Add(uobj);
                }
                con.Close();
            }
            return ulist;
        }
        public static User GetByIdUsers(int uid)
        {
            User uobj = new User();

            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_getbyid_users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", uid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    
                    uobj.UserId = Convert.ToInt32(sdr["user_id"]);
                    uobj.Name = Convert.ToString(sdr["user_name"]);
                    uobj.Gender = Convert.ToString(sdr["gender"]);
                    uobj.Mobile = Convert.ToString(sdr["mobile"]);
                    uobj.Email = Convert.ToString(sdr["email"]);
                    uobj.UserType = Convert.ToString(sdr["user_type"]);
                    uobj.UserName = Convert.ToString(sdr["user_login_name"]);
                    uobj.Password = Convert.ToString(sdr["user_login_password"]);


                  
                }
                con.Close();
            }
            return uobj;
        }

        public static  void  InsertUser(User uobj)
        {
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_admininsert_users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", uobj.Name);
                cmd.Parameters.AddWithValue("@gender", uobj.Gender);
                cmd.Parameters.AddWithValue("@mobile", uobj.Mobile);
                cmd.Parameters.AddWithValue("@email", uobj.Email);
                cmd.Parameters.AddWithValue("@usertype", uobj.UserType);
                cmd.Parameters.AddWithValue("@userlname", uobj.UserName);
                cmd.Parameters.AddWithValue("@userlpassword", uobj.Password);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void UpdateUser(User uobj)
        {
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_update_users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", uobj.Name);
                cmd.Parameters.AddWithValue("@gender", uobj.Gender);
                cmd.Parameters.AddWithValue("@mobile", uobj.Mobile);
                cmd.Parameters.AddWithValue("@email", uobj.Email);
                cmd.Parameters.AddWithValue("@usertype", uobj.UserType);
                cmd.Parameters.AddWithValue("@userlname", uobj.UserName);
                cmd.Parameters.AddWithValue("@userlpassword", uobj.Password);
                cmd.Parameters.AddWithValue("@userid", uobj.UserId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void RemoveUser(int uid)
        {
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_delete_users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", uid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
