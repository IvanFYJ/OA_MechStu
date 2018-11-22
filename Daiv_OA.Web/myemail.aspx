<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myemail.aspx.cs" Inherits="Daiv_OA.Web.myemail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的邮件</title><script type="text/javascript" language="javascript"> window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>

    <link href="style/global.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 20px;
        }
    </style>
</head>
<body>
    <form runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        填写我的邮件</h1>
                </td>
               <td class="actions" width="*">
                    <%--<table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td>
                                写邮件
                            </td>
                            <td>
                                接收邮件
                            </td>
                            <td>
                                已发邮件
                            </td>
                        </tr>
                    </table>--%>
                    
                </td>
            </tr>
        </table>
    </div>
    <div class="right1">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="0%" valign="top">
                    <h1>
                        <img src="images/ht16_03.gif" /></h1>
                </td>
                <td width="99%" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr><td height="23">   &nbsp;&nbsp; 想要自己的邮件来信件时，在OA系统中也能提醒自己。必须满足以下两个条件：</td></tr>
                       <tr><td height="46"> &nbsp;&nbsp; 1.保存邮箱名称和密码，您的密码会经过特殊的加密处理来保证您的密码安全。<br />
                           <br/> &nbsp; &nbsp;2.如果你的邮箱非将博网邮件，请启用你邮箱的Pop协议！<br />
                           <br/> &nbsp; &nbsp;如果你已经保存过邮箱，随时都可以“检索新邮件”，检索需要时间需耐心等待！需要修改邮箱密码请点击<asp:LinkButton 
                               ID="LinkButton1" runat="server" CausesValidation="False" Font-Bold="True" 
                               ForeColor="#0066CC" onclick="LinkButton1_Click">邮箱密码修改</asp:LinkButton>
                           <br />
                                </td></tr>
                        <tr>
                            <td bgcolor="#f6f9fe" 
                                style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;" 
                                class="style1">
                                &nbsp;&nbsp; 邮件<span class="bvjto styp">名称：</span>
                                <asp:TextBox ID="emailname" runat="server" MaxLength="20" Width="160px" CssClass="cpb"></asp:TextBox>
                                <asp:DropDownList ID="Tpdropdown" runat="server">
                                    <asp:ListItem>@daiv.cn</asp:ListItem>
                                    <asp:ListItem>@126.com</asp:ListItem>
                                    <asp:ListItem>@qq.com</asp:ListItem>
                                    <asp:ListItem>@163.com</asp:ListItem>
                                    <asp:ListItem>@yeah.net</asp:ListItem>
                                    <asp:ListItem>@sina.com</asp:ListItem>
                                    <asp:ListItem>@sina.cn</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="emailname"
                                    ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
                                <asp:Label ID="Label1" runat="server" ForeColor="#666666" Text="注意：用户名只须填写@前面的字符"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                &nbsp;&nbsp; 邮箱<span class="bvjto styp">密码：</span>
                                <asp:TextBox ID="emailpwd" runat="server" CssClass="cpb" Width="220px" MaxLength="30"
                                    TextMode="Password"></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:RequiredFieldValidator ID="rfvTitle0" runat="server" ControlToValidate="emailpwd"
                                    ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
                                <asp:Label ID="Label2" runat="server" ForeColor="#666666" Text="邮箱密码会进行特殊的加密"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                         
                        <tr>
                            <td align="center">
                                &nbsp;
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <%--<asp:Button ID="Button2" runat="server" CausesValidation="False" 
                                                CssClass="btnsubmit2" onclick="Button2_Click" Text="检索最新邮件" />--%>
                                <asp:Button ID="Button1" runat="server" CssClass="btnsubmit1" Text="保存邮箱" 
                                    onclick="Button1_Click" />
                                            <asp:Button ID="Button2" runat="server" CssClass="btnsubmit1" 
                                                onclick="Button2_Click" Text="修改密码" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="0%" valign="top">
                    <h2>
                        <img src="images/ht28_03.gif" /></h2>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
