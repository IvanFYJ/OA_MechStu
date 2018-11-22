<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Squestiondetail.aspx.cs"
    Inherits="Daiv_OA.Web.Squestiondetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>问题详细信息</title><script type="text/javascript" language="javascript">                             window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
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
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 2px;">
       
    </div>
    <div class="right">
        <div class="cntre">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%; padding: 10px;">
                        <div class="jsatp">
                            <div id="myTab1_Content0" class="cntut">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">选择项目：</span>
                                            <asp:DropDownList ID="Itemid" runat="server" Width="220px">
                                            </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="labfa" runat="server" ForeColor="#CCCCCC" Text="发布人："></asp:Label>
                                            <asp:Label ID="quuser" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">问题处理者：</span>
                                            <asp:DropDownList ID="touser" runat="server" Height="24px" Width="220px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">问题种类：</span>
                                            <asp:RadioButtonList ID="types" runat="server" RepeatDirection="Horizontal" ValidationGroup="ff">
                                                <asp:ListItem Selected="True" Value="0">技术问题</asp:ListItem>
                                                <asp:ListItem Value="1">非技术问题</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">问题处理等级：</span>
                                            <asp:DropDownList ID="classe" runat="server">
                                                <asp:ListItem Value="1">一般</asp:ListItem>
                                                <asp:ListItem Value="2">紧急</asp:ListItem>
                                                <asp:ListItem Value="3">十分紧急</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">问题主题：</span>
                                            <asp:TextBox ID="titels" runat="server" MaxLength="350" Width="420px" Height="20px"
                                                CssClass="ipt"></asp:TextBox>
                                            <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="titels"
                                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="260" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">问题详细描述：</span>
                                            <div style="width:80%; text-align: right">
                                                                  <textarea id="kindeditor" cols="100" rows="8" style="width:700px;height:200px;visibility:hidden;" runat="server"></textarea>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">问题所在页面地址：</span>
                                            <asp:TextBox ID="pages" runat="server" CssClass="ipt" Height="20px" Width="420px"></asp:TextBox>
                                            <asp:Label ID="Label2" runat="server" Text="*"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvTitle0" runat="server" ControlToValidate="pages"
                                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">发布问题日期：</span>
                                            <asp:Label ID="inserttime" runat="server" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                     </asp:Panel> 
                                    <asp:Panel ID="panelChu" runat="server"  Visible="false">
                                        <tr>
                                            <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                              <hr style="size:-15px; color:Black" />  <span class="bvjto styp">处理问题描述：</span>
                                                <asp:TextBox ID="answer" runat="server" Width="592px" Height="44px" CssClass="ipt"
                                                    onFocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',readOnly:true,minDate:'#F{$dp.$D(\'txtBegintime\')}'})"
                                                    MaxLength="350" Rows="2" TextMode="MultiLine" Font-Bold="True"></asp:TextBox>
                                                <asp:Label ID="Label3" runat="server" Text="*"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvTitle1" runat="server" ControlToValidate="answer"
                                                    ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                                <span class="bvjto styp">问题处理时间：</span>
                                                <asp:Label ID="antime" runat="server" ForeColor="#3399FF"></asp:Label>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                   <asp:Panel ID="panelFu" runat="server" Visible="false">
                                        <tr>
                                            <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                                <hr style="size:-15px; color:Black" /> <span class="bvjto styp">问题复测情况：</span>
                                                <asp:RadioButtonList ID="rescue" runat="server" RepeatDirection="Horizontal" ValidationGroup="cc">
                                                    <asp:ListItem Value="问题已处理">问题已处理</asp:ListItem>
                                                    <asp:ListItem Value="还存在问题">还存在问题</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                                <span class="bvjto styp">复测问题描述信息：</span>
                                                <asp:TextBox ID="okuser" TextMode="MultiLine" MaxLength="30" runat="server" 
                                                    CssClass="ipt" Height="40px" Width="420px" Rows="3"></asp:TextBox>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                                <span class="bvjto styp">问题修改完成日期：</span>
                                                <asp:Label ID="uptime" runat="server" ForeColor="#FF3300"></asp:Label>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                </table>
                            </div>
                        </div>
                        <div class="cntre1">
                            <asp:Button ID="Button2" runat="server" Text="提交" CssClass="btnsubmit1" OnClick="Button2_Click" />
                            <asp:Button ID="Button1" runat="server" Text="提交并继续" CssClass="btnsubmit1" OnClick="Button1_Click" />
                            <asp:Button ID="Button3" runat="server" Text="返回" CssClass="btnsubmit1" CausesValidation="False"
                                OnClick="Button3_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>

    <script type="text/javascript"> 
	 
    </script>

</body>
</html>
