<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task_Show.aspx.cs" Inherits="Daiv_OA.Web.Task_Show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工作展示</title><script type="text/javascript" language="javascript"> window.onerror = function () { return true; }</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>

</head>
<body>
    <form runat="server" id="fm1">
    <br />
    <table class="UserTableBorder" cellspacing="1" cellpadding="3" width="96%" align="center"
        border="0">
        <tr>
            <th colspan="3" style="height: 25px">
                任务查看
            </th>
        </tr>
        <tr>
            <td class="usertablerow2" align="left" style="height: 32px; font-size: 14px;" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width:  80px" align="right">
                       任务主题： </td>
                        <td>&nbsp;<asp:Label ID="lblTitle" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:  80px;color: #999999" align="right">基础信息：
                        </td>
                        <td style="color: #999999">&nbsp;开始时间：&nbsp;<asp:Label ID="lblBegintime" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;预计完成：&nbsp;<asp:Label 
                                ID="lblEndtime" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;完成时间：&nbsp;<asp:Label 
                                ID="labwork" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;任务类型：&nbsp;<asp:Label 
                                ID="classse" runat="server"></asp:Label>  &nbsp;&nbsp;&nbsp;发布人：&nbsp;<asp:Label 
                                ID="Manager" runat="server" ForeColor="Silver"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px" align="right">详细内容：
                        </td>
                        <td>&nbsp;<asp:TextBox ID="txt" runat="server" Height="418px" Width="99%" 
                                TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px"  align="right">任务要求：
                        </td>
                        <td>&nbsp;<asp:Label ID="question" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:  80px" align="right">附件下载：
                        </td>
                        <td>&nbsp;<%=download()%>
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" class="usertablerow1" colspan="2">
                <br />
                <input type="button" class="btnsubmit1" value="返回" onclick="parent.OA.Popup.hide();" />
            </td>
        </tr>
    </table>
    <br />
    </form>
</body>
</html>
