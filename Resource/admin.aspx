<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Label ID="lblin" CssClass="logo" runat="server" Text="Label"></asp:Label>
    <asp:HyperLink ID="HyperLink1" CssClass="link" NavigateUrl="~/login.aspx" runat="server">Logout</asp:HyperLink>
    <asp:Label ID="desig" CssClass="desi" runat ="server" Text="Label"></asp:Label>
 <div id="labels">
    <asp:Label ID="Label1" CssClass ="manager1" runat="server" Text="Add as a Manager "></asp:Label>
      <asp:Label ID="Label2" CssClass="manager0" runat="server" Text="Remove from Manager"></asp:Label> 
 </div> 
  <div id="admin">
      
         <asp:ListBox ID="ListBox1" CssClass="add" runat="server" SelectionMode="Multiple">
         </asp:ListBox>
         <asp:Button ID="Button1" CssClass ="Add" runat="server" Text=">> Add" OnClick="Button1_Click"/>
         <asp:Button ID="Button2" CssClass="Remove" runat="server" Text="Remove <<" OnClick="Button2_Click" />
         <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Junior Developer</asp:ListItem>
        <asp:ListItem>Senior Developer</asp:ListItem>
        <asp:ListItem>Tech_lead</asp:ListItem>
        </asp:DropDownList>
         <asp:ListBox ID="ListBox2" CssClass="remove" runat="server" SelectionMode="Multiple">
         </asp:ListBox>
        
 </div>
    </asp:Content>

