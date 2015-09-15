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

        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
        conn.Open();
        SqlCommand UpdateCommand = new SqlCommand("UPDATE Employee SET password=@pass where email_id='" + TextBox3.Text + "' ", conn);

        UpdateCommand.Parameters.Add("@pass",System.Data.SqlDbType.VarChar).Value = TextBox1.Text;

        
        UpdateCommand.ExecuteNonQuery();
        conn.Close();
        GridView1.DataBind();
        Response.Redirect("login.aspx");
    }
   
}