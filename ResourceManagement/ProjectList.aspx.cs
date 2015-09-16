using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class ProjectList : System.Web.UI.Page
{
    int b,id; 
   SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //id = Convert.ToInt32(Request.QueryString["ID"]);
        //GETTING SEESION ID  
        int b = Convert.ToInt32(Session["Emp_Id"]);
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
            id = Convert.ToInt32(Request.QueryString["ID"]);
            SetDefaultView();
            //BINDS DATA TO GRIDVIEW
            ShowData();
            Showdata1();
        }
    }
     private void SetDefaultView()
    {
        MultiView1.ActiveViewIndex = 0;
    }
     protected void LinkButton3_Click(object sender, EventArgs e)
     {
         MultiView1.ActiveViewIndex = 2;
     }
     protected void LinkButton1_Click(object sender, EventArgs e)
     {
         MultiView1.ActiveViewIndex = 0;
     }
     protected void LinkButton2_Click(object sender, EventArgs e)
     {

         //sqlConnn.Open();
         MultiView1.ActiveViewIndex = 1;
         //SqlCommand mycommand1 = new SqlCommand("select P_id,Emp_id,Role,Capacity from pro_resources where P_id=@id", sqlConnn);
         //mycommand1.Parameters.AddWithValue("@id", id);
         //SqlDataReader read1 = mycommand1.ExecuteReader();
         //DropDownList1.Items.Clear();
         //while (read1.Read())
         //{
         //    var item = new ListItem();
         //    item.Text = Convert.ToInt32(read1["P_id"]).ToString();
         //    item.Value = Convert.ToInt32(read1["P_id"]).ToString();
         //    DropDownList1.Items.Add(item);
         //}
         //read1.Close();
         //sqlConnn.Close();
     }
    protected void ShowData()
    {
        int b = Convert.ToInt32(Session["Emp_Id"]);
        sqlConnn.Open();
        SqlCommand cmd2 = new SqlCommand("Select P_id,P_name,Client,Duration,technology,start_date,end_date,Manager_Id,SOW_status,Project_Status from projectlist where P_id=@pid", sqlConnn);
        cmd2.Parameters.AddWithValue("@pid", id);
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

    void Showdata1()
    {
        //FOR GRIDVIEW 1 RESOURCES SHOWING
        id = Convert.ToInt32(Request.QueryString["ID"]);
        sqlConnn.Open();
        SqlCommand cmd3 = new SqlCommand("select P_id,Emp_id,Role,Capacity from pro_resources where P_id=@id", sqlConnn);
        cmd3.Parameters.AddWithValue("@id", id);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd3);
        adapter.Fill(dt3);
        //IF ROWS OF DATATABLE > 0 
        if (dt3.Rows.Count > 0)
        {
            GridView1.DataSource = dt3;
            GridView1.DataBind();
        }
        //IF NO RECORD FOUND
        else
        {
            dt3.Rows.Add(dt3.NewRow());
            GridView1.DataSource = dt3;
            GridView1.DataBind();
            int totalcolums = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
            GridView1.Rows[0].Cells[0].Text = "No Data Found";
        }
        sqlConnn.Close();

    }

    //THIS IS FOR CANCEL BUTTON
    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView3.EditIndex = -1;
        ShowData();
    }

    //THIS IS FOR EDITING BUTTON
    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView3.EditIndex = e.NewEditIndex;
        ShowData();
    }

    //THIS IS FOR UPDATION
    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label id = GridView3.Rows[e.RowIndex].FindControl("lbl_Id") as Label;
        TextBox name = GridView3.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
        TextBox Client = GridView3.Rows[e.RowIndex].FindControl("txt_Client") as TextBox;
        TextBox Duration = GridView3.Rows[e.RowIndex].FindControl("txt_Duration") as TextBox;
        TextBox start = GridView3.Rows[e.RowIndex].FindControl("txt_start_date") as TextBox;
        TextBox end = GridView3.Rows[e.RowIndex].FindControl("txt_end_date") as TextBox;
        // DropDownList city = GridView3.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList;
        sqlConnn.Open();

        SqlCommand cmd3 = new SqlCommand("Update projectlist set P_name='" + name.Text + "',Client='" + Client.Text + "',Duration='" + Duration.Text + "' where P_id=" + id.Text, sqlConnn);
        cmd3.ExecuteNonQuery();
        sqlConnn.Close();

        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView3.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        ShowData();

    }


    // THIS IS TO DELETE THE ROW AND UPDATE THE STATUS IN DATABASE TABLE
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ids = GridView3.DataKeys[e.RowIndex].Value.ToString();
        int id = Convert.ToInt32(ids);
        GridView3.Rows[e.RowIndex].Visible = false;
        sqlConnn.Open();
        SqlCommand cmd1 = new SqlCommand("Update projectlist set Flag=@fla where P_id=@idm", sqlConnn);
        cmd1.Parameters.AddWithValue("@fla", 1);
        cmd1.Parameters.AddWithValue("@idm", id);
        cmd1.ExecuteNonQuery();
        sqlConnn.Close();
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
        }
    }


    

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    SqlConnection co = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
    //    sqlConnn.Open();
    //    SqlCommand coo = new SqlCommand("select * from pro_resources where P_id='" + id + "' and emp_id<>'" + b + "'", sqlConnn);

    //    SqlDataAdapter da = new SqlDataAdapter(coo);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    if (dt.Rows.Count > 0)
    //    {
    //        GridView1.DataSource = dt;
    //        GridView1.DataBind();
    //    }
    //    sqlConnn.Close();
    //}

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

   //GRIDVIEW1 started
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView3.EditIndex = -1;
        Showdata1();
    }

    //THIS IS FOR EDITING BUTTON
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView3.EditIndex = e.NewEditIndex;
        Showdata1();
    }

    //THIS IS FOR UPDATION
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_Id") as Label;
        
        TextBox Role = GridView3.Rows[e.RowIndex].FindControl("txt_Role") as TextBox;
        TextBox Capacity = GridView3.Rows[e.RowIndex].FindControl("txt_Capacity") as TextBox;
        
        // DropDownList city = GridView3.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList;
        sqlConnn.Open();

        SqlCommand cmd3 = new SqlCommand("Update projectlist set Role='" + Role.Text + "',Capacity='" + Capacity.Text + "' where P_id=" + id.Text, sqlConnn);
        cmd3.ExecuteNonQuery();
        sqlConnn.Close();

        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView1.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        Showdata1();

    }


    // THIS IS TO DELETE THE ROW AND UPDATE THE STATUS IN DATABASE TABLE
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ids = GridView1.DataKeys[e.RowIndex].Value.ToString();
        int id = Convert.ToInt32(ids);
        GridView1.Rows[e.RowIndex].Visible = false;
        sqlConnn.Open();
        ////SqlCommand cmd1 = new SqlCommand("Update projectlist set Flag=@fla where P_id=@idm", sqlConnn);
        ////cmd1.Parameters.AddWithValue("@fla", 1);
        ////cmd1.Parameters.AddWithValue("@idm", id);
        //cmd1.ExecuteNonQuery();
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
        }
    }
}