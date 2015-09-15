<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="manager.aspx.cs" Inherits="manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/manager.css" rel="stylesheet" />
     <script src="js/jquery-1.11.0.js"></script>
     <script src="js/manager.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--MENU LINKBUTTONS--%>
    <div  id="menu">
     <ul>
        <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Projects</asp:LinkButton></li>
        <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Resources</asp:LinkButton></li>
        <li><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Add new project</asp:LinkButton></li>
        <li><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Dashboard</asp:LinkButton></li>
         <li><asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">Add new resouce</asp:LinkButton></li>
    </ul>
    </div>
    <%--MULTIVIEW STARTS--%>
        <asp:MultiView ID="MultiView1" runat="server">

            <%--VIEW1 FOR SHOWING PROJECTS UNDER MANAGER--%>
            <asp:View ID="View1" runat="server">
               <asp:GridView ID="GridView3" DataKeyNames="P_id" AutoGenerateColumns="false" runat="server" CellPadding="6" OnRowCancelingEdit="GridView3_RowCancelingEdit"  
  
OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" OnRowDeleting="GridView3_RowDeleting" OnRowDataBound="GridView3_RowDataBound" OnRowCommand="GridView3_RowCommand">  
            <Columns> 
                <asp:TemplateField HeaderText="Action">  
                    <ItemTemplate> 
                        <%--SELECT BUTTON--%>
                        <asp:Button ID="lbltest" runat="server" Text="Select" CommandName="Action"
CommandArgument='<%#Bind("P_id") %>'></asp:Button> 
                        <%--EDIT AND DELETE BUTTON IN ITEMTEMPLATE--%>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" /> 
                        <asp:Button ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete" />  
                    </ItemTemplate>  
                    <%--EDITITEM TEMPLATE TO SHOW UPDATE AND CANCEL AFTER CLICKING EDIT BUTTON--%>
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
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
                <asp:TemplateField HeaderText="Client">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Client" runat="server" Text='<%#Eval("Client") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Client" runat="server" Text='<%#Eval("Client") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                </asp:TemplateField>  
                <%--DURAION COLUMN--%>
                <asp:TemplateField HeaderText="Duration">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Duration" runat="server" Text='<%#Eval("Duration") %>'></asp:Label>  
                    </ItemTemplate> 
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Duration" runat="server" Text='<%#Eval("Duration") %>'></asp:TextBox>  
                    </EditItemTemplate>
                    </asp:TemplateField> 
                <%--STATUS OF PROJECT--%>
                 <asp:TemplateField HeaderText="Status">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_P_status" runat="server" Text='<%#Eval("Project_status") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>  
            </Columns>  
            <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>  
            <RowStyle BackColor="#e7ceb6"/>  
        </asp:GridView>
                <%--CONNECTION STRING FOR DROPDOWNLIST IN GRIDVIEW--%>

    <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server"
	ConnectionString="<%$ ConnectionStrings:projectConnectionString %>"
	SelectCommand="SELECT DISTINCT [role] FROM [Employee]"></asp:SqlDataSource>--%>

    <%--ADD resource--%>

   <%-- <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
    <tr>
        <td style="width: 150px">
            Name:<br />
            <asp:TextBox ID="txtName" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            ID:<br />
            <asp:TextBox ID="txtid" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            Technology:<br />
            <asp:TextBox ID="txttech" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            Role:<br />
            <asp:TextBox ID="txtrole" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            Email:<br />
            <asp:TextBox ID="txtemail" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            Pass:<br />
            <asp:TextBox ID="txtpass" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            Framework:<br />
            <asp:TextBox ID="txtframe" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            Flag:<br />
            <asp:TextBox ID="txtflag" runat="server" Width="140" />
        </td>
        <td style="width: 100px">
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />
        </td>
    </tr>
</table>
    <asp:SqlDataSource ID="source1" runat="server" ConnectionString="<%$ ConnectionStrings:sridharConnectionString %>"
        InsertCommand="INSERT INTO Employee(name,id,tech,role,email,pass,framework,flag) VALUES (@Name, @ID,@tech,@role,@email,@pass,@frame,@flag)">
        <InsertParameters>
        <asp:ControlParameter Name="Name" ControlID="txtName" Type="String" />
        <asp:ControlParameter Name="ID" ControlID="txtid" Type="Int32" />
            <asp:ControlParameter Name="tech" ControlID="txttech" Type="String" />
            <asp:ControlParameter Name="role" ControlID="txtrole" Type="String" />
            <asp:ControlParameter Name="email" ControlID="txtemail" Type="String" />
            <asp:ControlParameter Name="pass" ControlID="txtpass" Type="String" />
            <asp:ControlParameter Name="frame" ControlID="txtframe" Type="String" />
            <asp:ControlParameter Name="flag" ControlID="txtflag" Type="Int32" />
    </InsertParameters>
        </asp:SqlDataSource>--%>

                <%-- ADD RESOURCE ENDS --%>

                <%--VIEW2 FOR RESOURCES UNDER MANAGER--%>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Magesh"></asp:Label>
            </asp:View>
            <%--VIEW2 END HERE--%>

            <%--VIEW3 FOR ADDING NEW PROJECT--%>
            <asp:View ID="View3" runat="server">
                
              <asp:Label ID="lblin" CssClass="logo" runat="server" Text="Label"></asp:Label>
                <asp:HyperLink ID="HyperLink1" CssClass="link" NavigateUrl="~/login.aspx" runat="server">Logout</asp:HyperLink>
             <div id="table">
                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                  </asp:ScriptManager>
                 <h2>Enter Project details</h2>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
              <table id="tblFormTable" CellSpacing="20" runat="server"  >
                <tr>
                    <td>
                        <asp:Label ID="pro_name" runat="server" Text="Project Name"></asp:Label>
                    </td>
                    <td> <asp:TextBox ID="pro_name1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="cliname" runat="server" Text="Clinet Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="cliname1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="durate" runat="server" Text="Duration"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="duration" runat="server"></asp:TextBox></td>
                </tr>
                  
                <tr>
                    <td>
                    <asp:Label ID="tech" runat="server" Text="Technology"></asp:Label></td>
                     
                    <td>
                    
                        <asp:DropDownList ID="tech1" runat="server" CssClass="drop1" OnSelectedIndexChanged="tech1_SelectedIndexChanged" AutoPostBack="true" >
                            <asp:ListItem>select </asp:ListItem>
                            <asp:ListItem Value=".Net">.Net</asp:ListItem>
                            <asp:ListItem Value="Php">Php</asp:ListItem>
                        </asp:DropDownList>
                   </td>
                </tr>
                   
                <tr>
                    <td>
                        
                        <asp:Label ID="sdate" runat="server" Text="Start Date" ></asp:Label></td>
                    <td>
                        <asp:TextBox ID="sdate1" runat="server" TextMode="Date"></asp:TextBox>
                   </td>
                </tr>
                <tr>
                    <td>
                       
                        <asp:Label ID="edate" runat="server" Text="End Date"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="edate1" CssClass="pick1" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                        
                </tr>
                  <tr>
                      <td></td>
                      <td>
                          <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Junior Developer"></asp:Label>
                          <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Senior Developer"></asp:Label>
                          <asp:Label ID="Label6" runat="server" Text="Tech_Lead" CssClass="lbl"></asp:Label>
                      </td>
                  </tr>
                <tr>
                    <td>
                        <asp:Label ID="resource" runat="server" Text="Resources"></asp:Label>
                    </td>
                    <td>
                      
                     <asp:ListBox ID="ListBox1" runat="server" CssClass="drop2" AutoPostBack="True"  OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>
                     <asp:ListBox ID="ListBox2" runat="server" CssClass="drop2" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>
                     <asp:ListBox ID="ListBox3" runat="server" CssClass="drop2" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>             
                     
                       
                    </td>
                    
                </tr>
                      
               
                <tr>
                    <td>
                        <asp:Label ID="sow" runat="server" Text="SOW"></asp:Label></td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    
                </tr>
                 
            </table>
                     </ContentTemplate>
                     <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="ListBox1" EventName="SelectedIndexChanged" />
                     <asp:AsyncPostBackTrigger ControlID="ListBox2" EventName="SelectedIndexChanged" />
                     <asp:AsyncPostBackTrigger ControlID="ListBox3" EventName="SelectedIndexChanged" />
                    <%-- <asp:AsyncPostBackTrigger ControlID="jun_dev" EventName="SelectedIndexChanged" />--%>
                     </Triggers>
                     </asp:UpdatePanel> 
                    <asp:Button ID="btn1" CssClass="btn1" runat="server" Text="Submit" OnClick="btn1_Click" />
                    <asp:Button ID="btn2" runat="server" CssClass="btn2" Text="Cancel" />
                 </div>
            
            </asp:View>
            <asp:View ID="View4" runat="server">
                <asp:Label ID="Label3" runat="server" Text="Tamil"></asp:Label>
            </asp:View>
             <asp:View ID="View5" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Select Employees" OnClick="Button1_Click" />
   
    <asp:ListBox ID="ListBox4" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" SelectionMode="Multiple" Height="98px" Width="169px"></asp:ListBox>
     <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add Employess" Width="141px" />
            </asp:View>
            <%--VIEW3 ENDS HERE--%>

        </asp:MultiView>

    
        
</asp:Content>

