<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My_TaskCheckt.aspx.cs"
    Inherits="Daiv_OA.Web.My_TaskCheckt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的任务状态</title><script type="text/javascript" language="javascript">                             window.onerror = function () { return true; };</script>

    <script type="text/javascript" language="javascript">
    function close()
    {
     parent.pw.close();
     }
    </script>

    <link href="css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                &nbsp;
                <asp:Label ID="Label2" runat="server" Text="请选择任务状态：" Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="Workprogress" runat="server" Width="130px">
                    <asp:ListItem Value="2">已进行中</asp:ListItem>
                    <asp:ListItem Value="5">提前完成</asp:ListItem>
                    <asp:ListItem Value="6" Selected="True">完成</asp:ListItem>
                    <asp:ListItem Value="7">未完成</asp:ListItem>
                    <asp:ListItem Value="8">申请新时间</asp:ListItem>
                    <asp:ListItem Value="9">拒收此任务</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td  height="152">
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text="信息提交备注：" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="titlename" runat="server" MaxLength="100" Width="352px" TextMode="MultiLine"
                    CssClass="bntj" Height="152px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="btnsubmit1" OnClick="Button1_Click" />
                &nbsp;<asp:Button ID="Button2" runat="server" Text="关闭" CausesValidation="False"
                    CssClass="btnsubmit1" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
