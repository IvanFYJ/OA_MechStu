<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Learning_List.aspx.cs"
    Inherits="Daiv_OA.Web.Learning_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>学习资料</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>

    <link href="style/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        学习资料</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td class="active">
                                <a href="Learning_List.aspx">全部</a>
                            </td>
                            <td>
                                <a href="Learning_Add.aspx">我要添加</a>
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
                            <td height="154" valign="top">
                                <div class="envthp">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding- tom: 2px;">
                                                <asp:Repeater ID="Sinfo_repeater" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                                            <tr class="dataTableHead" align="center">
                                                                <td style="width: 40px;">
                                                                    序号
                                                                </td>
                                                                <td width="*">
                                                                    标题
                                                                </td>
                                                                <td style="width: 60px;">
                                                                    发布人
                                                                </td>
                                                                <td style="width: 120px;">
                                                                    发布时间
                                                                </td>
                                                                <td style="width: 120px;">
                                                                    操作
                                                                </td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%#Container.ItemIndex + 1 %>
                                                            </td>
                                                            <td align="center">
                                                                <a href="javascript:void(0);" onclick="OA.Popup.show('Learning_Show.aspx?id=<%#Eval("Sid") %>',-1,-1,true)">
                                                                    <%#Eval("Stitle")%></a>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Sauthor")%>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Sdate")%>
                                                            </td>
                                                            <td align="center">
                                                                <a href="javascript:void(0);" onclick="OA.Popup.show('Learning_Show.aspx?id=<%#Eval("Sid") %>',-1,-1,true)">
                                                                    详细内容</a>
                                                                <asp:LinkButton ID="lbEdit" runat="server" Text="修改" OnCommand="lbEdit_Click" CommandArgument='<%# Eval("Sid") %>'
                                                                    Visible='<%# Eval("Sauthor","{0}") == UserName %>'></asp:LinkButton>
                                                                <asp:Label ID="Label1" runat="server" Text="修改" CssClass="disabled" Visible='<%# Eval("Sauthor","{0}") != UserName %>'></asp:Label>
                                                                <asp:LinkButton ID="lbDel" runat="server" Text="删除" OnCommand="lbDel_Click" CommandArgument='<%# Eval("Sid") %>'
                                                                    Visible='<%# Eval("Sauthor","{0}") == UserName %>' OnClientClick="javascript:return confirm('您确定要删除吗？');"></asp:LinkButton>
                                                                <asp:Label ID="Label2" runat="server" Text="删除" CssClass="disabled" Visible='<%# Eval("Sauthor","{0}") != UserName %>'></asp:Label>
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
                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" NumericButtonCount="20" OnPageChanged="AspNetPager1_PageChanged"
                                                    PageSize="20" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
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

    <script type="text/javascript"> 
	 
    </script>

</body>
</html>
