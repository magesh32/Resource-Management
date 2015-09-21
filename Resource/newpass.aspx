<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="newpass.aspx.cs" Inherits="newpass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" type="text/css" href="css/newpass.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>FORGET PASSWORD?</h2>
    <table>
        <tr>
            <td>
                <asp:Label ID="Email_id" runat="server" Text="EMAIL_ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Email_id" ControlToValidate="TextBox3" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
           
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="NEW PASSWORD"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" type="password" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Password" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="CONFIRMATION PASSWORD"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" type="password" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter confirmation Password" ControlToValidate="TextBox2" Display="Dynamic"></asp:RequiredFieldValidator>

            </td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Mismatch" Display="Dynamic" ControlToCompare="TextBox1" ControlToValidate="TextBox2"></asp:CompareValidator>
            </td>
        </tr>
    </table>
   
    <asp:Button ID="Button1" Text="save" runat="server" OnClick="Button1_Click"/>
    <br />
</asp:Content>

