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
        cnn.ConnectionString = "Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false";
        cnn.Open();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int capacity = 0;
        if(drop_role.SelectedItem.Text=="Junior_Developer")
        {
            capacity=20;
        }
        else if (drop_role.SelectedItem.Text == "Senior_Developer")
        {
            capacity = 40;
        }
        else if (drop_role.SelectedItem.Text == "Tech_Lead")
        {
            capacity = 20;
        }

        //// String connectionString = WebConfigurationManager.ConnectionStrings["ConnectAntiFrack"].ConnectionString;
        SqlConnection sqlConn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false");
        

        sqlConn.Open();
        string que = "INSERT INTO Employee (emp_id, emp_name, email_id, technology, framework, role, password,Original_Capacity,manager,resigned,flag,Pro_flag) values (@id,@name,@email,@tech,@frame,@role,@pass,@capa,@man_id,@resign,@man_flag,@pro_flag)";
        //string query = "INSERT INTO signup (emp_name, email_id, technology, role, password) VALUES (@name, @email, @tech, @role, @pass); select emp_id from signup where emp_id=SCOPE IDENTITY()"; 
        SqlCommand myCommand = new SqlCommand(que, sqlConn);
        myCommand.Parameters.AddWithValue("@id", txt_empid.Text);
        myCommand.Parameters.AddWithValue("@name", txt_empname.Text);
        myCommand.Parameters.AddWithValue("@email", txt_emailid.Text);
        myCommand.Parameters.AddWithValue("@tech", drop_tech.Text);
        myCommand.Parameters.AddWithValue("@frame", drop_frame.Text);
        myCommand.Parameters.AddWithValue("@role", drop_role.Text);
        myCommand.Parameters.AddWithValue("@pass", txt_pwd.Text);
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
        if (drop_typeoftech.SelectedValue == "Proprietary")
        {
            drop_tech.Items.FindByValue(".Net").Enabled = true;
            drop_tech.Items.FindByValue("Php").Enabled = false;
            drop_tech.Items.FindByValue("Angular JS").Enabled = false;
        }
        else if (drop_typeoftech.SelectedValue == "Open Source")
        {
            drop_tech.Items.FindByValue(".Net").Enabled = false;
            drop_tech.Items.FindByValue("Php").Enabled = true;
            drop_tech.Items.FindByValue("Angular JS").Enabled = true;
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drop_tech.SelectedValue == ".Net")
        {
            drop_frame.Items.FindByValue("Ektron").Enabled = true;
            drop_frame.Items.FindByValue("Episerver").Enabled = true;
            drop_frame.Items.FindByValue("Kentico").Enabled = true;
            drop_frame.Items.FindByValue("Sitecore").Enabled = true;
            drop_frame.Items.FindByValue("Sharepoint").Enabled = true;
            drop_frame.Items.FindByValue("Majento").Enabled = false;
            drop_frame.Items.FindByValue("Drupal").Enabled = false;
            drop_frame.Items.FindByValue("Joomla").Enabled = false;
        }
        else if (drop_tech.SelectedValue == "Php")
        {
            drop_frame.Items.FindByValue("Ektron").Enabled = false;
            drop_frame.Items.FindByValue("Episerver").Enabled = false;
            drop_frame.Items.FindByValue("Kentico").Enabled = false;
            drop_frame.Items.FindByValue("Sitecore").Enabled = false;
            drop_frame.Items.FindByValue("Sharepoint").Enabled = false;
            drop_frame.Items.FindByValue("Majento").Enabled = true;
            drop_frame.Items.FindByValue("Drupal").Enabled = true;
            drop_frame.Items.FindByValue("Joomla").Enabled = true;
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


