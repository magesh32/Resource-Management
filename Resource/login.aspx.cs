using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }
    protected void Btn_Click(object sender, EventArgs e)
    {
        lbl_error.Visible = true;
        Session["Emp_Id"] = txt_empid.Text;
        SqlConnection con = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;Integrated Security=True");
        con.Open();

        SqlCommand command = new SqlCommand("select role from Employee where emp_id='" + txt_empid.Text + "' AND password='" + txt_password.Text + "'", con);

        SqlDataReader sdr = command.ExecuteReader();

        if (sdr.Read())
        {
            //PAGE REDIRECTION IF LOGGING IN PERSON IS MANAGER 
            if (sdr[0].ToString() == "Manager")
            {
                Response.Redirect("manager.aspx");

            }
            else if (sdr[0].ToString() == "Admin")
            {
                //PAGE REDIRECTION IF LOGGING IN PERSON IS A DEVELOPER
                Response.Redirect("admin.aspx");
            }
            else
            {
                Response.Redirect("developer.aspx");
            }
        }
        else
        {
            lbl_error.Text = "Invalid Id and Password";
        }
        command.Dispose();
        con.Close();
    }
}