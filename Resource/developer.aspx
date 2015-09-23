<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="developer.aspx.cs" Inherits="developer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/developer.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div  id="menu">
     <ul>
        <li><asp:LinkButton ID="link_projects" runat="server"  OnClick="LinkButton1_Click" >Projects</asp:LinkButton></li>
        <li><asp:LinkButton ID="link_resources" runat="server"  OnClick="LinkButton2_Click">Resources</asp:LinkButton></li>
    </ul>
          <asp:Label ID="lblin" CssClass="logo" runat="server" Text="Label"></asp:Label>
               <asp:Label ID="desig" CssClass="desi" runat ="server" Text="Label"></asp:Label>        

    </div>
           
       
        <asp:LinkButton ID="link_logout" CssClass="link" runat="server" OnClick="linkbutton7_Click">Logout</asp:LinkButton>
         
        <asp:MultiView ID="MultiView1" runat="server">

            <%--VIEW1 FOR SHOWING PROJECTS UNDER MANAGER--%>
            <asp:View ID="View1" runat="server">    
 <div id="grid4">
    <asp:GridView ID="grid_projects" CssClass="GridStyle" runat   ="server" AutoGenerateColumns="False"  DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="P_id" HeaderText="project_id" ReadOnly="True" SortExpression="P_id" />
            <asp:BoundField DataField="P_name" HeaderText="project_name" SortExpression="P_name" />
            <asp:BoundField DataField="Client" HeaderText="Client" SortExpression="Client" />
            <asp:BoundField DataField="technology" HeaderText="Technology" SortExpression="technology" />
            <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" />
            <asp:BoundField DataField="start_date" HeaderText="Start_date" SortExpression="start_date" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="end_date" HeaderText="End_date" SortExpression="end_date" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="Manager_id" HeaderText="Manager_id" SortExpression="Manager_id" />
            <asp:BoundField DataField="Project_status" HeaderText="Project_status" SortExpression="Project_status"/>
        </Columns>
                   
                    </asp:GridView>
     </div>
        </asp:View>

            <asp:View ID="View2" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:projectConnectionString %>" SelectCommand="select * from projectlist projtbl where projtbl.P_id in
(select rsc.P_id from Employee emp 
join pro_resources rsc on emp.emp_id=rsc.emp_id and rsc.emp_id=@session)">
        <SelectParameters>
     <asp:SessionParameter Name="session" SessionField="Emp_id" ConvertEmptyStringToNull="true" />
  </SelectParameters>
    </asp:SqlDataSource>
<div id="back">
    <table>
        <tr>
            <td>
  
    <asp:Label ID="lbl_id" runat="server" Text="Enter your Project Id"></asp:Label>
                </td>
           <td>
               <asp:DropDownList ID="drop_id" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="height: 20px"></asp:DropDownList>
           </td>
            </tr>
        <tr><td></td><td>
            <asp:Button ID="btn_show" runat="server" Text="Show" OnClick="Button1_Click1" /></td></tr>
     </table>
  </div>
                <div id="front1">  
    <asp:GridView ID="grid_resources" CssClass="GridStyle" runat="server">
                </asp:GridView>
   </div>
                </asp:View>
            </asp:MultiView>
  
</asp:Content>

