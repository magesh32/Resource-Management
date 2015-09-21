using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
 //updated
public partial class singup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection();
        cnn.ConnectionString = "Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false";
        cnn.Open();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int capacity = 0;
        if(DropDownList2.SelectedItem.Text=="Junior_Developer")
        {
            capacity=20;
        }
        else if (DropDownList2.SelectedItem.Text == "Senior_Developer")
        {
            capacity = 40;
        }
        else if(DropDownList2.SelectedItem.Text == "Tech_Lead")
        {
            capacity = 20;
        }

        //// String connectionString = WebConfigurationManager.ConnectionStrings["ConnectAntiFrack"].ConnectionString;
        SqlConnection sqlConn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
        

        sqlConn.Open();
        string que = "INSERT INTO Employee (emp_id, emp_name, email_id, technology, framework, role, password,Original_Capacity,manager,resigned,flag,Pro_flag) values (@id,@name,@email,@tech,@frame,@role,@pass,@capa,@man_id,@resign,@man_flag,@pro_flag)";
        //string query = "INSERT INTO signup (emp_name, email_id, technology, role, password) VALUES (@name, @email, @tech, @role, @pass); select emp_id from signup where emp_id=SCOPE IDENTITY()"; 
        SqlCommand myCommand = new SqlCommand(que, sqlConn);
        myCommand.Parameters.AddWithValue("@id", emp_id1.Text);
        myCommand.Parameters.AddWithValue("@name", TextBox1.Text);
        myCommand.Parameters.AddWithValue("@email", TextBox2.Text);
        myCommand.Parameters.AddWithValue("@tech", DropDownList3.Text);
        myCommand.Parameters.AddWithValue("@frame", DropDownList1.Text);
        myCommand.Parameters.AddWithValue("@role", DropDownList2.Text);
        myCommand.Parameters.AddWithValue("@pass", TextBox3.Text);
        myCommand.Parameters.AddWithValue("@capa", capacity);
        myCommand.Parameters.AddWithValue("@man_id", 0);
        myCommand.Parameters.AddWithValue("@resign", 0);     
        myCommand.Parameters.AddWithValue("@man_flag", 0);
        myCommand.Parameters.AddWithValue("@pro_flag", 0);
        myCommand.ExecuteNonQuery();
        sqlConn.Close();
       // Messagebox("Singup successfull");
        Response.Redirect("login.aspx");
        
    }
    //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Hello ' + TextBox1.Text);", true);
    protected void typeoftech1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (typeoftech1.SelectedValue == "Proprietary")
        {
            DropDownList3.Items.FindByValue(".Net").Enabled = true;
            DropDownList3.Items.FindByValue("Php").Enabled = false;
            DropDownList3.Items.FindByValue("Angular JS").Enabled = false;
        }
        else if (typeoftech1.SelectedValue == "Open Source")
        {
            DropDownList3.Items.FindByValue(".Net").Enabled = false;
            DropDownList3.Items.FindByValue("Php").Enabled = true;
            DropDownList3.Items.FindByValue("Angular JS").Enabled = true;
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedValue==".Net")
        {
            DropDownList1.Items.FindByValue("Ektron").Enabled = true;
            DropDownList1.Items.FindByValue("Episerver").Enabled = true;
            DropDownList1.Items.FindByValue("Kentico").Enabled = true;
            DropDownList1.Items.FindByValue("Sitecore").Enabled = true;
            DropDownList1.Items.FindByValue("Sharepoint").Enabled = true;
            DropDownList1.Items.FindByValue("Majento").Enabled = false;
            DropDownList1.Items.FindByValue("Drupal").Enabled = false;
            DropDownList1.Items.FindByValue("Joomla").Enabled = false;
        }
        else if (DropDownList3.SelectedValue == "Php")
        {
            DropDownList1.Items.FindByValue("Ektron").Enabled = false;
            DropDownList1.Items.FindByValue("Episerver").Enabled = false;
            DropDownList1.Items.FindByValue("Kentico").Enabled = false;
            DropDownList1.Items.FindByValue("Sitecore").Enabled = false;
            DropDownList1.Items.FindByValue("Sharepoint").Enabled = false;
            DropDownList1.Items.FindByValue("Majento").Enabled = true;
            DropDownList1.Items.FindByValue("Drupal").Enabled = true;
            DropDownList1.Items.FindByValue("Joomla").Enabled = true;
        }
    }

    protected void typeoftech1_SelectedIndexChanged1(object sender, EventArgs e)
    {

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


