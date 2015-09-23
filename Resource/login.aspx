<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="slider">
        
            <figure>
            <img src="images/10.jpg" alt="image1"/>
            <img src="images/2.jpg" alt="image2"/>
            <img src="images/11.jpg" alt="image3"/>
            <img src="images/4.jpg" alt="image4"/>        
            <img src="images/5.jpg" alt="image5"/>
            <img src="images/6.jpg" alt="image6" />
            <img src="images/7.jpg" alt="image7" />
            <img  src="images/8.jpg" alt="image8" />
            <img src="images/9.jpg" alt="image9" />
            
            </figure>
          
 </div>
    <div  id="cont">
        <h2>Signin</h2>
        <table id="dash">
            <tr>   
               <%-- EMPLOYEE ID--%>
                <td><asp:Label ID="lbl_empid" runat="server" Text="Emp_Id"></asp:Label></td>
                <td><asp:TextBox ID="txt_empid" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <%--PASSWORD--%>
                <td><asp:Label ID="lbl_password"  runat="server" Text="Password"></asp:Label></td>
                <td><asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr><td></td><td><asp:Label ID="lbl_error" runat="server" CssClass="error" Visible="false"></asp:Label></td></tr>
            <tr><td></td><td><asp:Button ID="Btn_login" CssClass="btn" runat="server" Text="Login" OnClick="Btn_Click" /></td></tr>
            <tr><td></td><td><asp:HyperLink Class="hyper" ID="hyper_forgot" runat="server" NavigateUrl="email.aspx">Forgot Password?</asp:HyperLink></td></tr>
            <tr><td></td><td><asp:HyperLink Class="hyper1" ID="hyper_signup" runat="server" NavigateUrl="singup.aspx">Signup</asp:HyperLink></td></tr>
       </table>
    </div>
</asp:Content>

