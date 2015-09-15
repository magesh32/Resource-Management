using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class singup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection();
        cnn.ConnectionString = "Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True";
        cnn.Open();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //// String connectionString = WebConfigurationManager.ConnectionStrings["ConnectAntiFrack"].ConnectionString;
        SqlConnection sqlConn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
        

        sqlConn.Open();
        string que = "INSERT INTO Employee (emp_id, emp_name, email_id, technology, framework, role, password) values (@id,@name,@email,@tech,@frame,@role,@pass)";
        //string query = "INSERT INTO signup (emp_name, email_id, technology, role, password) VALUES (@name, @email, @tech, @role, @pass); select emp_id from signup where emp_id=SCOPE IDENTITY()"; 
        SqlCommand myCommand = new SqlCommand(que, sqlConn);
        myCommand.Parameters.AddWithValue("@id", emp_id1.Text);
        myCommand.Parameters.AddWithValue("@name", TextBox1.Text);
        myCommand.Parameters.AddWithValue("@email", TextBox2.Text);
        myCommand.Parameters.AddWithValue("@tech", DropDownList3.Text);
        myCommand.Parameters.AddWithValue("@frame", DropDownList1.Text);
        myCommand.Parameters.AddWithValue("@role", DropDownList2.Text);
        myCommand.Parameters.AddWithValue("@pass", TextBox3.Text);
        myCommand.ExecuteNonQuery();
        sqlConn.Close();
        Response.Redirect("login.aspx");
    }
    //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Hello ' + TextBox1.Text);", true);
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedValue==".Net")
        {
            DropDownList1.Items.FindByValue("Ektron").Enabled = true;
            DropDownList1.Items.FindByValue("Episerver").Enabled = true;
            DropDownList1.Items.FindByValue("Majento").Enabled = false;
            DropDownList1.Items.FindByValue("Drupal").Enabled = false;
        }
        else if (DropDownList3.SelectedValue == "Php")
        {
            DropDownList1.Items.FindByValue("Ektron").Enabled = false;
            DropDownList1.Items.FindByValue("Episerver").Enabled = false;
            DropDownList1.Items.FindByValue("Majento").Enabled = true;
            DropDownList1.Items.FindByValue("Drupal").Enabled = true;
        }
    }
}