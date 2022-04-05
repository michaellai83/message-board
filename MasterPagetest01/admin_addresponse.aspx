<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="admin_addresponse.aspx.cs" Inherits="MasterPagetest01.admin_addresponse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>我要回應</h2>
        <p>
            <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="Blue" Text="主題:"></asp:Label>
&nbsp;<asp:TextBox ID="rmessage_title" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Fuchsia" Text="暱稱:"></asp:Label>
&nbsp;<asp:TextBox ID="rmessage_name" runat="server" ToolTip="請填名字"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Font-Italic="True" Font-Size="Larger" ForeColor="#33CC33" Text="內容:"></asp:Label>
&nbsp;<asp:TextBox ID="rmessage_main" runat="server" Height="237px" TextMode="MultiLine" Width="509px" ToolTip="請填寫文章"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="回應文章" OnClick="Button1_Click" BackColor="Blue" BorderColor="#FF0066" Font-Bold="True" Font-Size="X-Large" ForeColor="Yellow" />
            <input id="Reset1" type="reset" value="重新填寫" /></p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="首頁" OnClick="Button2_Click" BackColor="#CC00FF" BorderColor="#CCFF99" Font-Size="XX-Small" ForeColor="Aqua" />
        </p>
</asp:Content>
