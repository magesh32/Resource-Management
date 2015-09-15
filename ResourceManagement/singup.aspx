<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="singup.aspx.cs" Inherits="singup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/singup1.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.11.0.js"></script>
    <script src="/js/singup.js"></script>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $(".btn").click(function () {
                alert("Hello ,"+ $("TextBox1").text);
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="tags">
        <div id="form">
             <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
            <h2>Employee Registration</h2>
            <asp:Image ID="Image1" runat="server" imageUrl="images/ektron.jpg" style="z-index: 1; left: 672px; top: 199px; position: absolute; width: 213px; height: 125px" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <table class="registrationform">
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="emp_id" runat="server" Text="Employee_Id"></asp:Label>
                    </td>
                    <td> <asp:TextBox ID="emp_id1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Employee_Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>

                    <td>
                        <asp:Label ID="empnamevalidation" runat="server" CssClass="errors"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Email_ID"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>

                    <td>
                        <asp:Label ID="emailvalidation" runat="server" CssClass="errors"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Technology"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                            <asp:ListItem>select </asp:ListItem>
                            <asp:ListItem Value=".Net">.Net</asp:ListItem>
                            <asp:ListItem Value="Php">Php</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Framework"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>select </asp:ListItem>
                            <asp:ListItem Value="Ektron">Ektron</asp:ListItem>
                            <asp:ListItem Value="Episerver">Episerver</asp:ListItem>
                            <asp:ListItem Value="Majento">Majento</asp:ListItem>
                            <asp:ListItem Value="Drupal">Drupal</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <asp:Label ID="techvalidation" runat="server" CssClass="errors"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Role"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>select</asp:ListItem>
                            <asp:ListItem>Senior_Developer</asp:ListItem>
                            <asp:ListItem>Tech_Lead</asp:ListItem>
                            <asp:ListItem>Junior_Developer</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <asp:Label ID="rolevalidation" runat="server" CssClass="errors"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox3" type="password" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td class="auto-style2">
                        <asp:Label ID="pwdvalidation" runat="server" CssClass="errors"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Confirm Password"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox4" type="password" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:Label ID="cnfpwdvalidation" runat="server" CssClass="errors"></asp:Label></td>
                </tr>
                <tr><td></td><td><asp:Button ID="submit" Class="btn" runat="server" Text="submit" OnClick="Button1_Click" /></td></tr>
            </table>
             </ContentTemplate>
                     <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                     </Triggers>
                     </asp:UpdatePanel> 
        </div>

        <%--<div id="welcomemessage" runat="server" visible="false" class="welcomecontainer">
            <h2>
                <asp:Literal ID="welcomeheader" runat="server"></asp:Literal></h2>
            <br />
            <br />
            Your Employee Id is:
            <asp:Label ID="empid" CssClass="employeeid" runat="server"></asp:Label>
        </div>--%>


    </div>
</asp:Content>

