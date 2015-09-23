using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class newpass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string email = (string)(Session["emailid"]);

        if (txt_emailid.Text.ToString() == email)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false");
            conn.Open();
            SqlCommand UpdateCommand = new SqlCommand("UPDATE Employee SET password=@pass where email_id='" + txt_emailid.Text + "' ", conn);
            UpdateCommand.Parameters.Add("@pass", System.Data.SqlDbType.VarChar).Value = txt_pwd.Text;
            UpdateCommand.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("login.aspx");
        }
        else
        {
            Messagebox("Invalid Email_ID!");
        }

    }
    private void Messagebox(string Message)
    {
        Label lblMessageBox = new Label();

        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";

        Page.Controls.Add(lblMessageBox);

    }
}