<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="manager.aspx.cs" Inherits="manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/projects.css" rel="stylesheet" />
      <script src="js/jquery-1.11.0.js"></script>
    
    <script src="js/manager.js"></script>
     
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--MENU LINKBUTTONS--%>
    <div  id="menu">
     <ul>
        <li><a href="manager.aspx">Projects</a></li>
        <li><a href="resource.aspx">Resources</a></li>
        <li><a href="addproject.aspx">Add New Project</a></li>
        <li><a href="dash.aspx">Dashboard</a></li>
        <li><a href="addresource.aspx">Add New Resource</a></li>
      
    </ul>
        <asp:Label ID="lblin" CssClass="logo" runat="server" Text="Label"></asp:Label>
         <asp:Label ID="desig" CssClass="desi" runat ="server" Text="Label"></asp:Label>
   
    </div>
    <asp:LinkButton ID="link_logout" CssClass="link" runat="server" OnClick="linkbutton8_Click">Logout</asp:LinkButton>
   
    
                <div id="grid">
               <asp:GridView ID="grid_projects" AutoGenerateColumns="false" Width="900px" runat="server" CellPadding="6"  OnRowCommand="GridView3_RowCommand">  
              <HeaderStyle BackColor="#196763" ForeColor="#ffffff" Height="45px" Font-Size="18px"/>  
            <RowStyle BackColor="#C7CECD" Height="30px" Font-Size="17px"/> 
                   <Columns> 
                    
                 <%--PROJECT_NAME COLUMN--%>
                <asp:TemplateField HeaderText="Project_Name" ItemStyle-Font-Bold="true" ItemStyle-Font-Italic="true" ItemStyle-Font-Names="cambria">
                    <ItemTemplate>  
                        <asp:LinkButton ID="lbl_Name" runat="server" Text='<%#Eval("P_name") %>' CommandArgument='<%#Bind("P_id") %>' CommandName="select" Font-Underline="true"  ForeColor="#006666"></asp:LinkButton>  
                    </ItemTemplate>   
                   
                </asp:TemplateField> 
                 
                   <%--PROJECT_ID--%>
                  <asp:TemplateField HeaderText="Project_Id" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Id" runat="server" Text='<%#Eval("Project_id") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>

                <%--CLIENT COLUMN--%>
                <asp:TemplateField HeaderText="Client" HeaderStyle-Width="200px"  >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Client" runat="server" Text='<%#Eval("Client") %>'></asp:Label>  
                    </ItemTemplate>  
                   
                </asp:TemplateField>  
                <%--DURAION COLUMN--%>
                <asp:TemplateField HeaderText="Duration" >  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Duration" runat="server" Text='<%#Eval("Duration") %>'></asp:Label>  
                    </ItemTemplate> 
                   
                    </asp:TemplateField> 
                <%--STATUS OF PROJECT--%>
                 <asp:TemplateField HeaderText="Status" HeaderStyle-Width="200px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_P_status" runat="server" Text='<%#Eval("Project_status") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>  
            </Columns>  
           
        </asp:GridView>
           </div>
               
</asp:Content>

