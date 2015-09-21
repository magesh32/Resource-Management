using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin : System.Web.UI.Page
{
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
    int b;
    //string technology = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
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
        if (!IsPostBack)
        {
            add();
            remove();
        }
    }
    protected void remove()
    {
        SqlConnection co = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
        co.Open();
        SqlCommand com1 = new SqlCommand("select emp_name from Employee where role='manager'", co);
        SqlDataReader sdr1 = com1.ExecuteReader();
        ListBox2.Items.Clear();
        while (sdr1.Read())
        {
            ListItem name1 = new ListItem();
            name1.Text = sdr1["emp_name"].ToString();
            name1.Value = sdr1["emp_name"].ToString();
            ListBox2.Items.Add(name1);
            ListBox2.Rows = ListBox2.Items.Count;
        }
        com1.Dispose();
        co.Close();
    }
    protected void add()
    {
        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
        conn.Open();
        SqlCommand com = new SqlCommand("select emp_name from Employee where emp_name<>'sekar' AND role<>'manager'", conn);
        SqlDataReader sdr = com.ExecuteReader();
        ListBox1.Items.Clear();
        while (sdr.Read())
        {
            ListItem name = new ListItem();
            name.Text = sdr["emp_name"].ToString();
            name.Value = sdr["emp_name"].ToString();
            ListBox1.Items.Add(name);
            ListBox1.Rows = ListBox1.Items.Count;

        }
        com.Dispose();
        conn.Close();
    }


    //public string emp_name { get; set; }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (ListBox1.SelectedIndex > -1)
        {

            List<int> select = ListBox1.GetSelectedIndices().ToList();
            SqlConnection connect = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
            connect.Open();
            string l = string.Empty;
            for (int i = 0; i < select.Count; i++)
            {
                l = ListBox1.Items[select[i]].ToString();
                SqlCommand command = new SqlCommand("update Employee set role='manager' where emp_name=@len", connect);
                command.Parameters.AddWithValue("@len", l);

                command.ExecuteNonQuery();

                command.Dispose();

            }
            connect.Close();
            Messagebox(l + " is added as a MANAGER!");

        }
        else
        {
            Messagebox("please Select the Employee Name!");
        }


        add();
        remove();

    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        if (ListBox2.SelectedIndex > -1)
        {
            List<int> select1 = ListBox2.GetSelectedIndices().ToList();
            SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
            conn.Open();
            string l1 = string.Empty;
            for (int i = 0; i < select1.Count; i++)
            {
                l1 = ListBox2.Items[select1[i]].ToString();
                SqlCommand com2 = new SqlCommand("update Employee set role='" + DropDownList1.SelectedValue + "' where emp_name='" + l1 + "'", conn);
                com2.ExecuteNonQuery();
                com2.Dispose();

            }

            conn.Close();
            Messagebox(l1 + " is removed as a MANAGER! and he is designated as a " + DropDownList1.SelectedItem);

        }
        else
        {
            Messagebox("please Select the Manager Name!");
        }


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
}

