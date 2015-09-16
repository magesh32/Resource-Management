<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Add_Remove.aspx.cs" Inherits="Add_Remove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <ul>
      <li> <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Add </asp:LinkButton></li>
    <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Remove</asp:LinkButton></li>
   </ul>
      <asp:MultiView ID="MultiView1" runat="server">
         <asp:View ID="View1" runat="server">
         <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple"></asp:ListBox>
         <asp:Button ID="Add" runat="server" OnClick="Button2_Click" Text="Add" />
         </asp:View>
        <asp:View ID="View2" runat="server">
         <asp:ListBox ID="ListBox2" runat="server" SelectionMode="Multiple"></asp:ListBox>
         <asp:Button ID="Button1" runat="server" Text="Remove" OnClick="Button1_Click1" />
        </asp:View>
    </asp:MultiView>
</asp:Content>

