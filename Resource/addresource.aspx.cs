using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addresource : System.Web.UI.Page
{
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
    int b;
    string technology = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Tech"].ToString() != null && Session["Emp_Id"].ToString()!=null)
        {
            technology = Session["Tech"].ToString();

            b = Convert.ToInt32(Session["Emp_Id"].ToString());
        }
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
        if (!IsPostBack)
        {
            add();
            remove();
        }
    }
    protected void add()
    {
        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");

        conn.Open();
        SqlCommand com = new SqlCommand("select emp_name from Employee where role<>'manager' AND role<>'admin' AND flag<>1 AND technology=@tech", conn);
         com.Parameters.AddWithValue("@tech", technology);
        SqlDataReader sdr = com.ExecuteReader();
        ListBox4.Items.Clear();
        while (sdr.Read())
        {
            ListItem name = new ListItem();
            name.Text = sdr["emp_name"].ToString();
            name.Value = sdr["emp_name"].ToString();
            ListBox4.Items.Add(name);
            ListBox4.Rows = ListBox4.Items.Count;

        }
        com.Dispose();

        conn.Close();
    }
    protected void remove()
    {
        string id = (string)(Session["Emp_Id"]);
        SqlConnection co = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
        co.Open();
        SqlCommand com1 = new SqlCommand("select emp_name from Employee where manager='" + id + "'", co);
        SqlDataReader sdr1 = com1.ExecuteReader();
        ListBox5.Items.Clear();
        while (sdr1.Read())
        {
            ListItem name1 = new ListItem();
            name1.Text = sdr1["emp_name"].ToString();
            name1.Value = sdr1["emp_name"].ToString();
            ListBox5.Items.Add(name1);
            ListBox5.Rows = ListBox5.Items.Count;
        }
        com1.Dispose();
        co.Close();
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {


        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
        conn.Open();


        string eid = (string)(Session["empid"]);
        string l = string.Empty;

        if (ListBox5.SelectedIndex > -1)
        {

            List<int> select = ListBox5.GetSelectedIndices().ToList();
            for (int i = 0; i < select.Count; i++)
            {
                int a = 0;
                l = ListBox5.Items[select[i]].ToString();
                SqlCommand command = new SqlCommand("update Employee set manager='',flag='" + a + "' where emp_name=@len", conn);
                command.Parameters.AddWithValue("@len", l);
                command.ExecuteNonQuery();
                command.Dispose();
            }
            Messagebox(l + " is removed successfully!");
        }

        else
        {
            Messagebox(" Please select the Employee Name!");
        }
        conn.Close();
        remove();
        add();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
        conn.Open();


        string eid = (string)(Session["Emp_Id"]);
        string l = string.Empty;

        if (ListBox4.SelectedIndex > -1)
        {

            List<int> select = ListBox4.GetSelectedIndices().ToList();
            for (int i = 0; i < select.Count; i++)
            {
                int a = 1;
                l = ListBox4.Items[select[i]].ToString();
                SqlCommand command = new SqlCommand("update Employee set manager=@eid,flag=@flag where emp_name=@len", conn);
                command.Parameters.AddWithValue("@flag", a);
                command.Parameters.AddWithValue("@len", l);
                command.Parameters.AddWithValue("@eid", eid);
                command.ExecuteNonQuery();
                command.Dispose();
            }
            Messagebox(l + " is added successfully!");
        }

        else
        {
            Messagebox(" Please select the Employee Name!");
        }
        conn.Close();
        add();
        remove();
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