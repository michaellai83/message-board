<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_main.aspx.cs" Inherits="MasterPagetest01.user_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta charset="UTF-8"/>
  <meta content="IE=edge" http-equiv="X-UA-Compatible"/>
  <meta content="width=device-width,initial-scale=1" name="viewport"/>
  <meta content="description" name="description"/>
  <meta name="google" content="notranslate" />
  <meta content="Mashup templates have been developped by Orson.io team" name="author"/>

  <!-- Disable tap highlight on IE -->
  <meta name="msapplication-tap-highlight" content="no"/>
  
  
  <link rel="apple-touch-icon" sizes="180x180" href="./assets/apple-icon-180x180.png"/>
  <link href="./assets/favicon.ico" rel="icon"/>

  <link href="" rel="stylesheet"/>


  <title>Title page</title>

<link href="./main.550dcf66.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        
    <header>
  <nav class="navbar navbar-default active">
    <div class="container">
      <div class="navbar-header">
        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse" aria-expanded="false">
          <span class="sr-only">Toggle navigation</span>
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand" href="user_main.aspx" title="">
          <img src="./assets/images/mashup-icon.svg" class="navbar-logo-img" alt="">
          Message
        </a>
      </div>

      <div class="collapse navbar-collapse" id="navbar-collapse">
        <ul class="nav navbar-nav navbar-right">
          <li><a href="user_main.aspx" title="">Home</a></li>
          <li>
            <p>
              <a href="admin_login.aspx" class="btn btn-default navbar-btn" title="">管理員登入</a>
            </p>
          </li>

        </ul>
      </div> 
    </div>
  </nav>
</header>

    <!-- Add your site or app content here -->
  <div class="hero-full-container background-image-container white-text-container">
    <div class="container">
      <div class="row">
        <div class="col-xs-12">
          <h1>留言板</h1>
          <p>歡迎留下您寶貴的意見</p>
          <br>
             <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="我要留言" CssClass="btn btn-default btn-lg" />
          
        </div>
      </div>
    </div>
  </div>
    
        <div class="container">
            
            <p>
                <asp:Button ID="admin" runat="server" OnClick="admin_Click" Text="管理者登入" CssClass="btn btn-success btn-icon-split" />
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="我要留言" CssClass="btn btn-info btn-icon-split" />
            </p>
            <p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" Font-Size="Large" ForeColor="#33CC33" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="編號">
                            <ItemTemplate> <%# Container.DataItemIndex + 1%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="留言主題" SortExpression="title">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("title") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("title") %>' NavigateUrl= '<%# "user_response.aspx?ID=" + Eval("id") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="留言者" SortExpression="name" />
                        <asp:BoundField DataField="initdate" HeaderText="留言時間" SortExpression="initdate" />
                    </Columns>
                    <HeaderStyle BackColor="#CC00FF" Font-Bold="True" Font-Size="X-Large" ForeColor="#FFFFCC" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                </asp:GridView>
            </p>
        </div>
         
        
    </form>
    <script>
        document.addEventListener("DOMContentLoaded", function (event) {
            navbarFixedTopAnimation();
        });
</script>

<footer class="footer-container white-text-container">
  <div class="container">
    <div class="row">

     
      <div class="col-xs-12">
        <h3>Message</h3>

        <div class="row">
          <div class="col-xs-12 col-sm-7">
            <p><small>Website created with <a href="http://www.mashup-template.com/" title="Create website with free html template">Mashup Template</a>/<a href="https://www.unsplash.com/" title="Beautiful Free Images">Unsplash</a></small>
            </p>
          </div>
          <div class="col-xs-12 col-sm-5">
            <p class="text-right">
              <a href="https://facebook.com/" class="social-round-icon white-round-icon fa-icon" title="">
                <i class="fa fa-facebook" aria-hidden="true"></i>
              </a>
              <a href="https://twitter.com/" class="social-round-icon white-round-icon fa-icon" title="">
                <i class="fa fa-twitter" aria-hidden="true"></i>
              </a>
              <a href="https://www.linkedin.com/" class="social-round-icon white-round-icon fa-icon" title="">
                <i class="fa fa-linkedin" aria-hidden="true"></i>
              </a>
            </p>
          </div>
        </div>
        
        
      </div>
    </div>
  </div>
</footer>

<script>
    document.addEventListener("DOMContentLoaded", function (event) {
        navActivePage();
        scrollRevelation('.reveal');
    });
</script>
    <script type="text/javascript" src="./js/main.0cf8b554.js"></script>
</body>

</html>
