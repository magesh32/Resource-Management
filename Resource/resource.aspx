<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="resource.aspx.cs" Inherits="projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/projects.css" rel="stylesheet" />
     <script src="js/jquery-1.11.0.js"></script>
    
    <script src="js/manager.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    
  
    <asp:LinkButton ID="link_logout"  CssClass="link" runat="server" OnClick="linkbutton1_Click">Logout</asp:LinkButton>

    <div id="details">
    <asp:GridView ID="grid_resource" AutoGenerateColumns="false"   CellPadding="10"  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"  OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="emp_id"
                 runat="server">
         <HeaderStyle BackColor="#196763" ForeColor="#ffffff"  Font-Size="18px" Height="45px"/>  
        <rowstyle Height="40px" Font-Size="17px" BackColor="#C7CECD"/>
        <alternatingrowstyle  Height="35px" Font-Size="17px"/>
     <Columns> 
        <asp:TemplateField HeaderText="Employee_Id" HeaderStyle-Width="120px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Id" runat="server" Text='<%#Eval("emp_id") %>'></asp:Label>  
                    </ItemTemplate> 
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Employee_Name" HeaderStyle-Width="150px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_name" runat="server" Text='<%#Eval("emp_name") %>'></asp:Label>  
                    </ItemTemplate> 
                   <EditItemTemplate>  
                        <asp:TextBox ID="txt_name" runat="server" Text='<%#Eval("emp_name") %>'></asp:TextBox>  
                    </EditItemTemplate>
               </asp:TemplateField>
         <asp:TemplateField HeaderText="Email Id" HeaderStyle-Width="200px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_mail" runat="server" Text='<%#Eval("email_id") %>'></asp:Label>  
                    </ItemTemplate> 
                   <EditItemTemplate>  
                        <asp:TextBox ID="txt_mail" runat="server" Text='<%#Eval("email_id") %>'></asp:TextBox>  
                    </EditItemTemplate>
               </asp:TemplateField>
         <asp:TemplateField HeaderText="Role" HeaderStyle-Width="140px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_role" runat="server" Text='<%#Eval("Role") %>'></asp:Label>  
                    </ItemTemplate> 
                   <EditItemTemplate>  
                       <asp:DropDownList ID="role" runat="server" AutoPostBack="True" DataTextField="Role" DataValueField="Role" >       
                           <asp:ListItem Value="Junior_Developer">Junior_Developer</asp:ListItem> 
                                 <asp:ListItem Value="Senior_Developer">Senior_Developer</asp:ListItem>
                                 <asp:ListItem Value="Tech_Lead">Tech_Lead</asp:ListItem>
                         </asp:DropDownList>  
                    </EditItemTemplate>
               </asp:TemplateField>
          <asp:TemplateField HeaderText="Type Of Technology" HeaderStyle-Width="170px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_t_tech" runat="server" Text='<%#Eval("typeof_tech") %>'></asp:Label>  
                    </ItemTemplate> 
                   <EditItemTemplate>  
                       <asp:DropDownList ID="typeoftech" runat="server" AutoPostBack="True" DataTextField="typeof_tech" DataValueField="typeof_tech" >
                            <asp:ListItem Value="Select">Select</asp:ListItem>      
                           <asp:ListItem Value="Proprietary">Proprietary</asp:ListItem> 
                                 <asp:ListItem Value="Open Source">Open Source</asp:ListItem>
                                
                         </asp:DropDownList>  
                    </EditItemTemplate>
               </asp:TemplateField>
          <asp:TemplateField HeaderText="Technology" HeaderStyle-Width="120px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_tech" runat="server" Text='<%#Eval("technology") %>'></asp:Label>  
                    </ItemTemplate> 
                   <EditItemTemplate>  
                       <asp:DropDownList ID="tech" runat="server" AutoPostBack="True" DataTextField="technology" DataValueField="technology" >       
                           <asp:ListItem Value=".Net">.Net</asp:ListItem> 
                                 <asp:ListItem Value="Php">Php</asp:ListItem>
                                 <asp:ListItem Value="Angular JS">Angular JS</asp:ListItem>
                         </asp:DropDownList>  
                    </EditItemTemplate>
               </asp:TemplateField>
         <asp:TemplateField HeaderText="Framework" HeaderStyle-Width="110px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_framework" runat="server" Text='<%#Eval("framework") %>'></asp:Label>  
                    </ItemTemplate>
                    
                    <EditItemTemplate>
                        <asp:DropDownList ID="frame" runat="server" AutoPostBack="True" DataTextField="framework" DataValueField="framework">      
                             <asp:ListItem Value="Ektron">Ektron</asp:ListItem> 
                                 <asp:ListItem Value="Episerver">Episerver</asp:ListItem>
                            <asp:ListItem Value="Sharepoint">Sharepoint</asp:ListItem>
                            <asp:ListItem Value="Kentigo">Kentigo</asp:ListItem>
                            <asp:ListItem Value="Sitecore">Sitecore</asp:ListItem>
                            <asp:ListItem Value="Drupal">Drupal</asp:ListItem>
                                 <asp:ListItem Value="Majento">Majento</asp:ListItem>
                                 <asp:ListItem Value="Jumla">Jumla</asp:ListItem>
                         </asp:DropDownList>
                      </EditItemTemplate> 
                                              
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Original Capacity" HeaderStyle-Width="150px">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_capacity" runat="server" Text='<%#Eval("Original_Capacity") %>'></asp:Label>  
                    </ItemTemplate> 
                   <EditItemTemplate>  
                        <asp:TextBox ID="txt_capacity" runat="server" Text='<%#Eval("Original_Capacity") %>'></asp:TextBox>  
                    </EditItemTemplate>
                    </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px">  
                    <ItemTemplate> 
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" /> 
                         </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>
        </asp:TemplateField>
      </Columns>
        
           
            </asp:GridView>
        </div>
            
</asp:Content>

