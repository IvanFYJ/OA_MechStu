<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My_Task_List.aspx.cs" Inherits="Daiv_OA.Web.My_Task_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工作任务</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>

    <link href="style/global.css" rel="stylesheet" type="text/css" />

    <script src="js/popup.js" type="text/javascript"></script>
    <script type="text/javascript">
$(document).ready(function(){
	$('.td'+q('progress')).addClass('active');
});
</script>
<script language="javascript" type="text/javascript">
    var pw=new PopWindow();
    setIntTop=300;
 setIntLeft=150;
    //传值
     var Up=function(id)
      {
          var  strUrl="My_TaskCheckt.aspx?id="+id;
          pw.iframe("提交任务状态",strUrl,false,370,220)
      };
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        工作任务</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td >
                              <a href="My_Task_List.aspx">正在进行</a>
                            </td>
                            <td >
                                <a href="My_Task_List.aspx?progress=1">未读任务</a> 
                            </td>
                            <td >
                                <a href="My_Task_List.aspx?progress=3">任务档案</a>
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
                                                <asp:Repeater ID="Repeater_Work" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                                            <tr class="dataTableHead" align="center">
                                                                <td style="width: 40px">
                                                                    序号
                                                                </td>
                                                                <td width="*">
                                                                    任务主题
                                                                </td>
                                                                <td style="width: 120px">
                                                                    完成时间
                                                                </td>
                                                                <td style="width: 217px">
                                                                    时间进度
                                                                </td>
                                                                <td style="width: 60px">
                                                                    任务类型
                                                                </td>
                                                                <td style="width: 90px">
                                                                任务状态
                                                                </td>
                                                                 <td style="width: 160px" >
                                                                备注说明
                                                                </td>
                                                                <td style="width: 60px">
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
                                                                <a href="javascript:void(0);" title="查看详细"; onclick="top.OA.Popup.show('My_Work_Show.aspx?id=<%# Eval("Tlid") %>',1050,700,true)"> <%# Eval("Tasktitle") %></a>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("Worktime") %>
                                                            </td>
                                                            <td align="center">
                                                              <%#strimg(Eval("sumtime"), Eval("progresstime"))%>
                                                            </td>
                                                            <td align="center">
                                                                <%# Eval("classse")%>
                                                            </td>
                                                             <td align="center" style="width:90px;">
                                                                <%#str(Eval("Workprogress").ToString()) %>
                                                            </td>
                                                            <td  align="center">
                                                            <%# Daiv_OA.Utils.Strings.Left(Eval("remark").ToString(),20)%>
                                                            </td>
                                                            <td >
                                                             <%# astr(Eval("Tlid"),Eval("Workprogress"))%> 
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
                                                    PageSize="30" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
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
