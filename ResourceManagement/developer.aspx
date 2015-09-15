<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="developer.aspx.cs" Inherits="developer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/developer.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div  id="menu">
     <ul>
        <li><asp:LinkButton ID="LinkButton1" runat="server" >Projects</asp:LinkButton></li>
        <li><asp:LinkButton ID="LinkButton2" runat="server" >Resources</asp:LinkButton></li>
    </ul>
    </div>
    <asp:Label ID="lblin" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataSourceID="SqlDataSource1" >
        <Columns>
            <asp:BoundField DataField="P_id" HeaderText="project_id" ReadOnly="True" SortExpression="P_id" />
            <asp:BoundField DataField="P_name" HeaderText="project_name" SortExpression="P_name" />
            <asp:BoundField DataField="Client" HeaderText="Client" SortExpression="Client" />
            <asp:BoundField DataField="technology" HeaderText="Technology" SortExpression="technology" />
            <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" />
            <asp:BoundField DataField="start_date" HeaderText="start_date" SortExpression="start_date" />
            <asp:BoundField DataField="end_date" HeaderText="end_date" SortExpression="end_date" />
            <asp:BoundField DataField="Manager_id" HeaderText="Manager_id" SortExpression="Manager_id" />
            <asp:BoundField DataField="Project_status" HeaderText="Project_status" SortExpression="Project_status" />
        </Columns>
                   
                    </asp:GridView>
    
   
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:projectConnectionString %>" SelectCommand="select * from projectlist projtbl where projtbl.P_id in
(select rsc.P_id from Employee emp 
join pro_resources rsc on emp.emp_id=rsc.emp_id and rsc.emp_id=@session)">
        <SelectParameters>
     <asp:SessionParameter Name="session" SessionField="Emp_id" ConvertEmptyStringToNull="true" />
  </SelectParameters>
    </asp:SqlDataSource>
    <table>
        <tr>
            <td>
  
    <asp:Label ID="Label1" runat="server" Text="enter project details"></asp:Label>
                </td>
           <td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
           </td>
            <td>
                
                <asp:Button ID="Button1" runat="server" Text="show" OnClick="Button1_Click" />
            </td>
           
        </tr>
     </table>
    <asp:GridView ID="GridView3" runat="server">
                </asp:GridView>
</asp:Content>

