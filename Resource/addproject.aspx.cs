using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addproject : System.Web.UI.Page
{
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int b = Convert.ToInt32(Session["Emp_Id"]);

            sqlConnn.Open();
            SqlCommand mycommand = new SqlCommand("select emp_name,role,technology from Employee where emp_id=@id ", sqlConnn);
            mycommand.Parameters.AddWithValue("@id", b);

            SqlDataReader read = mycommand.ExecuteReader();

            if (read.Read())
            {
                lbl_welcome.Text = "Welcome, " + read["emp_name"].ToString();
                desig.Text = "Designation: " + read["role"].ToString();
                tech1.Text = read["technology"].ToString();
            }

            read.Close();
            sqlConnn.Close();
            Session.Add("Tech", tech1.Text);

            string jun = "Junior_Developer";
            SqlConnection sqlConn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
            sqlConn.Open();
            SqlCommand mycommand3 = new SqlCommand("select emp_name from Employee where manager=@emp and role=@roll", sqlConn);
            mycommand3.Parameters.AddWithValue("@emp", b);
            mycommand3.Parameters.AddWithValue("@roll", jun);



            SqlDataReader read3 = mycommand3.ExecuteReader();
            junior.Items.Clear();

            while (read3.Read())
            {
                var item = new ListItem();
                item.Text = read3["emp_name"].ToString();
                item.Value = read3["emp_name"].ToString();
                junior.Items.Add(item);
            }
            read3.Close();
            sqlConn.Close();
            string sen = "Senior_Developer";

            SqlConnection sqlCon = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
            sqlCon.Open();
            SqlCommand mycomman = new SqlCommand("select emp_name from Employee where manager=@emp and role=@rol", sqlCon);
            mycomman.Parameters.AddWithValue("@emp", b);
            mycomman.Parameters.AddWithValue("@rol", sen);


            SqlDataReader rea = mycomman.ExecuteReader();
            senior.Items.Clear();
            while (rea.Read())
            {
                var item = new ListItem();
                item.Text = rea["emp_name"].ToString();
                item.Value = rea["emp_name"].ToString();
                senior.Items.Add(item);
            }
            rea.Close();
            sqlCon.Close();
            string tec = "Tech_Lead";

            SqlConnection sqlCo = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
            sqlCo.Open();
            SqlCommand mycomma = new SqlCommand("select emp_name from Employee where manager=@emp and role=@ro", sqlCo);
            mycomma.Parameters.AddWithValue("@emp", b);
            mycomma.Parameters.AddWithValue("@ro", tec);
            SqlDataReader re = mycomma.ExecuteReader();
            techlead.Items.Clear();
            while (re.Read())
            {
                var item = new ListItem();
                item.Text = re["emp_name"].ToString();
                item.Value = re["emp_name"].ToString();
                techlead.Items.Add(item);
            }
            re.Close();
            sqlCo.Close();
            //}

            if (tech1.Text == ".Net")
            {
                typeoftech1.Text = "Proprietary";
            }
            else
            {
                typeoftech1.Text = "Open Source";
            }
            if (tech1.Text == ".Net")
            {
                frame.Items.FindByValue("Ektron").Enabled = true;
                frame.Items.FindByValue("Episerver").Enabled = true;
                frame.Items.FindByValue("Kentico").Enabled = true;
                frame.Items.FindByValue("Sitecore").Enabled = true;
                frame.Items.FindByValue("Sharepoint").Enabled = true;
                frame.Items.FindByValue("Majento").Enabled = false;
                frame.Items.FindByValue("Drupal").Enabled = false;
                frame.Items.FindByValue("Joomla").Enabled = false;
            }
            else if (tech1.Text == "Php")
            {
                frame.Items.FindByValue("Ektron").Enabled = false;
                frame.Items.FindByValue("Episerver").Enabled = false;
                frame.Items.FindByValue("Kentico").Enabled = false;
                frame.Items.FindByValue("Sitecore").Enabled = false;
                frame.Items.FindByValue("Sharepoint").Enabled = false;
                frame.Items.FindByValue("Majento").Enabled = true;
                frame.Items.FindByValue("Drupal").Enabled = true;
                frame.Items.FindByValue("Joomla").Enabled = true;
            }
        }
    }
   
    protected float CalculateTotalHours()
    {
        SqlConnection sqlCo = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
        sqlCo.Open();
        var keys = Request.Form.AllKeys.Where(x => x.Contains("Hours"));
        float total = 0;
        List<Employee> emplList = (List<Employee>)Application["SelectedEmployees"];
        if (keys != null && emplList != null ? keys.Count() > 0 : false)
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

            sqlCo.Close();
        }
        return total;

    }

    protected void ManipulateFields()
    {
        //List Box 1
        ManipulateRows(junior, "List1");
        //List Box 2
        ManipulateRows(senior, "List2");
        //List Box 3
        ManipulateRows(techlead, "List3");
    }


    protected void ManipulateRows(ListBox listControl, string uniqueKey)
    {
        SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
        sqlConnn.Open();

        if (listControl.SelectedIndex !=-1)
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
                    SqlCommand cmd = new SqlCommand("select emp_id,role,Balance_Capacity,Original_Capacity from Employee where emp_name=@name", sqlConnn);
                    cmd.Parameters.AddWithValue("@name", listControl.Items[i].Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    int maxCapacity = 0;
                    Employee empl = new Employee();
                    while (reader.Read())
                    {
                        empl.id = Convert.ToInt32(reader["emp_id"]);
                        empl.role = reader["role"].ToString();
                        var balanceCapacity = reader["Balance_Capacity"] != null ? reader["Balance_Capacity"].ToString() : null;
                        var originalCapacity = reader["Original_Capacity"] != null ? reader["Original_Capacity"].ToString() : null;
                        
                        if (balanceCapacity != null ? !string.IsNullOrEmpty(balanceCapacity) : false)
                            int.TryParse(balanceCapacity, out maxCapacity);
                        else
                            int.TryParse(originalCapacity, out maxCapacity);
                        empl.maxCapacity = maxCapacity;

                    }
                    cmd.Dispose();
                    //SqlCommand cmd1 = new SqlCommand("insert into pro_resources(Emp_id,Role) values (@id,@role)", sqlConnn);
                    //sqlConnn.Close();


                    System.Web.UI.HtmlControls.HtmlTableCell col1 = new System.Web.UI.HtmlControls.HtmlTableCell();
                    TextBox txt = new TextBox();
                    txt.ID = "Hours" + listControl.Items[i].Text;
                    txt.ClientIDMode = ClientIDMode.Static;
                    txt.Width = 150;
                    txt.Attributes.Add("maxCapacity", empl.maxCapacity.ToString());
                    txt.Attributes.Add("class", "capacity");
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



    

    protected void btn1_Click(object sender, EventArgs e)
    {
        var totalHours = CalculateTotalHours();
        Employee emp1 = new Employee();
        DateTime stratdate = Convert.ToDateTime(sdate1.Text);
        DateTime enddate = Convert.ToDateTime(edate1.Text);
        int weekdays = emp1.weekdays(stratdate, enddate);
        var totally = (totalHours / 5) * weekdays;
        if (totally >= Convert.ToInt32(duration.Text))
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;Integrated Security=True");
            sqlCon.Open();
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
            if (FileUpload1.HasFile)
            {
                try
                {

                    FileUpload1.SaveAs("D:\\Upload\\" + FileUpload1.FileName);
                    string path = "D:\\Upload\\" + FileUpload1.FileName;
                    myCom.Parameters.AddWithValue("@sow", path);
                    myCom.Parameters.AddWithValue("@status", 1);
                    //Label4.Text = "File Uploaded";
                }
                catch (Exception ex)
                {

                    //Label4.Text = "ERROR: " + ex.Message.ToString();
                }
            }
            else
            {
                myCom.Parameters.AddWithValue("@sow", "");
                myCom.Parameters.AddWithValue("@status", 0);
            }
            p_id = myCom.ExecuteScalar();
            //changed
            string prefix = string.Empty;
            //TO UPDATE THE PROJECT_ID WITH TYPE OF FRAMEWORK 
            if (frame.SelectedValue == "Ektron")
                prefix = "EKT_" + p_id;
            if (frame.SelectedValue == "Episerver")
                prefix = "EPS_" + p_id;
            if (frame.SelectedValue == "Kentico")
                prefix = "KEN_" + p_id;
            if (frame.SelectedValue == "Sitecore")
                prefix = "STC_" + p_id;
            if (frame.SelectedValue == "Sharepoint")
                prefix = "SHR_" + p_id;
            if (frame.SelectedValue == "Majento")
                prefix = "MAJ_" + p_id;
            if (frame.SelectedValue == "Drupal")
                prefix = "DRU_" + p_id;
            if (frame.SelectedValue == "Joomla")
                prefix = "JOO_" + p_id;

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
                string queries = "INSERT INTO pro_resources(P_id,Emp_id,Role,Capacity,added_date) values (@pid1,@eid,@role,@capacity,@added)";
                SqlCommand comm1 = new SqlCommand(queries, sqlCon);
                comm1.Parameters.AddWithValue("@pid1", p_id);
                comm1.Parameters.AddWithValue("@eid", emp.id);
                comm1.Parameters.AddWithValue("@role", emp.role);
                comm1.Parameters.AddWithValue("@capacity", emp.value);
                comm1.Parameters.AddWithValue("@added", sdate1.Text);
                comm1.ExecuteNonQuery();
                comm1.Dispose();
                sqlCon.Close();

                //Update Balance Hours
                float balanceCapacity = float.Parse(emp.maxCapacity.ToString()) - emp.value;

                
                if (balanceCapacity >= 1)
                {
                    sqlCon.Open();
                    SqlCommand com1 = new SqlCommand("update Employee set Balance_Capacity='" + balanceCapacity + "',pro_flag=@a where emp_id=@id", sqlCon);
                    com1.Parameters.AddWithValue("@id", emp.id);
                    com1.Parameters.AddWithValue("@a", 0);
                    com1.ExecuteScalar();
                    sqlCon.Close();
                }
                else 
                {
                    sqlCon.Open();
                    SqlCommand cmd1 = new SqlCommand("update Employee set Balance_Capacity = '" + balanceCapacity + "', Pro_flag=@a where emp_id=@id", sqlCon);
                    cmd1.Parameters.AddWithValue("@a", 1);
                    cmd1.Parameters.AddWithValue("@id", emp.id);
                    cmd1.ExecuteScalar();
                    sqlCon.Close();
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The entered capacity is high ');", true);
                }
            }




            sqlCon.Close();
            //Response.Redirect("login.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The given duration is not sufficient with entered resources capacity ');", true);
        }
    }

    private void ShowData()
   {
 	  throw new NotImplementedException();
   }

    
}
public class Employee
{
    public int id { get; set; }
    public string role { get; set; }
    public string name { get; set; }
    public float value { get; set; }
    public int maxCapacity { get; set; }

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