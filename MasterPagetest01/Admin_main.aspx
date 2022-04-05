<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin_main.aspx.cs" Inherits="MasterPagetest01.Admin_main" %>

<%@ Register Src="~/GVpage01.ascx" TagPrefix="uc1" TagName="GVpage01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
     <link href="css/GV.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="font-weight-bold text-info text-uppercase mb-1">管理留言區</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="card shadow mb-4" ForeColor="Blue" OnRowDataBound="GridView1_RowDataBound">
         <Columns>
                <asp:TemplateField HeaderText="編號">
                    <ItemTemplate><%# Container.DataItemIndex + 1%></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="留言者" SortExpression="name" />
                <asp:TemplateField HeaderText="留言主題" SortExpression="title">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("title") %>' NavigateUrl='<%# "admin_Rmain.aspx?ID=" + Eval("id") %>'  ></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="留言內容" SortExpression="main">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("main") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "admin_maincheck.aspx?ID=" + Eval("id") %>' Text='<%# Bind("main") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="initdate" HeaderText="留言時間" SortExpression="initdate" />
                <asp:TemplateField HeaderText="審核狀態" SortExpression="check">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("check") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text= '<%# Bind("check") %>'></asp:Label>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="全部審核通過" CssClass="btn btn-primary btn-icon-split" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="True" CommandName="Update" Text="更新" Class="btn btn-success btn-icon-split" ></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" CssClass="btn btn-warning btn-icon-split"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"  Class="btn btn-success btn-icon-split"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="回應數">
                     <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("回應") %>' CssClass="text-xs font-weight-bold text-primary text-uppercase mb-1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" class="btn btn-danger btn-circle" runat="server" CausesValidation="False" CommandName="Delete"  OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"> <i class="fas fa-trash"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
         
         <HeaderStyle CssClass="font-weight-bold" ForeColor="#00CC00" />
         
</asp:GridView>
    <br />
   <div >
        <uc1:GVpage01 runat="server" id="GVpage01" />
   </div>
   
    <br />
    <br />
  
</asp:Content>
