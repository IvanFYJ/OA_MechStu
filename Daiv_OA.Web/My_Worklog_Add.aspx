<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My_Worklog_Add.aspx.cs"
    Inherits="Daiv_OA.Web.My_Worklog_Add" %>

<%@ Register Assembly="Daiv_OA.FCKeditorV2" Namespace="Daiv_OA.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增日志</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <script src="_libs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
        <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <script src="_libs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
    <link href="kindeditor/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="kindeditor/kindeditor.js" type="text/javascript"></script>
    <script src="kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="kindeditor/plugins/code/prettify.js" type="text/javascript"></script>

	<script type="text/javascript">
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#kindeditor', {
	            cssPath: 'kindeditor/plugins/code/prettify.css',
	            uploadJson: 'kindeditor/asp.net/upload_json.ashx',
	            fileManagerJson: 'kindeditor/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=example]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
    </script>
<script type="text/javascript">
	var config1 = {isShowClear:false,startDate:'<%=date1%>',dateFmt:'yyyy-MM-dd HH:mm:ss',readOnly:true,minDate:'<%=date0%>',maxDate:'<%=date2%>'};
	var config2 = {isShowClear:false,startDate:'<%=date2%>',dateFmt:'yyyy-MM-dd HH:mm:ss',readOnly:true,maxDate:'<%=date2%>',minDate:'#F{$dp.$D(\'txtBegintime\')}'};
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        办公日志</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td>
                                <a href="My_Worklog_List.aspx">列表</a>
                            </td>
                            <td class="active">
                                新增日志
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="right">
        <div class="cntre">
            <asp:HiddenField ID="hidRecordID" runat="server" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%; padding: 10px;">
                        <div class="jsatp">
                            <div id="myTab1_Content0" class="cntut">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">所做的工作：</span>
                                            <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" Width="220px" 
                                                Height="24px" CssClass="ipt"></asp:TextBox><asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">工作起止时间：</span>
                                            <asp:TextBox ID="txtBegintime" runat="server" Width="150px" Height="24px" CssClass="ipt" onFocus="WdatePicker(config1)"></asp:TextBox> 至 <asp:TextBox ID="txtEndtime" runat="server" Width="150px" Height="24px" CssClass="ipt" onFocus="WdatePicker(config2)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">完成情况：</span>
                                            <asp:TextBox ID="txtContent" runat="server" Width="120px" MaxLength="20" Height="24px" CssClass="ipt"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContent" ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">遗留问题：</span>
                                            <asp:TextBox ID="txtProblem" runat="server" Width="400px" MaxLength="60" Height="24px" CssClass="ipt"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProblem" ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">任务分配人：</span>
                                            <asp:DropDownList ID="ddlManager" runat="server" Height="24px" Width="220px" Style="border-bottom: 1px solid #f3f6fb;
                                                border-top: 1px solid #FFFFFF;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">情况反馈及备注：</span>
                                            <div style="width: 98%; margin: auto;">
                                                <textarea id="kindeditor" cols="100" rows="8" style="width:700px;height:200px;visibility:hidden;" runat="server"></textarea>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="cntre1">
                            <ul>
                                <li>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn_submit.gif"
                                        OnClick="ImageButton1_Click" /></li>
                                        <li>
                                        <img alt="取消返回" src="images/btn_cancel.gif" style="cursor:pointer;" onclick="location.href='My_Worklog_List.aspx'" /></li>
                            </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
