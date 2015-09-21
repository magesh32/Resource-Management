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
    SqlConnection con = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
    protected void Page_Load(object sender, EventArgs e)
    {
        b = Convert.ToInt32(Session["Emp_Id"]);
        con.Open();
        SqlCommand mycommand = new SqlCommand("select emp_name,role from Employee where emp_id=@id ", con);
        mycommand.Parameters.AddWithValue("@id", b);
        SqlDataReader read = mycommand.ExecuteReader();
        if (read.Read())
        {
            lblin.Text = "Welcome, " + read["emp_name"].ToString();
            desig.Text = "Designation: " + read["role"].ToString();
        }
        read.Close();

        con.Close();
        if (!IsPostBack)
        {
                SetDefaultView();
               
        }

    }

    private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        con.Open();
        MultiView1.ActiveViewIndex = 1;
        SqlCommand mycommand1 = new SqlCommand("select P_id from pro_resources where Emp_id=@id", con);
        mycommand1.Parameters.AddWithValue("@id", b);
        SqlDataReader read1 = mycommand1.ExecuteReader();
        DropDownList1.Items.Clear();
        while (read1.Read())
        {
            var item = new ListItem();
            item.Text = Convert.ToInt32(read1["P_id"]).ToString();
            item.Value = Convert.ToInt32(read1["P_id"]).ToString();
            DropDownList1.Items.Add(item);
        }
        read1.Close();
        con.Close();
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        SqlConnection co = new SqlConnection(@"Data Source=AMX-522-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
        con.Open();
        SqlCommand coo = new SqlCommand("select P.Emp_id,E.emp_name,P.Role,P.Status,P.Rem_date from pro_resources P join Employee E on P.Emp_id=E.emp_id and P.P_id='" + DropDownList1.Text + "' and P.Emp_id<>'"+b+"'", con);

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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void logout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/login.aspx");
    }
}
