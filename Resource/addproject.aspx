<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="addproject.aspx.cs" Inherits="addproject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery-1.11.0.js"></script>

    <script src="js/manager.js"></script>
    <link href="css/projects.css" rel="stylesheet" />
    <link href="css/addproject.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="menu">
        <ul>
            <li><a href="manager.aspx">Projects</a></li>
            <li><a href="resource.aspx">Resources</a></li>
            <li><a href="addproject.aspx">Add New Project</a></li>
            <li><a href="dash.aspx">Dashboard</a></li>
            <li><a href="addresource.aspx">Add New Resource</a></li>

        </ul>
        <asp:Label ID="lbl_welcome" CssClass="logo" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="desig" CssClass="desi" runat="server" Text="Label"></asp:Label>
    </div>
    <asp:LinkButton ID="link_logout" CssClass="link" runat="server" OnClick="LinkButton1_Click">Logout</asp:LinkButton>



    <div id="table">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
        <h2>Enter Project details</h2>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table id="tblFormTable" cellspacing="20" runat="server">
                    <tr>
                        <td>
                            <asp:Label ID="pro_name" runat="server" Text="Project Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="pro_name1" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Label ID="proname" runat="server" CssClass="error"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="cliname" runat="server" Text="Clinet Name"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="cliname1" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Label ID="client" runat="server" CssClass="error"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="durate" runat="server" Text="Duration"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="duration" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Label ID="durat" runat="server" CssClass="error"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="typeoftech" runat="server" Text="Type of Technology"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="typeoftech1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="tech" runat="server" Text="Technology"></asp:Label></td>

                        <td>

                            <asp:DropDownList ID="tech1" runat="server" CssClass="drop1">
                                <asp:ListItem>select </asp:ListItem>
                                <asp:ListItem Value=".Net">.Net</asp:ListItem>
                                <asp:ListItem Value="Php">Php</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="framework" runat="server" Text="Framework"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="frame" runat="server" CssClass="drop1">
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

                            <asp:Label ID="sdate" runat="server" Text="Start Date"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="sdate1" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="sdating" runat="server" CssClass="error"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>

                            <asp:Label ID="edate" runat="server" Text="End Date"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="edate1" CssClass="pick1" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="edating" runat="server" CssClass="error"></asp:Label></td>

                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="lbl_jun" runat="server" CssClass="lbl" Text="Junior Developer"></asp:Label>
                            <asp:Label ID="lbl_sen" runat="server" CssClass="lbl" Text="Senior Developer"></asp:Label>
                            <asp:Label ID="lbl_tech" runat="server" Text="Tech_Lead" CssClass="lbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="resource" runat="server" Text="Resources"></asp:Label>
                        </td>
                        <td>
                            <div id="tblListBox">
                                <asp:ListBox ID="junior" runat="server" CssClass="drop2" AutoPostBack="True"
                                    OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>
                                <asp:ListBox ID="senior" runat="server" CssClass="drop2" AutoPostBack="True"
                                    OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>
                                <asp:ListBox ID="techlead" runat="server" CssClass="drop2" AutoPostBack="True"
                                    OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>
                            </div>

                        </td>

                    </tr>


                    <tr>
                        <td>
                            <asp:Label ID="sow" runat="server" Text="SOW"></asp:Label></td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" /></td>

                    </tr>

                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="junior" />
                <asp:PostBackTrigger ControlID="senior" />
                <asp:PostBackTrigger ControlID="techlead" />
                <%-- <asp:AsyncPostBackTrigger ControlID="jun_dev" EventName="SelectedIndexChanged" />--%>
            </Triggers>
        </asp:UpdatePanel>
        <asp:Button ID="btn_submit" CssClass="btn1" runat="server" Text="Submit" OnClick="btn1_Click" />
        <asp:Button ID="btn_cancel" runat="server" CssClass="btn2" Text="Cancel" />
    </div>


</asp:Content>

