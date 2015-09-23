using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin : System.Web.UI.Page
{
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false");
    int b;
    //string technology = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            add();
            remove();
        }
        if (Session["Emp_Id"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {

            //technology=Session["Tech"].ToString();

            b = Convert.ToInt32(Session["Emp_Id"]);
            sqlConnn.Open();
            SqlCommand mycommand = new SqlCommand("select emp_name,role from Employee where emp_id=@id ", sqlConnn);
            mycommand.Parameters.AddWithValue("@id", b);

            SqlDataReader read = mycommand.ExecuteReader();

            if (read.Read())
            {
                lblin.Text = "Welcome, " + read["emp_name"].ToString();
                desig.Text = "Designation: " + read["role"].ToString();

            }

            read.Close();
            sqlConnn.Close();
           
        }
    }
    protected void remove()
    {
        SqlConnection co = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false");
        co.Open();
        SqlCommand com1 = new SqlCommand("select emp_name from Employee where role='Manager'", co);
        SqlDataReader sdr1 = com1.ExecuteReader();
        list_remove.Items.Clear();
        while (sdr1.Read())
        {
            ListItem name1 = new ListItem();
            name1.Text = sdr1["emp_name"].ToString();
            name1.Value = sdr1["emp_name"].ToString();
            list_remove.Items.Add(name1);
            list_remove.Rows = list_remove.Items.Count;
        }
        com1.Dispose();
        co.Close();
    }
    protected void add()
    {
        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false");
        conn.Open();
        SqlCommand com = new SqlCommand("select emp_name from Employee where role NOT IN ('Manager','Admin')", conn);
        SqlDataReader sdr = com.ExecuteReader();
        list_add.Items.Clear();
        while (sdr.Read())
        {
            ListItem name = new ListItem();
            name.Text = sdr["emp_name"].ToString();
            name.Value = sdr["emp_name"].ToString();
            list_add.Items.Add(name);
            list_add.Rows = list_add.Items.Count;

        }
        com.Dispose();
        conn.Close();
    }


    //public string emp_name { get; set; }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection connect = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false");
        if (list_add.SelectedIndex > -1)
        {

            List<int> select = list_add.GetSelectedIndices().ToList();
            
            connect.Open();
            string l = string.Empty;
            for (int i = 0; i < select.Count; i++)
            {
                l = list_add.Items[select[i]].ToString();
                SqlCommand command = new SqlCommand("update Employee set role='Manager' where emp_name=@len", connect);
                command.Parameters.AddWithValue("@len", l);

                command.ExecuteNonQuery();
               
                command.Dispose();

            }
            Messagebox(l + " is added as a MANAGER!");
           
           

        }
        else
        {
            Messagebox("please Select the Employee Name!");
        }

        connect.Close();
        add();
        remove();

    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false");
        if (list_remove.SelectedIndex > -1)
        {
            List<int> select1 = list_remove.GetSelectedIndices().ToList();
            
            conn.Open();
            string l1 = string.Empty;
            for (int i = 0; i < select1.Count; i++)
            {
                l1 = list_remove.Items[select1[i]].ToString();
                SqlCommand com2 = new SqlCommand("update Employee set role='" + role.SelectedValue + "' where emp_name='" + l1 + "'", conn);
                com2.ExecuteNonQuery();
                com2.Dispose();

            }

          
            Messagebox(l1 + " is removed as a MANAGER! and he is designated as a " + role.SelectedItem);

        }
        else
        {
            Messagebox("please Select the Manager Name!");
        }

        conn.Close();
        remove();
        add();
    }


    private void Messagebox(string Message)
    {
        Label lblMessageBox = new Label();

        lblMessageBox.Text =
            "<script language='javascript'>" + Environment.NewLine +
            "window.alert('" + Message + "')</script>";

        Page.Controls.Add(lblMessageBox);

    }
    protected void linkbutton4_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session["Emp_Id"] = null;
        Response.Redirect("~/login.aspx");
    }
}

