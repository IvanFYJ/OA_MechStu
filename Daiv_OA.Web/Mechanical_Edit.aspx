﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mechanical_Edit.aspx.cs" Inherits="Daiv_OA.Web.Mechanical_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改设备</title><script type="text/javascript" language="javascript">                            window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    
    <script src="_libs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="_libs/jquery-3.1.1.js"></script>
    <script type="text/javascript" src="js/Grade/grade.js"></script>

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
                        设备管理</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td><a href="Mechanical_List.aspx">设备列表</a></td>
                            <td class="active">修改设备</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="right">
        <div class="cntre">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%; padding: 10px;">
                        <div class="jsatp">
                            <div class="TabTitle">
                                <ul id="myTab1">
                                    <li>基本信息</li>
                                </ul>
                            </div>
                             <div id="myTab1_Content0" class="cntut">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">学校名称：</span>
                                            <asp:DropDownList ID="schGid" runat="server" Enabled="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">年级名称：</span>
                                            <asp:DropDownList ID="schGradeGid" runat="server" Enabled="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">班级名称：</span>
                                            <asp:DropDownList ID="schClassgcid" runat="server" Enabled="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">设备IMEI：</span>
                                            <asp:TextBox ID="MechIMEI" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="MechIMEI"
                                                ErrorMessage="*必填选项"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">设备名称：</span>
                                            <asp:TextBox ID="MechName" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="MechName"
                                                ErrorMessage="*必填选项"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">设备联系电话：</span>
                                            <asp:TextBox ID="MechPhone" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="MechPhone"
                                                ErrorMessage="*必填选项"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="cntre1">
                            <ul><li>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn_submit.gif" OnClick="ImageButton1_Click" /></li>
                            <li>
                                        <img alt="取消返回" src="images/btn_cancel.gif" style="cursor:pointer;" onclick="location.href='Mechanical_List.aspx'" /></li>
                                        </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Image ID="Image1" runat="server" Width="1px" Height="1px" />
    <asp:Image ID="Image2" runat="server" Width="1px" Height="1px" />
    </form>
<script type="text/javascript"> 
        var sgjson = '<%=GetSchoolAndGradeStr()%>';
    var gcjson = '<%=GetGradeClassStr()%>';
    var sgObject = {};
    var gcObject = {};
    var shid = <%=SchID%>;
    var gradeid =  <%=SchGradeId%>;
    var gclassid =  <%=schClassgcid%>;
</script>

</body>
</html>
