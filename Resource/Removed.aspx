<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Removed.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/projectlist.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="menu3">
     <ul>
         <li><asp:LinkButton ID="link_delproject" runat="server" OnClick="LinkButton3_Click">Deleted projects</asp:LinkButton></li>
          <li><asp:LinkButton ID="link_delresource" runat="server" OnClick="LinkButton4_Click">Deleted resources</asp:LinkButton></li>
        
    </ul>
           <asp:LinkButton ID="link_back" runat="server" CssClass="back" OnClick="LinkButton1_Click" >Back</asp:LinkButton>
    </div>

     <asp:MultiView ID="MultiView1" runat="server">
   
     <%-- FOR DELETED RESOURCE LIST--%>
          
        <asp:View ID="View1" runat="server"> 
             <div id="project" >
         <asp:GridView ID="grid_delproject"  AutoGenerateColumns="false" DataKeyNames="P_id" runat="server" >  
            
          <HeaderStyle BackColor="#196763"  height="45px" ForeColor="#ffffff" Font-Bold="true" Font-Size="18px"/> 
        <rowstyle Height="35px" Font-Size="17px" BackColor="#C7CECD"/>
            <Columns> 
               
                <%--PROJECT_ID--%>
                <asp:TemplateField HeaderText="Project_Id"  >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Id" runat="server" Text='<%#Eval("P_id") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
                <%--PROJECT_NAME COLUMN--%>
                <asp:TemplateField HeaderText="Project_Name" >
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("P_name") %>'></asp:Label>  
                    </ItemTemplate>   
                </asp:TemplateField>  
                <%--CLIENT COLUMN--%>
                <asp:TemplateField HeaderText="Client">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Client" runat="server" Text='<%#Eval("Client") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <%--DURATION COLUMN--%>
                <asp:TemplateField HeaderText="Duration" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Duration" runat="server" Text='<%#Eval("Duration") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField> 
                <%--TECHNOLOGY--%>
                 <asp:TemplateField HeaderText="Technology" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_tech" runat="server" Text='<%#Eval("technology") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField> 
               <%-- Startdate--%>
                 <asp:TemplateField HeaderText="Start_date" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_start_date" runat="server" Text='<%#Eval("start_date","{0:MM/dd/yyyy}")%>'  ></asp:Label>  
                    </ItemTemplate>
                    </asp:TemplateField> 
                <%-- Enddate--%>
                 <asp:TemplateField HeaderText="End_date" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_end_date" runat="server" Text='<%#Eval("end_date","{0:MM/dd/yyyy}") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
                <%-- Manager_ID--%>
                 <asp:TemplateField HeaderText="Manager" >  
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
                 <asp:TemplateField HeaderText="Status">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_P_status" runat="server" Text='<%#Eval("Project_status") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>  
                       <asp:TemplateField HeaderText="Deleted_date" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_deleted" runat="server" Text='<%#Eval("deleted_date","{0:MM/dd/yyyy}") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
            </Columns>         
        </asp:GridView>
                </div>
            </asp:View>

         <%--FOR DELETED PROJECT LIST--%>

        <asp:View ID="View2" runat="server"> 
             <div id="resource">
    <asp:GridView ID="grid_delresource" Width ="700px" AutoGenerateColumns="false" DataKeyNames="P_id"  runat="server" CellPadding="6">  
        <HeaderStyle BackColor="#196763"  height="45px" ForeColor="#ffffff" Font-Bold="true" Font-Size="18px"/> 
        <rowstyle Height="35px" Font-Size="17px" BackColor="#C7CECD"/>
          <Columns> 
                <%--PROJECT_ID--%>
                <asp:TemplateField HeaderText="Project_Id" HeaderStyle-Width="150px">  
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
             <asp:TemplateField HeaderText="Emp Name" HeaderStyle-Width="150px">
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Emp_Name" runat="server" Text='<%#Eval("emp_name") %>'></asp:Label>  
                    </ItemTemplate> 
                </asp:TemplateField>  
                <%--CLIENT COLUMN--%>
                <asp:TemplateField HeaderText="Role">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Role" runat="server" Text='<%#Eval("Role") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <%--DURATION COLUMN--%>
                <asp:TemplateField HeaderText="Capacity">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Capacity" runat="server" Text='<%#Eval("Capacity") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField> 
            </Columns>  

        </asp:GridView>
                </div>
          
          </asp:View>
        </asp:MultiView>
</asp:Content>

