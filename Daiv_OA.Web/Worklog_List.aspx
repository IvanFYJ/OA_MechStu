<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Worklog_List.aspx.cs" Inherits="Daiv_OA.Web.Worklog_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>员工办公日志</title><script type="text/javascript" language="javascript">                             window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />

    <script src="_libs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>

    <link href="style/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="padding-left: 10px;">
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px;">
                &nbsp;姓名:
                <asp:DropDownList ID="ddlUname" runat="server" Width="100px">
                    <asp:ListItem Value="">==不限定==</asp:ListItem>
                </asp:DropDownList>
                &nbsp; 开始日期:<asp:TextBox ID="txtBegintime" class="Wdate" Width="90px" runat="server"
                    onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',readOnly:true,maxDate:'#F{$dp.$D(\'txtEndtime\')}'})">
                </asp:TextBox>&nbsp; 结束日期:<asp:TextBox ID="txtEndtime" class="Wdate" Width="90px"
                    runat="server" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',readOnly:true,minDate:'#F{$dp.$D(\'txtBegintime\')}'})">
                </asp:TextBox>&nbsp;
                <asp:Button ID="btnSelect" runat="server" CssClass="btnsubmit1" Text="查询" OnClick="btnSelect_Click" />
            </td>
        </tr>
    </table>
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
                                                <asp:Repeater ID="Repeater_Worklog" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                                            <tr class="dataTableHead" align="center">
                                                                <td width="40px">
                                                                    序号
                                                                </td>
                                                                <td style="width: 50px">
                                                                    姓名
                                                                </td>
                                                                <td style="width: 250px;">
                                                                    工作起止时间
                                                                </td>
                                                                <td width="*">
                                                                    所做的工作
                                                                </td>
                                                                <td style="width: 80px">
                                                                    完成情况
                                                                </td>
                                                                <td style="width: 80px">
                                                                    任务分配人
                                                                </td>
                                                                <td style="width: 60px">
                                                                    详情
                                                                </td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%#Container.ItemIndex + 1 %>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Uname")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Begintime")%>
                                                                至
                                                                <%# Eval("Endtime")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Title")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Content") %>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Manager") %>
                                                            </td>
                                                            <td align="center">
                                                                <a href="javascript:void(0);" onclick="OA.Popup.show('Worklog_Show.aspx?id=<%# Eval("Id") %>',-1,-1,true)">
                                                                    详情</a>
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
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript"> 
	 
    </script>

</body>
</html>
