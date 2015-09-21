<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectList.aspx.cs" Inherits="ProjectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/projects.css" rel="stylesheet" />
     <link href="css/projectlist.css" rel="stylesheet" />
      <script src="js/jquery-1.11.0.js"></script>
    
    <script type="text/javascript">
        $("#menu2 ul li a").each(function (index) {
            if (this.href.trim() == window.location)
                $(this).css("background-color", "blue");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div  id="menu">
     <ul>
        <li style ="background-color:#FFEFD5; margin: 5px 7px 0 36px;font-size: 17px;border-radius:5px;padding: 4px 0px;width: 155px;text-decoration: none;color: #800000;"><a href="manager.aspx">Projects</a></li>
        <li><a href="resource.aspx">Resources</a></li>
        <li><a href="addproject.aspx">Add New Project</a></li>
        <li><a href="dash.aspx">Dashboard</a></li>
        <li><a href="addresource.aspx">Add New Resource</a></li>
      
    </ul>
         </div>
    
    
    <asp:HyperLink ID="HyperLink1" CssClass="link" NavigateUrl="~/login.aspx" runat="server">Logout</asp:HyperLink>
    

    <div id="menu2">
     <ul>
        <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">Project details</asp:LinkButton></li>
       <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click1">Resource details</asp:LinkButton></li>
          <li> <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Add_Resource</asp:LinkButton></li>
        <li><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Removed List</asp:LinkButton></li>
        
    </ul>
    </div>
   

    <asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">    
           <div class="grid1">
               <asp:GridView ID="GridView3" DataKeyNames ="P_id" AutoGenerateColumns="false" runat="server" CellPadding="6" OnRowCancelingEdit="GridView3_RowCancelingEdit"  
  OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" OnRowDeleting="GridView3_RowDeleting" OnRowDataBound="GridView3_RowDataBound" >
        <HeaderStyle BackColor="#663300"  height="45px" ForeColor="#ffffff" Font-Bold="true" Font-Size="18px"/> 
        <rowstyle Height="35px" Font-Size="17px" BackColor="#e7ceb6"/>
          
         
           <Columns> 
               
                <%--PROJECT_ID--%>
                <asp:TemplateField HeaderText="Project_Id">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Id" runat="server" Text='<%#Eval("P_id") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
                <%--PROJECT_NAME COLUMN--%>
                <asp:TemplateField HeaderText="Project_Name">
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("P_name") %>'></asp:Label>  
                    </ItemTemplate>   
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("P_name") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <%--CLIENT COLUMN--%>
                <asp:TemplateField HeaderText="Client" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Client" runat="server" Text='<%#Eval("Client") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Client" runat="server" Text='<%#Eval("Client") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                </asp:TemplateField>  
                <%--DURATION COLUMN--%>
                <asp:TemplateField HeaderText="Duration" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Duration" runat="server" Text='<%#Eval("Duration") %>'></asp:Label>  
                    </ItemTemplate> 
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Duration" runat="server" Text='<%#Eval("Duration") %>'></asp:TextBox>  
                    </EditItemTemplate>
                    </asp:TemplateField> 
                <%--TECHNOLOGY--%>
                 <asp:TemplateField HeaderText="Technology" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_tech" runat="server" Text='<%#Eval("technology") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField> 
               <%-- Startdate--%>
                 <asp:TemplateField HeaderText="Start_date">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_start_date" runat="server" Text='<%#Eval("start_date","{0:MM/dd/yyyy}")%>'  ></asp:Label>  
                    </ItemTemplate> 
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_start_date" runat="server" Text='<%#Eval("start_date") %>' TextMode="Date"></asp:TextBox>  
                    </EditItemTemplate>
                    </asp:TemplateField> 
                <%-- Enddate--%>
                 <asp:TemplateField HeaderText="End_date" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_end_date" runat="server" Text='<%#Eval("end_date","{0:MM/dd/yyyy}") %>'></asp:Label>  
                    </ItemTemplate> 
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_end_date" runat="server" Text='<%#Eval("end_date") %>' TextMode="Date"></asp:TextBox>  
                    </EditItemTemplate>
                    </asp:TemplateField>
                <%-- Manager_ID--%>
                 <asp:TemplateField HeaderText="Manager">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Manger" runat="server" Text='<%#Eval("Manager_Id") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
                <%-- Sow_status--%>
                 <asp:TemplateField HeaderText="SOW_status" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_SOW_status" runat="server" Text='<%#Eval("SOW_status") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
                <%--STATUS OF PROJECT--%>
                 <asp:TemplateField HeaderText="Status" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_P_status" runat="server" Text='<%#Eval("Project_status") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>  
                       <%--<asp:TemplateField HeaderText="Deleted_date">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_deleted" runat="server" Text='<%#Eval("deleted_date","{0,MM/dd/yyyy}") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>--%>
                 <asp:TemplateField HeaderText="Action" ItemStyle-Width="140px" >  
                    <ItemTemplate> 
                        <%--EDIT AND DELETE BUTTON IN ITEMTEMPLATE--%>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit"/> 
                        <asp:Button ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete" />  
                    </ItemTemplate>  
                    <%--EDITITEM TEMPLATE TO SHOW UPDATE AND CANCEL AFTER CLICKING EDIT BUTTON--%>
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
            </Columns>  
          
                    
        </asp:GridView>
    </div>
          </asp:View>
               
        <asp:View ID="View2" runat="server">
            <div id="grid2"> 
    <asp:GridView ID="GridView1" width="800px" DataKeyNames="P_id" AutoGenerateColumns ="false" runat="server" CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit"  
  
OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="GridStyle"  OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound"> 
         <HeaderStyle BackColor="#663300"  height="45px" ForeColor="#ffffff" Font-Size="18px"/> 
        <rowstyle Height="35px" Font-Size="17px" BackColor="#e7ceb6"/> 
           <Columns> 
               
                <%--PROJECT_ID--%>
                <asp:TemplateField HeaderText="Project_Id">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Id" runat="server" Text='<%#Eval("P_id") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
                <%--PROJECT_NAME COLUMN--%>
                <asp:TemplateField HeaderText="Emp_Id">
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Emp_Id" runat="server" Text='<%#Eval("Emp_id") %>'></asp:Label>  
                    </ItemTemplate>   
                   
                </asp:TemplateField>  
             <%--EMPLOYEE NAME--%>
             <asp:TemplateField HeaderText="Emp Name">
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Emp_Name" runat="server" Text='<%#Eval("emp_name") %>'></asp:Label>  
                    </ItemTemplate>   
                   
                </asp:TemplateField>  
                <%--CLIENT COLUMN--%>
                <asp:TemplateField HeaderText="Role">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Role" runat="server" Text='<%#Eval("Role") %>'></asp:Label>  
                    </ItemTemplate>  
                   <EditItemTemplate>  
                       <asp:DropDownList ID="role" runat="server" AutoPostBack="True" DataTextField="Role" DataValueField="Role" >       
                           <asp:ListItem Value="Junior_Developer">Junior_Developer</asp:ListItem> 
                                 <asp:ListItem Value="Senior_Developer">Senior_Developer</asp:ListItem>
                                 <asp:ListItem Value="Tech_Lead">Tech_Lead</asp:ListItem>
                         </asp:DropDownList>  
                    </EditItemTemplate>
                </asp:TemplateField>  
                <%--Capacity COLUMN--%>
                <asp:TemplateField HeaderText="Capacity">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Capacity" runat="server" Text='<%#Eval("Capacity") %>'></asp:Label>  
                    </ItemTemplate> 
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Capacity" runat="server" Text='<%#Eval("Capacity") %>'></asp:TextBox>  
                    </EditItemTemplate>
                    </asp:TemplateField> 
                <%--Added_date COLUMN--%>
             <asp:TemplateField HeaderText="From Date">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_added_date" runat="server" Text='<%#Eval("added_date","{0:MM/dd/yyyy}") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField> 
              <asp:TemplateField HeaderText="Action">  
                    <ItemTemplate> 
                        <%--EDIT AND DELETE BUTTON IN ITEMTEMPLATE--%>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit"/> 
                        <asp:Button ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete" />  
                    </ItemTemplate>  
                    <%--EDITITEM TEMPLATE TO SHOW UPDATE AND CANCEL AFTER CLICKING EDIT BUTTON--%>
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
            </Columns>  
              
        </asp:GridView>
                </div>
            </asp:View>


        <asp:View ID="view3" runat ="server">

            <div id="additional">
                <table id="table">
             <tr><td height="50px"><asp:Label ID="Label1" runat="server"  Text="Select Name of Resource"></asp:Label></td>
    <td><asp:DropDownList ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server">
    </asp:DropDownList></td></tr>
    <tr><td height="50px"><asp:Label ID="Label2" runat="server" Text="Designation of the Resource"></asp:Label></td>
    <td><asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" ></asp:TextBox></td></tr>
    <tr><td><asp:Label ID="Label3" runat="server"  Text="Enter Capacity of the Resource For the project"></asp:Label></td>
    <td height="50px"><asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox></td>
    <td><asp:Label ID="Label4" runat="server" ForeColor="Red"  Text="Label" Visible="False"></asp:Label></td></tr>
    <tr><td height="50px"></td><td><asp:Button ID="Button1" CssClass ="btn" runat="server"  Text="Add Resource" OnClick="Button1_Click" /></td></tr>


    
</table>
                
</div>

        </asp:View>
        </asp:MultiView>
   
</asp:Content>

