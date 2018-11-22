<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Operatelog_List.aspx.cs" Inherits="Daiv_OA.Web.Operatelog_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>操作日志</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="right1">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="0%" valign="top">
                    <h1>
                        <img src="images/ht16_03.gif" /></h1>
                </td>
                <td width="99%" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="154" valign="top">
                                <div class="envthp">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="25" valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding- tom: 2px;">
                                                <asp:Repeater ID="pro_repeater" runat="server">
                                                    <headertemplate>
                                                        <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                                            <tr class="dataTableHead" align="center">
                                                                <td style="width: 40px">
                                                                    序号
                                                                </td>
                                                                <td width="*">
                                                                    日志标题
                                                                </td>
                                                                <td style="width: 120px">
                                                                    <b>时间</b>
                                                                </td>
                                                                <td style="width: 120px">
                                                                    日志类型
                                                                </td>
                                                                <td style="width: 80px">
                                                                    操作人
                                                                </td>
                                                                <td style="width: 30px">
                                                                    删除
                                                                </td>
                                                            </tr>
                                                    </headertemplate>
                                                    <itemtemplate>
                                                        <tr>
                                                            <td width="10%" align="center">
                                                                <%# Container.ItemIndex + 1 %>
                                                            </td>
                                                            <td style="width: 20%" align="center">
                                                                <%#Eval("Eupdatetitle")%>
                                                            </td>
                                                            <td style="width: 20%" align="center">
                                                                <%#Eval("Eupadatetime")%>
                                                            </td>
                                                            <td style="width: 20%" align="center">
                                                                <%#Eval("Eupdatetype")%>
                                                            </td>
                                                            <td style="width: 20%" align="center">
                                                                <%#Eval("Uname")%>
                                                            </td>
                                                            <td style="width: 10%" align="center">
                                                                <asp:LinkButton ID="lbDel" runat="server" Text="删除" OnCommand="lbDel_Click" CommandArgument='<%# Eval("Operatelogid") %>'
                                                                    onclientclick="javascript:return confirm('您确定要删除吗？');"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </itemtemplate>
                                                    <footertemplate>
                                                        </table>
                                                    </footertemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td align="center">
                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="20" OnPageChanged="AspNetPager1_PageChanged" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
                                                </webdiyer:AspNetPager>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
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
