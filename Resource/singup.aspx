<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="singup.aspx.cs" Inherits="singup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/singup1.css" rel="stylesheet" />
    
    <script src="js/jquery-1.11.0.js"></script>
    <script src="/js/singup.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="tags">
        
             <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
            <h2>Employee Registration</h2>
            <asp:Image ID="Image1" runat="server" imageUrl="images/ektron.jpg" style="z-index: 1; left: 699px; top: 152px; position: absolute; width: 213px; height: 125px" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <table class="registrationform">
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="emp_id" runat="server" Text="Employee_Id"></asp:Label>
                    </td>
                    <td> <asp:TextBox ID="emp_id1" runat="server"></asp:TextBox></td>
                    <td>
                        <br />
                        <asp:Label ID="empid" runat="server" CssClass="errors"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Employee_Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>

                    <td>
                        <br />
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
                        <br>
                        
                        <asp:Label ID="emailvalidation" runat="server" CssClass="errors"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="typeoftech" runat="server" Text=" Type of Technology"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="typeoftech1" runat="server" OnSelectedIndexChanged="typeoftech1_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>select </asp:ListItem>
                            <asp:ListItem Value="Proprietary">Proprietary</asp:ListItem>
                            <asp:ListItem Value="Open Source">Open Source</asp:ListItem>
                        </asp:DropDownList></td>
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
                            <asp:ListItem Value="Angular JS">Angular JS</asp:ListItem>
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
                            <asp:ListItem Value="Kentico">Kentico</asp:ListItem>
                            <asp:ListItem Value="Sitecore">Sitecore</asp:ListItem>
                            <asp:ListItem Value="Sharepoint">Sharepoint</asp:ListItem>
                            <asp:ListItem Value="Majento">Majento</asp:ListItem>
                            <asp:ListItem Value="Drupal">Drupal</asp:ListItem>
                            <asp:ListItem Value="Joomla">Joomla</asp:ListItem>
                        </asp:DropDownList></td>
                   
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
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox3" type="password" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td>
                        <br />
                        <asp:Label ID="pwdvalidation" runat="server" CssClass="errors"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Confirm Password"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox4" type="password" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td>
                        <br />
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
</asp:Content>

