<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My_Time_List.aspx.cs" Inherits="Daiv_OA.Web.My_Time_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>个人考勤</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="width: 100%; padding: 10px;">
                <table class="helptable">
                    <tr>
                        <td>
                            <ul>
                                <li>请如实进行各项登记操作，这将作为员工考评的标准之一。</li>
                                <li>“外出”、“出差”、“事病假”回来后，要进行“销假”操作。</li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px;">
                <asp:Button ID="btWork" runat="server" CssClass="btnsubmit1" Text="上班登记" OnClick="btWork_Click" />
                <asp:Button ID="btOff" runat="server" CssClass="btnsubmit1" Text="下班登记" OnClick="btOff_Click" />
                <asp:Button ID="btOut0" runat="server" CssClass="btnsubmit1" Text="外出登记" OnClick="btOut0_Click" />
                <asp:Button ID="btLeave0" runat="server" CssClass="btnsubmit1" Text="事病假登记" OnClick="btLeave0_Click" />
                <asp:Button ID="btErr0" runat="server" CssClass="btnsubmit1" Text="出差登记" OnClick="btErr0_Click" />
                <asp:Button ID="btLogout0" runat="server" CssClass="btnsubmit1" Text="销假登记" OnClick="btLogout0_Click" />
                <asp:Button ID="Button1" CssClass="btnsubmit1" runat="server" Text="本月考勤" 
                    onclick="Button1_Click" />
                <asp:Label ID="txtid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr id="trOut" runat="server" visible="false">
            <td style="padding-left: 10px;">
                外出事由：<asp:TextBox ID="txtOut" runat="server" Width="440px" MaxLength="16"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvOut" runat="server" ControlToValidate="txtOut"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Button ID="btOut" runat="server" CssClass="btnsubmit1" Text="确定" OnClick="btOut_Click" />
            </td>
        </tr>
        <tr id="trLeave" runat="server" visible="false">
            <td style="padding-left: 10px;">
                请假原因：<asp:TextBox ID="txtLeave" runat="server" Width="440px" MaxLength="16"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLeave" runat="server" ControlToValidate="txtLeave"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Button ID="btLeave" runat="server" CssClass="btnsubmit1" Text="确定" OnClick="btLeave_Click" />
            </td>
        </tr>
        <tr id="trErr" runat="server" visible="false">
            <td style="padding-left: 10px;">
                出差事由：<asp:TextBox ID="txtErr" runat="server" Width="440px" MaxLength="16"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvErr" runat="server" ControlToValidate="txtErr"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Button ID="btErr" runat="server" CssClass="btnsubmit1" Text="确定" OnClick="btErr_Click" />
            </td>
        </tr>
        <tr id="trLogout" runat="server" visible="false">
            <td style="padding-left: 10px;">
                销假备注：<asp:TextBox ID="txtLogout" runat="server" Width="440px" MaxLength="16"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLogout" runat="server" ControlToValidate="txtLogout"
                    LogoutorMessage="*"></asp:RequiredFieldValidator>
                <asp:Button ID="btLogout" runat="server" CssClass="btnsubmit1" Text="确定" OnClick="btLogout_Click" />
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
                                                                <td width="40px">
                                                                    序号
                                                                </td>
                                                                <td style="width: 100px;">
                                                                    登记类型
                                                                </td>
                                                                <td width="*">
                                                                    备注信息
                                                                </td>
                                                                <td style="width: 120px;">
                                                                    登记时间
                                                                </td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%#Container.ItemIndex + 1 %>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("TimeType")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Timeinfo")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Nowtime")%>
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
                                                    PageSize="30" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
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
