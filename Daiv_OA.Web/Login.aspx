﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Daiv_OA.Web.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>管理员登录</title><script type="text/javascript" language="javascript"> window.onerror = function () { return true; }</script>
<link href="../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="images/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.5.2.min.js"></script>

<%--
<script type="text/javascript" src="../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/jquery.validate.min.js"></script> 
<script type="text/javascript" src="../scripts/jquery/messages_cn.js"></script>
<script type="text/javascript" src="../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="js/function.js"></script>--%>
<script type="text/javascript">
    //表单验证
    $(function () {
        //检测IE
        if ($.browser.msie && $.browser.version == "6.0") {
            window.location.href = 'ie6update.html';
        }
        $('#txtUserName').focus();
//        $("#form1").validate({
//            errorPlacement: function (lable, element) {
//                element.ligerTip({ content: lable.html(), appendIdTo: lable });
//            },
//            success: function (lable) {
//                lable.ligerHideTip();
//            }
        //        });
        if (document.location.href.indexOf('localhost') > -1) {
            $('#txtUserName').val('<%=userName%>');
            $('#txtUserPwd').val('<%=password%>');
        }
    });

    function ToggleCode(obj, codeurl) {
        $(obj).attr("src", codeurl + "?time=" + Math.random());
    }
</script>
</head>
<body class="loginbody">
<form id="form1" runat="server">
<div class="login_div">
	<div class="login_box">
    	<div class="login_logo">LOGO</div>
        <div class="login_content">
          <dl>
			<dt>登录账号：</dt>
            <dd><asp:TextBox ID="txtUserName" runat="server" CssClass="login_input required" style="width:130px;" /></dd>
          </dl>
          <dl>
			<dt>登录密码：</dt>
            <dd><asp:TextBox ID="txtUserPwd" runat="server" CssClass="login_input required" TextMode="Password" style="width:130px;" /></dd>
          </dl>
          <dl>
			<dt>验证码：</dt>
            <dd>
                <asp:TextBox ID="txtCode" runat="server" CssClass="login_input required" MaxLength="6" style="width:55px;text-transform:uppercase;" />
                <img src="Ajax/verify_code.ashx" width="70" height="22" alt="点击切换验证码" title="点击切换验证码" style=" margin-top:2px; vertical-align:top;cursor:pointer;" onclick="ToggleCode(this, 'Ajax/verify_code.ashx');return false;" />
               
            </dd>
          </dl>
        </div>
        <div class="login_foot">
			<div class="right"><asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="login_btn" onclick="btnSubmit_Click" /></div>
			<span><asp:CheckBox ID="cbRememberId" runat="server" Text="记住用户名" Checked="True" /></span>
		</div>
        <div class="login_tip">
            <asp:Label ID="lblTip" runat="server" Text="请输入用户名及密码" Visible="False" />
        </div>
    </div>
	<div class="login_copyright">Copyright © 2019 - 2019 szhonganxin.cn Inc. All Rights Reserved.<br />
        深圳市鸿安信科技有限公司 版权所有</div>
</div>
</form>
</body>
</html>

