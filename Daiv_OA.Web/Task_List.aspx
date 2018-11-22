<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task_List.aspx.cs" Inherits="Daiv_OA.Web.Task_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>员工任务分配</title><script type="text/javascript" language="javascript">                             window.onerror = function () { return true; };</script>
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script src="_libs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>

    <link href="style/global.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        工作分配</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td class="active">
                                员工任务分配
                            </td>
                            <td>
                                <a href="Task_Add.aspx">分配新任务</a>
                            </td>
                              <td >
                               <a href="TastCheck.aspx?tast=45678">验收任务</a>
                            </td>
                             <td >
                               <a href="TastCheck.aspx?tast=9">拒收任务</a>
                            </td>
                            <td>
                                <a href="TastCheck.aspx?tast=3">任务档案</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
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
                &nbsp; 计划完成时间:<asp:TextBox ID="txtBegintime" class="Wdate" Width="90px" runat="server"
                    onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',readOnly:true,maxDate:'#F{$dp.$D(\'txtEndtime\')}'})">
                </asp:TextBox>&nbsp;至&nbsp;<asp:TextBox ID="txtEndtime" class="Wdate" Width="90px"
                    runat="server" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',readOnly:true,minDate:'#F{$dp.$D(\'txtBegintime\')}'})">
                </asp:TextBox>&nbsp;
                <asp:DropDownList ID="classse" runat="server">
                                                <asp:ListItem Value="普通任务">普通任务</asp:ListItem>
                                                <asp:ListItem Value="重要任务">重要任务</asp:ListItem>
                                                <asp:ListItem Value="紧急任务">紧急任务</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="0">==不限定==</asp:ListItem>
                                            </asp:DropDownList>
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
                            <td height="154" valign="top">
                                <div class="envthp">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="25" valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding- tom: 2px;">
                                                <asp:Repeater ID="pro_repeater" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                                            <tr class="dataTableHead" align="center">
                                                                <td style="width: 40px;">
                                                                    序号
                                                                </td>
                                                                <td style="width: 50px">
                                                                    接收人
                                                                </td>
                                                                <td style="width: 50px">
                                                                    分配人
                                                                </td>
                                                                <td width="*">
                                                                    任务主题
                                                                </td>
                                                                <td style="width: 120px;">
                                                                    计划完成时间
                                                                </td>
                                                                <td style="width: 60px">
                                                                    任务状态
                                                                </td>
                                                                <td style="width: 120px;">
                                                                    操作
                                                                </td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%# Container.ItemIndex + 1 %>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Uname")%>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Manager")%>
                                                            </td>
                                                            <td align="center">
                                                                <span title="<%#Eval("Tasktitle")%>">
                                                                    <%#Eval("Tasktitle")%></span>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Plantime","{0:yyyy-MM-dd HH:mm:ss}")%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Workstate") %>
                                                            </td>
                                                            <td align="center">
                                                                <a href="javascript:void(0);" onclick="OA.Popup.show('Task_Show.aspx?id=<%#Eval("Tlid") %>',-1,-1,true)">
                                                                    详细内容</a>
                                                                <asp:LinkButton ID="lblEdit" runat="server" OnCommand="lbEdit_Click" CommandArgument='<%# Eval("Tlid") %>'
                                                                    Visible='<%# Eval("Manager","{0}") == UserName %>'>修改</asp:LinkButton>
                                                                <asp:Label ID="lblNone1" runat="server" Text="修改" ForeColor="#eeeeee" Visible='<%# Eval("Manager","{0}") != UserName %>'></asp:Label>
                                                                <asp:LinkButton ID="lbDel" runat="server" Text="删除" OnCommand="lbDel_Click" CommandArgument='<%# Eval("Tlid") %>'
                                                                    OnClientClick="javascript:return confirm('您确定要删除吗？');" Visible='<%# Eval("Manager","{0}") == UserName %>'></asp:LinkButton>
                                                                <asp:Label ID="lblNone2" runat="server" Text="删除" ForeColor="#eeeeee" Visible='<%# Eval("Manager","{0}") != UserName %>'></asp:Label>
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
