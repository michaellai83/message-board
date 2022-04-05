<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_response.aspx.cs" Inherits="MasterPagetest01.user_response" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta charset="UTF-8">
  <meta content="IE=edge" http-equiv="X-UA-Compatible">
  <meta content="width=device-width,initial-scale=1" name="viewport">
  <meta content="description" name="description">
  <meta name="google" content="notranslate" />
  <meta content="Mashup templates have been developped by Orson.io team" name="author">

  <!-- Disable tap highlight on IE -->
  <meta name="msapplication-tap-highlight" content="no">
  
  
  <link rel="apple-touch-icon" sizes="180x180" href="./assets/apple-icon-180x180.png">
  <link href="./assets/favicon.ico" rel="icon">

  <link href="" rel="stylesheet">


  <title>Title page</title>

<link href="./main.550dcf66.css" rel="stylesheet">
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
        <div class="container">
             <h1 class="text-center">留言內容</h1>
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
        </div>
        
    </form>
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

<!-- Google Analytics: change UA-XXXXX-X to be your site's ID 

<script>
  (function (i, s, o, g, r, a, m) {
    i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
      (i[r].q = i[r].q || []).push(arguments)
    }, i[r].l = 1 * new Date(); a = s.createElement(o),
      m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
  })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
  ga('create', 'UA-XXXXX-X', 'auto');
  ga('send', 'pageview');
</script>

--> <script type="text/javascript" src="./js/main.0cf8b554.js"></script>
</body>
</html>
