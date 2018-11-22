<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Show.aspx.cs" Inherits="Daiv_OA.Web.Message_Show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看短信</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>
</head>
<body>
    <form runat="server" id="fm1">
    <br>
    <table class="UserTableBorder" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
        <tr>
            <td class="usertablerow2" align="left" style="height: 32px;font-size:14px;" colspan="2">
                <br />
                <b>主题：</b><asp:Label ID="lblTitle" runat="server"></asp:Label>
                <br />
                <br />
                <b>内容：</b><br />
                <div id="text">
                    <%=text %></div>
            </td>
        </tr>
        <tr>
            <td align="center" class="usertablerow1" colspan="2">
                <br>
                <input type="button" class="btnsubmit1" value="返回" onclick="parent.OA.Popup.hide();" /><div
                    id="Div2">
                </div>
            </td>
        </tr>
    </table>
    <br>
    </form>
</body>
</html>
