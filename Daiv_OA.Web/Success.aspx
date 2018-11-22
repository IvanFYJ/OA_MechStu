<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="Daiv_OA.Web.Success" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>操作成功</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div class="right">
        <div class="ecntr">
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border: 1px solid #e5edf0;">
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="36" align="center" background="images/ht31_03.gif">
                                    <strong style="color: #000000;">系统操作提示信息</strong>
                                </td>
                            </tr>
                            <tr>
                                <td height="229" valign="top" bgcolor="#f6f9fe" style="border-top: 1px solid #e8edf1;">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="40%" height="249" align="center">
                                                <img src="images/success.gif" />
                                            </td>
                                            <td width="60%" align="right" valign="top">
                                                <p>
                                                    &nbsp;</p>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="197" align="center">
                                                            恭喜，操作成功！<br />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Button runat="server" Text="返回上一页" OnClick="Unnamed1_Click"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
