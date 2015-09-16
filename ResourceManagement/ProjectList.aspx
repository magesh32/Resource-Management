<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectList.aspx.cs" Inherits="ProjectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="css/manager.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div  id="menu">
     <ul>
        <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Project details</asp:LinkButton></li>
        <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Resource details</asp:LinkButton></li>
        <li><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Capacity calculation</asp:LinkButton></li>
    </ul>
    </div>
    <asp:Label ID="lblin" CssClass="logo" runat="server" Text="Label"></asp:Label>
    <asp:HyperLink ID="HyperLink1" CssClass="link" NavigateUrl="~/login.aspx" runat="server">Logout</asp:HyperLink>
    <asp:Label ID="desig" CssClass="desi" runat ="server" Text="Label"></asp:Label>
    <%--MULTIVIEW STARTS--%>
        <asp:MultiView ID="MultiView1" runat="server">

            <%--VIEW1 FOR SHOWING PROJECTS UNDER MANAGER--%>
            <asp:View ID="View1" runat="server">
               <asp:GridView ID="GridView3" DataKeyNames="P_id" AutoGenerateColumns="false" runat="server" CellPadding="6" OnRowCancelingEdit="GridView3_RowCancelingEdit"  
  
OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" OnRowDeleting="GridView3_RowDeleting" OnRowDataBound="GridView3_RowDataBound">  
            <Columns> 
                <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">  
                    <ItemTemplate> 
                        <%--EDIT AND DELETE BUTTON IN ITEMTEMPLATE--%>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit"/> 
                        <asp:Button ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete" />  
                    </ItemTemplate>  
                    <%--EDITITEM TEMPLATE TO SHOW UPDATE AND CANCEL AFTER CLICKING EDIT BUTTON--%>
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <%--PROJECT_ID--%>
                <asp:TemplateField HeaderText="Project_Id">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Id" runat="server" Text='<%#Eval("P_id") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
                <%--PROJECT_NAME COLUMN--%>
                <asp:TemplateField HeaderText="Project_Name">
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("P_name") %>'></asp:Label>  
                    </ItemTemplate>   
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("P_name") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <%--CLIENT COLUMN--%>
                <asp:TemplateField HeaderText="Client">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Client" runat="server" Text='<%#Eval("Client") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Client" runat="server" Text='<%#Eval("Client") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                </asp:TemplateField>  
                <%--DURATION COLUMN--%>
                <asp:TemplateField HeaderText="Duration">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Duration" runat="server" Text='<%#Eval("Duration") %>'></asp:Label>  
                    </ItemTemplate> 
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Duration" runat="server" Text='<%#Eval("Duration") %>'></asp:TextBox>  
                    </EditItemTemplate>
                    </asp:TemplateField> 
                <%--TECHNOLOGY--%>
                 <asp:TemplateField HeaderText="TECHNOLOGY">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_tech" runat="server" Text='<%#Eval("technology") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField> 
               <%-- Startdate--%>
                 <asp:TemplateField HeaderText="Start_date">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_start_date" runat="server" Text='<%#Eval("start_date")%>'  ></asp:Label>  
                    </ItemTemplate> 
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_start_date" runat="server" Text='<%#Eval("start_date") %>'></asp:TextBox>  
                    </EditItemTemplate>
                    </asp:TemplateField> 
                <%-- Enddate--%>
                 <asp:TemplateField HeaderText="End_date">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_end_date" runat="server" Text='<%#Eval("end_date") %>'></asp:Label>  
                    </ItemTemplate> 
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_end_date" runat="server" Text='<%#Eval("end_date") %>'></asp:TextBox>  
                    </EditItemTemplate>
                    </asp:TemplateField>
                <%-- Manager_ID--%>
                 <asp:TemplateField HeaderText="Manager">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Manger" runat="server" Text='<%#Eval("Manager_Id") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
                <%-- Sow_status--%>
                 <asp:TemplateField HeaderText="SOW_status">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_SOW_status" runat="server" Text='<%#Eval("SOW_status") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
                <%--STATUS OF PROJECT--%>
                 <asp:TemplateField HeaderText="Status">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_P_status" runat="server" Text='<%#Eval("Project_status") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>  
            </Columns>  
            <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>  
            <RowStyle BackColor="#e7ceb6"/>  
        </asp:GridView>
                </asp:View>
            <asp:View ID="View2" runat="server">
                <%--<table>
        <tr>
            <td>
  
    <asp:Label ID="Label1" runat="server" Text="enter your project Id"></asp:Label>
                </td>
           <td>
               <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="height: 20px"></asp:DropDownList>
           </td>
            </tr>
        <tr><td></td>
           <td>
                
                <asp:Button ID="Button1" runat="server" Text="show" OnClick="Button1_Click" />
            </td>
           
        </tr>
     </table>--%>
    <asp:GridView ID="GridView1" DataKeyNames="P_id" AutoGenerateColumns="false" runat="server" CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit"  
  
OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">  
            <Columns> 
                <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">  
                    <ItemTemplate> 
                        <%--EDIT AND DELETE BUTTON IN ITEMTEMPLATE--%>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit"/> 
                        <asp:Button ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete" />  
                    </ItemTemplate>  
                    <%--EDITITEM TEMPLATE TO SHOW UPDATE AND CANCEL AFTER CLICKING EDIT BUTTON--%>
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <%--PROJECT_ID--%>
                <asp:TemplateField HeaderText="Project_Id">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Id" runat="server" Text='<%#Eval("P_id") %>'></asp:Label>  
                    </ItemTemplate> 
                    </asp:TemplateField>
                <%--PROJECT_NAME COLUMN--%>
                <asp:TemplateField HeaderText="Emp_Id">
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Emp_Id" runat="server" Text='<%#Eval("Emp_id") %>'></asp:Label>  
                    </ItemTemplate>   
                   
                </asp:TemplateField>  
                <%--CLIENT COLUMN--%>
                <asp:TemplateField HeaderText="Role">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Role" runat="server" Text='<%#Eval("Role") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Role" runat="server" Text='<%#Eval("Role") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                </asp:TemplateField>  
                <%--DURATION COLUMN--%>
                <asp:TemplateField HeaderText="Capacity">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Capacity" runat="server" Text='<%#Eval("Capacity") %>'></asp:Label>  
                    </ItemTemplate> 
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Capacity" runat="server" Text='<%#Eval("Capacity") %>'></asp:TextBox>  
                    </EditItemTemplate>
                    </asp:TemplateField> 
            </Columns>  
            <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>  
            <RowStyle BackColor="#e7ceb6"/>  
        </asp:GridView>
            </asp:View>
            <asp:View ID="View3" runat="server">

            </asp:View>
                </asp:MultiView>
</asp:Content>

