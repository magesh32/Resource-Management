using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class developer : System.Web.UI.Page
{
     int b;
    SqlConnection con=new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
    protected void Page_Load(object sender, EventArgs e)
    {
         b = Convert.ToInt32(Session["Emp_id"]);
        con.Open();
        SqlCommand mycommand = new SqlCommand("select emp_name from Employee where emp_id=@id ", con);
        mycommand.Parameters.AddWithValue("@id", b);
        SqlDataReader read = mycommand.ExecuteReader();
        if (read.Read())
        {
            lblin.Text = "Welcome, " + read["emp_name"].ToString();
        }
        read.Close();
        con.Close();

        if (!IsPostBack)
        {
            showdata();
        }

    }

    
    protected void showdata()
    {
        con.Open();
        SqlCommand com = new SqlCommand("select P_id from pro_resources where emp_id=@id", con);
        com.Parameters.AddWithValue("@id", b);
        SqlDataReader sdr = com.ExecuteReader();
        com.Dispose();
        con.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection co = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
        con.Open();
        SqlCommand coo = new SqlCommand("select * from pro_resources where P_id='" + TextBox1.Text + "' and emp_id<>'"+ b +"'", con);

        SqlDataAdapter da = new SqlDataAdapter(coo);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
        con.Close();
    }
}
