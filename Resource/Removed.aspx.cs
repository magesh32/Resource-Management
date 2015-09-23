using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page
{
    int id;
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false");
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetDefaultView();
            Show_deleted_data();
            Showdata_deleted_resource();
        }
    }

    private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    //shows removed project or finished projects
    protected void Show_deleted_data()
    {
        int b = Convert.ToInt32(Session["Emp_Id"]);
        sqlConnn.Open();
        SqlCommand cmd4 = new SqlCommand("Select P_id,P_name,Client,Duration,technology,start_date,end_date,Manager_Id,SOW_status,Project_Status,deleted_date from projectlist where Manager_Id=@emp_id and Flag=@one", sqlConnn);
        cmd4.Parameters.AddWithValue("@emp_id", b);
        cmd4.Parameters.AddWithValue("@one", 1);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd4);
        adapter.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            grid_delproject.DataSource = dt2;
            grid_delproject.DataBind();
        }
        else
        {
            dt2.Rows.Add(dt2.NewRow());
            grid_delproject.DataSource = dt2;
            grid_delproject.DataBind();
            int totalcolums = grid_delproject.Rows[0].Cells.Count;
            grid_delproject.Rows[0].Cells.Clear();
            grid_delproject.Rows[0].Cells.Add(new TableCell());
            grid_delproject.Rows[0].Cells[0].ColumnSpan = totalcolums;
            grid_delproject.Rows[0].Cells[0].Text = "No Data Found";
        }
        sqlConnn.Close();
    }
    void Showdata_deleted_resource()
    {
        //FOR GRIDVIEW 1 RESOURCES SHOWING
        id = Convert.ToInt32(Request.QueryString["ID"]);
        sqlConnn.Open();
        SqlCommand cmd3 = new SqlCommand("select P.P_id,P.Emp_id,E.emp_name,P.Role,P.Capacity from pro_resources P JOIN Employee E on E.emp_id=P.Emp_id and P.P_id=@id and P.Flag='1' ", sqlConnn);
        cmd3.Parameters.AddWithValue("@id", id);
        SqlDataAdapter adapter3 = new SqlDataAdapter(cmd3);
        adapter3.Fill(dt3);
        //IF ROWS OF DATATABLE > 0 
        if (dt3.Rows.Count > 0)
        {
            grid_delresource.DataSource = dt3;
            grid_delresource.DataBind();
        }
        //IF NO RECORD FOUND
        else
        {
            dt3.Rows.Add(dt3.NewRow());
            grid_delresource.DataSource = dt3;
            grid_delresource.DataBind();
            int totalcolums = grid_delresource.Rows[0].Cells.Count;
            grid_delresource.Rows[0].Cells.Clear();
            grid_delresource.Rows[0].Cells.Add(new TableCell());
            grid_delresource.Rows[0].Cells[0].ColumnSpan = totalcolums;
            grid_delresource.Rows[0].Cells[0].Text = "No Data Found";
        }
        sqlConnn.Close();

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["ID"]);
        Response.Redirect("~/ProjectList.aspx?ID="+id);
    }
}