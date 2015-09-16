<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ul>
        <li>
            
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">Add Manager</asp:LinkButton></li>
        <li>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Remove Manager</asp:LinkButton>
        </li>
    </ul>
    <asp:MultiView ID="MultiView1" runat="server">
         <asp:View ID="View1" runat="server">
         <asp:ListBox ID="ListBox1" CssClass="list" runat="server" SelectionMode="Multiple">
         </asp:ListBox>
         <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"/>
         </asp:View>
         <asp:View ID="View2" runat="server">
         <asp:ListBox ID="ListBox2" runat="server" SelectionMode="Multiple">
         </asp:ListBox>
       
         <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Junior Developer</asp:ListItem>
        <asp:ListItem>Senior Developer</asp:ListItem>
        <asp:ListItem>Tech_lead</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button2" runat="server" Text="Remove" OnClick="Button2_Click" />
        </asp:View>
    </asp:MultiView>
    </asp:Content>

