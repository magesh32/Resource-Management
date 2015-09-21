using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class projects : System.Web.UI.Page
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
            showdata();
   
        }

    }


    protected void showdata()
    {
        con.Open();
        SqlCommand com4 = new SqlCommand("select emp_id,emp_name,email_id,typeof_tech,technology,framework,role,Original_Capacity from employee where manager='" + b + "'", con);

        SqlDataAdapter da = new SqlDataAdapter(com4);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        con.Close();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        showdata();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        showdata();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int org_capacity = 0, balanced = 0, bal_capacity=0;
        con.Open();
        Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_Id") as Label;
        TextBox name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox mail = GridView1.Rows[e.RowIndex].FindControl("txt_mail") as TextBox;
        TextBox capacity = GridView1.Rows[e.RowIndex].FindControl("txt_capacity") as TextBox;
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("lbl_framework");
        DropDownList role = (DropDownList)row.FindControl("role");
        DropDownList drop = (DropDownList)row.FindControl("typeoftech");
        DropDownList drop1 = (DropDownList)row.FindControl("tech");
        DropDownList drop2 = (DropDownList)row.FindControl("frame");
        GridView1.EditIndex = -1;
        //UPDATING BLANCED AND PRO_FLAG
        SqlCommand command = new SqlCommand("select Original_Capacity,Balance_Capacity from Employee where emp_id='" + Int32.Parse(id.Text) + "'", con);
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            org_capacity = Convert.ToInt32(reader["Original_Capacity"]);
            bal_capacity = Convert.ToInt32(reader["Original_Capacity"]);
        }
        reader.Close();
        
        //UPDATED IN EMPLOYEE TABLE
       
        SqlCommand cmd3 = new SqlCommand("Update Employee set Original_Capacity='" + Int32.Parse(capacity.Text) + "',emp_name='" + name.Text + "',email_id='" + mail.Text +"',Role='"+role.SelectedValue+ "',typeof_tech='" + drop.SelectedValue + "', technology='" + drop1.SelectedValue + "',framework='" + drop2.SelectedValue+"' where emp_id='" + Int32.Parse(id.Text)+"'" , con);
        
        cmd3.ExecuteNonQuery();

        //UPDATED IN PRO_RESOURCES TABLE
        SqlCommand cmd = new SqlCommand("update pro_resources set Role='" + role.SelectedValue + "' where Emp_id='" + Int32.Parse(id.Text) + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        if (org_capacity != Int32.Parse(capacity.Text))
        {
            if (org_capacity < Int32.Parse(capacity.Text))
            {
                balanced =Int32.Parse(capacity.Text)- org_capacity;
                balanced += bal_capacity;
            }
        }
        con.Open();
        SqlCommand command1 = new SqlCommand("update Employee set Balance_Capacity='" + balanced + "',Pro_flag='" + 0 + "' where emp_id='" + Int32.Parse(id.Text) + "'", con);
        command1.ExecuteNonQuery();

        con.Close();
        GridView1.EditIndex = -1;
        showdata();

    }
    //changed
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button up = (Button)e.Row.FindControl("btn_Update");
            if (up != null)
                up.Attributes.Add("onclick", "javascript:return " +
                     "confirm('Are you sure you want to delete this record " +
                     DataBinder.Eval(e.Row.DataItem, "emp_id") + "')");
            Button edit = (Button)e.Row.FindControl("btn_Edit");
            if (edit != null)
                edit.Attributes.Add("onclick", "javascript:return " +
                     "confirm('Are you sure you want to Edit this record " +
                     DataBinder.Eval(e.Row.DataItem, "emp_id") + "')");
        }
    }


}