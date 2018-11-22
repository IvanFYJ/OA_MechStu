<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My_Plan_List.aspx.cs" Inherits="Daiv_OA.Web.My_Plan_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的计划</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
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
                        我的计划</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td class="active">
                                列表
                            </td>
                            <td>
                                <a href="My_Plan_Add.aspx">上报计划</a>
                            </td>
                        </tr>
                    </table>
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
                        <tr>
                            <td valign="top">
                                <div class="envthp">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="25" valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding- tom: 2px;">
                                                <asp:Repeater ID="Plan_repeater" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                                            <tr class="dataTableHead" align="center">
                                                                <td style="width: 40px">
                                                                    序号
                                                                </td>
                                                                <td style="width: 120px">
                                                                    上报时间
                                                                </td>
                                                                <td width="*">
                                                                    计划名称
                                                                </td>
                                                                <td style="width: 70px">
                                                                    接收领导
                                                                </td>
                                                                <td style="width: 50px">
                                                                    状态
                                                                </td>
                                                                <td style="width: 30px">
                                                                    下载
                                                                </td>
                                                                <td style="width: 30px">
                                                                    删除
                                                                </td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%# Container.ItemIndex + 1 %>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Pwdate")%>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Pwtitle") %>
                                                            </td>
                                                            <td align="center">
                                                                <%# GetUserNameById(Eval("Manager", "{0}")) %>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Locked") %>
                                                            </td>
                                                            <td align="center">
                                                                <asp:LinkButton ID="lbDown" runat="server" Text="下载" OnCommand="lbDown_Click" CommandArgument='<%# Eval("Pwid") %>'></asp:LinkButton>
                                                            </td>
                                                            <td align="center">
                                                                <asp:LinkButton ID="lbDel" runat="server" Text="删除" OnCommand="lbDel_Click" CommandArgument='<%# Eval("Pwid") %>'
                                                                    OnClientClick="javascript:return confirm('您确定要删除吗？');"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td align="center">
                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                                                    PageSize="15" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
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
        </table>
    </div>
    </form>
<script type="text/javascript"> 
	 
</script>

</body>
</html>