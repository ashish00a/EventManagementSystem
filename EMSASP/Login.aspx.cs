using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMSASP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

           
            int USER_ID = Convert.ToInt32(TextBox1.Text);
            string Pass = Convert.ToString(TextBox2.Text);
            Session["REST_ID"] = USER_ID;
            int uid = 0;
            string password ="ss";
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_getbyid_users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", USER_ID);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    uid = Convert.ToInt32(sdr["user_id"]);
                    password = Convert.ToString(sdr["user_login_password"]);
                }
                con.Close();
            }
            if (USER_ID == uid && Pass.Equals(password))
            {
                Response.Redirect("UserGrid.aspx");  }
            else
            {
                Response.Write("Invalid credintials");
                Response.Redirect("Login.aspx");

            }
        }
    }
}