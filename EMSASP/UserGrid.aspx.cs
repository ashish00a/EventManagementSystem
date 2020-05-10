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
    public partial class UserGrid : System.Web.UI.Page
    {
        String cs = ConfigurationManager.ConnectionStrings["EMSCS"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            SqlConnection SQLConn = new SqlConnection(cs);
            SqlDataAdapter SQLAdapter = new SqlDataAdapter("Select * from USERS", SQLConn);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);

            GridView1.DataSource = DT;
            GridView1.DataBind();

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection SQLConn = new SqlConnection(cs);
            SqlDataAdapter SQLAdapter = new SqlDataAdapter("insert into USERS values('" + txtname.Text + "','" + txtgender.Text + "','" + txtmobile.Text + "','" + Textemail.Text + "','" + txtutype.Text + "','" + txtuname.Text + "','" +txtpass.Text + "')", SQLConn);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);

            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection SQLConn = new SqlConnection(cs);
            int idd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            TextBox tname = GridView1.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox;
            TextBox tgender = GridView1.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox;
            TextBox tmobile = GridView1.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox;
            TextBox temail = GridView1.Rows[e.RowIndex].Cells[5].Controls[0] as TextBox;
            TextBox tutype = GridView1.Rows[e.RowIndex].Cells[6].Controls[0] as TextBox;
            TextBox tuname = GridView1.Rows[e.RowIndex].Cells[7].Controls[0] as TextBox;
            TextBox tpass = GridView1.Rows[e.RowIndex].Cells[8].Controls[0] as TextBox;

            SqlDataAdapter SQLAdapter = new SqlDataAdapter("update USERS set user_name='" + tname.Text + "', gender='" + tgender.Text + "',mobile='"+tmobile.Text + "',email='" + temail.Text + "',user_type='" + tutype.Text + "',user_login_name='" + tuname.Text + "',user_login_password='" + tpass.Text + "' where user_id=" + idd + "", SQLConn);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);

            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection SQLConn = new SqlConnection(cs);
            int idd = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlDataAdapter SQLAdapter = new SqlDataAdapter("delete from USERS where user_id=" + idd + "", SQLConn);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);

            BindGrid();
        }
    }
}