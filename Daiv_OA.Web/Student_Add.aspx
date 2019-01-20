<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Add.aspx.cs" Inherits="Daiv_OA.Web.Student_Add" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加学生</title><script type="text/javascript" language="javascript">                            window.onerror = function () { return true; };</script>
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
                        学生管理</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td><a href="Student_List.aspx">学生列表</a></td>
                            <td class="active">添加学生</td>
                            <td><a href="Student_Import.aspx">导入学生</a></td>
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
                                            <span class="bvjto styp">学生学号：</span>
                                            <asp:TextBox ID="Snumber" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Snumber"
                                                ErrorMessage="*必填选项"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">学生名称：</span>
                                            <asp:TextBox ID="Sname" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Sname"
                                                ErrorMessage="*必填选项"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">出生年月日：</span>
                                            <asp:TextBox ID="Sbirthday" class="Wdate" Width="90px"
                                                runat="server" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',readOnly:true,minDate:'1960-01-01',maxDate:'2019-01-01'})">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Sbirthday"
                                                ErrorMessage="*必填选项"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">家长电话号码：</span>
                                            <table id="contactTable"  class="ipt" width="280px;"  >
                                                <thead><tr><td>名称</td><td>电话号码</td><td>操作<input type="button" id="contactAdd" value="添加" /></td></tr></thead>
                                                <tr class="contactTr">
                                                    <td><input type="text" name="contactName" value="" maxlength="32" style="width:60px;" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5]/g,'')" onpaste="return false" oncontextmenu="return false;" /></td>
                                                    <td ><input type="text" name="contactPhone" value="" maxlength="11" style="width:120px;" onkeyup="value=value.replace(/[^0-9]/g,'')" onpaste="return false" oncontextmenu="return false;"/></td>
                                                    <td><input type="button" class="contactDelete" value="删除"  style="display:none;"  /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">家长电话号码2：</span>
                                            <asp:TextBox ID="Cphone2" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">家长电话号码3：</span>
                                            <asp:TextBox ID="Cphone3" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">家长电话号码4：</span>
                                            <asp:TextBox ID="Cphone4" runat="server" Width="220px" Height="24px" CssClass="ipt"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="cntre1">
                            <ul><li>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn_submit.gif" OnClick="ImageButton1_Click" /></li>
                            <li>
                                        <img alt="取消返回" src="images/btn_cancel.gif" style="cursor:pointer;" onclick="location.href='Student_List.aspx'" /></li>
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
    var shid = 0;
    var gradeid = 0;
    var gclassid = 0;

    $(function () {
        gcObject = $.parseJSON(gcjson);

        $('#contactTable').find('tbody tr:eq(0)').find('.contactDelete').click(removeTr);
        $('#contactAdd').click(function () {
            $newTr = $($('#contactTable').find('tbody tr:eq(0)')[0].outerHTML);
            $('#contactTable tbody').append($newTr);
            $newTr.find('input[name="contactName"]').val("");
            $newTr.find('input[name="contactPhone"]').val("");
            $newTr.find('.contactDelete').click(removeTr).show();
        });
    });

    function removeTr($delbtn) {
        $(this).parent().parent().remove();
    }
</script>

</body>
</html>

