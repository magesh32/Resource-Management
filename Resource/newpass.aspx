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
                <asp:TextBox ID="txt_emailid" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="emailvalidate" runat="server" ErrorMessage="Enter Email_id" ControlToValidate="TextBox3" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
           
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_pwd" runat="server" Text="NEW PASSWORD"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_pwd" type="password" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="pwdvalidate" runat="server" ErrorMessage="Enter Password" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_conpwd" runat="server" Text="CONFIRMATION PASSWORD"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_conpwd" type="password" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="conpwdvalidate" runat="server" ErrorMessage="Enter confirmation Password" ControlToValidate="TextBox2" Display="Dynamic"></asp:RequiredFieldValidator>

            </td>
            <td>
                <asp:CompareValidator ID="comparevalidate" runat="server" ErrorMessage="Password Mismatch" Display="Dynamic" ControlToCompare="TextBox1" ControlToValidate="TextBox2"></asp:CompareValidator>
            </td>
        </tr>
    </table>
   
    <asp:Button ID="btn_save" Text="save" runat="server" OnClick="Button1_Click"/>
    <br />
</asp:Content>

