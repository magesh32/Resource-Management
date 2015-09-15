<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="Admin  page"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Select Employees" OnClick="Button2_Click" />
<asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Height="132px" Width="97px">
    </asp:ListBox>
    <asp:Button ID="Button1" runat="server" Text="Add as a Manager" OnClick="Button1_Click" />
    </asp:Content>

