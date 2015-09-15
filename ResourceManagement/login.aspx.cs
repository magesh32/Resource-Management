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
       
    }
    protected void Btn_Click(object sender, EventArgs e)
    {
        Session["Emp_Id"] = TextBox1.Text;
        SqlConnection con = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
        con.Open();

        SqlCommand command = new SqlCommand("select role from Employee where emp_id='" + TextBox1.Text + "' AND password='" + TextBox2.Text + "'", con);

        SqlDataReader sdr = command.ExecuteReader();

        if (sdr.Read())
        {
            //PAGE REDIRECTION IF LOGGING IN PERSON IS MANAGER 
            if (sdr[0].ToString() == "manager")
            {
                Response.Redirect("manager.aspx");

            }
            else if (sdr[0].ToString() == "admin")
            {
                //PAGE REDIRECTION IF LOGGING IN PERSON IS A DEVELOPER
                Response.Redirect("admin.aspx");
            }
            else
            {
                Response.Redirect("developer.aspx");
            }

        }
        command.Dispose();
        con.Close();
    }
}