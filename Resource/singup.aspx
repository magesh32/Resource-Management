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
            <asp:Image ID="img_ektron" runat="server" imageUrl="images/ektron.jpg" style="z-index: 1; left: 699px; top: 142px; position: absolute; width: 213px; height: 125px" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <table class="registrationform">
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lbl_empid" runat="server" Text="Employee_Id"></asp:Label>
                    </td>
                    <td> <asp:TextBox ID="txt_empid" runat="server"></asp:TextBox></td>
                    <td>
                        <br />
                        <asp:Label ID="empidvalidate" runat="server" CssClass="errors"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lbl_empname" runat="server" Text="Employee_Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txt_empname" runat="server"></asp:TextBox></td>

                    <td>
                        <br />
                        <asp:Label ID="empnamevalidation" runat="server" CssClass="errors"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lbl_emailid" runat="server" Text="Email_ID"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txt_emailid" runat="server"></asp:TextBox></td>

                    <td>
                        <br>
                        
                        <asp:Label ID="emailvalidation" runat="server" CssClass="errors"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lbl_typeoftech" runat="server" Text=" Type of Technology"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="drop_typeoftech" runat="server" OnSelectedIndexChanged="typeoftech1_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>select </asp:ListItem>
                            <asp:ListItem Value="Proprietary">Proprietary</asp:ListItem>
                            <asp:ListItem Value="Open Source">Open Source</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lbl_tech" runat="server" Text="Technology"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="drop_tech" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                            <asp:ListItem>select </asp:ListItem>
                            <asp:ListItem Value=".Net">.Net</asp:ListItem>
                            <asp:ListItem Value="Php">Php</asp:ListItem>
                            <asp:ListItem Value="Angular JS">Angular JS</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lbl_frame" runat="server" Text="Framework"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="drop_frame" runat="server">
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
                        <asp:Label ID="lbl_role" runat="server" Text="Role"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="drop_role" runat="server">
                            <asp:ListItem>select</asp:ListItem>
                            <asp:ListItem>Senior_Developer</asp:ListItem>
                            <asp:ListItem>Tech_Lead</asp:ListItem>
                            <asp:ListItem>Junior_Developer</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lbl_pwd" runat="server" Text="Password"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txt_pwd" type="password" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td>
                        <br />
                        <asp:Label ID="pwdvalidation" runat="server" CssClass="errors"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lbl_cnfpwd" runat="server" Text="Confirm Password"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txt_cnfpwd" type="password" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td>
                        <br />
                        <asp:Label ID="cnfpwdvalidation" runat="server" CssClass="errors"></asp:Label></td>
                </tr>
                <tr><td></td><td><asp:Button ID="btn_submit" Class="btn" runat="server" Text="submit" OnClick="Button1_Click" /></td></tr>
            </table>
             </ContentTemplate>
                     <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="drop_frame" EventName="SelectedIndexChanged" />
                     </Triggers>
                     </asp:UpdatePanel> 
      
    </div>
</asp:Content>

