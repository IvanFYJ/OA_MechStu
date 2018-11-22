<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_List.aspx.cs" Inherits="Daiv_OA.Web.Message_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>站内短信</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />

    <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>

    <link href="style/global.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
function ajaxBacthDelMessage(){
	var ids = JoinSelect("selectID");
	if(ids=="")
	{
		OA.Alert("没有任何选择项", "0"); 
		return;
	}
	OA.Loading.show("正在处理...",260,80);
	$.ajax({
		type:		"post",
		dataType:	"json",
		data:		"ids="+ids,
		url:		"ajax.aspx?oper=ajaxBacthDelMessage&time="+(new Date().getTime()),
		error:		function(XmlHttpRequest,textStatus, errorThrown){OA.Loading.hide();alert(XmlHttpRequest.responseText); },
		success:	function(d){
			switch (d.result)
			{
			case '0':
				OA.Alert(d.returnval, "0");
				break;
			case '1':
				OA.Message(d.returnval, "1");
				location.href= 'Message_List.aspx';
				break;
			}
		}
	});
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        站内短信</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td class="active">
                                收件箱
                            </td>
                            <td>
                                <a href="Message_MySend.aspx">已发短信</a>
                            </td>
                            <td>
                                <a href="Message_Add.aspx">发送新短信</a>
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
                <input type="button" value="批量删除" id="btnDelete" class="btnsubmit1" onclick="ajaxBacthDelMessage()" />
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
                                                <asp:Repeater ID="Repeater_Message" runat="server">
                                                    <HeaderTemplate>
                                                        <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                                            <tr class="dataTableHead" align="center">
                                                                <td style="width: 30px;">
                                                                    <input onclick="checkAllLine()" id="checkedAll" name="checkedAll" type="checkbox"
                                                                        title="全部选择/全部不选" /></th>
                                                                    <td style="width: 20px">
                                                                    </td>
                                                                    <td style="width: 50px">
                                                                        发信人
                                                                    </td>
                                                                    <td width="*">
                                                                        标题
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        发送时间
                                                                    </td>
                                                                    <td style="width: 70px;">
                                                                        操作
                                                                    </td>
                                                            </tr>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <input class="checkbox" name="selectID" type="checkbox" value='<%#Eval("Mid","{0}")%>' />
                                                            </td>
                                                            <td align="center">
                                                                <img id="img<%#Eval("Mid","{0}")%>" src="images/ico_isread<%#Eval("Isread","{0}")%>.gif" />
                                                            </td>
                                                            <td align="center">
                                                                <a title="给<%#Eval("FromUname")%>回复短信" href="Message_Add.aspx?mesid=<%#Eval("Mid")%>&&toid=<%#Eval("FromUid") %>">
                                                                    <%#Eval("FromUname")%></a>
                                                            </td>
                                                            <td align="center">
                                                                <a onclick="javascript:$$('img<%#Eval("Mid","{0}")%>').src='images/ico_isread1.gif';OA.Popup.show('Message_Show.aspx?id=<%#Eval("Mid","{0}")%>',-1,-1,true)"
                                                                    href="javascript:void(0);">
                                                                    <%#Eval("Mtitle")%></a>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Addtime","{0:yyyy-MM-dd HH:mm:ss}")%>
                                                            </td>
                                                            <td align="center">
                                                                <a onclick="javascript:$$('img<%#Eval("Mid","{0}")%>').src='images/ico_isread1.gif';OA.Popup.show('Message_Show.aspx?id=<%#Eval("Mid","{0}")%>',-1,-1,true)"
                                                                    href="javascript:void(0);">查看</a>
                                                                <asp:LinkButton ID="lbDel" runat="server" Text="删除" OnCommand="lbDel_Click" CommandArgument='<%# Eval("Mid") %>'
                                                                    OnClientClick="javascript:return confirm('您确定要删除吗？');"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody> </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td align="center">
                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                                                    PageSize="22" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
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
