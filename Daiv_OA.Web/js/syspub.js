/*
* 文件名：syspub.js
* 作者：许浩
* 创建日期：2011.3.1
* 描述：系统公共脚本
*/

//打开层窗口
function OpenDivDialog(dTitle, dSrc, dWidth, dHeight) {
    parent.OpenDivDialog(dTitle, dSrc, dWidth, dHeight);
}
//关闭层窗口
function CloseDivDialog() {
    parent.$("#dataAdd").dialog("close");
}
//打开Open窗口
function OpenDialog(dSrc, dName, dWidth, dHeight, dScroll, dResizable) {
    var iWidth = dWidth;
    var iHeight = dHeight;
    var iTop = (window.screen.availHeight - 30 - iHeight) / 2;
    var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;
    window.open(dSrc, dName, 'left=' + iLeft + ',top=' + iTop + ',width=' + iWidth + ',height=' + iHeight + ',scrollbars=' + dScroll + ',resizable=' + dResizable);
}
//关闭Open窗口
function CloseOpenDialog() {
    window.close();
}
//打开模态窗口
function OpenModelDialog(dSrc, dWidth, dHeight) {
    return window.showModalDialog(dSrc, '', 'dialogHeight:' + dHeight + 'px;dialogWidth:' + dWidth + 'px;help:0;');
}
//关闭模态窗口
function CloseModelDialog() {
    window.close();
}
//显示查询窗口
function ShowQueryBox() {
    document.getElementById('divQuery').style.display = 'block';
}
//隐藏查询窗口
function HiddenQueryBox() {
    document.getElementById('divQuery').style.display = 'none';
}

//打开页面-main
function OpenPageToMain(pSrc) {
    var mainFrame = parent.frames('mainFrame');
    if (mainFrame) {
        mainFrame.location.href = pSrc;
    }
}
//注销登录
function Logout() {
    if (confirm('确定要注销登录吗？')) {
        parent.location.href = '../Logout.aspx';
    }
}
//接收HTTP传值
function RequestQueryString(strName) {
    var strHref = window.document.location.href;
    var intPos = strHref.indexOf("?");
    var strRight = strHref.substr(intPos + 1);

    var arrTmp = strRight.split("&");
    for (var i = 0; i < arrTmp.length; i++) {
        var arrTemp = arrTmp[i].split("=");

        if (arrTemp[0].toUpperCase() == strName.toUpperCase()) return arrTemp[1];
    }
    return "";
}
//去空格 调用 value.trim();
function Trim(strTrim) {
    return strTrim.replace(/(^\s*)|(\s*$)/g, '');
}
//给String类型增加一个div方法,调用起来更加方便.
//String.prototype.trim = function () {
//    return Trim(this);
//}
//验证数字
function IsNum(strNum) {
    return !isNaN(strNum);
}
//批量验证 strIds：txtID#1#0#codeMore()|txtName#1#0|txtWidth#1#1
function CheckControlValue(strIds) {
    //参数说明：参数1-控件ID # 参数2-是否获得焦点 # 参数3-是否验证数字 # 验证为空后调用的方法
    var arrControls = strIds.split('|');
    var arrInfo;
    if (arrControls.length > 0) {
        for (var i = 0; i < arrControls.length; i++) {
            arrInfo = arrControls[i].split('#');
            if (arrInfo.length > 0) {
                if (document.getElementById(arrInfo[0])) {
                    //验证空
                    if (document.getElementById(arrInfo[0]).value.trim().length == 0) {
                        alert(document.getElementById(arrInfo[0]).title + '不可以为空！');
                        //是否获得焦点
                        if (arrInfo[1] == '1') { document.getElementById(arrInfo[0]).focus(); }
                        //是否存在调用方法
                        if (arrInfo[3] != '') {
                            eval(arrInfo[3]);
                        }
                        return false;
                    }
                    //验证数字
                    if (arrInfo[2] == '1') {
                        if (IsNum(document.getElementById(arrInfo[0]).value)) {
                            alert(document.getElementById(arrInfo[0]).title + '格式错误，必须为数字！');
                            //是否获得焦点
                            if (arrInfo[1] == '1') { document.getElementById(arrInfo[0]).select(); }
                            return false;
                        }
                    }
                    //验证邮件/手机...
                }
            }
        }
    }
}
//乘法函数，用来得到精确的乘法结果
//说明：javascript的乘法结果会有误差，在两个浮点数相乘的时候会比较明显。这个函数返回较为精确的乘法结果。   
//调用：AccMul(arg1,arg2)
//返回值：arg1乘以 arg2的精确结果
function AccMul(arg1, arg2) {
    var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
    try { m += s1.split(".")[1].length } catch (e) { }
    try { m += s2.split(".")[1].length } catch (e) { }
    return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m);
}

//树的选择事件 nodeId-节点ID;recordId-记录ID;controlId-存储控件ID
var oldNode = null;
function NodeSelect(nodeId, recordId, controlId) {
    var aObj = document.getElementById(nodeId);
    aObj.style.backgroundColor = '#EEEEEE';
    aObj.style.fontWeight = 'bold';
    if (controlId) {
        document.getElementById(controlId).value = recordId;
    }
    if (oldNode != null && aObj != oldNode) {
        oldNode.style.backgroundColor = '#FFFFFF';
        oldNode.style.fontWeight = 'normal';
    }
    oldNode = aObj;
}
//对象内CheckBox 全选/全消
function CheckBoxSelect(tagName, check) {
    if (document.getElementById(tagName) != null) {
        chs = document.getElementById(tagName).getElementsByTagName("INPUT");
        n = 0;
        for (i = 0; i < chs.length; i++) {
            if (!chs[i].disabled) {
                chs[i].checked = check;
            }
        }
    }
    else {
        alert('暂无数据');
    }
}
//判断对象内CheckBox 是否选中
function CheckBoxIsSelect(tagName) {
    if (document.getElementById(tagName) != null) {
        chs = document.getElementById(tagName).getElementsByTagName("INPUT");
        n = 0;
        for (i = 0; i < chs.length; i++) {
            if (chs[i].checked) {
                n++;
                break;
            }
        }
        if (n > 0) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}
//页面跳转是否有效
function CheckGoValue() {
    //判断页码是否输入
    if (document.getElementById("txtGoValue").value.length == 0 || document.getElementById("txtGoValue").value == "0") {
        alert('请输入页码！');
        document.getElementById("txtGoValue").focus();
        return false;
    }
}
//删除确认
function DelConfirm() {
    if (!confirm('确定要删除选中的记录吗？')) {
        return false;
    } else {
        return true;
    }
}
//检查字数长度 maxLength-最大长度;controlId-控件ID
function CheckFontLength(maxLength, controlID) {
    var objControl = document.getElementById(controlID);
    if (objControl.value.length > maxLength) {
        // 超过限制的字数了就将 文本框中的内容按规定的字数 截取
        objControl.value = objControl.value.substring(0, maxLength);
        return false;
    }
    else {
        var curr = maxLength - objControl.value.length;
        document.getElementById("sFontLength").innerHTML = curr.toString();
        return true;
    }
}
//刷新主页面
function ReloadMainFrame() {
    var mainWin = parent.frames('mainFrame');
    if (mainWin.document.getElementById('btnReload')) {
        mainWin.document.getElementById('btnReload').click();
    }
}
//验证网址
function IsURL(urlString) {
    regExp = /(http[s]?|ftp):\/\/[^\/\.]+?\..+\w$/i;
    return urlString.match(regExp);
}
//验证邮箱
function IsEmail(emailString) {
    var regExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regExp.test(emailString);
}
//验证邮编
function IsPost(postString) {
    if (postString.length != 6) {
        return false;
    } else {
        var regExp = /^[0-9]+$/;
        return regExp.test(postString);
    }
}
//验证手机
function IsMobile(urlString) {
    regExp = /^((\(\d{3}\))|(\d{3}\-))?13[0-9]\d{8}|15[0-9]\d{8}|18[0-9]\d{8}/;
    return urlString.match(regExp);
}
//验证电话号码
function IsTele(urlString) {
    regExp = /^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$/;
    return urlString.match(regExp);
}
//验证特殊电话号码
function IsTelePhone(urlString) {
    regExp = /^[0-9]*[1-9][0-9]*$/;
    return urlString.match(regExp);
}
//实现treeview中选中父节点，子节点也选中,如果子节点全部选中，自动选中父节点
function OnTreeNodeChecked() {
    var ele = event.srcElement;
    if (ele.type == 'checkbox') {
        var childrenDivID = ele.id.replace('CheckBox', 'Nodes');
        var div = document.getElementById(childrenDivID);
        if (div != null) {
            var checkBoxs = div.getElementsByTagName('INPUT');
            for (var i = 0; i < checkBoxs.length; i++) {
                if (checkBoxs[i].type == 'checkbox')
                    checkBoxs[i].checked = ele.checked;
            }
        }
        OnTreeNodeChildChecked(ele);

    }
}

function OnTreeNodeChildChecked(ele) {
    //递归处理
    if (ele == null) {
        ele = event.srcElement;
    }
    var parentDiv = ele.parentElement;

    var parentChkBox = document.getElementById(parentDiv.id.replace('Nodes', 'CheckBox'));
    if (parentChkBox != null) {
        var ChildsChkAll = true;
        var Boxs = parentDiv.getElementsByTagName('INPUT');
        for (var i = 0; i < Boxs.length; i++) {
            if (Boxs[i].type == 'checkbox' && Boxs[i].checked == false) {
                ChildsChkAll = false;
            }
        }
        parentChkBox.checked = ChildsChkAll;
        OnTreeNodeChildChecked(parentChkBox);
    }
}

//鼠标滑过行变色效果
var oldBgColor;
function BgMouseOver(obj) {
    oldBgColor = obj.style.backgroundColor;
    obj.style.backgroundColor = '#C7E4FC';
}

//鼠标滑过行变色效果
function BgMouseOut(obj) {
    obj.style.backgroundColor = oldBgColor;
}

//显示进度条
function ToggleVisibility(id, type) {
    el = document.getElementById(id);
    if (el.style) {
        if (type == 'on') {
            el.style.display = 'block';
        } else {
            el.style.display = 'none';
        }
    } else {
        if (type == 'on') {
            el.display = 'block';
        } else {
            el.display = 'none';
        }
    }
}
//发送短消息
function SendMsg(scode, sname) {
    OpenDialog('/OA_Modules/UserOffice/MsgAdd.aspx?mode=open&scode=' + scode + '&sname=' + escape(sname), 'sendmsg', 550, 500, 'no', 'no');
}

//判断两个字符串日期的大小
function compareDate(Date1, Date2) {
    var Month1 = Date1.substring(5, Date1.lastIndexOf("-"));
    var Day1 = Date1.substring(Date1.length, Date1.lastIndexOf("-") + 1);
    var Year1 = Date1.substring(0, Date1.indexOf("-"));

    var Month2 = Date2.substring(5, Date2.lastIndexOf("-"));
    var Day2 = Date2.substring(Date2.length, Date2.lastIndexOf("-") + 1);
    var Year2 = Date2.substring(0, Date2.indexOf("-"));

    if (Date.parse(Month1 + "/" + Day1 + "/" + Year1) > Date.parse(Month2 + "/" + Day2 + "/" + Year2)) {
        return true;
    }
    else {
        return false;
    }
}

//字符串转换成日期类型
function strToDate(str) {
    var arrays = new Array();
    arrays = str.split('-');
    var newDate = new Date(arrays[0], arrays[1], arrays[2]);
    return newDate;
}

//详细列表-行添加层-打开
function InvoiceOpenRowAdd(dSrc, dWidth, dHeight) {
    //获得承载对象
    var objDivAdd = document.getElementById('divAdd');
    if (objDivAdd) {
        //是否已创建页承载对象
        var objAddContent = document.getElementById('divAddContent');
        if (objAddContent == null) {
            //创建层/对象
            var divOverlay = document.createElement('div');
            divOverlay.setAttribute('id', 'divOverlay');
            objDivAdd.appendChild(divOverlay);
            var divAddContent = document.createElement('div');
            divAddContent.setAttribute('id', 'divAddContent');
            divAddContent.innerHTML = '<iframe src="' + dSrc + '" frameborder="0" scrolling="no" class="frameRowAdd" style="width:' + dWidth + 'px;height:' + dHeight + 'px;"></iframe>';
            objDivAdd.appendChild(divAddContent);
        }
        //显示层
        document.getElementById('divOverlay').style.display = 'block';
        document.getElementById('divAddContent').style.display = 'block';
    }
}
//详细列表-行添加层-关闭
function InvoiceCloseRowAdd() {
    //判断层是否存在,如果存在:隐藏层
    var divOverlay = parent.document.getElementById('divOverlay');
    if (divOverlay) { divOverlay.style.display = 'none'; }
    var divAddContent = parent.document.getElementById('divAddContent');
    if (divAddContent) { divAddContent.style.display = 'none'; }
}
//产品编码
function MNumberMore() {
    OpenDialog('/MRP_Modules/BOM/WLNumberList1.aspx?value=hidMNumber&nameid=txtMNumber', '产品编码', 480, 450, 'no', 'no');
}
//需求类型
function DemandType() {
    OpenDialog('/MRP_Modules/MRP/DemandTypeList.aspx?value=hidDemandType&nameid=txtDemandType', '需求类型', 280, 330, 'no', 'no');
}
//生产部门more
function scbmMore() {
    OpenDialog('../../dialog/DeptMore.aspx?codeid=hidDeptCode&nameid=txtDeptCode', '生产部门', 470, 520, 'no', 'no');
}
//物料编码
function WLNumberMore() {
    OpenDialog('/MRP_Modules/BOM/WLNumberList.aspx?value=hidWLNumber&nameid=txtWLNumber', '物料代码', 400, 480, 'no', 'no');
}

//验证字符串是否为空，是否是空格
function IfNull(strings) {
    //var strs = /(^\s*|\s*$)/;   
    var str = strings;
    if (str != null) {
        str = str.replace(/(^\s*)|(\s*$)/g, "");
        str = str.replace(/(^　*)|(　*$)/g, "");
        if (str == '') {
            return false;
        }
        return true;
    } else {
        return false;
    }
}

//获取url参数
function QueryString() {
    var name, value, i;
    var str = location.href;
    var num = str.indexOf("?");
    str = str.substr(num + 1);
    var arrtmp = str.split("&");
    for (i = 0; i < arrtmp.length; i++) {
        num = arrtmp[i].indexOf("=");
        if (num > 0) {
            name = arrtmp[i].substring(0, num);
            value = arrtmp[i].substr(num + 1);
            this[name] = value;
        }
    }
}
//调用:
//var Request=new QueryString();
//ID=Request["ID"]
//str=Request["str"]


//去除空格元素
function Delspaceele(elem) {
    var elemchild = elem.childNodes; //获取所有子元素
    for (var i = 0; i < elemchild.length; i++) {
        //如果是文本节点，并且内容只包含空格则删除该节点
        if (elemchild[i].nodeName == "#text" && (!/\S/.test(elemchild[i].innerText) || !/\S/.test(elemchild[i].textContent))) {
            elem.removeChild(elemchild[i]); //如果该元素为空格则删除
        }
    }
}

// 验证文本框内容是否正确
function IsRight(obj) {
    return obj.value.indexOf('\'')
}