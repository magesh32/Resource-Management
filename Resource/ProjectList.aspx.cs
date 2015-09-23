using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
public partial class ProjectList : System.Web.UI.Page
{
    int b, id;
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project1;User Id=sa;Password=sa5;Trusted_connection=false");
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    int c;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Emp_Id"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            c = Convert.ToInt32(Session["Emp_Id"]);
            sqlConnn.Open();
            SqlCommand mycommand = new SqlCommand("select emp_name,role from Employee where emp_id=@id ", sqlConnn);
            mycommand.Parameters.AddWithValue("@id", c);

            SqlDataReader read = mycommand.ExecuteReader();

            if (read.Read())
            {
                welcome.Text = "Welcome, " + read["emp_name"].ToString();
                role.Text = "Designation: " + read["role"].ToString();

            }

            read.Close();
            sqlConnn.Close();

            if (!IsPostBack)
            {
                SetDefaultView();
                //BINDS DATA TO GRIDVIEW
                ShowData();
                Showdata1();
                BindData();
            }
        }
    }
    private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }
   
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void LinkButton2_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;


    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        //id = Convert.ToInt32(Request.QueryString["ID"]);
        //Response.Redirect("~/Add_Resource_Project.aspx?ID=" + id);
        MultiView1.ActiveViewIndex = 2;

    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["ID"]);
        Response.Redirect("~/Removed.aspx?ID=" + id);
    }
    protected void ShowData()
    {
        id = Convert.ToInt32(Request.QueryString["ID"]);
        sqlConnn.Open();
        SqlCommand cmd2 = new SqlCommand("Select P_id,P_name,Client,Duration,technology,start_date,end_date,Manager_Id,SOW_status,Project_status,deleted_date from projectlist where P_id=@pid and Flag=@zero", sqlConnn);
        cmd2.Parameters.AddWithValue("@pid", id);
        cmd2.Parameters.AddWithValue("@zero", 0);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd2);
        adapt.Fill(dt2);
        //IF ROWS OF DATATABLE > 0 
        if (dt2.Rows.Count > 0)
        {
            grid_project.DataSource = dt2;
            grid_project.DataBind();

        }
        //IF NO RECORD FOUND
        else
        {
            dt2.Rows.Add(dt2.NewRow());
            grid_project.DataSource = dt2;
            grid_project.DataBind();
            int totalcolums = grid_project.Rows[0].Cells.Count;
            grid_project.Rows[0].Cells.Clear();
            grid_project.Rows[0].Cells.Add(new TableCell());
            grid_project.Rows[0].Cells[0].ColumnSpan = totalcolums;
            grid_project.Rows[0].Cells[0].Text = "No Data Found";
        }

        sqlConnn.Close();

    }




    void Showdata1()
    {
        //FOR GRIDVIEW 1 RESOURCES SHOWING
        id = Convert.ToInt32(Request.QueryString["ID"]);
        sqlConnn.Open();
        SqlCommand cmd3 = new SqlCommand("select P.P_id,P.Emp_id,E.emp_name,P.Role,P.Capacity,P.added_date from pro_resources P JOIN Employee E on E.emp_id=P.Emp_id and P.P_id=@id ", sqlConnn);
        cmd3.Parameters.AddWithValue("@id", id);
        SqlDataAdapter adapter1 = new SqlDataAdapter(cmd3);
        adapter1.Fill(dt3);
        //IF ROWS OF DATATABLE > 0 
        if (dt3.Rows.Count > 0)
        {
            grid_resource.DataSource = dt3;
            grid_resource.DataBind();
        }
        //IF NO RECORD FOUND
        else
        {
            dt3.Rows.Add(dt3.NewRow());
            grid_resource.DataSource = dt3;
            grid_resource.DataBind();
            int totalcolums = grid_resource.Rows[0].Cells.Count;
            grid_resource.Rows[0].Cells.Clear();
            grid_resource.Rows[0].Cells.Add(new TableCell());
            grid_resource.Rows[0].Cells[0].ColumnSpan = totalcolums;
            grid_resource.Rows[0].Cells[0].Text = "No Data Found";
        }
        sqlConnn.Close();

    }


    //THIS IS FOR CANCEL BUTTON
    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid_project.EditIndex = -1;
        ShowData();
    }

    //THIS IS FOR EDITING BUTTON
    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid_project.EditIndex = e.NewEditIndex;
        ShowData();
    }

    //THIS IS FOR UPDATION
    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label id = grid_project.Rows[e.RowIndex].FindControl("lbl_Id") as Label;
        TextBox name = grid_project.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
        TextBox Client = grid_project.Rows[e.RowIndex].FindControl("txt_Client") as TextBox;
        TextBox Duration = grid_project.Rows[e.RowIndex].FindControl("txt_Duration") as TextBox;
        TextBox start = grid_project.Rows[e.RowIndex].FindControl("txt_start_date") as TextBox;
        TextBox end = grid_project.Rows[e.RowIndex].FindControl("txt_end_date") as TextBox;
        //UPDATING PROJECT STATUS AND EDITED VALUES
        string p_status = string.Empty;
        sqlConnn.Open();
        DateTime startdate = Convert.ToDateTime(start.Text);
        DateTime enddate = Convert.ToDateTime(end.Text);
        if (DateTime.Compare(startdate, DateTime.Now) > 0)
        {
            p_status = "Will be started";
            SqlCommand cmd3 = new SqlCommand("Update projectlist set P_name='" + name.Text + "',Client='" + Client.Text + "',Duration='" + Duration.Text + "',start_date='" + start.Text + "',end_date='" + end.Text + "',Project_status='" + p_status + "' where P_id=" + id.Text, sqlConnn);
            cmd3.ExecuteNonQuery();
            sqlConnn.Close();
        }
        else if (DateTime.Compare(enddate, DateTime.Now) < 0)
        {
            p_status = "End date finished";
            SqlCommand cmd3 = new SqlCommand("Update projectlist set P_name='" + name.Text + "',Client='" + Client.Text + "',Duration='" + Duration.Text + "',start_date='" + start.Text + "',end_date='" + end.Text + "',Project_status='" + p_status + "' where P_id=" + id.Text, sqlConnn);
            cmd3.ExecuteNonQuery();
            sqlConnn.Close();
        }
        else
        {
            p_status = "In Progress";
            SqlCommand cmd3 = new SqlCommand("Update projectlist set P_name='" + name.Text + "',Client='" + Client.Text + "',Duration='" + Duration.Text + "',start_date='" + start.Text + "',end_date='" + end.Text + "',Project_status='" + p_status + "' where P_id=" + id.Text, sqlConnn);
            cmd3.ExecuteNonQuery();
            sqlConnn.Close();
        }
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        grid_project.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        ShowData();

    }


    // THIS IS TO DELETE THE ROW AND UPDATE THE STATUS IN DATABASE TABLE
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ids = grid_project.DataKeys[e.RowIndex].Value.ToString();
        int id = Convert.ToInt32(ids);
        grid_project.Rows[e.RowIndex].Visible = false;
        sqlConnn.Open();
        SqlCommand cmd1 = new SqlCommand("Update projectlist set Flag=@fla, Project_status='Deleted', deleted_date='" + DateTime.Today + "' where P_id=@idm", sqlConnn);
        cmd1.Parameters.AddWithValue("@fla", 1);
        cmd1.Parameters.AddWithValue("@idm", id);
        cmd1.ExecuteNonQuery();
        cmd1.Dispose();
        sqlConnn.Close();
        ShowData();
    }

    //THIS IS TO VIEW CONFIRM DIALOG WHILE DELETING THE DATA
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btn = (Button)e.Row.FindControl("btn_Delete");
            if (btn != null)
                btn.Attributes.Add("onclick", "javascript:return " +
                     "confirm('Are you sure you want to delete this record " +
                     DataBinder.Eval(e.Row.DataItem, "P_id") + "')");
            Button edit = (Button)e.Row.FindControl("btn_Edit");
            if (edit != null)
                edit.Attributes.Add("onclick", "javascript:return " +
                     "confirm('Are you sure you want to Edit this record " +
                     DataBinder.Eval(e.Row.DataItem, "P_id") + "')");
        }
    }

    //GRIDVIEW 1 started
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid_resource.EditIndex = -1;
        Showdata1();
    }

    //THIS IS FOR EDITING BUTTON
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid_resource.EditIndex = e.NewEditIndex;
        Showdata1();
    }

    //THIS IS FOR UPDATION
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int pro_capacity = 0, balanced = 0, value = 0;
        GridViewRow row = (GridViewRow)grid_resource.Rows[e.RowIndex];
        Label id = grid_resource.Rows[e.RowIndex].FindControl("lbl_Id") as Label;
        Label emp_id = grid_resource.Rows[e.RowIndex].FindControl("lbl_Emp_id") as Label;
        DropDownList role = (DropDownList)row.FindControl("role");
        TextBox Capacity = grid_resource.Rows[e.RowIndex].FindControl("txt_Capacity") as TextBox;
        sqlConnn.Open();
        //TO CHECK CAN CAPACITY OF RESOURCE CAN BE CHANGED FOR THE PROJECT

        //GETTING SELECTED RESOURCE'S CAPACITY OF PROJECT
        SqlCommand command_res = new SqlCommand("select Capacity from pro_resources where P_id='" + Convert.ToInt32(id.Text) + "' and Emp_id='" + Convert.ToInt32(emp_id.Text) + "'", sqlConnn);
        SqlDataReader reader_res = command_res.ExecuteReader();
        if (reader_res.Read())
        {
            pro_capacity = Convert.ToInt32(reader_res["Capacity"]);
        }
        reader_res.Close();

        //CHECKS IF ENTERED CAPACITY IS LESS THAN THE PROEJECT_CAPACITY
        if (Convert.ToInt32(Capacity.Text) < pro_capacity)
        {
            //CALCULATING BALANCED VALUE OF EXISTING CAPACITY AND ENTERED CAPACITY
            value = pro_capacity - Convert.ToInt32(Capacity.Text);
            //GET BALANCE CAPACITY OF EMPLOYEE FROM EMPLOYEE TABLE
            SqlCommand command_res1 = new SqlCommand("select Balance_Capacity from Employee where emp_id='" + Convert.ToInt32(emp_id.Text) + "'", sqlConnn);

            SqlDataReader reader_res1 = command_res1.ExecuteReader();
            if (reader_res1.Read())
            {
                balanced = Convert.ToInt32(reader_res1["Balance_capacity"]);
                //ADD THAT VALUE TO BALANCED CAPACITY AND UPDATE IT
                balanced += value;
                reader_res1.Close();
                //UPDATE SELECTED ROLE AND ENTERED CAPACITY
                SqlCommand command_res4 = new SqlCommand("Update pro_resources set Role='" + role.SelectedValue + "',Capacity='" + Convert.ToInt32(Capacity.Text) + "' where P_id='" + Convert.ToInt32(id.Text) + "' and Emp_id='" + Convert.ToInt32(emp_id.Text) + "'", sqlConnn);
                command_res4.ExecuteNonQuery();
            }
            reader_res1.Close();
            //UPDATING BALANCED IN EMPLOYEE TABLE
            SqlCommand command_res2 = new SqlCommand("update Employee set Balance_capacity='" + balanced + "' where emp_id='" + Convert.ToInt32(emp_id.Text) + "'", sqlConnn);
            command_res2.ExecuteNonQuery();

        }      // ELSE 

        else if (Convert.ToInt32(Capacity.Text) > pro_capacity)
        {
            value = Convert.ToInt32(Capacity.Text) - pro_capacity;
            //GET BALANCE CAPACITY OF EMPLOYEE FROM EMPLOYEE TABLE
            SqlCommand command_res1 = new SqlCommand("select Balance_Capacity from Employee where emp_id='" + Convert.ToInt32(emp_id.Text) + "'", sqlConnn);

            SqlDataReader reader_res1 = command_res.ExecuteReader();
            if (reader_res1.Read())
            {
                balanced = Convert.ToInt32(reader_res1[0].ToString());
                balanced -= value;
            }
            reader_res1.Close();
            //IF BALANCED GREATER THAN ZERO
            if (balanced > 0)
            {
                //UPDATE BALANCED IN EMPLOYEE TABLE
                SqlCommand command_res2 = new SqlCommand("update Employee set Balance_capacity='" + balanced + "' where emp_id='" + Convert.ToInt32(emp_id.Text) + "'", sqlConnn);
                command_res2.ExecuteNonQuery();
                sqlConnn.Close();
                sqlConnn.Open();
                //UPDATE SELECTED ROLE AND ENTERED CAPACITY
                SqlCommand command_res3 = new SqlCommand("Update pro_resources set Role='" + role.SelectedValue + "',Capacity='" + Convert.ToInt32(Capacity.Text) + "' where P_id='" + Convert.ToInt32(id.Text) + "' and Emp_id='" + Convert.ToInt32(emp_id.Text) + "'", sqlConnn);
                command_res3.ExecuteNonQuery();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage",
"alert('Entered capacity cannot be accepted so please enter valid capacity!');", true); ;
            }

        }

        sqlConnn.Close();

        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        grid_resource.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        Showdata1();

    }


    // THIS IS TO DELETE THE ROW AND UPDATE THE STATUS IN DATABASE TABLE
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ids = grid_resource.DataKeys[e.RowIndex].Value.ToString();
        int p_id = Convert.ToInt32(ids);
        grid_resource.Rows[e.RowIndex].Visible = false;
        Label emp_id = grid_resource.Rows[e.RowIndex].FindControl("lbl_Emp_Id") as Label;
        sqlConnn.Open();
        SqlCommand cmd1 = new SqlCommand("Update pro_resources set Flag=@fla,Status=@status,Rem_date=@date where P_id=@idm and Emp_id=@emp", sqlConnn);
        cmd1.Parameters.AddWithValue("@fla", 1);
        cmd1.Parameters.AddWithValue("@status", "Removed");
        cmd1.Parameters.AddWithValue("@date", DateTime.Today);
        cmd1.Parameters.AddWithValue("@idm", p_id);
        cmd1.Parameters.AddWithValue("@emp", Convert.ToInt32(emp_id.Text));
        cmd1.ExecuteNonQuery();
        sqlConnn.Close();

     
        //TO UPDATE PROJECTS TOTAL CAPACITY WHEN RESOURCE IS REMOVED FROM PROJECT
        sqlConnn.Open();
        int e_capacity = 0, total = 0;
        int e_id = Convert.ToInt32(emp_id.Text);
        SqlCommand command = new SqlCommand("select Capacity from pro_resources where Emp_id='" + e_id + "' and P_id='" + p_id + "'", sqlConnn);
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            e_capacity = Convert.ToInt32(reader["Capacity"]);
        }
        reader.Close();
        SqlCommand command1 = new SqlCommand("select Total_capacity from projectlist where P_id='" + p_id + "'", sqlConnn);
        SqlDataReader reader1 = command1.ExecuteReader();
        if (reader1.Read())
        {
            total = Convert.ToInt32(reader1["Total_capacity"]);
        }
        reader1.Close();
        total -= e_capacity;
        SqlCommand cmd = new SqlCommand("update projectlist set Total_capacity='" + total + "' where P_id='" + p_id + "'", sqlConnn);
        cmd.ExecuteNonQuery();
        sqlConnn.Close();
    }

    //THIS IS TO VIEW CONFIRM DIALOG WHILE DELETING THE DATA
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btn = (Button)e.Row.FindControl("btn_Delete");
            if (btn != null)
                btn.Attributes.Add("onclick", "javascript:return " +
                     "confirm('Are you sure you want to delete this record " +
                     DataBinder.Eval(e.Row.DataItem, "Emp_id") + "')");
            Button edit = (Button)e.Row.FindControl("btn_Edit");
            if (edit != null)
                edit.Attributes.Add("onclick", "javascript:return " +
                     "confirm('Are you sure you want to Edit this record " +
                     DataBinder.Eval(e.Row.DataItem, "Emp_id") + "')");
        }
    }


    //view 3 add additional resource to the project

    protected void BindData()
    {
        int b = Convert.ToInt32(Session["Emp_Id"]);
        string name = string.Empty;
        sqlConnn.Open();
        SqlCommand command = new SqlCommand("select emp_name,role,Balance_Capacity from Employee where manager='" + b + "' and Balance_Capacity > '0' and Pro_flag<>'1'", sqlConnn);
        SqlDataReader reader = command.ExecuteReader();
        DropDownList1.Items.Clear();
        while (reader.Read())
        {
            var item = new ListItem();
            item.Text = reader["emp_name"].ToString();
            item.Value = reader["emp_name"].ToString();
            DropDownList1.Items.Add(item);
        }
        reader.Close();
        sqlConnn.Close();
        // to set employees role to text box
        sqlConnn.Open();
        SqlCommand commander = new SqlCommand("select role from Employee where emp_name=@name", sqlConnn);
        commander.Parameters.AddWithValue("@name", DropDownList1.SelectedValue.Trim());
        SqlDataReader reader1 = commander.ExecuteReader();
        if (reader1.Read())
        {
            TextBox1.Text = reader1["role"].ToString();
        }
        sqlConnn.Close();
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int b = Convert.ToInt32(Session["Emp_Id"]);
        int id = Convert.ToInt32(Request.QueryString["ID"]);
        sqlConnn.Open();
        string replacement = Regex.Replace(DropDownList1.SelectedValue.Trim(), @"\t|\n|\r", "");
        SqlCommand command = new SqlCommand("select role from Employee where emp_name=@name", sqlConnn);
        command.Parameters.AddWithValue("@name", replacement);
        SqlDataReader rd= command.ExecuteReader();
        
      if(rd.Read())
      {
            TextBox1.Text = rd["role"].ToString();
      }
        sqlConnn.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int emp_id = 0;
        int b = Convert.ToInt32(Session["Emp_Id"]);
        int id = Convert.ToInt32(Request.QueryString["ID"]);
        int balance = 0;
        int capacity = 0, total = 0;
        sqlConnn.Open();
        SqlCommand command = new SqlCommand("select emp_id,Balance_Capacity from Employee where emp_name=@name", sqlConnn);
        command.Parameters.AddWithValue("@name", DropDownList1.SelectedValue.Trim());
        SqlDataReader reader1 = command.ExecuteReader();
        if (reader1.Read())
        {
            balance = Convert.ToInt32(reader1["Balance_Capacity"]);
            emp_id = Convert.ToInt32(reader1["emp_id"]);
        }
        reader1.Close();

        if (balance > 0)
        {
            if (Convert.ToInt32(TextBox2.Text) <= balance)
            {
                balance -= Convert.ToInt32(TextBox2.Text);
                string queries = "insert into pro_resources(P_id,Emp_id,Role,Capacity,Status,Flag,added_date) values(@P_id,@Emp_id,@Role,@Capacity,@Status,@Flag,@add_date);" + "update Employee set Balance_Capacity='" + balance + "',Pro_flag='1' where emp_id='" + emp_id + "'";
                SqlCommand command1 = new SqlCommand(queries, sqlConnn);
                command1.Parameters.AddWithValue("@P_id", id);
                command1.Parameters.AddWithValue("@Emp_id", emp_id);
                command1.Parameters.AddWithValue("@Role", TextBox1.Text);
                command1.Parameters.AddWithValue("@Capacity", Convert.ToInt32(TextBox2.Text));
                command1.Parameters.AddWithValue("@Status", "On Project");
                command1.Parameters.AddWithValue("@Flag", 0);
                command1.Parameters.AddWithValue("@add_date", DateTime.Today);
                command1.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, GetType(), "alert Message", "alert('Resource succesfully added to project')", true);
                sqlConnn.Close();
                //to update the total capacity when it is calculated
                sqlConnn.Open();
                capacity = Convert.ToInt32(TextBox2.Text);
                SqlCommand commander = new SqlCommand("select Total_capacity from projectlist where P_id='" + id + "'", sqlConnn);
                SqlDataReader reader2 = commander.ExecuteReader();
                if (reader2.Read())
                {
                    total = Convert.ToInt32(reader2["Total_capacity"]);
                }
                total += capacity;
                reader2.Close();
                SqlCommand commander1 = new SqlCommand("update projectlist set Total_capacity='" + total + "'", sqlConnn);
                commander1.ExecuteNonQuery();
                sqlConnn.Close();
                Response.Redirect("~/ProjectList.aspx?ID=" + id);
            }
            else
            {
                Label4.Text = "Entered Capacity is greater than balance capacity. " + DropDownList1.SelectedValue.Trim() + "\'s Balance Capacity is: " + balance;
                Label4.Visible = true;
            }
        }

    }
    protected void linkbut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session["Emp_Id"] = null;
        Response.Redirect("~/login.aspx");
    }
}