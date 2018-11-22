/*
本文件不能单独运行，需要引用jquery-1.2.6.js
*/
(function (jQuery){
	this.layer = {'width' : 200, 'height': 24};
	this.title = '1';
	this.sfuc = null;
	this.time = 4000;
	this.anims = {'type' : 'slide', 'speed' : 1000};
	this.inits = function(title, text){
		if($("#PopTips").is("div")){ return; }
		var sBody = '\
			<div id="PopTips" style="z-index:100;width:90%;margin:0px auto;text-align:center;height:'+(this.layer.height+2)+'px;position:absolute;display:none; top:2px;">\
				<div id="tips_Content" style="margin:0px auto;font-size:12px;width:'+(this.layer.width)+'px;height:'+(this.layer.height)+'px;border:#000000 1px solid;color:#000000;background:#ffffcc;text-align:left;">\
					<span style="background:url(/style/tips/' + this.title + '.gif) 1px no-repeat; text-indent:25px;float:left;height:16px;line-height:16px;padding-top:6px;">'+text+'</span>\
					<span id="PopTips_Close" style="float:right; padding-right:2px;width:16px;line-height:auto;color:red;font-size:12px;font-weight:bold;text-align:center;cursor:pointer;overflow:hidden;padding-top:6px;">×</span>\
				</div>\
			</div>\
		';
		$(document.body).prepend(sBody);

	};
	this.show = function(title, text, time){
		if($("#PopTips").is("div")){ return; }
		if(title=='0' || !title)title = this.title;
		this.inits(title, text);
		if(time)this.time = time;
		switch(this.anims.type){
			case 'slide':$("#PopTips").slideDown(this.anims.speed);break;
			case 'fade':$("#PopTips").fadeIn(this.anims.speed);break;
			case 'show':$("#PopTips").show(this.anims.speed);break;
			default:$("#PopTips").slideDown(this.anims.speed);break;
		}
		$("#PopTips_Close").click(function(){		
			setTimeout('this.close()', 1);
		});
		this.rmtips(this.time);
	};
	this.lays = function(width, height){
		if($("#PopTips").is("div")){ return; }
		if(width!=0 && width)this.layer.width = width;
		if(height!=0 && height)this.layer.height = height;
	}
	this.anim = function(type,speed){
		if($("#PopTips").is("div")){ return; }
		if(type!=0 && type)this.anims.type = type;
		if(speed!=0 && speed){
			switch(speed){
				case 'slow' : this.anims.speed = 1000;break;
				case 'fast' : this.anims.speed = 200;break;
				case 'normal' : this.anims.speed = 400;break;
				default: this.anims.speed = speed;
			}			
		}
	}
	this.rmtips = function(time){
		setTimeout('this.close()', time);
	};
	this.close = function(){
		if($("#PopTips").is("div")){
			switch(this.anims.type){
				case 'slide': $("#PopTips").slideUp(this.anims.speed);break;
				case 'fade': $("#PopTips").fadeOut(this.anims.speed);break;
				case 'show': $("#PopTips").hide(this.anims.speed);break;
				default: $("#PopTips").slideUp(this.anims.speed);break;
			};
			setTimeout('$("#PopTips").remove();', this.anims.speed);
			if(this.sfuc != null) eval(this.sfuc);
			this.original();
		}
	};
	this.original = function(){	
		this.layer = {'width' : 200, 'height': 24};
		this.title = '1';
		this.sfuc = null;
		this.time = 4000;
		this.anims = {'type' : 'slide', 'speed' : 1000};
	};
	this.doafter = function(_sFuc){//关闭后的操作
		this.sfuc = _sFuc;
	};
	jQuery.tips = this;
	return jQuery;
})(jQuery);
var jcms$$DialogUrl		= "/style/dialog/";
/*------------------------------------------------------------------*/
function $$(el)
{
	if(typeof el=='string')
		return document.getElementById(el);
	else if(typeof el=='object')
		return el;
}
var OA=new Object();
OA.Cookie={//
	set:function(name,value,expires,path,domain){
		if(typeof expires=="undefined"){
			expires=new Date(new Date().getTime()+24*3600*100);
		}
		document.cookie=name+"="+jcms$$UrlEncode(value)+((expires)?"; expires="+expires.toGMTString():"")+((path)?"; path="+path:"; path=/")+((domain!=null && domain.length>0)?";domain="+domain:"");
	},
	get:function(name, subname){
		var re = new RegExp((subname ? name + "=(.*?&)*?" + subname + "=(.*?)(&|;)" : name + "=([^;]*)(;|$)"), "i");
		return jcms$$UrlDecode(re.test(document.cookie) ? (subname ? RegExp["$2"] : RegExp["$1"]) : ""); 
	}, 
	clear:function(name,path,domain){
		if(this.get(name)){
			document.cookie=name+"="+((path)?"; path="+path:"; path=/")+((domain)?"; domain="+domain:"")+";expires=Fri, 02-Jan-1970 00:00:00 GMT";
		}
	}
};
//追加/删除事件
OA.Event={
	add:function(obj, evType, fn){
		if (obj.addEventListener){obj.addEventListener(evType, fn, false);return true;}
		else if (obj.attachEvent){var r = obj.attachEvent("on"+evType, fn);return r;}
		else {return false;}
	},
	remove:function(obj, evType, fn, useCapture){
		if (obj.removeEventListener){obj.removeEventListener(evType, fn, useCapture);return true;}
		else if (obj.detachEvent){var r = obj.detachEvent("on"+evType, fn);return r;}
		else {alert("Handler could not be removed");}
	}
};
//追加onload事件
OA.addOnloadEvent=function(fnc) {
	if ( typeof window.addEventListener != "undefined" )
		window.addEventListener( "load", fnc, false );
	else if ( typeof window.attachEvent != "undefined" )
	{
		window.attachEvent( "onload", fnc );
	}
	else
	{
		if ( window.onload != null )
		{
			var oldOnload = window.onload;
			window.onload = function (e) {
				oldOnload(e);
				window[fnc]();
			};
		} else
			window.onload = fnc;
	}
};
OA.isFunction=function(variable) {
	return typeof variable == 'function' ? true : false;
};
OA.isUndefined=function(variable) {
	return typeof variable == 'undefined' ? true : false;
};
OA.Length=function(variable) {
	var len = 0;
	var val = variable;
	for (var i = 0; i < val.length; i++) 
	{
		if (val.charCodeAt(i) >= 0x4e00 && val.charCodeAt(i) <= 0x9fa5){ 
			len += 2;
		}else {
			len++;
		}
	}
	return len;
};
OA.Eval=function(data) {
	OA.Loading.hide();
	try {
		eval(data);
	}
	catch(e) {
		alert(data);	
	}
};
/////////////////////////////
//弹出消息框
/////////////////////////////
OA.Message=function(errstr, success, returnFunc){
	new jcms$$Dialog().reset();
	var MSG = $.tips;
	MSG.lays(200, 24);
	MSG.anim('fade', 'slow');
	if(returnFunc) MSG.doafter(returnFunc);
	MSG.show(success, errstr, 3000);
};
/////////////////////////////
//弹出提示框
/////////////////////////////
OA.Alert=function(errstr, success, returnFunc){
	var oDialog = new jcms$$Dialog('2', '', 360, 180, success, true);
	oDialog.init();
	oDialog.event(errstr,'');
	if (returnFunc == null)
		oDialog.button('dialogSubmit', '');
	else
		oDialog.button('dialogSubmit', returnFunc);
};
/////////////////////////////
//弹出确认框
//例如:
//1、OA.Confirm("是否操作", act, null) //函数不加()
//2、OA.Confirm("是否操作", "alert('yes')", "alert('no')")
/////////////////////////////
OA.Confirm=function(errstr, returnSubmitFunc, returnCancelFunc)
{
	var oDialog = new jcms$$Dialog('2', '', 360, 180, null, true);
	oDialog.init();
	oDialog.event(errstr,'');
	oDialog.button('dialogSubmit', returnSubmitFunc);
	if (returnCancelFunc == null)
		oDialog.button('dialogCancel', '');
	else
		oDialog.button('dialogCancel', returnCancelFunc);
};
/////////////////////////////
//弹出模拟窗口
/////////////////////////////
OA.Popup={
	show:function(url, width, height, showCloseBox, showTitle, returnFunc)
	{
		new jcms$$Dialog().reset();
		if(showTitle==null) showTitle="&nbsp;";
		var oDialog = new jcms$$Dialog('2', showTitle, width, height, null, showCloseBox);
		if (url.indexOf("?") == -1)
			oDialog.open(url+"?windowCode="+(new Date().getTime()), returnFunc, "auto");
		else
			oDialog.open(url+"&windowCode="+(new Date().getTime()), returnFunc, "auto");
	},
	hide:function(callReturnFunc){
		new jcms$$Dialog().reset(callReturnFunc);
	}
};
/////////////////////////////
//弹出加载层
/////////////////////////////
OA.Loading={
	show:function(msgstr, width, height)
	{
		if(width==null) width=280;
		if(height==null) height=100;
		var oDialog = new jcms$$Dialog('0', '友情提示', width, height, null, false);
		oDialog.init(true);
		oDialog.html("<div style='text-align:center;padding-top:20px;'>"+msgstr+"<br /><br /><img src='" + jcms$$DialogUrl + "loading.gif' align='absmiddle'></div>");
	},
	hide:function(callReturnFunc){
		new jcms$$Dialog().reset(callReturnFunc);
	}
};
OA.Event.add(window,"load",jcms$$OperatorPlus);
OA.Event.add(window,"scroll",jcms$$OperatorPlus);
OA.Event.add(window,"resize",jcms$$OperatorPlus);

////////////////////////////////////////////////////////////////////////////////////////////
//标题栏跑马灯
////////////////////////////////////////////////////////////////////////////////////////////
var jcms$$ScrollTitle$$Oldtitle		= top.document.title;
var jcms$$ScrollTitle$$i		= 0;
var jcms$$ScrollTitle$$Speed		= 200;
var jcms$$ScrollTitle$$Timer		= function(message){
	if(jcms$$ScrollTitle$$i == message.length)
	{
		top.document.title = jcms$$ScrollTitle$$Oldtitle;
		jcms$$ScrollTitle$$i = 0;
		return;
	}
	else{
		top.document.title = message.substring(jcms$$ScrollTitle$$i);
		jcms$$ScrollTitle$$i++;
		setTimeout("jcms$$ScrollTitle$$Timer('"+message+"')",jcms$$ScrollTitle$$Speed);
	}
}

////////////////////////////////////////////////////////////////////////////////////////////

var jcms$$HideSelects			= false;
var jcms$$DialogIsShown			= false;
var jcms$$WindowMask			= null;
////////////////////////////////////////////////////////////////////////////////////////////
//以下为弹出窗口的类
////////////////////////////////////////////////////////////////////////////////////////////
function jcms$$Dialog(styletype, title, width, height, iswhat, showCloseBox){
	//半透明边框宽度
	var shadowBorder h=0;
	var oWidth = width;
	var oHeight = height;
	if(oWidth<0 || oWidth>jcms$$GetViewportWidth()-15)
	{
		oWidth=jcms$$GetViewportWidth()-15;
		shadowBorder h = 0;
	}
	if(oHeight<0 || oHeight>jcms$$GetViewportHeight()-44)
	{
		oHeight=jcms$$GetViewportHeight()-44;
		shadowBorder h = 0;
	}
	var sTitle = "友情提示";
	if (iswhat == "0")
		sTitle = "错误提示";
	else if (iswhat == "1")
		sTitle = "成功提示";
	else
		if (title!='') sTitle = title;
	var src = "";
	var path = jcms$$DialogUrl + styletype + "/";
	var gReturnFunc;
	var gReturnVal = null;
	var sButtonFunc = '<input id="dialogSubmit" class="dialogSubmit' + styletype + '" type="button" value="确 认" onclick="new jcms$$Dialog().reset();" /> <input id="dialogCancel" class="dialogCancel' + styletype + '" type="button" value="取 消" onclick="new jcms$$Dialog().reset();" />';
	var sClose = '';
	if (showCloseBox == null || showCloseBox == true)
		sClose = '<img alt="关闭" style="cursor:pointer;" id="dialogBoxClose" onclick="new jcms$$Dialog().reset();" src="' + path + 'dialogCloseOut.gif" border="0" onmouseover="this.src=\'' + path + 'dialogCloseOver.gif\';" onmouseout="this.src=\'' + path + 'dialogCloseOut.gif\';" align="absmiddle" />';
	var sSuccess = '';
	if (iswhat != null)
		sSuccess = '<td width="80" align="center" valign="middle"><img id="dialogBoxFace" class="dialogBoxFace' + styletype + '" src="' + path + iswhat + '.gif" valign="absmiddle" /></td>';
	else
		sSuccess = '<td width="80" align="center" valign="middle"><img id="dialogBoxFace" class="dialogBoxFace' + styletype + '" src="' + path + '0.gif" valign="absmiddle" /></td>';
	var sBody = '\
		<table id="dialogBodyBox" class="dialogBodyBox' + styletype + '" border="0" align="center" cellpadding="0" cellspacing="0" width="100%" height="100%" >\
			<tr height="' + (oHeight - 60) + '">\
				<td width="10"></td>' + sSuccess + '<td id="dialogMsg" class="dialogMsg' + styletype + '"></td>\
				<td width="10"></td>\
			</tr>\
			<tr height="30"><td id="dialogFunc" class="dialogFunc' + styletype + '" colspan="4">' + sButtonFunc + '</td></tr>\
		</table>\
	';
	var sBox = '\
		<div style="display:none;" id="dialogBox" class="dialogBox' + styletype + '">\
			<div id="dialogTitleDiv" class="dialogTitleDiv' + styletype + '" style="width:' + oWidth + 'px;">\
				<span id="dialogBoxTitle" class="dialogBoxTitle' + styletype + '">' + sTitle + '</span>\
				<span id="dialogBoxClose" class="dialogBoxClose' + styletype + '">' + sClose + '</span>\
			</div>\
			<div id="dialogHeight" style="width:' + oWidth + 'px;height:' + oHeight + 'px;">\
				<div id="dialogBody" class="dialogBody' + styletype + '" style="height:' + oHeight + 'px;">' + sBody + '</div>\
			</div>\
		</div>\
		<div id="dialogBoxShadow" style="display:none;"></div>\
	';
	this.init = function(_showTitleBar){
		document.body.oncontextmenu=function(){return false;};
		document.body.onselectstart=function(){return false;};
		document.body.ondragstart=function(){return false;};
		document.body.onsource=function(){return false;};
		$$('dialogFrame') ? $$('dialogFrame').src='' : function(){};
		$$('dialogCase') ? $$('dialogCase').parentNode.removeChild($$('dialogCase')) : function(){};
		$$('windowMask') ? $$('windowMask').parentNode.removeChild($$('windowMask')) : function(){};
		var oDiv = document.createElement('span');
		oDiv.id = "dialogCase";
		oDiv.innerHTML = sBox;
		document.body.appendChild(oDiv);
		var oMask = document.createElement('div');
		oMask.id = 'windowMask';
		document.body.appendChild(oMask);
		jcms$$WindowMask = $$("windowMask");
		jcms$$WindowMask.style.display="block";
		var brsVersion = parseInt(window.navigator.appVersion.charAt(0), 10);
		if (brsVersion <= 6 && window.navigator.userAgent.indexOf("MSIE") > -1) {
			jcms$$HideSelects = true;
		}
		if (jcms$$HideSelects == true) {
			HideSelectBoxes();
		}
		if (_showTitleBar == true || _showTitleBar == null)
			$$("dialogTitleDiv").style.display = "block";
		else
			$$("dialogTitleDiv").style.display = "none";
		jcms$$OperatorPlus();
	}
	//this.show = function(){$$('dialogBox') ? function(){} : this.init();jcms$$DialogIsShown=true;this.middle('dialogBox');}
	this.show = function(){$$('dialogBox') ? function(){} : this.init();jcms$$DialogIsShown=true;this.middle('dialogBox');this.shadow();this.middle('dialogBoxShadow');jcms$$OperatorPlus();}
	this.html = function(_sHtml){
		this.show();
		$$('dialogBody').innerHTML = _sHtml;
	}
	this.button = function(_sId, _sFuc){
		if($$(_sId)){
			$$(_sId).style.display = '';
			if($$(_sId).addEventListener){
				if($$(_sId).act){$$(_sId).removeEventListener('click', function(){eval($$(_sId).act);}, false);}
				$$(_sId).act = _sFuc;
				$$(_sId).addEventListener('click', function(){eval(_sFuc);this.reset();}, false);
			}else{
				if($$(_sId).act){$$(_sId).detachEvent('onclick', function(){eval($$(_sId).act);});}
				$$(_sId).act = _sFuc;
				$$(_sId).attachEvent('onclick', function(){eval(_sFuc);});
			}
		}
	}
	this.shadow = function(){
		if(shadowBorder h>0){
			var oShadow = $$('dialogBoxShadow');
			var oDialogDiv = $$('dialogBox');
			oShadow.style.position = "absolute";
			oShadow.style.background = "#000";
			oShadow.style.display = "";
			oShadow.style.opacity = "0.25";
			oShadow.style.filter = "alpha(opacity=25)";
			oShadow.style.width = (oDialogDiv.offsetWidth + shadowBorder h)+"px";
			oShadow.style.height = (oDialogDiv.offsetHeight + shadowBorder h)+"px";
		}
	}
	this.open = function(_sUrl, _returnFunc, _sMode){
		this.show();
		gReturnFunc = _returnFunc;
		//if(!_sMode || _sMode == "no" || _sMode == "yes"){
			$$("dialogBody").innerHTML = "<iframe id='dialogFrame' name='dialogFrame' src='"+_sUrl+"' width='" + oWidth + "' height='" + oHeight + "' frameborder='no' border='0' marginwidth='0' marginheight='0' scrolling='" + _sMode + "'></iframe>";
			$$("dialogFrame").src = _sUrl;
		//}
	}
	this.reset = function(callReturnFunc){$$('dialogCase') ? this.dispose(callReturnFunc) : function(){};}
	this.dispose = function(callReturnFunc){
		jcms$$DialogIsShown = false;
		document.body.oncontextmenu=function(){return true;};
		document.body.onselectstart=function(){return true;};
		document.body.ondragstart=function(){return true;};
		document.body.onsource=function(){return true;};
		$$('dialogFrame') ? $$('dialogFrame').src='' : function(){};
		$$('dialogCase').parentNode.removeChild($$('dialogCase'));
		$$('windowMask').parentNode.removeChild($$('windowMask'));
		jcms$$WindowMask=null;
		if (callReturnFunc == true && gReturnFunc != null) {
			gReturnVal = window.dialogFrame.returnVal;
			window.setTimeout('gReturnFunc(gReturnVal);', 1);
		}
		if (jcms$$HideSelects == true) {
			ShowSelectBoxes();
			jcms$$HideSelects = false;
		}
		//$$('dialogBoxShadow').style.display = "none";
	}
	this.event = function(_sMsg, _sSubmit, _sCancel, _sClose){
		this.show();
		$$('dialogFunc').innerHTML = sButtonFunc;
		$$('dialogBoxClose').innerHTML = sClose;
		$$('dialogBodyBox') == null ? $$('dialogBody').innerHTML = sBody : function(){};
		$$('dialogMsg') ? $$('dialogMsg').innerHTML = _sMsg  : function(){};
		_sSubmit ? this.button('dialogSubmit', _sSubmit) | $$('dialogSubmit').focus() : $$('dialogSubmit').style.display = "none";
		_sCancel ? this.button('dialogCancel', _sCancel) : $$('dialogCancel').style.display = "none";
		_sClose ? this.button('dialogBoxClose', _sClose) : function(){};
	}
	this.set = function(_oAttr, _sVal){
		var oDialogDiv = $$('dialogBox');
		var oHeight = $$('dialogHeight');
		if(_sVal != ''){
			switch(_oAttr){
				case 'title':
					$$('dialogBoxTitle').innerHTML = _sVal;
					title = _sVal;
					break;
				case 'width':
					oDialogDiv.style.width = _sVal;
					width = _sVal;
					this.middle('dialogBox');
					this.shadow();
					this.middle('dialogBoxShadow');
					jcms$$OperatorPlus();
					break;
				case 'height':
					oHeight.style.height = _sVal;
					height = _sVal;
					this.middle('dialogBox');
					this.shadow();
					this.middle('dialogBoxShadow');
					jcms$$OperatorPlus();
					break;
				case 'src':
					if(parseInt(_sVal) > 0){
						$$('dialogBoxFace') ? $$('dialogBoxFace').src = path + _sVal + '.png' : function(){};
					}else{
						$$('dialogBoxFace') ? $$('dialogBoxFace').src = _sVal : function(){};
					}
					src = _sVal;
					break;
				case 'url':
					this.open(_sVal);
					break;
			}
		}
	}
	this.middle = function(_sId){	
		var theWidth;
		var theHeight;
		if (document.documentElement && document.documentElement.clientWidth) { 
			theWidth = document.documentElement.clientWidth+document.documentElement.scrollLeft*2;
			theHeight = document.documentElement.clientHeight+document.documentElement.scrollTop*2; 
		} else if (document.body) { 
			theWidth = document.body.clientWidth;
			theHeight = document.body.clientHeight; 
		}else if(window.innerWidth){
			theWidth = window.innerWidth;
			theHeight = window.innerHeight;
		}
		$$(_sId).style.display = '';
		$$(_sId).style.position = "absolute";
		$$(_sId).style.left = (theWidth / 2) - ($$(_sId).offsetWidth / 2)+"px";
		if(document.all||$$("user_page_top")){
			$$(_sId).style.top = (theHeight / 2 + document.body.scrollTop) - ($$(_sId).offsetHeight / 2)+"px";
		}else{
			var sClientHeight = parent ? parent.document.body.clientHeight : document.body.clientHeight;
			var sScrollTop = parent ? parent.document.body.scrollTop : document.body.scrollTop;
			var sTop = -80 + (sClientHeight / 2 + sScrollTop) - ($$(_sId).offsetHeight / 2);
			$$(_sId).style.top = (theHeight / 2 + document.body.scrollTop) - ($$(_sId).offsetHeight / 2)+"px";
		}
	}
	BtnOver=function(obj,path){obj.style.backgroundImage = "url("+path+"button2.gif)";}
	BtnOut=function(obj,path){obj.style.backgroundImage = "url("+path+"button1.gif)";}
	ShowSelectBoxes=function(){var x = document.getElementsByTagName("SELECT");for (i=0;x && i < x.length; i++){x[i].style.visibility = "visible";}}
	HideSelectBoxes=function(){var x = document.getElementsByTagName("SELECT");for (i=0;x && i < x.length; i++) {x[i].style.visibility = "hidden";}}

}
///////////////////////////////////////////////////////////////////////////
function jcms$$OperatorPlus() {
	if (jcms$$DialogIsShown == true) {
		var oDialogDiv = $$("dialogBox");
		var oShadow = $$("dialogBoxShadow");
		var oWidth = oDialogDiv.offsetWidth;
		var oHeight = oDialogDiv.offsetHeight;
		var theBody = document.getElementsByTagName("BODY")[0];
		var scTop = parseInt(jcms$$GetScrollTop(),10);
		var scLeft = parseInt(theBody.scrollLeft,10);
		var fullHeight = jcms$$GetViewportHeight();
		var fullWidth = jcms$$GetViewportWidth();
		oDialogDiv.style.top = (scTop + ((fullHeight - oHeight) / 2)) + "px";
		oDialogDiv.style.left = (scLeft + ((fullWidth - oWidth) / 2)) + "px";
		oShadow.style.top = (scTop + ((fullHeight - oShadow.offsetHeight) / 2)) + "px";
		oShadow.style.left = (scLeft + ((fullWidth - oShadow.offsetWidth) / 2)) + "px";
		if (jcms$$WindowMask != null) {
			var popHeight = theBody.scrollHeight;
			var popWidth = theBody.scrollWidth;
			if (fullHeight > theBody.scrollHeight) popHeight = fullHeight;
			if (fullWidth > theBody.scrollWidth) popWidth = fullWidth;
			jcms$$WindowMask.style.height = popHeight + "px";
			jcms$$WindowMask.style.width = popWidth + "px";
		}
	}
}
function jcms$$GetViewportHeight() {
	if (window.innerHeight!=window.undefined)//FF
	{
		return window.innerHeight;
	}
	if (document.compatMode=='CSS1Compat')//IE
	{
		return document.documentElement.clientHeight;
	}
	if (document.body)//other
	{
		return document.body.clientHeight; 
	}
	return window.undefined; 
}
function jcms$$GetViewportWidth() {
	var offset = 17;
	var width = null;
	if (window.innerWidth!=window.undefined)//FF
	{
		//return window.innerWidth-offset; 
		return window.innerWidth; 
	}
	if (document.compatMode=='CSS1Compat')//IE
	{
		return document.documentElement.clientWidth; 
	}
	if (document.body)//other
	{
		return document.body.clientWidth; 
	}
	return window.undefined; 
}
function jcms$$GetScrollTop() {
	if (self.pageYOffset){return self.pageYOffset;}
	else if (document.documentElement && document.documentElement.scrollTop){return document.documentElement.scrollTop;}
	else if (document.body){return document.body.scrollTop;}
}
function jcms$$GetScrollLeft() {
	if (self.pageXOffset){return self.pageXOffset;}
	else if (document.documentElement && document.documentElement.scrollLeft){return document.documentElement.scrollLeft;}
	else if (document.body){return document.body.scrollLeft;}
}
function jcms$$SetDialogTitle(){
	if(window.document.title!=""){
		try {
			$$('dialogBoxTitle').innerHTML = window.document.title;
		}
		catch(e) {
			try {
				parent.$$('dialogBoxTitle').innerHTML = window.document.title;
			}
			catch(e) {
			}	
		}
	}
}
function jcms$$SetDialogSize(w,h){
	try {
		if(w>0) $$('dialogBox').style.width = w;
		if(h>0) $$('dialogHeight').style.height = h;
		jcms$$OperatorPlus();
	}
	catch(e) {
		try {
			if(w>0) parent.$$('dialogBox').style.width = w;
			if(h>0) parent.$$('dialogHeight').style.height = h;
			parent.jcms$$OperatorPlus();
		}
		catch(e) {
		}	
	}	
}
/* Url编码 */ 
jcms$$UrlEncode = function(unzipStr){ 
	var zipstr=""; 
	var strSpecial="!\"#$%&'()*+,/:;<=>?[]^`{|}~%"; 
	var tt= ""; 
	for(var i=0;i<unzipStr.length;i++){ 
		var chr = unzipStr.charAt(i); 
		var c=jcms$$StringToAscii(chr); 
		tt += chr+":"+c+"n"; 
		if(parseInt("0x"+c) > 0x7f){ 
			zipstr+=encodeURI(unzipStr.substr(i,1)); 
		}else{ 
		if(chr==" ") 
			zipstr+="+"; 
		else if(strSpecial.indexOf(chr)!=-1) 
			zipstr+="%"+c.toString(16); 
		else 
			zipstr+=chr; 
		} 
	} 
	return zipstr; 
} 
/* Url解码 */ 
jcms$$UrlDecode=function(zipStr){ 
	var uzipStr=""; 
	for(var i=0;i<zipStr.length;i++){ 
		var chr = zipStr.charAt(i); 
		if(chr == "+"){ 
			uzipStr+=" "; 
		}else if(chr=="%"){ 
			var asc = zipStr.substring(i+1,i+3); 
			if(parseInt("0x"+asc)>0x7f){ 
				uzipStr+=decodeURI("%"+asc.toString()+zipStr.substring(i+3,i+9).toString()); 
				i+=8; 
			}else{ 
				uzipStr+=jcms$$AsciiToString(parseInt("0x"+asc)); 
				i+=2; 
			} 
		}else{ 
			uzipStr+= chr; 
		} 
	} 
	return uzipStr; 
} 
var jcms$$StringToAscii = function(str){
	return str.charCodeAt(0).toString(16);
}
var jcms$$AsciiToString = function(asccode){
	return String.fromCharCode(asccode);
}

////////////////////////////////////////////////////////////////////////////////////////////
function jcms$$SetUrlRefresh(url)
{
	if(url.indexOf("?") > 0)
    		return url+"&t="+(new Date().getTime());   
	else
    		return url+"?t="+(new Date().getTime());   
}

var jcms$$StuHover = function() {
	var cssRule;
	var newSelector;
	for (var i = 0; i < document.styleSheets.length; i++)
		for (var x = 0; x < document.styleSheets[i].rules.length ; x++)
			{
			cssRule = document.styleSheets[i].rules[x];
			if (cssRule.selectorText.indexOf("LI:hover") != -1)
			{
				 newSelector = cssRule.selectorText.replace(/LI:hover/gi, "LI.iehover");
				document.styleSheets[i].addRule(newSelector , cssRule.style.cssText);
			}
		}
	var topnavbar = $$("topnavbar");
	if(topnavbar != null)
	{
		var getElm = topnavbar.getElementsByTagName("LI");
		for (var i=0; i<getElm.length; i++) {
			getElm[i].onmouseover=function() {
				this.className+=" iehover";
			}
			getElm[i].onmouseout=function() {
				this.className=this.className.replace(new RegExp(" iehover\\b"), "");
			}
		}
	}
}
/*HTML标签小写*/
function HTML2LowerCase(html)
{
	return html.replace(/(<\/?)([a-z\d\:]+)((\s+.+?)?>)/gi,function(s,a,b,c){return a+b.toLowerCase()+c;});
}
/*获取指定字符串的长度*/
function GetLength(id)
{
	var srcjo = $("#"+id);
	sType = srcjo.get(0).type;
	var len = 0;
	switch(sType)
	{
		case "text":
		case "hidden":
		case "password":
		case "textarea":
		case "file":
			var val = srcjo.val();
			for (var i = 0; i < val.length; i++) 
			{
				if (val.charCodeAt(i) >= 0x4e00 && val.charCodeAt(i) <= 0x9fa5){ 
					len += 2;
				}else {
					len++;
				}
			}
			break;
		case "checkbox":
		case "radio": 
			len = $("input[@type='"+sType+"'][@name='"+srcjo.attr("name")+"'][@checked]").length;
			break;
		case "select-one":
			len = srcjo.get(0).options ? srcjo.get(0).options.selectedIndex : -1;
			break;
		case "select-more":
			break;
	}
	return len;
}
function InsertUnit(text, obj) {
	if(!obj) {
		obj = 'jstemplate';
	}
	var o = $$(obj);
	o.focus();
	if(!OA.isUndefined(o.selectionStart)) {
		var opn = o.selectionStart + 0;
		o.value = o.value.substr(0, o.selectionStart) + text + o.value.substr(o.selectionEnd);
	} else if(document.selection && document.selection.createRange) {
		var sel = document.selection.createRange();
		sel.text = text.replace(/\r?\n/g, '\r\n');
		//sel.moveStart('character', -strlen(text));
	} else {
		o.value += text;
	}
}
function JoinSelect(selectName)
{
	var selectIDs="";
	$("input[@name='" + selectName + "']").each(function(){
   		if($(this).attr("checked")==true){
			if(selectIDs=="")
    				selectIDs = $(this).attr("value");
			else
				selectIDs += ","+$(this).attr("value");
   		}
	})
	return selectIDs;
}
/*========================================================================================*/
function UrlSearch(){ //重复时只取最后一个
	var name,value; 
	var str=window.location.href; //取得整个地址栏
	var num=str.indexOf("?") 
	str=str.substr(num+1); //取得所有参数
	var arr=str.split("&"); //各个参数放到数组里
	for(var i=0;i < arr.length;i++){ 
		num=arr[i].indexOf("="); 
		if(num>0){ 
			name=arr[i].substring(0,num);
			value=arr[i].substr(num+1);
			this[name]=value;
		} 
	}
	this["getall"]=str;
}
var RQ=new UrlSearch(); //实例化
function formatStr(s){
	if(typeof(s) == "string")
		return s;
	else
		return "";
}
function joinValue(parameter){
	eval("var temp=RQ."+parameter);
	if((typeof(temp) == "string") && (typeof(temp) != null))
	{
		return "&"+parameter+"="+temp.replace(/(^\s*)|(\s*$)/g, "");
	}
	else
		return "";
}
function q(pname){
	var query = location.search.substring(1);
	var qq = "";
	params = query.split("&");
	if(params.length>0){
		for(var n in params){
			var pairs = params[n].split("=");
			if(pairs[0]==pname){
				qq = pairs[1];
				break;
			}
		}
	}
	return qq;
}
function anchor(){
	var str=window.location.href; //取得整个地址栏
	var num=str.indexOf("#") 
	str=str.substr(num+1);
	return str;
}
/*获取当前页页码*/
function thispage(){
	var r = /^\+?[1-9][0-9]*$/;
	if(r.test(q('page')))
		return q('page');
	else
		return "1";
}
/*全选*/
function CheckAll(form)
{
	var f;
	if(form==null)
		f = document.getElementsByTagName('FORM')[0];
	else
		f = $$(form);
	for (var i=0;i<f.elements.length;i++)
	{
		var e = f.elements[i];
		if (e.name != 'chkall' && e.type == "checkbox")
			e.checked = $$("chkall").checked;
	}
}
/*全不选*/
function CheckNo(form)
{
	var f;
	if(form==null)
		f = document.getElementsByTagName('FORM')[0];
	else
		f = $$(form);
	for (var i=0;i<f.elements.length;i++)
	{
		var e = f.elements[i];
		if (e.type == "checkbox")
			e.checked = false;
	}
}
function WinFullOpen(url){
	var newwin=window.open(url,"","scrollbars");
	if(document.all){
		newwin.moveTo(0,0);
		newwin.resizeTo(screen.width,screen.height);
	}
}
function WindowOpen(url,iWidth,iHeight,name)
{
	if(name==null) name='';
	var iTop = (window.screen.availHeight-30-iHeight)/2;
	var iLeft = (window.screen.availWidth-10-iWidth)/2;
	window.open(url,name,'height='+iHeight+',,innerHeight='+iHeight+',width='+iWidth+',innerWidth='+iWidth+',top='+iTop+',left='+iLeft+',toolbar=no,menubar=no,scrollbars=auto,resizeable=no,location=no,status=no');
}
/*字符串格式化*/
String.prototype.Trim = function(){return this.replace(/(^\s*)|(\s*$)/g, "");}
String.prototype.LTrim = function(){return this.replace(/(^\s*)/g, "");}
String.prototype.RTrim = function(){return this.replace(/(\s*$)/g, "");}

/*日期格式化(2009-06-30+++)*/
function formatDate(strDate, format){
	return parseDate(strDate).format(format);
} 
Date.prototype.format = function(format)
{
	if(format == null) format = "yyyy-MM-dd hh:mm:ss";
	var o = 
	{
		"M+" : this.getMonth()+1, //month
		"d+" : this.getDate(),    //day
		"h+" : this.getHours(),   //hour
		"m+" : this.getMinutes(), //minute
		"s+" : this.getSeconds(), //second
		"q+" : Math.floor((this.getMonth()+3)/3), //quarter
		"S" : this.getMilliseconds() //millisecond
	}
		
	if(/(y+)/.test(format)) 
		format=format.replace(RegExp.$1,(this.getFullYear()+"").substr(4 - RegExp.$1.length));
	for(var k in o)
		if(new RegExp("("+ k +")").test(format))
			format = format.replace(RegExp.$1,RegExp.$1.length==1 ? o[k] : ("00"+ o[k]).substr((""+ o[k]).length));
	return format;
}
function parseDate(str){   
	if(typeof str == 'string'){   
		var results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2}) *$/);   
		if(results && results.length>3)   
			return new Date(parseInt(results[1]),parseInt(results[2]) -1,parseInt(results[3]));    
		results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2}) +(\d{1,2}):(\d{1,2}):(\d{1,2}) *$/);   
		if(results && results.length>6)   
			return new Date(parseInt(results[1]),parseInt(results[2]) -1,parseInt(results[3]),parseInt(results[4]),parseInt(results[5]),parseInt(results[6]));    
		results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2}) +(\d{1,2}):(\d{1,2}):(\d{1,2})\.(\d{1,9}) *$/);   
		if(results && results.length>7)   
			return new Date(parseInt(results[1]),parseInt(results[2]) -1,parseInt(results[3]),parseInt(results[4]),parseInt(results[5]),parseInt(results[6]),parseInt(results[7]));    
	}   
	return null;   
}
/**
 * 将数值四舍五入(保留2位小数)后格式化成金额形式
 *
 * @param num 数值(Number或者String)
 * @return 金额格式的字符串,如'1,234,567.45'
 * @type String
 */
function formatCurrency(num) {
	num = num.toString().replace(/\$|\,/g,'');
	if(isNaN(num))
	num = "0";
	sign = (num == (num = Math.abs(num)));
	num = Math.floor(num*100+0.50000000001);
	cents = num%100;
	num = Math.floor(num/100).toString();
	if(cents<10)
		cents = "0" + cents;
	for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
	num = num.substring(0,num.length-(4*i+3))+','+
	num.substring(num.length-(4*i+3));
	return (((sign)?'':'-') + num + '.' + cents);
}
/*预览HTML代码*/
function PreviewHTML(txt)
{
	var win = window.open("", "win");
	win.document.open("text/html", "replace"); 
	win.document.write(txt); 
	win.document.close();
}
/*格式化列表*/
function FormatListValue(id)
{
	var _val = $('#'+id).val();
	if(_val=='') return;
	_val =_val.replace(/[，]/g,",");
	_val =_val.replace(/ /g,",");
	_val =_val.replace(/[,]+/g,",");
	$('#'+id).val(_val);
}
/*格式化在线状态*/
function FormatOnline(t){
	if(t<10)
		return "<img src='images/ico_online.gif' alt='在线' border='0' />";
	else
		return "<img src='images/ico_offline.gif' alt='离线' border='0' />";	
}

/*格式化新短信状态*/
function FormatMessage(t,uid){
	if(t>0)
		return "<a href='Message_List.aspx?uid="+uid+"'><img src='images/ico_message1.gif' alt='有"+t+"条新短信' border='0' /></a>";
	else
		return "<img src='images/ico_message0.gif'  alt='暂无新短信' border='0' />";	
}

function ajaxUserList(seconds)
{
	$('body').everyTime('1s',function(){
		if(seconds==0){
			$.ajax({
				type:		"get",
				dataType:	"json",
				data:		"time="+(new Date().getTime()),
				url:		"ajax.aspx?oper=ajaxUserList",
				//error:		function(XmlHttpRequest,textStatus, errorThrown) { alert(XmlHttpRequest.responseText);},
				success:	function(d){
					switch (d.result)
					{
					case '0':
						break;
					case '1':
						$("#ajaxUserList").setTemplateElement("tplList", null, {filter_data: true});
						$("#ajaxUserList").processTemplate(d);
						break;
					}
					seconds++;
				}
			});
		}else{
			if(seconds>11){
				seconds = 0;
				return;
			}else{
				seconds++;
			}
		}

	},0,true);

}

function checkAllLine() { 
	if ($("#checkedAll").attr("checked") == true) { // 全选 
		$('.dataTable tbody tr').each(
			function() {
				$(this).find('input[type="checkbox"]').attr('checked','checked');
			}
		);
	} else { // 取消全选 
		$('.dataTable tbody tr').each(
			function() {
				$(this).find('input[type="checkbox"]').removeAttr('checked');
			}
		);
	}
}