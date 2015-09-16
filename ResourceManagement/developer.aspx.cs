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
   
//    protected void BindContrydropdown()
//{
////conenction path for database
//using (SqlConnection con = new SqlConnection("Data Source=SureshDasari;Integrated Security=true;Initial Catalog=MySampleDB"))
//{
//con.Open();
//SqlCommand cmd = new SqlCommand("Select UserId,UserName FROM UserInformation", con);
//SqlDataAdapter da = new SqlDataAdapter(cmd);
//DataSet ds = new DataSet();
//da.Fill(ds);
//ddlCountry.DataSource = ds;
//ddlCountry.DataTextField = "UserName";
//ddlCountry.DataValueField = "UserId";
//ddlCountry.DataBind();
//ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
//con.Close();
//}
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection co = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
        con.Open();
        SqlCommand coo = new SqlCommand("select * from pro_resources where P_id='" + DropDownList1.Text + "' and emp_id<>'" + b + "'", con);

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
}
