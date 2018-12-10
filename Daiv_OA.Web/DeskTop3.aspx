<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeskTop3.aspx.cs" Inherits="Daiv_OA.Web.DeskTop3" %>
<%@ Register src="webcontrol/WebDate.ascx" tagname="WebDate" tagprefix="uc1" %>
<%@ Register src="webcontrol/address.ascx" tagname="address" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>我的桌面</title><script type="text/javascript" language="javascript">                       window.onerror = function () { return true; };</script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<link href="css/style1.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>
<script type="text/javascript" src="_libs/jquery.jtemplates.js"></script>
<script type="text/javascript" src="_libs/jquery.timers.js"></script>
<script type="text/javascript" src="js/global.js"></script>
<link href="style/global.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form runat="server" id="fm1">

  <table border="0" cellpadding="0" cellspacing="10" style="width: 100%" align="center">
        <tr>
            <td valign="top" colspan="2">
              <uc1:WebDate ID="WebDate1" runat="server" />
            </td>
        </tr>
        <tr  style="display:none;" >
            <td width="40%" valign="top">
                <table cellspacing="1" cellpadding="6" width="100%" align="center" border="0">
                    <tr>
                        <td>
                            <div class="TabTitle">
                                <ul>
                                    <li>通知公告</li>
                                </ul>
                            </div>
                            <asp:Repeater ID="Repeater_Placard" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                        <tr class="dataTableHead" align="center">
                                            <td width="*" align="center">
                                                标题
                                            </td>
                                            <td style="width: 130px;" align="center">
                                                发布时间
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                            <a href="javascript:void(0);" onclick="OA.Popup.show('Placard_Show.aspx?id=<%#Eval("Pid") %>',-1,-1,true)">
                                                <%#Eval("Ptitle") %></a>
                                        </td>
                                        <td align="center">
                                            <%#Eval("Pdate") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </td>
             <td width="50%" valign="top">
                 <table cellspacing="1" cellpadding="6" width="100%" align="center" border="0">
                    <tr>
                        <td>
                            <div class="TabTitle">
                                <ul>
                                    <li>人员列表</li>
                                </ul>
                            </div>
                <asp:Repeater ID="Repeater1" runat="server">
                  <HeaderTemplate>
             <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                        <tr class="dataTableHead" align="center">
                                           <td style="width: 50px">姓名</td>
        <td style="width: 70px">部门</td>
        <td style="width: 50px">状态</td>
        <td style="width: 280px">操作</td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                      <td style="width: 50px"><%#Eval("Uname")%></td>
        <td style="width: 70px"><%#Eval("departmentname")%></td>
        <td style="width: 50px"><%#Format(Eval("seconds"))%><%#FormatMessage(Eval("newmessage"), Eval("Uid"))%></td>
        <td style="width: 280px"> <a href="Message_Add.aspx?fid=<%#Eval("Uid") %>">发送短信</a>
            <a href="Worklog_List.aspx?uid=<%#Eval("Uid") %>">办公日志</a>
            <a href="Summarize_List.aspx?uid=<%#Eval("Uid") %>">工作总结</a>
            <a href="Time_List.aspx?uid=<%#Eval("Uid") %>">考勤查询</a>
            <a href="Task_Add.aspx?uid=<%#Eval("Uid") %>">分配新任务</a></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
            </table>
                                </FooterTemplate>
                </asp:Repeater>
                </td>
                </tr>
                </table>
            </td>
        </tr>
       <tr  style="display:none;" >
            <td valign="top" colspan="2">
                <uc2:address ID="address1" runat="server" />
            </td>
        </tr>
    </table>
<script type="text/javascript"> 
	 
</script>

    
    </form>

</body>
</html>