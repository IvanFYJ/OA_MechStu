<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParentMessage_Add.aspx.cs" Inherits="Daiv_OA.Web.ParentMessage_Add" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加留言</title><script type="text/javascript" language="javascript">                            window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        留言管理</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                     <%--    <td>
                                <a href="role.aspx?roleid=1">部门列表</a>
                            </td>
                            <td>
                                <a href="role.aspx?roleid=0">角色列表</a>
                            </td>--%>
                            <td><a href="ParentMessage_List.aspx">留言列表</a></td>
                            <td class="active">添加留言</td>
<%--                            <td><a href="ParentMessage_Add2.aspx">添加主管</a></td>
                            <td><a href="ParentMessage_Add3.aspx">添加副主管</a></td>
                            <td><a href="ParentMessage_Add4.aspx">添加员工</a></td>--%>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="right">
        <div class="cntre">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%; padding: 10px;">
                        <div class="jsatp">
                            <div class="TabTitle">
                                <ul id="myTab1">
                                    <li>基本信息</li>
                                </ul>
                            </div>
                             <div id="myTab1_Content0" class="cntut">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">留言标题：</span>
                                            <asp:TextBox ID="Mtitle" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mtitle"
                                                ErrorMessage="*必填选项"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">留言内容：</span>
                                            <asp:TextBox ID="Content" runat="server" Width="220px" TextMode="MultiLine" Rows ="5" Height="24px" CssClass="ipt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Content"
                                                ErrorMessage="*必填选项"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="cntre1">
                            <ul><li>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn_submit.gif" OnClick="ImageButton1_Click" /></li>
                            <li>
                                        <img alt="取消返回" src="images/btn_cancel.gif" style="cursor:pointer;" onclick="location.href='ParentMessage_List.aspx'" /></li>
                                        </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Image ID="Image1" runat="server" Width="1px" Height="1px" />
    <asp:Image ID="Image2" runat="server" Width="1px" Height="1px" />
    </form>
<script type="text/javascript"> 
	 
</script>

</body>
</html>
