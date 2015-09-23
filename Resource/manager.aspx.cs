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
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false;MultipleActiveResultSets=True;");
    DataTable dt2 = new DataTable();
    int b,p_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Emp_Id"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
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
        List<int> Emp_id = new List<int>();
        string p_status = string.Empty;
        string query = "update projectlist set Project_status=@status,Flag=@flag where P_id=@pid";
        foreach (project_status project in list)
        {
            sqlConnn.Open();

            if (DateTime.Compare(project.start, DateTime.Now) > 0)
            {
                SqlCommand command1 = new SqlCommand(query, sqlConnn);
                p_status = "Will be started";
                command1.Parameters.AddWithValue("@status", p_status);
                command1.Parameters.AddWithValue("@pid", project.pid);
                command1.Parameters.AddWithValue("@flag", 0);
                command1.ExecuteNonQuery();
                sqlConnn.Close();
            }
            else if (DateTime.Compare(project.end, DateTime.Now) < 0)
            {
                //start
                p_id = project.pid;
                SqlCommand command_res = new SqlCommand("select Emp_id from pro_resources where P_id='" + project.pid + "' and Flag=@flag", sqlConnn);
                command_res.Parameters.AddWithValue("@flag", 0);
                SqlDataReader reader_res = command_res.ExecuteReader();
                while(reader_res.Read())
                {
                    Emp_id.Add( Convert.ToInt32(reader_res["Emp_id"]));
                }
                reader_res.Close();
                freeresource(Emp_id);
                //end
                SqlCommand command1 = new SqlCommand(query, sqlConnn);
                p_status = "End date finished";
                command1.Parameters.AddWithValue("@status", p_status);
                command1.Parameters.AddWithValue("@pid", project.pid);
                command1.Parameters.AddWithValue("@flag", 1);
                command1.ExecuteNonQuery();
                sqlConnn.Close();
            }
            else
            {
                SqlCommand command1 = new SqlCommand(query, sqlConnn);
                p_status = "In Progress";
                command1.Parameters.AddWithValue("@status", p_status);
                command1.Parameters.AddWithValue("@pid", project.pid);
                command1.Parameters.AddWithValue("@flag", 0);
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
        SqlCommand cmd2 = new SqlCommand("Select P_id,P_name,Project_id,Client,Duration,Project_Status from projectlist where Manager_id=@man_id", sqlConnn);
        cmd2.Parameters.AddWithValue("@man_id", b);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd2);
        adapt.Fill(dt2);
        //IF ROWS OF DATATABLE > 0 
        if (dt2.Rows.Count > 0)
        {
            grid_projects.DataSource = dt2;
            grid_projects.DataBind();
        }
        //IF NO RECORD FOUND
        else
        {
            dt2.Rows.Add(dt2.NewRow());
            grid_projects.DataSource = dt2;
            grid_projects.DataBind();
            int totalcolums = grid_projects.Rows[0].Cells.Count;
            grid_projects.Rows[0].Cells.Clear();
            grid_projects.Rows[0].Cells.Add(new TableCell());
            grid_projects.Rows[0].Cells[0].ColumnSpan = totalcolums;
            grid_projects.Rows[0].Cells[0].Text = "No Data Found";
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
   
    protected void linkbutton8_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session["Emp_Id"] = null;
        Response.Redirect("~/login.aspx");
    }


    protected void freeresource(List<int> emp_id)
    {
        int flag = 0;
        if (sqlConnn.State != System.Data.ConnectionState.Open)
        sqlConnn.Open();
        List<int> capacity = new List<int>();
        foreach (int emp in emp_id)
        {
            SqlCommand command_res2 = new SqlCommand("select Capacity, Flag from pro_resources where Emp_id='" + emp +"' and P_id='" + p_id + "'", sqlConnn);
            SqlDataReader reader_res2 = command_res2.ExecuteReader();
            while (reader_res2.Read())
            {
                flag = Convert.ToInt32(reader_res2["Flag"]);
                if (flag == 1)
                    break;
                capacity.Add(Convert.ToInt32(reader_res2["Capacity"]));
            }
            reader_res2.Close();
        }
        if (sqlConnn.State == System.Data.ConnectionState.Closed)
        sqlConnn.Close();
        assigncapacity(capacity, emp_id);
    }


    protected void assigncapacity(List<int> capacity, List<int> emp_id)
    {
        if (sqlConnn.State != System.Data.ConnectionState.Open)
            sqlConnn.Open();
        int balance = 0, update = 0;
        for (int i = 0; i < emp_id.Count; i++)
        {
            SqlCommand command_res3 = new SqlCommand("select Balance_Capacity from Employee where Emp_id='" + emp_id[i] + "'", sqlConnn);
            SqlDataReader reader_res3 = command_res3.ExecuteReader();
            while (reader_res3.Read())
            {
                balance = Convert.ToInt32(reader_res3["Balance_Capacity"]);
                update = balance + capacity[i];
                SqlCommand command_res2 = new SqlCommand("update Employee set Balance_Capacity='" + update + "'where Emp_id='" + emp_id[i] + "'", sqlConnn);
                command_res2.ExecuteNonQuery();
                SqlCommand command_res4 = new SqlCommand("update pro_resources set Flag='" + 1 + "'where Emp_id='" + emp_id[i] + "' and P_id='" + p_id + "'", sqlConnn);
                command_res4.ExecuteNonQuery();
            }
            reader_res3.Close();

            if (sqlConnn.State == System.Data.ConnectionState.Closed)
                sqlConnn.Close();
        }

    }
}




//changed
public class project_status
{
    public int pid { get; set; }
    public DateTime start { get; set; }
    public DateTime end { get; set; }
}

