<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="admin_addmessage.aspx.cs" Inherits="MasterPagetest01.admin_addmessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>我要留言</h2>
        <br />
        <asp:Label ID="Lbl_title" runat="server" Text="主題:" Font-Size="Large" ForeColor="Blue"></asp:Label>
        &nbsp;<asp:TextBox ID="message_title" runat="server" ToolTip="請填寫主題"></asp:TextBox>
        <br />
        <asp:Label ID="Lbl_name" runat="server" Text="名子:" Font-Size="Large" ForeColor="Lime"></asp:Label>
        &nbsp;<asp:TextBox ID="message_name" runat="server" ToolTip="請填寫名子"></asp:TextBox>
        <br />
        <asp:Label ID="Lbl_main" runat="server" Text="內容:" Font-Size="Large" ForeColor="Red"></asp:Label>
        &nbsp;<asp:TextBox ID="message_main" runat="server" Height="303px" TextMode="MultiLine" Width="619px" BorderColor="#FF99FF" Font-Size="Large" ToolTip="請填寫內容" Wrap="False"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="確定留言" BackColor="#FFFF99" BorderColor="Fuchsia" Font-Bold="True" Font-Size="XX-Large" ForeColor="#666699" />
        <input id="Reset1" type="reset" value="重新填寫" /><br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="回首頁" BackColor="#0066FF" BorderColor="#99FF99" Font-Italic="True" ForeColor="#FF9999" />
</asp:Content>
