<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="admin_response.aspx.cs" Inherits="MasterPagetest01.admin_response" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>留言內容</h2>
        <p>
            <asp:Button ID="Button2" runat="server" Text="首頁" OnClick="Button2_Click" BackColor="#CCFFFF" BorderColor="#6600CC" />
            </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="回應文章" OnClick="Button1_Click" BackColor="#006699" BorderColor="Fuchsia" Font-Bold="True" Font-Size="X-Large" ForeColor="#FF99CC" />
            </p>
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
            &nbsp;</p>
        <h3>回應內容</h3>
        <p>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text="暱稱: " ForeColor="Blue"></asp:Label><asp:Label ID="Lbl_rname" runat="server" Text='<%# Eval("name") %>' ForeColor="#3366FF"></asp:Label><br/>
                    <asp:Label ID="Label6" runat="server" Text="回應內容: " ForeColor="#99CC00"></asp:Label><asp:Label ID="Lbl_rmain" runat="server" Text='<%# Eval("main") %>' ForeColor="Red"></asp:Label><br/>
                    <asp:Label ID="Label7" runat="server" Text="回應時間: " ForeColor="#CC3399"></asp:Label><asp:Label ID="Lbl_rtime" runat="server" Text='<%# Eval("initdate") %>' ForeColor="#00CC00"></asp:Label><br/>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </p>
</asp:Content>
