<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div  id="cont">
        <h2>Login</h2>
        <table>
            <tr>   
               <%-- EMPLOYEE ID--%>
                <td><asp:Label ID="Label1" runat="server" Text="Emp_Id"></asp:Label></td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <%--PASSWORD--%>
                <td><asp:Label ID="Label2"  runat="server" Text="Password"></asp:Label></td>
                <td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr><td></td><td><asp:Button ID="Btn" CssClass="btn" runat="server" Text="Login" OnClick="Btn_Click" /></td></tr>
            <tr><td></td><td><asp:HyperLink Class="hyper" ID="HyperLink1" runat="server" NavigateUrl="email.aspx">Forgot Password</asp:HyperLink></td></tr>
            <tr><td><asp:Label ID="Label3" Class="lbl" runat="server" Text="If you are new,"></asp:Label><asp:HyperLink Class="hyper1" ID="HyperLink2" runat="server" NavigateUrl="singup.aspx">Singup Here</asp:HyperLink></td></tr>
       </table>
    </div>
</asp:Content>

