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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_admininsert_users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", Textname.Text);
                cmd.Parameters.AddWithValue("@gender", Textgender.Text);
                cmd.Parameters.AddWithValue("@mobile", Textmobile.Text);
                cmd.Parameters.AddWithValue("@email", Textemail.Text);
                cmd.Parameters.AddWithValue("@usertype", Textutype.Text);
                cmd.Parameters.AddWithValue("@userlname", Textuname.Text);
                cmd.Parameters.AddWithValue("@userlpassword", Textpass.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("Default.aspx");
        }
    }
}