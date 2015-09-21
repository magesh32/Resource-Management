using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dash : System.Web.UI.Page
{
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false;MultipleActiveResultSets=True;");

    Employee1 emp = new Employee1();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
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
            DateTime today = Calendar1.TodaysDate;
            overall_capacity(today);
        }
    }

    // CALENDER DATE SELECTION CHANGED
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime cal = Calendar1.SelectedDate;
        if (typeoftech1.SelectedIndex != 0)
            if (Technology.SelectedIndex != 0)
                if (Framework.SelectedIndex != 0)
                    if (ProjectList.SelectedIndex != 0)
                        project_one(Convert.ToInt32(ProjectList.SelectedValue), cal);
                    else
                        frame_calculate(Framework.SelectedValue);
                else
                    tech_calculate(Technology.SelectedValue);
            else
                type_of_tech_calculate(typeoftech1.SelectedValue);
        else
            overall_capacity(cal);
    }

    // TYPE OF PROJECT SELECTION CHANGED

    protected void typeoftech1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (typeoftech1.SelectedValue == "proprietary")
        {
            Technology.Items.FindByValue(".Net").Enabled = true;
            Technology.Items.FindByValue("Php").Enabled = false;
            Technology.Items.FindByValue("Angular JS").Enabled = false;
        }
        else if (typeoftech1.SelectedValue == "Open Source")
        {
            Technology.Items.FindByValue(".Net").Enabled = false;
            Technology.Items.FindByValue("Php").Enabled = true;
            Technology.Items.FindByValue("Angular JS").Enabled = true;
        }
        type_of_tech_calculate(typeoftech1.SelectedValue);
    }

    //TECHNOLOGY SELECTION CHANGED
    protected void Technology_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Technology.SelectedValue == ".Net")
        {
            Framework.Items.FindByValue("Ektron").Enabled = true;
            Framework.Items.FindByValue("Episerver").Enabled = true;
            Framework.Items.FindByValue("Kentigo").Enabled = true;
            Framework.Items.FindByValue("Sitecore").Enabled = true;
            Framework.Items.FindByValue("Sharepoint").Enabled = true;
            Framework.Items.FindByValue("Majento").Enabled = false;
            Framework.Items.FindByValue("Drupal").Enabled = false;
            Framework.Items.FindByValue("Jumla").Enabled = false;
        }
        else if (Technology.SelectedValue == "Php")
        {
            Framework.Items.FindByValue("Ektron").Enabled = false;
            Framework.Items.FindByValue("Episerver").Enabled = false;
            Framework.Items.FindByValue("Kentigo").Enabled = false;
            Framework.Items.FindByValue("Sitecore").Enabled = false;
            Framework.Items.FindByValue("Sharepoint").Enabled = false;
            Framework.Items.FindByValue("Majento").Enabled = true;
            Framework.Items.FindByValue("Drupal").Enabled = true;
            Framework.Items.FindByValue("Jumla").Enabled = true;
        }
        tech_calculate(Technology.SelectedValue);
    }

    // framework selection index changed
    protected void Framework_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData(Framework.SelectedValue);
        frame_calculate(Framework.SelectedValue);
    }

    //DATA BINDING TO DROPDOWNLIST 2 FOR PROJECTLIST
    protected void BindData(string framework)
    {
        string query = "Select * from projectlist where framework='" + framework + "'";
        SqlDataAdapter adpt = new SqlDataAdapter(query, sqlConnn);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        ProjectList.DataSource = dt;
        ProjectList.DataBind();
        ProjectList.DataTextField = "P_name";
        ProjectList.DataValueField = "P_id";
        ProjectList.DataBind();
        ProjectList.Items.Insert(0, new ListItem("Select", "0"));
    }

    //FOR PROJECTLIST SELECTING INDEX CHANGED

    protected void ProjectList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int project_id = Convert.ToInt32(ProjectList.SelectedValue);
        DateTime selected = Calendar1.SelectedDate;
        if (selected.Date == DateTime.MinValue)
        {
            selected = Calendar1.TodaysDate;
        }
        project_one(project_id, selected);
    }


    //FOR OVERALL CAPACITY CALCULATION

    protected void overall_capacity(DateTime selected)
    {
        sqlConnn.Open();
        float total_utilize = 0.0f, total_ideal = 0.0f, totally_utilized = 0.0f;
        int count, original_capacity = 40, weekday;
        float total_percentage;
        count = emp.employee_count();
        SqlCommand cmd3 = new SqlCommand("select distinct typeof_tech from projectlist", sqlConnn);
        SqlDataReader reader4 = cmd3.ExecuteReader();
        while (reader4.Read())
        {
            string t_tech = reader4["typeof_tech"].ToString();
            total_utilize = type_of_technology(t_tech, selected);
            totally_utilized += total_utilize;
        }
        sqlConnn.Close();
        DateTime startDate = new DateTime(selected.Year, selected.Month, 1);
        weekday = emp.weekdays(startDate, selected);
        total_ideal = (count) * (weekday * (original_capacity / 5));
        total_percentage = (totally_utilized / total_ideal) * 100;
        if (totally_utilized != 0 && total_ideal != 0)
        {
            Utilized.Text = "Utilized Capacity is: " + totally_utilized;
            Ideal.Text = "Ideal Capacity is: " + total_ideal;
            Percentage.Text = "Utilized Percentage is: " + total_percentage + "%";
        }
        else if (total_ideal == 0)
        {
            Utilized.Text = "There is no resource or project in the framework";
            Ideal.Text = "";
            Percentage.Text = "";
        }
    }



    //FOR TYPE OF TECHNOLOGY

    protected void type_of_tech_calculate(string type_of_tech)
    {
        float type_of_tech_utilized = 0.0f, type_of_tech_ideal = 0.0f, t_of_percentage;

        int count, type_of_tech_org_capacity = 40, weekday;
        count = emp.type_of_tech_employee_count(type_of_tech);
        DateTime selected = Calendar1.SelectedDate;
        if (selected.Date == DateTime.MinValue)
        {
            selected = Calendar1.TodaysDate;
        }
        type_of_tech_utilized = type_of_technology(type_of_tech, selected);
        DateTime startDate = new DateTime(selected.Year, selected.Month, 1);
        weekday = emp.weekdays(startDate, selected);
        type_of_tech_ideal = (count) * (weekday * (type_of_tech_org_capacity / 5));
        t_of_percentage = (type_of_tech_utilized / type_of_tech_ideal) * 100;
        if (type_of_tech_utilized != 0 && type_of_tech_ideal != 0)
        {
            Utilized.Text = "Utilized Capacity is: " + type_of_tech_utilized;
            Ideal.Text = "Ideal Capacity is: " + type_of_tech_ideal;
            Percentage.Text = "Utilized Percentage is: " + t_of_percentage + "%";
        }
        else if (type_of_tech_ideal == 0)
        {
            Utilized.Text = "There is no resource or project in the framework";
            Ideal.Text = "";
            Percentage.Text = "";
        }
    }

    //FOR TYPE_OF _TECHNOLOGY PARENT CALL
    protected float type_of_technology(string type_of_tech, DateTime selected)
    {
        if (sqlConnn.State != System.Data.ConnectionState.Open)
            sqlConnn.Open();
        float type_tech_utilized = 0.0f;
        float total_calculate = 0.0f;
        SqlCommand cmd2 = new SqlCommand("select distinct technology from projectlist where typeof_tech=@t_tech", sqlConnn);
        cmd2.Parameters.AddWithValue("@t_tech", type_of_tech);
        SqlDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            string type_tech_tech = reader2["technology"].ToString();
            total_calculate = technology(type_tech_tech, selected);
            type_tech_utilized += total_calculate;
        }
        return type_tech_utilized;
    }

    //FOR TECHNOLOGY
    protected void tech_calculate(string name)
    {

        float tech_utilized = 0.0f, tech_ideal = 0.0f, tech_percentage;

        int count, tech_org_capacity = 40, weekday;
        count = emp.tech_employee_count(name);
        DateTime selected = Calendar1.SelectedDate;
        if (selected.Date == DateTime.MinValue)
        {
            selected = Calendar1.TodaysDate;
        }
        tech_utilized = technology(name, selected);
        DateTime startDate = new DateTime(selected.Year, selected.Month, 1);
        weekday = emp.weekdays(startDate, selected);
        tech_ideal = (count) * (weekday * (tech_org_capacity / 5));
        tech_percentage = (tech_utilized / tech_ideal) * 100;

        if (tech_utilized != 0 && tech_ideal != 0)
        {
            Utilized.Text = "Utilized Capacity is: " + tech_utilized;
            Ideal.Text = "Ideal Capacity is: " + tech_ideal;
            Percentage.Text = "Utilized Percentage is: " + tech_percentage + "%";
        }
        else if (tech_ideal == 0)
        {
            Utilized.Text = "There is no resource or project in the framework";
            Ideal.Text = "";
            Percentage.Text = "";
        }
    }

    //TECHNOLOGY FOR PARENT CALL
    protected float technology(string tech, DateTime selected)
    {
        if (sqlConnn.State != System.Data.ConnectionState.Open)
            sqlConnn.Open();
        float tech_utilized = 0.0f;
        ArrayList tech_arr = new ArrayList();
        SqlCommand cmd2 = new SqlCommand("select distinct framework from projectlist where technology=@tech", sqlConnn);
        cmd2.Parameters.AddWithValue("@tech", tech);
        SqlDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            string frame_tech = reader2["framework"].ToString();
            tech_arr = framework(frame_tech, selected);
            tech_utilized += (float)tech_arr[0];
        }
        return tech_utilized;
    }



    // FOR FRAMEWORK CALCULATION FROM DROPDOWN SELECTION
    protected void frame_calculate(string frame)
    {
        ArrayList arr1 = new ArrayList();
        float frame_ideal = 0.0f;
        int org_capacity = 40, weekday;
        float frame_percentage = 0.0f;
        DateTime selected = Calendar1.SelectedDate;
        if (selected.Date == DateTime.MinValue)
        {
            selected = Calendar1.TodaysDate;
        }
        arr1 = framework(frame, selected);
        DateTime startDate = new DateTime(selected.Year, selected.Month, 1);

        weekday = emp.weekdays(startDate, selected);

        frame_ideal = ((int)arr1[1]) * (weekday * (org_capacity / 5));
        frame_percentage = (((float)arr1[0]) / frame_ideal) * 100;

        if ((float)arr1[0] != 0 && frame_ideal != 0)
        {
            Utilized.Text = "Utilized Capacity is: " + arr1[0];
            Ideal.Text = "Ideal Capacity is: " + frame_ideal;
            Percentage.Text = "Utilized Percentage is: " + frame_percentage + "%";
        }
        else if (frame_ideal == 0)
        {
            Utilized.Text = "There is no resource or project in the framework";
            Ideal.Text = "";
            Percentage.Text = "";
        }
    }

    //FROM PARENT CALL OF TECH SELECTED
    protected ArrayList framework(string frame, DateTime selected)
    {
        int[] frame_calculated = new int[3];
        float frame_utilized = 0.0f;
        ArrayList arr = new ArrayList();
        if (sqlConnn.State != System.Data.ConnectionState.Open)
            sqlConnn.Open();
        int p_count;
        int count = 0, p_id;
        for (int i = 0; i < Framework.Items.Count; i++)
        {
            if (Framework.Items[i].Text == frame)
            {
                count = emp.employee_count(frame);
                SqlCommand cmd1 = new SqlCommand("select P_id from projectlist where framework=@frame", sqlConnn);
                cmd1.Parameters.AddWithValue("@frame", frame);
                SqlDataReader p_read = cmd1.ExecuteReader();
                while (p_read.Read())
                {
                    p_id = Convert.ToInt32(p_read["P_id"]);
                    p_count = emp.employee_count(p_id);
                    frame_calculated = emp.capcacity_today(p_id, selected, p_count);
                    frame_utilized += frame_calculated[0];
                }
            }
        }
        arr.Add(frame_utilized);
        arr.Add(count);
        return arr;
    }



    //FOR ONE PROJECT
    protected void project_one(int project_id, DateTime cal)
    {
        int count = 0;
        int[] calculated = new int[3];
        float project_utilized = 0.0f, project_ideal = 0.0f;
        float project_percentage;
        count = emp.employee_count(project_id);
        calculated = emp.capcacity_today(project_id, cal, count);
        project_utilized = calculated[0];
        project_ideal = calculated[1];
        project_percentage = (project_utilized / project_ideal) * 100;
        if (project_utilized != 0 && project_ideal != 0)
        {
            Utilized.Text = "Utilized Capacity is: " + project_utilized;
            Ideal.Text = "Ideal Capacity is: " + project_ideal;
            Percentage.Text = "Utilized Percentage is: " + project_percentage + "%";
        }
        else if (project_ideal == 0)
        {
            Utilized.Text = "There is no resource in the project";
            Ideal.Text = "";
            Percentage.Text = "";
        }
        else
        {
            Utilized.Text = "Selected date is not in between project's start date and end date";
            Ideal.Text = "";
            Percentage.Text = "";
        }
    }

}

//EMPLOYEE1 CLASS

public class Employee1
{
    SqlConnection sqlConnn = new SqlConnection(@"Data Source=AMX503-PC;Initial Catalog=project;User Id=sa;Password=sa5;Trusted_connection=false;MultipleActiveResultSets=true");

    //ARRAY OF AMEEX HOLIDAYS
    DateTime[] ameexHolidays = new DateTime[] { new DateTime(2015, 01, 15), new DateTime(2015, 01, 26), new DateTime(2015, 05, 01), new DateTime(2015, 07, 03), new DateTime(2015, 07, 18), new DateTime(2015, 08, 15), new DateTime(2015, 09, 07), new DateTime(2015, 10, 02), new DateTime(2015, 11, 10), new DateTime(2015, 12, 25) };

    //CALCULATING WEEKDAYS
    public int weekdays(DateTime start, DateTime end)
    {
        int noofdays = 0;
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

    //  CALCULATING CAPACITY OF PROJECT WHEN NO DATE IS SELECTED 

    public int[] capcacity_today(int project_id, DateTime today, int count)
    {
        int weekday;
        int org_capacity = 40;
        int[] calculated = new int[3];
        int total_capacity = 0;
       
        DateTime start = DateTime.MinValue, end = DateTime.MinValue;
        sqlConnn.Open();
        SqlCommand command = new SqlCommand("select start_date,end_date,Total_capacity from projectlist where P_id=@pro_id", sqlConnn);
        command.Parameters.AddWithValue("@pro_id", project_id);
        SqlDataReader reader = command.ExecuteReader();
        //READING TOTAL_CAPACITY , START_DATE AND END_DATE OF A PROJECT
        if (reader.Read())
        {
            total_capacity = Convert.ToInt32(reader["Total_capacity"]);
            start = Convert.ToDateTime(reader["start_date"]);
            end = Convert.ToDateTime(reader["end_date"]);
        }
        //COMPARING WHETHER TODAY IS BETWEEN PROJECT'S START_DATE AND END_DATE 
      
        DateTime this_month = new DateTime(today.Year, today.Month, 1);
       // IF PROJECT START DATE'S MONTH AND TODAY'S MONTH SAME AND CALCULATING WEEKDAYS 
        if (start.Month == today.Month)
        {
            if (DateTime.Compare(start, this_month) >= 0)
            {
                if (DateTime.Compare(end, today) >= 0)
                {
                    weekday = weekdays(start, today);
                    calculated[0] = weekday * (total_capacity / 5);
                    calculated[1] = count * (weekday * (org_capacity / 5));
                    calculated[2] = weekday;
                }
                else
                {
                    weekday = weekdays(start, end);
                    calculated[0] = weekday * (total_capacity / 5);
                    calculated[1] = count * (weekday * (org_capacity / 5));
                    calculated[2] = weekday;
                }
            }
            //ELSE IT WILL CALCULATE FROM 1ST DAY OF THIS MONTH TO TODAY 
            else if (DateTime.Compare(start, this_month)<=0)
            {
                if (DateTime.Compare(end, today) >= 0)
                {
                    weekday = weekdays(this_month, today);
                    calculated[0] = weekday * (total_capacity / 5); //UTILIZED
                    calculated[1] = count * (weekday * (org_capacity / 5)); //IDEAL
                    calculated[2] = weekday; //WEEKDAYS
                }
                else
                {
                    weekday = weekdays(this_month, end);
                    calculated[0] = weekday * (total_capacity / 5);
                    calculated[1] = count * (weekday * (org_capacity / 5));
                    calculated[2] = weekday;
                }
            }
        }
        // }
        //IF NOT IN BETWEEN
        else
        {
            if (DateTime.Compare(start, this_month) >= 0)
            {
                if (DateTime.Compare(end, today) >= 0)
                {
                    weekday = weekdays(start, today);
                    calculated[0] = weekday * (total_capacity / 5);
                    calculated[1] = count * (weekday * (org_capacity / 5));
                    calculated[2] = weekday;
                }
                else
                {
                    weekday = weekdays(start, end);
                    calculated[0] = weekday * (total_capacity / 5);
                    calculated[1] = count * (weekday * (org_capacity / 5));
                    calculated[2] = weekday;
                }
            }
            else if (DateTime.Compare(start, this_month) <= 0)
            {
                if (DateTime.Compare(end, today) >= 0)
                {
                    weekday = weekdays(this_month, today);
                    calculated[0] = weekday * (total_capacity / 5); //UTILIZED
                    calculated[1] = count * (weekday * (org_capacity / 5)); //IDEAL
                    calculated[2] = weekday; //WEEKDAYS
                }
                else
                {
                    weekday = weekdays(this_month, end);
                    calculated[0] = weekday * (total_capacity / 5);
                    calculated[1] = count * (weekday * (org_capacity / 5));
                    calculated[2] = weekday;
                }
            }

        }
        sqlConnn.Close();
        return calculated;
    }

    //TOTAL EMPLOYEE COUNT

    public int employee_count()
    {
        //THIS TO CHECK WHETHER THE CONNECTION IS ALREADY OPENED
        if (sqlConnn.State != System.Data.ConnectionState.Open)
            sqlConnn.Open();
        int count = 0;
        SqlCommand command1 = new SqlCommand("select Emp_id from Employee where role NOT IN('admin','manager')", sqlConnn);
        SqlDataReader reader1 = command1.ExecuteReader();
        while (reader1.Read())
        {
            count++;
        }
        //THIS TO CHECK WHETHER THE CONNECTION IS ALREADY CLOSED
        if (sqlConnn.State != System.Data.ConnectionState.Closed)
            sqlConnn.Close();
        return count;
    }

    //Employee COUNT for project

    public int employee_count(int p_id)
    {
        //THIS TO CHECK WHETHER THE CONNECTION IS ALREADY OPENED
        if (sqlConnn.State != System.Data.ConnectionState.Open)
            sqlConnn.Open();
        int count = 0;
        SqlCommand command1 = new SqlCommand("select Emp_id from pro_resources where P_id=@pro_id and Flag<>@flag", sqlConnn);
        command1.Parameters.AddWithValue("@pro_id", p_id);
       command1.Parameters.AddWithValue("@flag",1);
        SqlDataReader reader1 = command1.ExecuteReader();
        while (reader1.Read())
        {
            count++;
        }
        //THIS TO CHECK WHETHER THE CONNECTION IS ALREADY CLOSED
        if (sqlConnn.State != System.Data.ConnectionState.Closed)
            sqlConnn.Close();
        return count;  // EMPLOYEE COUNT

    }

    // Employee count for framework
    public int employee_count(string framework)
    {
        if (sqlConnn.State != System.Data.ConnectionState.Open)
            sqlConnn.Open();
        int count = 0;
        SqlCommand command1 = new SqlCommand("select Emp_id from Employee where role NOT IN('admin','manager') and framework=@frame", sqlConnn);
        command1.Parameters.AddWithValue("@frame", framework);
        SqlDataReader reader1 = command1.ExecuteReader();
        while (reader1.Read())
        {
            count++;
        }
        if (sqlConnn.State != System.Data.ConnectionState.Closed)
            sqlConnn.Close();
        return count;


    }

    //Employee count for technology
    public int tech_employee_count(string tech)
    {
        if (sqlConnn.State != System.Data.ConnectionState.Open)
            sqlConnn.Open();
        int count = 0;
        SqlCommand command1 = new SqlCommand("select Emp_id from Employee where role NOT IN('admin','manager') and technology=@tech", sqlConnn);
        command1.Parameters.AddWithValue("@tech", tech);
        SqlDataReader reader1 = command1.ExecuteReader();
        while (reader1.Read())
        {
            count++;
        }
        if (sqlConnn.State != System.Data.ConnectionState.Closed)
            sqlConnn.Close();
        return count;
    }

    //EMPLOYEE COUNT FOR TYPE_OF_TECH

    public int type_of_tech_employee_count(string type_of_tech)
    {
        if (sqlConnn.State != System.Data.ConnectionState.Open)
            sqlConnn.Open();
        int count = 0;
        SqlCommand command1 = new SqlCommand("select Emp_id from Employee where role NOT IN('admin','manager') and typeof_tech=@type_tech", sqlConnn);
        command1.Parameters.AddWithValue("@type_tech", type_of_tech);
        SqlDataReader reader1 = command1.ExecuteReader();
        while (reader1.Read())
        {
            count++;
        }
        if (sqlConnn.State != System.Data.ConnectionState.Closed)
            sqlConnn.Close();
        return count;
    }

}