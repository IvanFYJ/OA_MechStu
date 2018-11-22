<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Time_List.aspx.cs" Inherits="Daiv_OA.Web.Time_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>员工日常考勤</title><script type="text/javascript" language="javascript">                             window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <script src="_libs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="padding-left: 10px;">&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td style="padding-left: 10px;">
                &nbsp;姓名:
                <asp:DropDownList ID="ddlUname" runat="server" Width="100px">
                <asp:ListItem Value="">==不限定==</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                考勤类别:<asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem>所有类型</asp:ListItem>
                    <asp:ListItem>上班登记</asp:ListItem>
                    <asp:ListItem>下班登记</asp:ListItem>
                    <asp:ListItem>外出登记</asp:ListItem>
                    <asp:ListItem>出差登记</asp:ListItem>
                    <asp:ListItem>事病假登记</asp:ListItem>
                    <asp:ListItem>销假登记</asp:ListItem>
                </asp:DropDownList>
                开始时间:<asp:TextBox ID="txtBegintime" class="Wdate" Width="90px" runat="server" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',readOnly:true,maxDate:'#F{$dp.$D(\'txtEndtime\')}'})">
                </asp:TextBox>&nbsp;    
                结束时间:<asp:TextBox ID="txtEndtime" class="Wdate" Width="90px" runat="server" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',readOnly:true,minDate:'#F{$dp.$D(\'txtBegintime\')}'})">
                </asp:TextBox>&nbsp;
                <asp:Button ID="btnSelect" runat="server" CssClass="btnsubmit1" 
                    Text="查询" onclick="btnSelect_Click" />
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
                                                <asp:Repeater ID="Repeater_Time" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                                            <tr class="dataTableHead" align="center">
                                                                <td style="width: 75px;">
                                                                    日期
                                                                </td>
                                                                <td style="width: 50px">
                                                                    姓名
                                                                </td>
                                                                <td style="width: 60px;">
                                                                    登记时间
                                                                </td>
                                                                <td style="width: 120px;">
                                                                    登记IP地址
                                                                </td>
                                                                <td width="*">
                                                                    登记信息
                                                                </td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%# Eval("Nowtime", "{0:yyyy-MM-dd}")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Uname")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Nowtime", "{0:HH:mm:ss}")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("IPaddress")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# GetTimeRemark(Eval("TimeType", "{0}"), Eval("TimeInfo", "{0}"), Eval("Retime", "{0:HHmm}"), Eval("Nowtime", "{0:HHmm}"))%>
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
                                                    PageSize="31" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
                                                    PrevPageText="上一页">
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