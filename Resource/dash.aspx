<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="dash.aspx.cs" Inherits="dash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/projects.css" rel="stylesheet" />
    <link href="css/dash.css" rel="stylesheet" />
     
     <script src="js/jquery-1.11.0.js"></script>
    
    <script src="js/manager.js"></script>  
     
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
        <asp:Label ID="lblin" CssClass="logo" runat="server" Text="Label"></asp:Label>
         <asp:Label ID="desig" CssClass="desi" runat="server" Text="Label"></asp:Label>
    </div>

    
  <asp:LinkButton ID="link_logout" runat="server" CssClass="link" OnClick="linkbuto3_Click">Logout</asp:LinkButton>
   

    <div id="content">

        <div id="calender">
            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">--%>
        <%--<ContentTemplate>--%>
            <asp:Calendar ID="calender" runat="server" Width="400px" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender">
                <DayHeaderStyle BackColor="White" BorderColor="#006666" />
                <DayStyle BackColor="#669999" />
                <NextPrevStyle BackColor="#CCCCCC" Font-Bold="True" Font-Italic="True" Font-Names="Cambria" ForeColor="#333300" />
                <SelectedDayStyle BackColor="#00CC99" ForeColor="#003366" />
                <TitleStyle BackColor="#CCFFFF" />
                <TodayDayStyle BackColor="#0099CC" />
                <WeekendDayStyle BackColor="#006666" />
            </asp:Calendar>
          <%--   </ContentTemplate>
                     <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                     </Triggers>
                     </asp:UpdatePanel>--%>
        </div>
        <asp:Label ID="Utilized" runat="server" Style="z-index: 1; left: 583px; top: 202px; position: absolute; width: 392px"></asp:Label>

        <asp:Label ID="lbl_Ideal" runat="server" Style="z-index: 1; left: 583px; top: 282px; position: absolute; width: 502px"></asp:Label>
        <asp:Label ID="lbl_Percentage" runat="server" Style="z-index: 1; left: 582px; top: 364px; position: absolute; width: 505px"></asp:Label>
        <div id="table">
            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <table>
                <tr>
                    <td>

                        <asp:Label ID="lbl_typeoftech" runat="server" Text=" Type of Technology"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="drop_typeoftech" runat="server" OnSelectedIndexChanged="typeoftech1_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>select </asp:ListItem>
                            <asp:ListItem Value="proprietary">proprietary</asp:ListItem>
                            <asp:ListItem Value="Open Source">Open Source</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>

                        <asp:Label ID="lbl_tech" runat="server" Text="Technology"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="drop_tech" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Technology_SelectedIndexChanged">
                            <asp:ListItem>select </asp:ListItem>
                            <asp:ListItem Value=".Net">.Net</asp:ListItem>
                            <asp:ListItem Value="Php">Php</asp:ListItem>
                            <asp:ListItem Value="Angular JS">Angular JS</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>

                        <asp:Label ID="lbl_frame" runat="server" Text="Framework"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="drop_frame" runat="server" OnSelectedIndexChanged="Framework_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>select </asp:ListItem>
                            <asp:ListItem Value="Ektron">Ektron</asp:ListItem>
                            <asp:ListItem Value="Episerver">Episerver</asp:ListItem>
                            <asp:ListItem Value="Kentigo">Kentigo</asp:ListItem>
                            <asp:ListItem Value="Sitecore">Sitecore</asp:ListItem>
                            <asp:ListItem Value="Sharepoint">Sharepoint</asp:ListItem>
                            <asp:ListItem Value="Majento">Majento</asp:ListItem>
                            <asp:ListItem Value="Drupal">Drupal</asp:ListItem>
                            <asp:ListItem Value="Jumla">Jumla</asp:ListItem>
                        </asp:DropDownList></td>

                </tr>
                <tr>
                    <td>

                        <asp:Label ID="lbl_projectlist" runat="server" Text="ProjectList"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="drop_Projectlist" CssClass="select" runat="server" OnSelectedIndexChanged="ProjectList_SelectedIndexChanged" AutoPostBack="true" Height="22px" Width="95px">
                        </asp:DropDownList></td>
                </tr>
            </table>
          <%--  </ContentTemplate>
                     <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                     </Triggers>
                     </asp:UpdatePanel>--%>
        </div>
    </div>
</asp:Content>

