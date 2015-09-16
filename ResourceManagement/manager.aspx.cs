﻿using System;
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
    //CREATING SQLCONNECTION 
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
    DataTable dt2 = new DataTable();

    // PAGE LOAD
    protected void Page_Load(object sender, EventArgs e)
    {
        //GETTING SEESION ID  
        int b = Convert.ToInt32(Session["Emp_Id"]);
        sqlConnn.Open();
        //COMMAND TO CHECK LOGGED IN USER AND DISPLAYING
        //
        SqlCommand mycommand = new SqlCommand("select emp_name,role,technology from Employee where emp_id=@id ", sqlConnn);
        mycommand.Parameters.AddWithValue("@id", b);
        SqlDataReader read = mycommand.ExecuteReader();
        if (read.Read())
        {
            lblin.Text = "Welcome, " + read["emp_name"].ToString();
            desig.Text = "Designation: " + read["role"].ToString();
            tech1.Text = read["technology"].ToString();
        }
        read.Close();
        sqlConnn.Close();

        if (!IsPostBack)
        {
            SetDefaultView();
            //BINDS DATA TO GRIDVIEW
            ShowData();

            string jun = "Junior_Developer";
            //THIS IS TO CHECK AND FILL NAMES OF THE JUNIOR DEVELOPER DROPDOWNLIST
            SqlConnection sqlConn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
            sqlConn.Open();
            SqlCommand mycommand3 = new SqlCommand("select emp_name from Employee where manager=@emp and role=@roll", sqlConn);
            mycommand3.Parameters.AddWithValue("@emp", b);
            mycommand3.Parameters.AddWithValue("@roll", jun);



            SqlDataReader read3 = mycommand3.ExecuteReader();
            ListBox1.Items.Clear();

            while (read3.Read())
            {
                //DropDownList1.Items.Clear();
                /*code omitted*/
                var item = new ListItem();
                item.Text = read3["emp_name"].ToString();
                item.Value = read3["emp_name"].ToString();
                ListBox1.Items.Add(item);
            }
            read.Close();
            sqlConn.Close();
            string sen = "Senior_Developer";

            SqlConnection sqlCon = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
            sqlCon.Open();
            SqlCommand mycomman = new SqlCommand("select emp_name from Employee where manager=@emp and role=@rol", sqlCon);
            mycomman.Parameters.AddWithValue("@emp", b);
            mycomman.Parameters.AddWithValue("@rol", sen);


            SqlDataReader rea = mycomman.ExecuteReader();
            ListBox2.Items.Clear();
            while (rea.Read())
            {
                //DropDownList2.Items.Clear();
                /*code omitted*/
                var item = new ListItem();
                item.Text = rea["emp_name"].ToString();
                item.Value = rea["emp_name"].ToString();
                ListBox2.Items.Add(item);
            }
            rea.Close();
            sqlCon.Close();
            //SENIOR DEVELOPER DROPDOWNLIST ENDS HERE

            //THIS IS TO CHECK AND FILL NAMES OF THE TECH_LEAD DROPDOWNLIST
            string tec = "Tech_Lead";

            SqlConnection sqlCo = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
            sqlCo.Open();
            SqlCommand mycomma = new SqlCommand("select emp_name from Employee where manager=@emp and role=@ro", sqlCo);
            mycomma.Parameters.AddWithValue("@emp", b);
            mycomma.Parameters.AddWithValue("@ro", tec);
            SqlDataReader re = mycomma.ExecuteReader();
            ListBox3.Items.Clear();
            while (re.Read())
            {
                //DropDownList3.Items.Clear();
                /*code omitted*/
                var item = new ListItem();
                item.Text = re["emp_name"].ToString();
                item.Value = re["emp_name"].ToString();
                ListBox3.Items.Add(item);
            }
            re.Close();
            sqlCo.Close();
        }
    }
    //SHOWING  DEFAULT VIEW OF MULTIVIEW
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
        MultiView1.ActiveViewIndex = 1;
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Add_Remove.aspx");
    }

    //THIS IS TO SHOW THE CORRESPONDING DEVELOPER IN THE SELECTED TECHNOLOGY UNDER A PARTICULAR MANAGER
    protected void tech1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int b = Convert.ToInt32(Session["Emp_Id"]);
    }

    //Calculate Total Hours
    protected float CalculateTotalHours()
    {
        var keys = Request.Form.AllKeys.Where(x => x.Contains("Hours"));
        float total = 0;
        List<Employee> emplList = (List<Employee>)Application["SelectedEmployees"];
        if (keys != null ? keys.Count() > 0 : false)
        {
            var itemIndex = 0;
            foreach (string key in keys)
            {

                float value = 0;
                float.TryParse(Request.Form[key].ToString(), out value);
                total += value;
                if (emplList[itemIndex] != null)
                    emplList[itemIndex].value = value;
                itemIndex++;
            }
        }
        return total;
    }

    //TO DYNAMICALLY CREATE A CORRESPONDING TEXT BOX NAME FOR SELECTED DEVELOPER
    protected void ManipulateFields()
    {
        //List Box 1
        ManipulateRows(ListBox1, "List1");
        //List Box 2
        ManipulateRows(ListBox2, "List2");
        //List Box 3
        ManipulateRows(ListBox3, "List3");
    }


    protected void ManipulateRows(ListBox listControl, string uniqueKey)
    {

        if (listControl.SelectedIndex != -1)
        {
            List<Employee> emplList = (List<Employee>)Application["SelectedEmployees"];
            for (int i = 0; i < listControl.Items.Count; i++)
            {
                if (listControl.Items[i].Selected)
                {
                    System.Web.UI.HtmlControls.HtmlTableRow tr = new System.Web.UI.HtmlControls.HtmlTableRow();
                    System.Web.UI.HtmlControls.HtmlTableCell col = new System.Web.UI.HtmlControls.HtmlTableCell();
                    Label Lbl = new Label();
                    Lbl.Text = "Capacity of " + listControl.Items[i].Text;
                    Lbl.ID = "lbl" + uniqueKey + i.ToString();
                    Lbl.ForeColor = System.Drawing.Color.Black;
                    col.Controls.Add(Lbl);
                    tr.Cells.Add(col);

                    sqlConnn.Close();
                    sqlConnn.Open();
                    SqlCommand cmd = new SqlCommand("select emp_id,role from Employee where emp_name=@name", sqlConnn);
                    cmd.Parameters.AddWithValue("@name", listControl.Items[i].Text);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Employee empl = new Employee();
                    while (reader.Read())
                    {
                        empl.id = Convert.ToInt32(reader["emp_id"]);
                        empl.role = reader["role"].ToString();
                    }
                    cmd.Dispose();
                    //SqlCommand cmd1 = new SqlCommand("insert into pro_resources(Emp_id,Role) values (@id,@role)", sqlConnn);
                    //sqlConnn.Close();


                    System.Web.UI.HtmlControls.HtmlTableCell col1 = new System.Web.UI.HtmlControls.HtmlTableCell();
                    TextBox txt = new TextBox();
                    txt.ID = "Hours" + listControl.Items[i].Text;
                    txt.ClientIDMode = ClientIDMode.Static;
                    txt.Width = 150;
                    txt.Height = 20;
                    col1.Controls.Add(txt);
                    tr.Cells.Add(col1);
                    tblFormTable.Rows.Add(tr);
                    empl.name = listControl.Items[i].Text.ToString();
                    emplList.Add(empl);
                }
            }
            Application["SelectedEmployees"] = emplList;
        }
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Application["SelectedEmployees"] = new List<Employee>();
        ManipulateFields();
    }


    //METHOD EXECUTED WHILE SUBMIT BUTTON PRESSED
    protected void btn1_Click(object sender, EventArgs e)
    {
        var totalHours = CalculateTotalHours();
        Employee emp1 = new Employee();
        DateTime stratdate = Convert.ToDateTime(sdate1.Text);
        DateTime enddate = Convert.ToDateTime(edate1.Text);
        int weekdays=emp1.weekdays(stratdate,enddate);
        var totally = (totalHours/5) * weekdays;
        if (totally >= Convert.ToInt32(duration.Text))
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
            sqlCon.Open();

            //QUERY TO INSERT A VALUE OF PROJECT DETAILS IN PROJECTLIST TABLE

            string que = "INSERT INTO projectlist(P_name, Client,technology,Duration,start_date,end_date,Manager_Id,Total_capacity,SOW,SOW_status) values (@name,@client,@tech,@duration,@sdate,@edate,@id,@total,@sow,@status);" + "select Scope_Identity();";
            object p_id;
            SqlCommand myCom = new SqlCommand(que, sqlCon);

            myCom.Parameters.AddWithValue("@name", pro_name1.Text);
            myCom.Parameters.AddWithValue("@client", cliname1.Text);
            myCom.Parameters.AddWithValue("@tech", tech1.Text);
            myCom.Parameters.AddWithValue("@duration", duration.Text);
            myCom.Parameters.AddWithValue("@sdate", sdate1.Text);
            myCom.Parameters.AddWithValue("@edate", edate1.Text);
            int b = Convert.ToInt32(Session["Emp_Id"]);
            myCom.Parameters.AddWithValue("@id", b);
            myCom.Parameters.AddWithValue("@total", totalHours);
            //FOR FILE UPLOADING AND CHECKING CONDITION
            //IF FILE IS THERE IT WILL SET SOW_STATUS TO 1 && FILE PATH TO SOW COLUMN
            if (FileUpload1.HasFile)
            {
                try
                {

                    FileUpload1.SaveAs("D:\\Upload\\" + FileUpload1.FileName);
                    string path = "D:\\Upload\\" + FileUpload1.FileName;
                    myCom.Parameters.AddWithValue("@sow", path);
                    myCom.Parameters.AddWithValue("@status", 1);
                    Label4.Text = "File Uploaded";
                }
                catch (Exception ex)
                {

                    Label4.Text = "ERROR: " + ex.Message.ToString();
                }
            }
            else
            {
                myCom.Parameters.AddWithValue("@sow", "");
                myCom.Parameters.AddWithValue("@status", 0);
            }
            p_id = myCom.ExecuteScalar();
            string prefix = "p_" + p_id;

            //TO UPDATE THE PROJECT_ID WITH PREFIX 

            string query = "update projectlist set project_id=@project_id where P_id=@pid";
            SqlCommand comm = new SqlCommand(query, sqlCon);
            comm.Parameters.AddWithValue("@pid", p_id);
            comm.Parameters.AddWithValue("@project_id", prefix);
            comm.ExecuteNonQuery();
            ShowData();

            sqlCon.Close();

            List<Employee> emplList = (List<Employee>)Application["SelectedEmployees"];

            foreach (Employee emp in emplList)
            {
                sqlCon.Open();
                string queries = "INSERT INTO pro_resources(P_id,Emp_id,Role,Capacity) values (@pid1,@eid,@role,@capacity)";
                SqlCommand comm1 = new SqlCommand(queries, sqlCon);
                comm1.Parameters.AddWithValue("@pid1", p_id);
                comm1.Parameters.AddWithValue("@eid", emp.id);
                comm1.Parameters.AddWithValue("@role", emp.role);
                comm1.Parameters.AddWithValue("@capacity", emp.value);
                comm1.ExecuteNonQuery();
                comm1.Dispose();
                sqlCon.Close();
            }

            sqlCon.Close();
            //Response.Redirect("login.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The given duration is not sufficient with entered resources capacity ');", true);
        }
    }

    

    //
    // GRIDVIEW CODE STARTS
    //

    //TO BIND THE DATA TO GRIDVIEW
    protected void ShowData()
    {
        int b = Convert.ToInt32(Session["Emp_Id"]);
        sqlConnn.Open();
        SqlCommand cmd2 = new SqlCommand("Select P_id,P_name,Client,Duration,Project_Status from projectlist where Manager_id=@man_id", sqlConnn);
        cmd2.Parameters.AddWithValue("@man_id", b);
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

    //THIS IS FOR CANCEL BUTTON
    //protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    GridView3.EditIndex = -1;
    //    ShowData();
    //}

    ////THIS IS FOR EDITING BUTTON
    //protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    GridView3.EditIndex = e.NewEditIndex;
    //    ShowData();
    //}

    ////THIS IS FOR UPDATION
    //protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    Label id = GridView3.Rows[e.RowIndex].FindControl("lbl_Id") as Label;
    //    TextBox name = GridView3.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
    //    TextBox Client = GridView3.Rows[e.RowIndex].FindControl("txt_Client") as TextBox;
    //    TextBox Duration = GridView3.Rows[e.RowIndex].FindControl("txt_Duration") as TextBox;
    //    // DropDownList city = GridView3.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList;
    //    sqlConnn.Open();

    //    SqlCommand cmd3 = new SqlCommand("Update projectlist set P_name='" + name.Text + "',Client='" + Client.Text + "',Duration='" + Duration.Text + "' where P_id=" + id.Text, sqlConnn);
    //    cmd3.ExecuteNonQuery();
    //    sqlConnn.Close();

    //    //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
    //    GridView3.EditIndex = -1;
    //    //Call ShowData method for displaying updated data  
    //    ShowData();

    //}

    ////THIS IS TO ADD THE VALUES AND BINDS AND SHOWS THE DATA IN GRIDVIEW

    ////protected void Insert(object sender, EventArgs e)
    ////{
    ////   if(IsPostBack)
    ////    source1.Insert();
    ////    sqlConn.Close();
    ////    txtName.Text=string.Empty;
    ////        txtid.Text=string.Empty;
    ////        txttech.Text=string.Empty;
    ////            txtrole.Text=string.Empty;
    ////            txtemail.Text=string.Empty;
    ////                txtpass.Text=string.Empty;
    ////                txtframe.Text=string.Empty;
    ////                txtflag.Text = string.Empty;
    ////                btnAdd.Visible = false;
    ////                ShowData();
    ////}


    //// THIS IS TO DELETE THE ROW AND UPDATE THE STATUS IN DATABASE TABLE
    //protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    string ids = GridView3.DataKeys[e.RowIndex].Value.ToString();
    //    int id = Convert.ToInt32(ids);
    //    GridView3.Rows[e.RowIndex].Visible = false;
    //    sqlConnn.Open();
    //    SqlCommand cmd1 = new SqlCommand("Update projectlist set Flag=@fla where P_id=@idm", sqlConnn);
    //    cmd1.Parameters.AddWithValue("@fla", 1);
    //    cmd1.Parameters.AddWithValue("@idm", id);
    //    cmd1.ExecuteNonQuery();
    //    sqlConnn.Close();
    //}

    ////THIS IS TO VIEW CONFIRM DIALOG WHILE DELETING THE DATA
    //protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Button btn = (Button)e.Row.FindControl("btn_Delete");
    //        if (btn != null)
    //            btn.Attributes.Add("onclick", "javascript:return " +
    //                 "confirm('Are you sure you want to delete this record " +
    //                 DataBinder.Eval(e.Row.DataItem, "P_id") + "')");
    //    }
    //}

    //THIS IS TO GET THE SELECT BUTTON ACTION AND NAVIGATE TO PROJECTLIST PAGE WITH SELECTED PROJECT ID
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Action")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("~/ProjectList.aspx?ID=" + id);
        }


    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/login.aspx");
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");

    //    conn.Open();
    //    SqlCommand com = new SqlCommand("select emp_name from Employee where role<>'manager' AND role<>'admin' AND flag<>1", conn);
    //    SqlDataReader sdr = com.ExecuteReader();
    //    ListBox4.Items.Clear();
    //    while (sdr.Read())
    //    {
    //        ListItem name = new ListItem();
    //        name.Text = sdr["emp_name"].ToString();
    //        name.Value = sdr["emp_name"].ToString();
    //        //ListItem rol = new ListItem();
    //        //rol.Text = sdr["role"].ToString();
    //        //rol.Value = sdr["role"].ToString();
    //        ListBox4.Items.Add(name);
    //        ListBox4.Rows = ListBox4.Items.Count;

    //    }
    //    com.Dispose();

    //    conn.Close();
    //}


    //protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //SqlConnection conn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");
    //    conn.Open();

        
    //        string eid = (string)(Session["Emp_Id"]);
           

    //        if (ListBox4.SelectedIndex > -1)
    //        {

    //            List<int> select = ListBox4.GetSelectedIndices().ToList();
    //            for (int i = 0; i < select.Count; i++)
    //            {
    //                int a = 1;
    //                string l = ListBox4.Items[select[i]].ToString();
    //                SqlCommand command = new SqlCommand("update employee set manager=@eid,flag=@flag where emp_name=@len", conn);
    //                command.Parameters.AddWithValue("@flag", a);
    //                command.Parameters.AddWithValue("@len", l);
    //                command.Parameters.AddWithValue("@eid", eid);
    //                command.ExecuteNonQuery();
    //                command.Dispose();

    //            }
    //        }
    //            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Resources has been added under you');", true);
    //        conn.Close();

    //    }


    }
    


//Employee Class - Used to store employee Info
public class Employee
{
    public int id { get; set; }
    public string role { get; set; }
    public string name { get; set; }
    public float value { get; set; }

    DateTime[] ameexHolidays = new DateTime[] { new DateTime(2015, 01, 15), new DateTime(2015, 01, 26), new DateTime(2015, 05, 01), new DateTime(2015, 07, 03), new DateTime(2015, 07, 18), new DateTime(2015, 08, 15), new DateTime(2015, 09, 07), new DateTime(2015, 10, 02), new DateTime(2015, 11, 10), new DateTime(2015, 12, 25) };
    //CALCULATING WEEKDAYS
   public int weekdays(DateTime start, DateTime end)
    {
        int noofdays = 0;
        int count = 0;
        if (DateTime.Compare(start, end) == 1)
            Console.WriteLine("entered date should be in startdate < enddate");
        while (DateTime.Compare(start, end) <= 0)
        {
            if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
            {
                string holiday = (from date in ameexHolidays where DateTime.Compare(start, date) == 0 select "Holiday").FirstOrDefault();
                if (holiday != "Holiday")
                {
                    noofdays += 1;
                    count++;
                }
                start = start.AddDays(1);
            }
            else
            {
                start = start.AddDays(1);
            }
        }
        return noofdays;
    }
}