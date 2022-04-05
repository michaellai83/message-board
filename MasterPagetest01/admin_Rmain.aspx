<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="admin_Rmain.aspx.cs" Inherits="MasterPagetest01.admin_Rmain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="font-weight-bold text-info text-uppercase mb-1">管理回應區</h1>
    <p class="font-weight-bold text-info text-uppercase mb-1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ForeColor="#9900FF">
            <Columns>
                <asp:TemplateField HeaderText="編號">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="回應者暱稱" SortExpression="name" />
                <asp:BoundField DataField="title" HeaderText="主題" SortExpression="title" />
                <asp:BoundField DataField="main" HeaderText="回應內容" SortExpression="main" />
                <asp:BoundField DataField="initdate" HeaderText="回應日期" SortExpression="initdate" />
                <asp:TemplateField HeaderText="是否審核" SortExpression="check">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("check") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("check") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="編輯審核" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新" Class="btn btn-success btn-icon-split"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" CssClass="btn btn-warning btn-icon-split" ></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯" Class="btn btn-primary btn-icon-split"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" class="btn btn-danger btn-circle" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"> <i class="fas fa-trash"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="text-lg mb-0" ForeColor="#0099CC" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:message03ConnectionString %>" SelectCommand="SELECT * FROM [r_message]"></asp:SqlDataSource>
    </p>
</asp:Content>
