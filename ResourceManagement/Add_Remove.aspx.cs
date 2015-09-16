using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_Remove : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void add()
    {
        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");

        conn.Open();
        SqlCommand com = new SqlCommand("select emp_name from Employee where role<>'manager' AND role<>'admin' AND flag<>1", conn);
        SqlDataReader sdr = com.ExecuteReader();
        ListBox1.Items.Clear();
        while (sdr.Read())
        {
            ListItem name = new ListItem();
            name.Text = sdr["emp_name"].ToString();
            name.Value = sdr["emp_name"].ToString();
            //ListItem rol = new ListItem();
            //rol.Text = sdr["role"].ToString();
            //rol.Value = sdr["role"].ToString();
            ListBox1.Items.Add(name);
            ListBox1.Rows = ListBox1.Items.Count;

        }
        com.Dispose();

        conn.Close();
    }
    protected void remove()
    {
        string id = (string)(Session["Emp_Id"]);
        SqlConnection co = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
        co.Open();
        SqlCommand com1 = new SqlCommand("select emp_name from Employee where manager='" + id + "'", co);
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


    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
        conn.Open();


        string eid = (string)(Session["Emp_Id"]);
        string l = string.Empty;

        if (ListBox1.SelectedIndex > -1)
        {

            List<int> select = ListBox1.GetSelectedIndices().ToList();
            for (int i = 0; i < select.Count; i++)
            {
                int a = 1;
                l = ListBox1.Items[select[i]].ToString();
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
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
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

    protected void Button1_Click1(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
        conn.Open();


        string eid = (string)(Session["Emp_Id"]);
        string l = string.Empty;

        if (ListBox2.SelectedIndex > -1)
        {

            List<int> select = ListBox2.GetSelectedIndices().ToList();
            for (int i = 0; i < select.Count; i++)
            {
                int a = 0;
                l = ListBox2.Items[select[i]].ToString();
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
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        remove();
    }
}

