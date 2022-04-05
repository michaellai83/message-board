<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="admin_index.aspx.cs" Inherits="MasterPagetest01.admin_index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
        
            <h1>留言板</h1>
            <p>
                <asp:Button ID="admin" runat="server" OnClick="admin_Click" Text="管理者登入" CssClass="btn btn-success btn-icon-split" />
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="我要留言" CssClass="btn btn-info btn-icon-split" />
            </p>
            <p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="編號">
                            <ItemTemplate> <%# Container.DataItemIndex + 1%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="留言主題" SortExpression="title">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("title") %>' NavigateUrl= '<%# "admin_response.aspx?ID=" + Eval("id") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="留言者" SortExpression="name" />
                        <asp:BoundField DataField="initdate" HeaderText="留言時間" SortExpression="initdate" />
                    </Columns>
                </asp:GridView>
            </p>
        
    
</asp:Content>
