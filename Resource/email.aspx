﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="email.aspx.cs" Inherits="email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" type="text/css" href="css/email.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>FORGET YOUR PASSWORD?</h2>
    <div id="email">
    <asp:Label ID="lbl_email" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
    <asp:Button ID="btn_submit" runat="server" Text="submit" OnClick="Button1_Click" />
    </div>
</asp:Content>

