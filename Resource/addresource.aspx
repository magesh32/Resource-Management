<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="addresource.aspx.cs" Inherits="addresource" %>

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
    </div>
    <asp:Label ID="lblin" CssClass="logo" runat="server" Text="Label"></asp:Label>
    <asp:HyperLink ID="HyperLink1" CssClass="link" NavigateUrl="~/login.aspx" runat="server">Logout</asp:HyperLink>
    <asp:Label ID="desig" CssClass="desi" runat ="server" Text="Label"></asp:Label>
    <div id="labels">
    <asp:Label ID="Label1" CssClass ="manager1" runat="server" Text="Add Resource under you "></asp:Label>
      <asp:Label ID="Label2" CssClass="manager0" runat="server" Text="Remove Resource under you"></asp:Label> 
 </div> 
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                  </asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
              <ContentTemplate>
          
                   </ContentTemplate>
                     <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="ListBox4" EventName="SelectedIndexChanged" />
                     <asp:AsyncPostBackTrigger ControlID="ListBox5" EventName="SelectedIndexChanged" />
                    <%-- <asp:AsyncPostBackTrigger ControlID="jun_dev" EventName="SelectedIndexChanged" />--%>
                    <%-- </Triggers>
                     </asp:UpdatePanel> --%>
    <div id="resource">
    <asp:ListBox ID="ListBox4" CssClass="add" runat="server" SelectionMode="Multiple"></asp:ListBox>

         <asp:Button ID="Add" CssClass="Add" runat ="server" OnClick="Button2_Click" Text=" >> Add " />
        <asp:Button ID="Button1" CssClass="Remove" runat ="server" Text=" Remove <<" OnClick="Button1_Click1" />
        <asp:ListBox ID="ListBox5" runat="server" CssClass="remove" SelectionMode="Multiple"></asp:ListBox>
    </div>
</asp:Content>

