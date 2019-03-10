<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeUpdateConfig_List.aspx.cs" Inherits="Daiv_OA.Web.GradeUpdateConfig_List" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>年级迁升配置</title><script type="text/javascript" language="javascript">                            window.onerror = function () { return true; };</script>
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
                        迁升配置</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td><a href="SchoolGrade_List.aspx?shid=<%=schId %>">年级列表</a></td>
                            <td><a href="SchoolGrade_Add.aspx?shid=<%=schId %>">添加年级</a></td>
                            <td class="active">年级提升配置</td>
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
                                            <span class="bvjto styp">年级提升配置：</span>
                                            <table id="contactTable"  class="ipt" width="650px;"  >
                                                <thead><tr><td>当前学校名称</td><td>当前年级</td><td>当前班级</td><td>提升年级</td><td>提升班级</td><td>操作<input type="button" id="contactAdd" value="添加" /></td></tr></thead>
                                                <tr class="contactTr">
                                                    <td>
                                                        <input name="configId" style="display:none" value="0" />
                                                        <select name="currschGid" ></select>
                                                    </td>
                                                    <td>
                                                        <select name="currGradeGid" ></select>
                                                    </td>
                                                    <td>
                                                        <select name="currClassGid" ></select>
                                                    </td>
                                                    <td >
                                                        <select name="furGradeGid" ></select>
                                                    </td>
                                                    <td >
                                                        <select name="furClassGid" ></select>
                                                    </td>
                                                    <td><input type="button" class="contactDelete" value="删除"  style="display:none;"  /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="cntre1">
                            <ul><li>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn_submit.gif" OnClientClick="return submitCheck();"  OnClick="ImageButton1_Click" /></li>
                            <li>
                                        <img alt="取消返回" src="images/btn_cancel.gif" style="cursor:pointer;" onclick="location.href='SchoolGrade_List.aspx?shid=<%=schId %>'" /></li>
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
    var sgjson = '<%=GetSchoolAndGradeStr(schId)%>';
    var gcjson = '<%=GetGradeClassStr()%>';
    var allconfig = '<%=GetAllConfigStr()%>';
    var sgObject = {};
    var gcObject = {};
    var shid = 0;
    var gradeid = 0;
    var gclassid = 0;

    $(function () {
        gcObject = $.parseJSON(gcjson);

        $('#contactTable').find('tbody tr:eq(0)').find('.contactDelete').click(removeTr);
        $('#contactAdd').click(function () {
            shid = 0;
            gradeid = 0;
            gclassid = 0;
            $newTr = $($('#contactTable').find('tbody tr:eq(0)')[0].outerHTML);
            $('#contactTable tbody').append($newTr);
            $newTr.find('select[name="currGradeGid"]').empty();
            $newTr.find('select[name="furGradeGid"]').empty();
            $newTr.find('select[name="currClassGid"]').empty();
            $newTr.find('select[name="furClassGid"]').empty();
            $newTr.find('input[name="configId"]').val("0");
            $newTr.find('.contactDelete').click(removeTr).show();
            $newTr.find('select[name="currschGid"]').on('change', schoolChange);

            $newTr.find('select[name="currGradeGid"]').on('change',curGradeChange);
            $newTr.find('select[name="furGradeGid"]').on('change', furGradeChange);

            $newTr.find('select[name="currschGid"]').change();
            $newTr.find('select[name="currGradeGid"]').change();
            $newTr.find('select[name="furGradeGid"]').change();
        });
        //填充学校下拉框
        if (sgjson !== undefined && sgjson !== null && sgjson != '') {
            var sgObject = $.parseJSON(sgjson);
            var selectStr = "";
            var $schGid = $('#contactTable').find('tbody tr:eq(0)').find('select[name="currschGid"]');
            var $currGradeGid = $('#contactTable').find('tbody tr:eq(0)').find('select[name="currGradeGid"]');
            var $furGradeGid = $('#contactTable').find('tbody tr:eq(0)').find('select[name="furGradeGid"]');
            var $currClassGid = $('#contactTable').find('tbody tr:eq(0)').find('select[name="currClassGid"]');
            var $furClassGid = $('#contactTable').find('tbody tr:eq(0)').find('select[name="furClassGid"]');
            var tempshid = 0;
            //console.log(sgObject);
            for (var i = 0; i < sgObject.length; i++) {
                if (shid == sgObject[i].shid) {
                    selectStr = "selected";
                    tempshid = shid;
                }
                $schGid.append('<option value="' + sgObject[i].shid + '" ' + selectStr + ' >' + sgObject[i].shname + '</option>');
                selectStr = "";
            }
            if (tempshid <= 0)
                tempshid = sgObject[0].shid;
            schGradeChangeByEle(tempshid, $currGradeGid);
            schGradeChangeByEle(tempshid, $furGradeGid);
            schClassChangeByEle(sgObject[0].grades[0].ID, $currClassGid);
            schClassChangeByEle(sgObject[0].grades[0].ID, $furClassGid);
        }
        //设置学校下拉框改变事件
        $('select[name="currschGid"]').on('change', schoolChange);
        $('select[name="currGradeGid"]').on('change', curGradeChange);
        $('select[name="furGradeGid"]').on('change', furGradeChange);

        //构造已有配置内容
        if (allconfig !== undefined && allconfig !== null && allconfig != '') {
            var configs = $.parseJSON(allconfig);
            for (var i = 0; i < configs.length; i++) {
                var curgid = getGradeIDByClassID(configs[i].CurrGradeID);
                var curshid = getSchoolIDByGradeID(curgid);
                if (parseInt(curshid) > 0) {
                    debugger;
                    var $schGid = $('#contactTable').find('tbody tr:eq('+i+')').find('select[name="currschGid"]');
                    var $currGradeGid = $('#contactTable').find('tbody tr:eq(' + i + ')').find('select[name="currGradeGid"]');
                    var $furGradeGid = $('#contactTable').find('tbody tr:eq(' + i + ')').find('select[name="furGradeGid"]');
                    var $currClassGid = $('#contactTable').find('tbody tr:eq(' + i + ')').find('select[name="currClassGid"]');
                    var $furClassGid = $('#contactTable').find('tbody tr:eq(' + i + ')').find('select[name="furClassGid"]');
                    var $inputId = $('#contactTable').find('tbody tr:eq(' + i + ')').find('input[name="configId"]');
                    $schGid.val(curshid);
                    $inputId.val(configs[i].ID);
                    gradeid = curgid;
                    //设置年级
                    schGradeChangeByEle(curshid, $currGradeGid);
                    //设置班级
                    gclassid = configs[i].CurrGradeID;
                    schClassChangeByEle(curgid, $currClassGid);

                    gradeid = getGradeIDByClassID(configs[i].UpGradeID);
                    schGradeChangeByEle(curshid, $furGradeGid);
                    gclassid = configs[i].UpGradeID;
                    schClassChangeByEle(gradeid, $furClassGid);
                    if (i < configs.length - 1) {
                        $('#contactAdd').click();
                    }
                }
            }
        }
    });

    function removeTr($delbtn) {
        $(this).parent().parent().remove();
    }

    //学校下来框更改方法
    function schoolChange() {
        var shid = $(this).val();
        var $currGradeGid = $(this).parent().parent().find('select[name="currGradeGid"]');
        var $furGradeGid = $(this).parent().parent().find('select[name="furGradeGid"]');
        schGradeChangeByEle(shid, $currGradeGid);
        schGradeChangeByEle(shid, $furGradeGid);
    }
    //年级下拉框更改方法
    function curGradeChange() {
        var gid = $(this).val();
        var $currClassGid = $(this).parent().parent().find('select[name="currClassGid"]');
        schClassChangeByEle(gid, $currClassGid);
    }

    function furGradeChange() {
        var gid = $(this).val();
        var $furClassGid = $(this).parent().parent().find('select[name="furClassGid"]');
        schClassChangeByEle(gid, $furClassGid);
    }

    //验证方法
    function submitCheck() {
        //alert("提交咯！不让你提交！");
        //检查是否选择相同的班级，提示重新选择
        var $curGArr = $('select[name="currGradeGid"]');
        var $furGArr = $('select[name="furGradeGid"]');
        var $curCArr = $('select[name="currClassGid"]');
        var $furCArr = $('select[name="furClassGid"]');
        if ($curGArr.length != $furGArr.length) {
            alert("班级信息有误，请联系管理员！")
            return false;
        }
        for (var i = 0; i < $curCArr.length; i++) {
            if ($($curCArr[i]).val() === undefined || $($curCArr[i]).val() === null || $($curCArr[i]).val() == "") {
                alert("存在当前班级没有选择");
                return false;
            }
        }

        for (var i = 0; i < $furCArr.length; i++) {
            if ($($furCArr[i]).val() === undefined || $($furCArr[i]).val() === null || $($furCArr[i]).val() == "") {
                alert("存在提升班级没有选择");
                return false;
            }
        }

        for (var i = 0; i < $curCArr.length; i++) {
            if ($($curCArr[i]).val() == $($furCArr[i]).val()) {
                alert("不能选择相同的班级，请重新选择！");
                return false;
            }
        }
        return true;
    }


</script>

</body>
</html>
