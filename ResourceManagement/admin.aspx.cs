using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
     protected void Button1_Click(object sender, EventArgs e)
    {

        if (ListBox1.SelectedIndex > -1)
        {

            List<int> select = ListBox1.GetSelectedIndices().ToList();
            SqlConnection connect = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
            connect.Open();
            for (int i = 0; i < select.Count; i++)
            {
              string l = ListBox1.Items[select[i]].ToString();    
              SqlCommand command = new SqlCommand("update Employee set role='manager' where emp_name=@len ", connect);
                command.Parameters.AddWithValue("@len", l);

                command.ExecuteNonQuery();
                
                command.Dispose();
               
            }
            connect.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
        conn.Open();
        SqlCommand com = new SqlCommand("select emp_name from employee where emp_name<>'sekar' and role<>'manager'", conn);
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
}
