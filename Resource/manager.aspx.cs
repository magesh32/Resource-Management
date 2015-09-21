using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.ModelBinding;

public partial class manager : System.Web.UI.Page
{
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
    DataTable dt2 = new DataTable();
    int b;

    protected void Page_Load(object sender, EventArgs e)
    {
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

            ShowData();
            project_status();
        }


    }


    //TO CHECK END DATE OF THE PROJECT 
    protected void project_status()
    {

        List<project_status> list = new List<project_status>();
        sqlConnn.Open();
        SqlCommand command = new SqlCommand("select P_id,start_date,end_date from projectlist", sqlConnn);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            project_status pro = new project_status();
            pro.pid = Convert.ToInt32(reader["P_id"]);
            pro.start = Convert.ToDateTime(reader["start_date"]);
            pro.end = Convert.ToDateTime(reader["end_date"]);
            list.Add(pro);
        }
        sqlConnn.Close();
        status(list);
    }
   
    protected void status(List<project_status> list)
    {

        string p_status = string.Empty;
        string query = "update projectlist set Project_status=@status where P_id=@pid";
        foreach (project_status project in list)
        {
            sqlConnn.Open();

            if (DateTime.Compare(project.start, DateTime.Now) > 0)
            {
                SqlCommand command1 = new SqlCommand(query, sqlConnn);
                p_status = "Will be started";
                command1.Parameters.AddWithValue("@status", p_status);
                command1.Parameters.AddWithValue("@pid", project.pid);
                command1.ExecuteNonQuery();
                sqlConnn.Close();
            }
            else if (DateTime.Compare(project.end, DateTime.Now) < 0)
            {
                SqlCommand command1 = new SqlCommand(query, sqlConnn);
                p_status = "End date finished";
                command1.Parameters.AddWithValue("@status", p_status);
                command1.Parameters.AddWithValue("@pid", project.pid);
                command1.ExecuteNonQuery();
                sqlConnn.Close();
            }
            else
            {
                SqlCommand command1 = new SqlCommand(query, sqlConnn);
                p_status = "In Progress";
                command1.Parameters.AddWithValue("@status", p_status);
                command1.Parameters.AddWithValue("@pid", project.pid);
                command1.ExecuteNonQuery();
                sqlConnn.Close();
            }
            if (sqlConnn.State != System.Data.ConnectionState.Closed)
                sqlConnn.Close();
        }


    }

    //DATA BINDING TO GRIDVIEW

    protected void ShowData()
    {
        int b = Convert.ToInt32(Session["Emp_Id"]);
        sqlConnn.Open();
        SqlCommand cmd2 = new SqlCommand("Select P_id,P_name,Project_id,Client,Duration,Project_Status from projectlist where Manager_id=@man_id and Flag=@fla", sqlConnn);
        cmd2.Parameters.AddWithValue("@man_id", b);
        cmd2.Parameters.AddWithValue("@fla", 0);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd2);
        adapt.Fill(dt2);
        //IF ROWS OF DATATABLE > 0 
        if (dt2.Rows.Count > 0)
        {
            GridView3.DataSource = dt2;
            GridView3.DataBind();
        }
        //IF NO RECORD FOUND
        else
        {
            dt2.Rows.Add(dt2.NewRow());
            GridView3.DataSource = dt2;
            GridView3.DataBind();
            int totalcolums = GridView3.Rows[0].Cells.Count;
            GridView3.Rows[0].Cells.Clear();
            GridView3.Rows[0].Cells.Add(new TableCell());
            GridView3.Rows[0].Cells[0].ColumnSpan = totalcolums;
            GridView3.Rows[0].Cells[0].Text = "No Data Found";
        }
        sqlConnn.Close();
    }

    //THIS IS TO GET THE SELECT BUTTON ACTION AND NAVIGATE TO PROJECTLIST PAGE WITH SELECTED PROJECT ID
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("~/ProjectList.aspx?ID=" + id);
        }


    }
    //For session
    protected void logout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/login.aspx");
    }


}
//changed
public class project_status
{
    public int pid { get; set; }
    public DateTime start { get; set; }
    public DateTime end { get; set; }
}

