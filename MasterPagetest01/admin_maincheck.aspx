﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="admin_maincheck.aspx.cs" Inherits="MasterPagetest01.admin_maincheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>留言內容</h2>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="主題:" Font-Size="Large" ForeColor="Blue"></asp:Label>
&nbsp;<asp:Label ID="Lbl_title" runat="server" Font-Size="Larger" ForeColor="#006699"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="暱稱:" Font-Size="Large" ForeColor="#6600CC"></asp:Label>
&nbsp;<asp:Label ID="Lbl_name" runat="server" Font-Size="Larger" ForeColor="#9933FF"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="留言時間:" Font-Size="Large" ForeColor="#006600"></asp:Label>
&nbsp;<asp:Label ID="Lbl_time" runat="server" Font-Size="Larger" ForeColor="#33CCCC"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="內容:" Font-Size="Large" ForeColor="#FF9900"></asp:Label>
&nbsp;<asp:Label ID="Lbl_main" runat="server" Font-Size="Larger" ForeColor="#CC0066"></asp:Label>
        </p>
     <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="審核通過" Class="btn btn-success btn-icon-split" />
        </p>
</asp:Content>
