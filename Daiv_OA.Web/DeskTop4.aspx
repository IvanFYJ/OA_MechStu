<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeskTop4.aspx.cs" Inherits="Daiv_OA.Web.DeskTop4" %>
<%@ Register Src="webcontrol/WebDate.ascx" TagName="WebDate" TagPrefix="uc1" %>
<%@ Register Src="webcontrol/address.ascx" TagName="address" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的桌面</title>
     <script > window.onerror = function () { return true; }</script>
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<link href="css/style1.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.5.2.min.js" type="text/javascript"></script>

<%--<script type="text/javascript" src="_libs/jquery.jtemplates.js"></script>
<script type="text/javascript" src="_libs/jquery.timers.js"></script>--%>
<script type="text/javascript" src="js/global.js"></script>
<link href="style/global.css" rel="stylesheet" type="text/css" />

<%--
<script language="javascript" type="text/javascript">
    /*
    * 消息构造
    */
    window.onerror = function () { return true; };
    function Message(id, width, height, caption, title, message, target, action) {
        //init params
        this.id = id;
        this.title = title;
        this.caption = caption;
        this.message = message;
        this.target = target;
        this.action = action;
        this.width = width;
        this.height = height;
        //setting params
        this.timeout = 150;
        this.speed = 30;
        this.step = 1;
        //seting position 
        this.right = screen.width - 1;
        this.tom = screen.height;
        this.left = this.right - this.width;
        this.top = this.tom - this.height;
        this.timer = 0;
        this.pause = false;
        this.close = false;
    }
    /*
    * 隐藏消息方法
    */
    Message.prototype.hide = function () {
        if (this.onunload()) {
            var offset = this.height > this.tom - this.top ? this.height : this.tom - this.top;
            var me = this;
            if (this.timer > 0) {
                window.clearInterval(me.timer);
            }

            var fun = function () {
                if (me.pause == false || me.close) {
                    var x = me.left;
                    var y = 0;
                    var width = me.width;
                    var height = 0;
                    if (me.offset > 0) {
                        height = me.offset;
                    }
                    y = me.tom - height;
                    if (y >= me.tom) {
                        window.clearInterval(me.timer);
                        me.Pop.hide();
                    } else {
                        me.offset = me.offset - me.step; //等于0是马上消失,否则为逐渐消失
                    }
                    me.Pop.show(x, y, width, height);
                }
            } //end fun
            this.timer = window.setInterval(fun, this.speed)
        } //end if 
    }
    Message.prototype.onunload = function () {
        return true;
    }
//    Message.prototype.oncommand = function () {
//        OA.Popup.show(unescape(this.action), -1, -1, true);
//        this.hide();
//    }
    Message.prototype.show = function () {
        var oPopup = window.createPopup(); //IE5.5+
        this.Pop = oPopup;

        var w = this.width;
        var h = this.height;
        var str = "<div style='BORDER-RIGHT: #455690 1px solid; BORDER-TOP: #a6b4cf 1px solid; Z-INDEX: 99999; LEFT: 0px; BORDER-LEFT: #a6b4cf 1px solid; WIDTH: " + w + "px; border-bottom: #455690 1px solid; POSITION: absolute; TOP: 0px; HEIGHT: " + h + "px; BACKGROUND-COLOR: #c9d3f3'>"
        str += "<table style='BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid' cellSpacing=0 cellPadding=0 width='100%' bgColor=#cfdef4 border=0>"
        str += "<tr>"
        str += "<td style='background-image:url(/images/message1.jpg); FONT-SIZE: 12px;COLOR: #0f2c8c ;width:30;height:24'></td>"
        str += "<td style='PADDING-LEFT: 4px; FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #1f336b; PADDING-TOP: 4px' vAlign=center width='100%'>" + this.caption + "</td>"
        str += "<td style='PADDING-RIGHT: 2px; PADDING-TOP: 2px' vAlign=center align=right width=19>"
        str += "<span title=关闭 style='FONT-WEIGHT: bold; FONT-SIZE: 12px; CURSOR: hand; COLOR: red; MARGIN-RIGHT: 4px' id='btSysClose' >×</span></td>"
        str += "</tr>"
        str += "<tr>"
        str += "<td style='PADDING-RIGHT: 1px;PADDING- TOM: 1px' colSpan=3 height=" + (h - 28) + ">"
        str += "<div style='BORDER-RIGHT: #b9c9ef 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #728eb8 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px; PADDING- TOM: 8px; BORDER-LEFT: #728eb8 1px solid; WIDTH: 100%; COLOR: #1f336b; PADDING-TOP: 8px; border-bottom: #b9c9ef 1px solid; HEIGHT: 100%'>" + this.title + "<br><br>"
        str += "<div style='WORD-BREAK: break-all' align=left><a href='javascript:void(0)' hidefocus=false id='btCommand'><font color=#ff0000>" + this.message + "</font></a></div>"
        str += "</div>"
        str += "</td>"
        str += "</tr>"
        str += "</table>"
        str += "</div>"


        oPopup.document.body.innerHTML = str;

        this.offset = 0;
        var me = this;

        oPopup.document.body.onmouseover = function () { me.pause = true; }
        oPopup.document.body.onmouseout = function () { me.pause = false; }
        var fun = function () {
            var x = me.right;
            var y = 0;
            var width = me.width;
            var height = me.height;

            if (me.offset > me.height) {
                height = me.height;
            } else {
                height = me.offset;
            }

            y = me.tom - me.offset;
            if (y <= me.top)//让消息框消失
            {
                me.timeout--;
                if (me.timeout == 0)//当消息框在页面中显示的时间到期时，将消息框隐藏
                {
                    //alert(me.timer);
                    window.clearInterval(me.timer);
                    me.hide();
                }
            } else {
                me.offset = me.offset + me.step;
            }
            me.Pop.show(x, y, width, height);

        } //end fun

        this.timer = window.setInterval(fun, this.speed)
        var btClose = oPopup.document.getElementById("btSysClose");

        btClose.onclick = function () {
            me.close = true;
            me.hide();
        }
        var btCommand = oPopup.document.getElementById("btCommand");
        btCommand.onclick = function () {
            me.oncommand();
        }
    } //end show

    Message.prototype.speed = function (s) {
        var t = 20;
        try {
            t = praseInt(s);
        } catch (e) { }
        this.speed = t;
    }
    Message.prototype.step = function (s) {
        var t = 1;
        try {
            t = praseInt(s);
        } catch (e) { }
        this.step = t;
    }

    Message.prototype.rect = function (left, right, top, tom) {
        try {
            this.left = left != null ? left : this.right - this.width;
            this.right = right != null ? right : this.left + this.width;
            this.tom = tom != null ? (tom > screen.height ? screen.height : tom) : screen.height;
            this.top = top != null ? top : this.tom - this.height;
        } catch (e) { }
    }

    function initMessage(title, content, action) {
        var count = 1; //initMessage
        if (count <= 1) {
            var msg = new Message(count, 200, 120, "Daiv_OA平台", title, content, "content3", action);
            msg.rect(null, null, null, screen.availHeight); //screen 是任务栏，availHeight代表当前任务栏的高度
            msg.speed = 10;
            msg.step = 5;
            msg.show();
        } else if (count > 1) {
            //        for(i=1;i<=count;i++){
            //            var msg = new Message(i,200,120,"将博OA平台",title,content,"content3",action);
            //            var pophieght;
            //            if(i==1){
            //                popheight=screen.availHeight;
            //            }else{
            //                popheight=popheight-120;
            //            }
            //            msg.rect(null,null,null,popheight); //screen 是任务栏，availHeight代表当前任务栏的高度
            //            msg.speed = 10;
            //            msg.step = 5;
            //            window.setTimeout('Ktime()',10000);
            //            msg.show();
            //        }//end for
        } //end if
    } //end init
    function Ktime() {
        window.setTimeout('Ktime()', 100000);
    }
    </script>--%>

</head>
<body>
    <form runat="server" id="fm1">
   
    
    <table border="0" cellpadding="0" cellspacing="10" style="width: 100%; " align="center">
        <tr>
            <td valign="top" colspan="2">
                <uc1:WebDate ID="WebDate1" runat="server" />
            </td>
        </tr>
        <tr  style="display:none;" >
            <td width="50%" valign="top">
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
                                            <td style="width: 120px;" align="center">
                                                发布时间
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                            <a href="javascript:void(0);" onclick="top.OA.Popup.show('My_Placard_Show.aspx?id=<%#Eval("Pid") %>',-1,-1,true)">
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
                                    <li>最新任务</li>
                                </ul>
                            </div>
                            <asp:Repeater ID="Repeater_Work" runat="server">
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                        <tr class="dataTableHead" align="center">
                                            <td width="*" align="center">
                                                工作任务
                                            </td>
                                            <td width="217" align="center">
                                                任务时间进度
                                            </td>
                                             <td width="70" align="center">
                                                截止日期
                                            </td>
                                           
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                            <a href="javascript:void(0);" onclick="top.OA.Popup.show('My_Work_Show.aspx?id=<%#Eval("Tlid") %>',1050,700,true)">
                                                <%# Daiv_OA.Utils.Strings.Left(Eval("Tasktitle").ToString(),14) %></a>
                                        </td>
                                        <td width="216" align="left">
                                            <%#strimg(Eval("sumtime"), Eval("progresstime"))%>
                                        </td >
                                        <td align="center">
                                        <%#Eval("Plantime","{0:yyyy-MM-dd}")%>
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
        </tr>
        <tr  style="display:none;" >
            <td valign="top" colspan="2">
                <uc2:address ID="address1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
