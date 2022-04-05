<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_addmessage.aspx.cs" Inherits="MasterPagetest01.user_addmessage" %>

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
      
        <h1 class="text-center">我要留言</h1>
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
        <input id="Reset1" type="reset" value="重新填寫" class="btn btn-primary btn-lg" /><br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="回首頁" BackColor="#0066FF" BorderColor="#99FF99" Font-Italic="True" ForeColor="#FF9999" />
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
